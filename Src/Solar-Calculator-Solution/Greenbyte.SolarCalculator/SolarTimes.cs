// ***
// *** Solar Calculator 3.1.0
// *** Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU General Public License as published by
// *** the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// *** GNU General Public License for more details.
// *** 
// *** You should have received a copy of the GNU General Public License
// *** along with this program.If not, see<http://www.gnu.org/licenses/>.
// *** 
using System;

namespace Innovative.SolarCalculator {
    /// <summary>
    /// Provides mathematical operations to calculate the sunrise and sunset for a given date.
    /// </summary>
    public class SolarTimes {
        /// <summary>
        /// Creates an instance of the SolarTimes object with the specified For Date, Latitude and Longitude.
        /// </summary>
        /// <param name="forDate">Specifies the Date for which the sunrise and sunset will be calculated.</param>
        /// <param name="latitude">Specifies the angular measurement of north-south location on Earth's surface.</param>
        /// <param name="longitude">Specifies the angular measurement of east-west location on Earth's surface.</param>
        public SolarTimes(DateTimeOffset forDate) {
            ForDate = forDate;

            TimeZoneOffset = ForDate.Offset.TotalHours;
            JulianDay = ExcelFormulae.ToExcelDateValue(ForDate.Date) + 2415018.5d - (TimeZoneOffset / 24d);
            JulianCentury = (JulianDay - 2451545d) / 36525d;
            SunGeometricMeanLongitudeDegrees = ExcelFormulae.Mod(280.46646d + JulianCentury * (36000.76983d + JulianCentury * 0.0003032d), 360d);
            SunMeanAnomalyRadians = ToRadians(357.52911d + JulianCentury * (35999.05029d - 0.0001537d * JulianCentury));
            EccentricityOfEarthOrbit = 0.016708634d - JulianCentury * (0.000042037d + 0.0000001267d * JulianCentury);
            SunEquationOfCenterDegrees = Math.Sin(SunMeanAnomalyRadians) * (1.914602d - JulianCentury * (0.004817d + 0.000014d * JulianCentury)) + Math.Sin(SunMeanAnomalyRadians * 2d) * (0.019993d - 0.000101d * JulianCentury) + Math.Sin(SunMeanAnomalyRadians * 3d) * 0.000289d;
            SunTrueLongitudeDegrees = SunGeometricMeanLongitudeDegrees + SunEquationOfCenterDegrees;

            var sunApparentLongitude_a1 = ToRadians(125.04d - 1934.136d * JulianCentury);
            SunApparentLongitudeRadians = ToRadians(SunTrueLongitudeDegrees - 0.00569d - 0.00478d * Math.Sin(sunApparentLongitude_a1));

            // Formula 22.3 from Page 147 of Astronomical Algorithms, Second Edition (Jean Meeus)
            // Original spreadsheet formula based on 22.2 same page of book
            MeanEclipticObliquityDegrees = 23d + (26d + ((21.448d - JulianCentury * (46.815d + JulianCentury * (0.00059d - JulianCentury * 0.001813d)))) / 60d) / 60d;

            var obliquityCorrection_a1 = ToRadians(125.04d - 1934.136d * JulianCentury);
            ObliquityCorrectionRadians = ToRadians(MeanEclipticObliquityDegrees + 0.00256d * Math.Cos(obliquityCorrection_a1));

            SolarDeclinationRadians = Math.Asin(Math.Sin(ObliquityCorrectionRadians) * Math.Sin(SunApparentLongitudeRadians));

            VarY = Math.Tan(ObliquityCorrectionRadians / 2d) * Math.Tan(ObliquityCorrectionRadians / 2d);

            var sunGeometricMeanLongitudeRadians = ToRadians(SunGeometricMeanLongitudeDegrees);
            EquationOfTime = 4d * ToDegrees(VarY * Math.Sin(2d * sunGeometricMeanLongitudeRadians) - 2d * EccentricityOfEarthOrbit * Math.Sin(SunMeanAnomalyRadians) + 4d * EccentricityOfEarthOrbit * VarY * Math.Sin(SunMeanAnomalyRadians) * Math.Cos(2d * sunGeometricMeanLongitudeRadians) - 0.5d * VarY * VarY * Math.Sin(4d * sunGeometricMeanLongitudeRadians) - 1.25d * EccentricityOfEarthOrbit * EccentricityOfEarthOrbit * Math.Sin(SunMeanAnomalyRadians * 2d));
        }

        public (DateTime Sunrise, DateTime Sunset) ForCoordinates(double latitude, double longitude) {
            if (latitude < -90d || latitude > 90d) {
                throw new ArgumentOutOfRangeException("The value for Latitude must be between -90° and 90°.");
            }

            if (longitude < -180d || longitude > 180d) {
                throw new ArgumentOutOfRangeException("The value for Longitude must be between -180° and 180°.");
            }

            var latitudeRadians = ToRadians(latitude);

            var hourAngleSunriseDegrees_a1 = ToRadians(90d + AtmosphericRefractionDegrees);
            var hourAngleSunriseDegreesRadians = Math.Acos(Math.Cos(hourAngleSunriseDegrees_a1) / (Math.Cos(latitudeRadians) * Math.Cos(SolarDeclinationRadians)) - Math.Tan(latitudeRadians) * Math.Tan(SolarDeclinationRadians));
            var hourAngleSunriseDegrees = ToDegrees(hourAngleSunriseDegreesRadians);

            var solarNoonDayFraction = (720d - (4d * longitude) - EquationOfTime + (TimeZoneOffset * 60d)) / 1440d;
            var solarNoon = ForDate.Date.AddDays(solarNoonDayFraction);

            var sunriseDayFraction = solarNoon.TimeOfDay.TotalDays - hourAngleSunriseDegrees * 4d / 1440d;
            var sunrise = ForDate.Date.AddDays(sunriseDayFraction);

            var sunsetDayFraction = solarNoon.TimeOfDay.TotalDays + hourAngleSunriseDegrees * 4d / 1440d;
            var sunset = ForDate.Date.AddDays(sunsetDayFraction);

            return (sunrise, sunset);
        }

        /// <summary>
        /// Specifies the Date for which the sunrise and sunset will be calculated.
        /// </summary>
        public readonly DateTimeOffset ForDate;

        /// <summary>
        /// Gets the time zone offset for the specified date.
        /// Time Zones are longitudinally defined regions on the Earth that keep a common time. A time 
        /// zone generally spans 15° of longitude, and is defined by its offset (in hours) from UTC. 
        /// For example, Mountain Standard Time (MST) in the US is 7 hours behind UTC (MST = UTC - 7).
        /// (Spreadsheet Column B, Row 5)
        /// </summary>
        public readonly double TimeZoneOffset;

        /// <summary>
        /// As light from the sun (or another celestial body) travels from the vacuum of space into Earth's atmosphere, the 
        /// path of the light is bent due to refraction. This causes stars and planets near the horizon to appear higher in 
        /// the sky than they actually are, and explains how the sun can still be visible after it has physically passed 
        /// beyond the horizon at sunset. See also apparent sunrise.
        /// </summary>
        private const double AtmosphericRefractionDegrees = 0.833d;

        /// <summary>
        /// Julian Day: a time period used in astronomical circles, defined as the number of days 
        /// since 1 January, 4713 BCE (Before Common Era), with the first day defined as Julian 
        /// day zero. The Julian day begins at noon UTC. Some scientists use the term Julian day 
        /// to mean the numerical day of the current year, where January 1 is defined as day 001. 
        /// (Spreadsheet Column F)
        /// </summary>
        public readonly double JulianDay;

        /// <summary>
        /// Julian Century
        /// calendar established by Julius Caesar in 46 BC, setting the number of days in a year at 365, 
        /// except for leap years which have 366, and occurred every 4 years. This calendar was reformed 
        /// by Pope Gregory XIII into the Gregorian calendar, which further refined leap years and corrected 
        /// for past errors by skipping 10 days in October of 1582. 
        /// (Spreadsheet Column G)
        /// </summary>
        public readonly double JulianCentury;

        /// <summary>
        /// Sun's Geometric Mean Longitude (degrees): Geometric Mean Ecliptic Longitude of Sun.
        /// (Spreadsheet Column I)
        /// </summary>
        public readonly double SunGeometricMeanLongitudeDegrees;

        /// <summary>
        /// Sun's Mean Anomaly (radians): Position of Sun relative to perigee
        /// (Spreadsheet Column J)
        /// </summary>
        public readonly double SunMeanAnomalyRadians;

        /// <summary>
        /// Eccentricity of the Earth's Orbit: Eccentricity e is the ratio of half the distance between the foci c to
        /// the semi-major axis a: e = c / a. For example, an orbit with e = 0 is circular, e = 1 is parabolic, and e 
        /// between 0 and 1 is elliptic.
        /// (Spreadsheet Column K)
        /// </summary>
        public readonly double EccentricityOfEarthOrbit;

        /// <summary>
        /// Sun Equation of the Center: Difference between mean anomaly and true anomaly.
        /// (Spreadsheet Column L)
        /// </summary>
        public readonly double SunEquationOfCenterDegrees;

        /// <summary>
        /// Sun True Longitude (degrees)
        /// (Spreadsheet Column M)
        /// </summary>
        public readonly double SunTrueLongitudeDegrees;

        /// <summary>
        /// Sun Apparent Longitude (radians)
        /// (Spreadsheet Column P)
        /// </summary>
        public readonly double SunApparentLongitudeRadians;

        /// <summary>
        /// Mean Ecliptic Obliquity (degrees): Inclination of ecliptic plane w.r.t. celestial equator
        /// (Spreadsheet Column Q)
        /// </summary>
        public readonly double MeanEclipticObliquityDegrees;

        /// <summary>
        /// Obliquity Correction (radians)
        /// (Spreadsheet Column R)
        /// </summary>
        public readonly double ObliquityCorrectionRadians;

        /// <summary>
        /// Solar Declination (Degrees): The measure of how many degrees North (positive) or South (negative) 
        /// of the equator that the sun is when viewed from the centre of the earth.  This varies from 
        /// approximately +23.5 (North) in June to -23.5 (South) in December.
        /// (Spreadsheet Column T)
        /// </summary>
        public readonly double SolarDeclinationRadians;

        /// <summary>
        /// Var Y
        /// (Spreadsheet Column U)
        /// </summary>
        public readonly double VarY;

        /// <summary>
        /// Equation of Time (minutes)
        /// Accounts for changes in the time of solar noon for a given location over the course of a year. Earth's 
        /// elliptical orbit and Kepler's law of equal areas in equal times are the culprits behind this phenomenon.
        /// (Spreadsheet Column V)
        /// </summary>
        public readonly double EquationOfTime;

        private static double ToDegrees(double radians) => radians * (180d / Math.PI);
        private static double ToRadians(double degrees) => (degrees * Math.PI) / 180d;
    }
}
