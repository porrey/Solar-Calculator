// ***
// *** Solar Calculator 3.0.0
// *** Copyright(C) 2013-2020, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class SolarCalculatorTests
	{
		// ***
		// *** Get the test data.
		// ***
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
		public void CheckSunsetDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTimeOffset forDate = DateTimeOffset.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunset.Date);
		}

		[Test]
		public void CheckSunriseDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTimeOffset forDate = DateTimeOffset.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunrise.Date);
		}

		[Test]
		public void CheckSolarNoonDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTimeOffset forDate = DateTimeOffset.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.SolarNoon.Date);
		}
	}
}
