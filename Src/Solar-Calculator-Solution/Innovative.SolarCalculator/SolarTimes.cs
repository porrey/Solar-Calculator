// ***
// *** Solar Calculator 3.0.0
// *** Copyright(C) 2013-2020, Daniel M. Porrey. All rights reserved.
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
using Innovative.Geometry;

namespace Innovative.SolarCalculator
{
	/// <summary>
	/// Provides mathematical operations to calculate the sunrise and sunset for a given date.
	/// </summary>
	public class SolarTimes
	{
		private Angle _longitude = Angle.Empty;
		private Angle _latitude = Angle.Empty;

		#region Constructors
		/// <summary>
		/// Creates a default instance of the SolarTimes object.
		/// </summary>
		public SolarTimes()
		{
			this.ForDate = DateTime.Now;
		}

		/// <summary>
		/// Creates an instance of the SolarTimes object with the specified For Date.
		/// </summary>
		/// <param name="forDate">Specifies the Date for which the sunrise and sunset will be calculated.</param>
		public SolarTimes(DateTimeOffset forDate)
		{
			this.ForDate = forDate;
		}

		/// <summary>
		/// Creates an instance of the SolarTimes object with the specified For Date, Latitude and Longitude.
		/// </summary>
		/// <param name="forDate">Specifies the Date for which the sunrise and sunset will be calculated.</param>
		/// <param name="latitude">Specifies the angular measurement of north-south location on Earth's surface.</param>
		/// <param name="longitude">Specifies the angular measurement of east-west location on Earth's surface.</param>
		public SolarTimes(DateTimeOffset forDate, Angle latitude, Angle longitude)
		{
			this.ForDate = forDate;
			this.Latitude = latitude;
			this.Longitude = longitude;
		}

		/// <summary>
		/// Creates an instance of the SolarTimes object with the specified For Date, Latitude Longitude and Time Zone Offset
		/// </summary>
		/// <param name="forDate">Specifies the Date for which the sunrise and sunset will be calculated.</param>
		/// <param name="timeZoneOffset">Specifies the time zone offset for the specified date in hours.</param>
		/// <param name="latitude">Specifies the angular measurement of north-south location on Earth's surface.</param>
		/// <param name="longitude">Specifies the angular measurement of east-west location on Earth's surface.</param>
		public SolarTimes(DateTime forDate, int timeZoneOffset, Angle latitude, Angle longitude)
		{
			this.ForDate = new DateTimeOffset(forDate, TimeSpan.FromHours(timeZoneOffset));
			this.Latitude = latitude;
			this.Longitude = longitude;
		}
		#endregion

		#region Public Members
		/// <summary>
		/// Specifies the Date for which the sunrise and sunset will be calculated.
		/// </summary>
		public DateTimeOffset ForDate { get; set; }

		/// <summary>
		/// Angular measurement of east-west location on Earth's surface. Longitude is defined from the 
		/// prime meridian, which passes through Greenwich, England. The international date line is defined 
		/// around +/- 180° longitude. (180° east longitude is the same as 180° west longitude, because 
		/// there are 360° in a circle.) Many astronomers define east longitude as positive. This 
		/// solar calculator conforms to the international standard, with east longitude positive.
		/// (Spreadsheet Column B, Row 4)
		/// </summary>
		public Angle Longitude
		{
			get
			{
				return _longitude;
			}
			set
			{
				if (value >= -180M && value <= 180M)
				{
					_longitude = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The value for Longitude must be between -180° and 180°.");
				}
			}
		}

		/// <summary>
		/// Angular measurement of north-south location on Earth's surface. Latitude ranges from 90° 
		/// south (at the south pole; specified by a negative angle), through 0° (all along the equator), 
		/// to 90° north (at the north pole). Latitude is usually defined as a positive value in the 
		/// northern hemisphere and a negative value in the southern hemisphere.
		/// (Spreadsheet Column B, Row 3)
		/// </summary>
		public Angle Latitude
		{
			get
			{
				return _latitude;
			}
			set
			{
				if (value >= -90M && value <= 90M)
				{
					_latitude = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("The value for Latitude must be between -90° and 90°.");
				}
			}
		}

		/// <summary>
		/// Gets the time zone offset for the specified date.
		/// Time Zones are longitudinally defined regions on the Earth that keep a common time. A time 
		/// zone generally spans 15° of longitude, and is defined by its offset (in hours) from UTC. 
		/// For example, Mountain Standard Time (MST) in the US is 7 hours behind UTC (MST = UTC - 7).
		/// (Spreadsheet Column B, Row 5)
		/// </summary>
		public decimal TimeZoneOffset
		{
			get
			{
				return (decimal)this.ForDate.Offset.TotalHours;
			}
		}

		/// <summary>
		/// Sun Rise Time  
		/// (Spreadsheet Column Y)
		/// </summary>
		public DateTime Sunrise
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays - this.HourAngleSunrise * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// Sun Set Time
		/// (Spreadsheet Column Z)
		/// </summary>
		public DateTime Sunset
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays + this.HourAngleSunrise * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// The Astronomical Dawn Time
		/// This is when the sun is &lt; 18 degrees below the horizon
		/// </summary>
		public DateTime DawnAstronomical
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays - this.HourAngleDawnAstronomical * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// Astronomical Dusk Time
		/// This is when the sun is &lt; 18 degrees below the horizon
		/// </summary>
		public DateTime DuskAstronomical
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays + this.HourAngleDawnAstronomical * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}
		/// <summary>
		/// The Civil Dawn Time
		/// This is when the sun is &lt; 6 degrees below the horizon
		/// </summary>
		public DateTime DawnCivil
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays - this.HourAngleDawnCivil * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// Civil Dusk Time
		/// This is when the sun is &lt; 6 degrees below the horizon
		/// </summary>
		public DateTime DuskCivil
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays + this.HourAngleDawnCivil * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// The Nautical Dawn Time
		/// This is when the sun is &lt; 12 degrees below the horizon
		/// </summary>
		public DateTime DawnNautical
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays - this.HourAngleDawnNautical * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// Nautical Dusk Time
		/// This is when the sun is &lt; 12 degrees below the horizon
		/// </summary>
		public DateTime DuskNautucal
		{
			get
			{
				DateTime returnValue = DateTime.MinValue;

				decimal dayFraction = (decimal)this.SolarNoon.TimeOfDay.TotalDays + this.HourAngleDawnNautical * 4M / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// As light from the sun (or another celestial body) travels from the vacuum of space into Earth's atmosphere, the 
		/// path of the light is bent due to refraction. This causes stars and planets near the horizon to appear higher in 
		/// the sky than they actually are, and explains how the sun can still be visible after it has physically passed 
		/// beyond the horizon at sunset. See also apparent sunrise.
		/// </summary>
		public Angle AtmosphericRefraction { get; set; } = new Angle(0.833d);
		#endregion

		#region Computational Members
		/// <summary>
		/// Time past local midnight.
		/// (Spreadsheet Column E)
		/// </summary>	
		public decimal TimePastLocalMidnight
		{
			get
			{
				decimal returnValue = 0M;

				// ***
				// *** .1 / 24
				// ***
				returnValue = (new DateTime(1899, 12, 30, 0, 0, 0)).Add(this.ForDate.TimeOfDay).ToOleAutomationDate();

				return returnValue;
			}
		}

		/// <summary>
		/// Julian Day: a time period used in astronomical circles, defined as the number of days 
		/// since 1 January, 4713 BCE (Before Common Era), with the first day defined as Julian 
		/// day zero. The Julian day begins at noon UTC. Some scientists use the term Julian day 
		/// to mean the numerical day of the current year, where January 1 is defined as day 001. 
		/// (Spreadsheet Column F)
		/// </summary>
		public decimal JulianDay
		{
			get
			{
				decimal returnValue = 0M;

				// ***
				// *** this.TimePastLocalMidnight was removed since the time is in ForDate
				// ***
				returnValue = ExcelFormulae.ToExcelDateValue(this.ForDate.Date) + 2415018.5M - (this.TimeZoneOffset / 24M);

				return returnValue;
			}
		}

		/// <summary>
		/// Julian Century
		/// calendar established by Julius Caesar in 46 BC, setting the number of days in a year at 365, 
		/// except for leap years which have 366, and occurred every 4 years. This calendar was reformed 
		/// by Pope Gregory XIII into the Gregorian calendar, which further refined leap years and corrected 
		/// for past errors by skipping 10 days in October of 1582. 
		/// (Spreadsheet Column G)
		/// </summary>
		public decimal JulianCentury
		{
			get
			{
				decimal returnValue = 0M;

				returnValue = (this.JulianDay - 2451545M) / 36525M;

				return returnValue;
			}
		}

		/// <summary>
		/// Sun's Geometric Mean Longitude (degrees): Geometric Mean Ecliptic Longitude of Sun.
		/// (Spreadsheet Column I)
		/// </summary>
		public Angle SunGeometricMeanLongitude
		{
			get
			{
				Angle returnValue = Angle.Empty;

				returnValue = new Angle(ExcelFormulae.Mod(280.46646M + this.JulianCentury * (36000.76983M + this.JulianCentury * 0.0003032M), 360M));

				return returnValue;
			}
		}

		/// <summary>
		/// Sun's Mean Anomaly (degrees): Position of Sun relative to perigee
		/// (Spreadsheet Column J)
		/// </summary>
		public Angle SunMeanAnomaly
		{
			get
			{
				Angle returnValue = Angle.Empty;

				returnValue = new Angle(357.52911M + this.JulianCentury * (35999.05029M - 0.0001537M * this.JulianCentury));

				return returnValue;
			}
		}

		/// <summary>
		/// Eccentricity of the Earth's Orbit: Eccentricity e is the ratio of half the distance between the foci c to
		/// the semi-major axis a: e = c / a. For example, an orbit with e = 0 is circular, e = 1 is parabolic, and e 
		/// between 0 and 1 is elliptic.
		/// (Spreadsheet Column K)
		/// </summary>
		public decimal EccentricityOfEarthOrbit
		{
			get
			{
				decimal returnValue = 0M;

				returnValue = 0.016708634M - this.JulianCentury * (0.000042037M + 0.0000001267M * this.JulianCentury);

				return returnValue;
			}
		}

		/// <summary>
		/// Sun Equation of the Center: Difference between mean anomaly and true anomaly.
		/// (Spreadsheet Column L)
		/// </summary>
		public Angle SunEquationOfCenter
		{
			get
			{
				Angle returnValue = Angle.Empty;

				returnValue = new Angle(Universal.Math.Sin(this.SunMeanAnomaly.Radians) * (1.914602M - this.JulianCentury * (0.004817M + 0.000014M * this.JulianCentury)) + Universal.Math.Sin(this.SunMeanAnomaly.RadiansMultiplied(2M)) * (0.019993M - 0.000101M * this.JulianCentury) + Universal.Math.Sin(this.SunMeanAnomaly.RadiansMultiplied(3M)) * 0.000289M);

				return returnValue;
			}
		}

		/// <summary>
		/// Sun True Longitude (degrees)
		/// (Spreadsheet Column M)
		/// </summary>
		public Angle SunTrueLongitude
		{
			get
			{
				Angle returnValue = Angle.Empty;

				returnValue = this.SunGeometricMeanLongitude + this.SunEquationOfCenter;

				return returnValue;
			}
		}

		/// <summary>
		/// Sun Apparent Longitude (degrees)
		/// (Spreadsheet Column P)
		/// </summary>
		public Angle SunApparentLongitude
		{
			get
			{
				Angle returnValue = Angle.Empty;

				Angle a1 = new Angle(125.04M - 1934.136M * this.JulianCentury);
				returnValue = new Angle((decimal)(this.SunTrueLongitude - 0.00569M - 0.00478M * Universal.Math.Sin(a1.Radians)));

				return returnValue;
			}
		}

		/// <summary>
		/// Mean Ecliptic Obliquity (degrees): Inclination of ecliptic plane w.r.t. celestial equator
		/// (Spreadsheet Column Q)
		/// </summary>
		public Angle MeanEclipticObliquity
		{
			get
			{
				Angle returnValue = 0d;

				// ***
				// *** Formula 22.3 from Page 147 of Astronomical Algorithms, Second Edition (Jean Meeus)
				// *** Original spreadsheet formula based on 22.2 same page of book
				// ***
				returnValue = 23M + (26M + ((21.448M - this.JulianCentury * (46.815M + this.JulianCentury * (0.00059M - this.JulianCentury * 0.001813M)))) / 60M) / 60M;

				return returnValue;
			}
		}

		/// <summary>
		/// Obliquity Correction (degrees)
		/// (Spreadsheet Column R)
		/// </summary>
		public Angle ObliquityCorrection
		{
			get
			{
				Angle returnValue = Angle.Empty;

				Angle a1 = 125.04M - 1934.136M * this.JulianCentury;
				returnValue = new Angle((decimal)(this.MeanEclipticObliquity + 0.00256M * Universal.Math.Cos(a1.Radians)));

				return returnValue;
			}
		}

		/// <summary>
		/// Solar Declination (Degrees): The measure of how many degrees North (positive) or South (negative) 
		/// of the equator that the sun is when viewed from the centre of the earth.  This varies from 
		/// approximately +23.5 (North) in June to -23.5 (South) in December.
		/// (Spreadsheet Column T)
		/// </summary>
		public Angle SolarDeclination
		{
			get
			{
				decimal returnValue = 0M;

				decimal radians = Universal.Math.Asin(Universal.Math.Sin(this.ObliquityCorrection.Radians) * Universal.Math.Sin(this.SunApparentLongitude.Radians));
				returnValue = Angle.FromRadians(radians);

				return returnValue;
			}
		}

		/// <summary>
		/// Var Y
		/// (Spreadsheet Column U)
		/// </summary>
		public decimal VarY
		{
			get
			{
				decimal returnValue = 0M;

				returnValue = Universal.Math.Tan(this.ObliquityCorrection.RadiansDivided(2M)) * Universal.Math.Tan(this.ObliquityCorrection.RadiansDivided(2M));

				return returnValue;
			}
		}

		/// <summary>
		/// Equation of Time (minutes)
		/// Accounts for changes in the time of solar noon for a given location over the course of a year. Earth's 
		/// elliptical orbit and Kepler's law of equal areas in equal times are the culprits behind this phenomenon.
		/// (Spreadsheet Column V)
		/// </summary>
		public decimal EquationOfTime
		{
			get
			{
				decimal returnValue = 0M;

				returnValue = 4M * Angle.ToDegrees(this.VarY * Universal.Math.Sin(2M * this.SunGeometricMeanLongitude.Radians) - 2M * this.EccentricityOfEarthOrbit * Universal.Math.Sin(this.SunMeanAnomaly.Radians) + 4M * this.EccentricityOfEarthOrbit * this.VarY * Universal.Math.Sin(this.SunMeanAnomaly.Radians) * Universal.Math.Cos(2M * this.SunGeometricMeanLongitude.Radians) - 0.5M * this.VarY * this.VarY * Universal.Math.Sin(4M * this.SunGeometricMeanLongitude.Radians) - 1.25M * this.EccentricityOfEarthOrbit * this.EccentricityOfEarthOrbit * Universal.Math.Sin(this.SunMeanAnomaly.RadiansMultiplied(2M)));

				return returnValue;
			}
		}

		/// <summary>
		/// HA Sunrise (degrees)
		/// (Spreadsheet Column W)
		/// </summary>
		public Angle HourAngleSunrise
		{
			get
			{
				decimal returnValue = 0M;

				Angle a1 = 90d + this.AtmosphericRefraction;
				decimal radians = Universal.Math.Acos(Universal.Math.Cos(a1.Radians) / (Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Cos(this.SolarDeclination.Radians)) - Universal.Math.Tan(this.Latitude.Radians) * Universal.Math.Tan(this.SolarDeclination.Radians));
				returnValue = Angle.FromRadians(radians);

				return returnValue;
			}
		}

		/// <summary>
		/// HA Astronomical Dawn (degrees)
		/// </summary>
		public Angle HourAngleDawnAstronomical
		{
			get
			{
				decimal returnValue = 0M;

				Angle a1 = 108d + this.AtmosphericRefraction;
				decimal radians = Universal.Math.Acos(Universal.Math.Cos(a1.Radians) / (Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Cos(this.SolarDeclination.Radians)) - Universal.Math.Tan(this.Latitude.Radians) * Universal.Math.Tan(this.SolarDeclination.Radians));
				returnValue = Angle.FromRadians(radians);

				return returnValue;
			}
		}

		/// <summary>
		/// HA Civil Dawn (degrees)
		/// </summary>
		public Angle HourAngleDawnCivil
		{
			get
			{
				decimal returnValue = 0M;

				Angle a1 = 96d + this.AtmosphericRefraction;
				decimal radians = Universal.Math.Acos(Universal.Math.Cos(a1.Radians) / (Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Cos(this.SolarDeclination.Radians)) - Universal.Math.Tan(this.Latitude.Radians) * Universal.Math.Tan(this.SolarDeclination.Radians));
				returnValue = Angle.FromRadians(radians);

				return returnValue;
			}
		}

		/// <summary>
		/// HA Nautical Dawn (degrees)
		/// (Spreadsheet Column W)
		/// </summary>
		public Angle HourAngleDawnNautical
		{
			get
			{
				decimal returnValue = 0M;

				Angle a1 = 102d + this.AtmosphericRefraction;
				decimal radians = Universal.Math.Acos(Universal.Math.Cos(a1.Radians) / (Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Cos(this.SolarDeclination.Radians)) - Universal.Math.Tan(this.Latitude.Radians) * Universal.Math.Tan(this.SolarDeclination.Radians));
				returnValue = Angle.FromRadians(radians);

				return returnValue;
			}
		}

		/// <summary>
		/// Solar Noon LST
		/// Defined for a given day for a specific longitude, it is the time when the sun crosses the meridian of 
		/// the observer's location. At solar noon, a shadow cast by a vertical pole will point either directly 
		/// north or directly south, depending on the observer's latitude and the time of year. 
		/// (Spreadsheet Column X)
		/// </summary>
		public DateTime SolarNoon
		{
			get
			{
				DateTime returnValue = this.ForDate.Date;

				decimal dayFraction = (720M - (4M * this.Longitude) - this.EquationOfTime + (this.TimeZoneOffset * 60M)) / 1440M;
				returnValue = this.ForDate.Date.Add(DecimalTimeSpan.FromDays(dayFraction));

				return returnValue;
			}
		}

		/// <summary>
		/// Sunlight Duration: The amount of time the sun is visible during the specified day.
		/// (Spreadsheet Column AA)
		/// </summary>
		public TimeSpan SunlightDuration
		{
			get
			{
				TimeSpan returnValue = TimeSpan.Zero;

				returnValue = DecimalTimeSpan.FromMinutes(8M * this.HourAngleSunrise);

				return returnValue;
			}
		}

		/// <summary>
		/// Hour Angle (degrees)
		/// (Spreadsheet Column AC)
		/// </summary>
		public Angle HourAngleDegrees
		{
			get
			{
				var temp = this.TrueSolarTime / 4;
				return temp < 0 ? temp + 180 : temp - 180;
			}
		}

		/// <summary>
		/// Solar Zenith (degrees)
		/// (Spreadsheet Column AD)
		/// </summary>
		public Angle SolarZenith
		{
			get
			{
				return Angle.FromRadians
				(
					Universal.Math.Acos(Universal.Math.Sin(this.Latitude.Radians) * Universal.Math.Sin(this.SolarDeclination.Radians) +
					Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Cos(this.SolarDeclination.Radians) * Universal.Math.Cos(this.HourAngleDegrees.Radians))
				);
			}
		}

		/// <summary>
		/// Solar Elevation (degrees)
		/// (Spreadsheet Column AE)
		/// </summary>
		public Angle SolarElevation
		{
			get
			{
				return new Angle(90) - this.SolarZenith;
			}
		}

		/// <summary>
		/// Solar Azimuth (degrees)
		/// (Spreadsheet Column AH)
		/// </summary>
		public Angle SolarAzimuth
		{
			get
			{
				Angle angle = Angle.FromRadians(Universal.Math.Acos(
											  ((Universal.Math.Sin(this.Latitude.Radians) * Universal.Math.Cos(this.SolarZenith.Radians)) -
												Universal.Math.Sin(this.SolarDeclination.Radians)) /
											   (Universal.Math.Cos(this.Latitude.Radians) * Universal.Math.Sin(this.SolarZenith.Radians))));

				if (this.HourAngleDegrees > 0.0)
				{
					return Angle.Reduce(angle + new Angle(180.0));
				}
				else
				{
					return Angle.Reduce(new Angle(540.0) - angle);
				}
			}
		}
		#endregion

		#region Obsolete Members
		/// <summary>
		/// This method is obsolete. Use Angle.ToRadians() instead.
		/// </summary>
		/// <param name="degrees">N/A</param>
		/// <returns>N/A</returns>
		[Obsolete("Use Angle.ToRadians() instead.", false)]
		public decimal ToRadians(decimal degrees)
		{
			return Angle.ToRadians(degrees);
		}

		/// <summary>
		/// This method is obsolete. Use Angle.ToDegrees() instead.
		/// </summary>
		/// <param name="radians">N/A</param>
		/// <returns>N/A</returns>
		[Obsolete("Use Angle.ToDegrees() instead.", false)]
		public decimal ToDegrees(decimal radians)
		{
			return Angle.ToDegrees(radians);
		}
		#endregion

		#region Additional Members
		/// <summary>
		/// Gets the True Solar Time in minutes. The Solar Time is defined as the time elapsed since the most recent 
		/// meridian passage of the sun. This system is based on the rotation of the Earth with respect to the sun. 
		/// A mean solar day is defined as the time between one solar noon and the next, averaged over the year.
		/// (Spreadsheet Column AB)
		/// </summary>
		public decimal TrueSolarTime
		{
			get
			{
				decimal returnValue = 0M;

				returnValue = ExcelFormulae.Mod(this.TimePastLocalMidnight * 1440M + this.EquationOfTime + 4M * this.Longitude - 60M * this.TimeZoneOffset, 1440M);

				return returnValue;
			}
		}
		#endregion
	}
}
