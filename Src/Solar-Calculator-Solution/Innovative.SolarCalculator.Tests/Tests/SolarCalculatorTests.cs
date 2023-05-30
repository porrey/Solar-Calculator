//
// Solar Calculator
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
// 
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
    [TestFixture]
    public class SolarCalculatorTests
    {
        //
        // Get the test data.
        //
        static readonly IEnumerable<SolarCalculationsTestData> TestDataItems = TestDirector.LoadSolarCalculatorTestData();

        [Test]
        [TestCaseSource("TestDataItems")]
        public void JulianDayComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.JulianDay;
            decimal actualValue = solarTimes.JulianDay;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void JulianCenturyComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.JulianCentury;
            decimal actualValue = solarTimes.JulianCentury;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunGeometricMeanLongitudeComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.GeomMeanLongSun;
            decimal actualValue = solarTimes.SunGeometricMeanLongitude;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunMeanAnomalyComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.GeomMeanAnomSun;
            decimal actualValue = solarTimes.SunMeanAnomaly;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void EccentricityOfEarthOrbitComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.EccentEarthOrbit;
            decimal actualValue = solarTimes.EccentricityOfEarthOrbit;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunEquationOfCenterComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.SunEqofCtr;
            decimal actualValue = solarTimes.SunEquationOfCenter;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunTrueLongitudeComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.SunTrueLong;
            decimal actualValue = solarTimes.SunTrueLongitude;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunApparentLongitudeComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.SunAppLong;
            decimal actualValue = solarTimes.SunApparentLongitude;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void MeanEclipticObliquityComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.MeanObliqEcliptic;
            decimal actualValue = solarTimes.MeanEclipticObliquity;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void ObliquityCorrectionComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.ObliqCorr;
            decimal actualValue = solarTimes.ObliquityCorrection;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SolarDeclinationComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.SunDeclin;
            decimal actualValue = solarTimes.SolarDeclination;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void VarYComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.Vary;
            decimal actualValue = solarTimes.VarY;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void EquationOfTimeComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.EqofTime;
            decimal actualValue = solarTimes.EquationOfTime;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void HourAngleSunriseComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.HaSunrise;
            decimal actualValue = solarTimes.HourAngleSunrise;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SolarNoonComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            DateTime expectedValue = Convert.ToDateTime(item.SolarNoon);
            DateTime actualValue = solarTimes.SolarNoon;
            TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

            if (difference > TestDirector.TimeSpanDelta)
            {
                Assert.Fail($"The Solar Noon (Column X) calculation does not match Excel. The difference is {difference}");
            }
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunriseComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            DateTime expectedValue = item.SunriseTime;
            DateTime actualValue = solarTimes.Sunrise;
            TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

            if (difference > TestDirector.TimeSpanDelta)
            {
                Assert.Fail($"The Sunrise (Column Y) calculation does not match Excel. The difference is {difference}");
            }
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunsetComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            DateTime expectedValue = item.SunsetTime;
            DateTime actualValue = solarTimes.Sunset;
            TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

            if (difference > TestDirector.TimeSpanDelta)
            {
                Assert.Fail($"The Sunset (Column Z) calculation does not match Excel. The difference is {difference}");
            }
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void SunlightDurationComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            TimeSpan expectedValue = TimeSpan.FromMinutes(item.SunlightDuration);
            TimeSpan actualValue = solarTimes.SunlightDuration;
            TimeSpan difference = expectedValue - actualValue;

            if (difference > TestDirector.TimeSpanDelta)
            {
                Assert.Fail($"The Sunlight Duration (Column AA) calculation does not match Excel. The difference is {difference}");
            }
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void TrueSolarTimeComparisonTest(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            decimal expectedValue = item.TrueSolarTime;
            decimal actualValue = solarTimes.TrueSolarTime;

            CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void CheckSunriseDate(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunrise.Date);
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void CheckSunsetDate(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            //Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunset.Date);
            Assert.Inconclusive("Disabled until further research can be done.");
        }

        [Test]
        [TestCaseSource("TestDataItems")]
        public void CheckSolarNoonDate(SolarCalculationsTestData item)
        {
            SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
            //Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.SolarNoon.Date);
            Assert.Inconclusive("Disabled until further research can be done.");
        }

        [Test]
        public void CheckDawnDuskTimes()
        {
            // Test data is sourced from http://www.ga.gov.au/geodesy/astro/sunrise.jsp
            // Times slightly adjusted as the website is rounded to the minute

            SolarTimes solarTimes = new SolarTimes()
            {
                Latitude = -33.856837,
                Longitude = 151.215066,
                ForDate = new DateTimeOffset(new DateTime(2020, 07, 21).Date, TimeSpan.FromHours(10)),
            };

            Assert.AreEqual(2020, solarTimes.DawnAstronomical.Year);
            Assert.AreEqual(07,   solarTimes.DawnAstronomical.Month);
            Assert.AreEqual(21,   solarTimes.DawnAstronomical.Day);
            Assert.AreEqual(05,   solarTimes.DawnAstronomical.Hour);
            Assert.AreEqual(27,   solarTimes.DawnAstronomical.Minute);
            Assert.AreEqual(52,   solarTimes.DawnAstronomical.Second);

            Assert.AreEqual(2020, solarTimes.DawnNautical.Year);
            Assert.AreEqual(07,   solarTimes.DawnNautical.Month);
            Assert.AreEqual(21,   solarTimes.DawnNautical.Day);
            Assert.AreEqual(05,   solarTimes.DawnNautical.Hour);
            Assert.AreEqual(57,   solarTimes.DawnNautical.Minute);
            Assert.AreEqual(46,   solarTimes.DawnNautical.Second);

            Assert.AreEqual(2020, solarTimes.DawnCivil.Year);
            Assert.AreEqual(07,   solarTimes.DawnCivil.Month);
            Assert.AreEqual(21,   solarTimes.DawnCivil.Day);
            Assert.AreEqual(06,   solarTimes.DawnCivil.Hour);
            Assert.AreEqual(28,   solarTimes.DawnCivil.Minute);
            Assert.AreEqual(18,   solarTimes.DawnCivil.Second);

            Assert.AreEqual(2020, solarTimes.Sunrise.Year);
            Assert.AreEqual(07,   solarTimes.Sunrise.Month);
            Assert.AreEqual(21,   solarTimes.Sunrise.Day);
            Assert.AreEqual(06,   solarTimes.Sunrise.Hour);
            Assert.AreEqual(55,   solarTimes.Sunrise.Minute);
            Assert.AreEqual(14,   solarTimes.Sunrise.Second);

            Assert.AreEqual(2020, solarTimes.Sunset.Year);
            Assert.AreEqual(07,   solarTimes.Sunset.Month);
            Assert.AreEqual(21,   solarTimes.Sunset.Day);
            Assert.AreEqual(17,   solarTimes.Sunset.Hour);
            Assert.AreEqual(07,   solarTimes.Sunset.Minute);
            Assert.AreEqual(52,   solarTimes.Sunset.Second);

            Assert.AreEqual(2020, solarTimes.DuskCivil.Year);
            Assert.AreEqual(07,   solarTimes.DuskCivil.Month);
            Assert.AreEqual(21,   solarTimes.DuskCivil.Day);
            Assert.AreEqual(17,   solarTimes.DuskCivil.Hour);
            Assert.AreEqual(34,   solarTimes.DuskCivil.Minute);
            Assert.AreEqual(48,   solarTimes.DuskCivil.Second);

            Assert.AreEqual(2020, solarTimes.DuskNautical.Year);
            Assert.AreEqual(07,   solarTimes.DuskNautical.Month);
            Assert.AreEqual(21,   solarTimes.DuskNautical.Day);
            Assert.AreEqual(18,   solarTimes.DuskNautical.Hour);
            Assert.AreEqual(05,   solarTimes.DuskNautical.Minute);
            Assert.AreEqual(20,   solarTimes.DuskNautical.Second);

            Assert.AreEqual(2020, solarTimes.DuskAstronomical.Year);
            Assert.AreEqual(07,   solarTimes.DuskAstronomical.Month);
            Assert.AreEqual(21,   solarTimes.DuskAstronomical.Day);
            Assert.AreEqual(18,   solarTimes.DuskAstronomical.Hour);
            Assert.AreEqual(35,   solarTimes.DuskAstronomical.Minute);
            Assert.AreEqual(14,   solarTimes.DuskAstronomical.Second);
        }

        [Test]
        public void CheckPolarTimes()
        {
            // https://gml.noaa.gov/grad/solcalc/table.php?lat=68.262796&lon=14.249245&year=2023
            SolarTimes polarDay = new SolarTimes()
            {
                Latitude = 68.2627966,
                Longitude = 14.2492450,
                ForDate = new DateTimeOffset(new DateTime(2023, 5, 29, 12, 0, 0), TimeSpan.FromHours(2)),
            };
            
            SolarTimes polarNight = new SolarTimes()
            {
                Latitude = 68.2627966,
                Longitude = 14.2492450,
                ForDate = new DateTimeOffset(new DateTime(2024, 01, 01, 12, 0, 0), TimeSpan.FromHours(1)),
            };
            
            SolarTimes notPolarTime = new SolarTimes()
            {
                Latitude = 68.2627966,
                Longitude = 14.2492450,
                ForDate = new DateTimeOffset(new DateTime(2024, 02, 15, 12, 0, 0), TimeSpan.FromHours(1)),
            };
            
            // During polar night, the sunset was some time in the past, for now MinValue
            Assert.AreEqual(DateTime.MinValue, polarNight.Sunset);
            // During polar night, the sunrise is some time in future, for now MaxValue
            Assert.AreEqual(DateTime.MaxValue, polarNight.Sunrise);
            // Is polar night, sun never rises
            Assert.AreEqual(true, polarNight.IsPolarNight);
            Assert.AreEqual(false, polarNight.IsPolarDay);
            
            // During polar day, the sunrise was some time in the past, for now MinValue
            Assert.AreEqual(DateTime.MinValue, polarDay.Sunrise);
            // During polar day, the sunset is some time in future, for now MaxValue
            Assert.AreEqual(DateTime.MaxValue, polarDay.Sunset);
            // Is polar day, sun never goes down
            Assert.AreEqual(true, polarDay.IsPolarDay);
            Assert.AreEqual(false, polarDay.IsPolarNight);
            
            Assert.AreEqual(false, notPolarTime.IsPolarDay);
            Assert.AreEqual(false, notPolarTime.IsPolarNight);
        }
    }
}
