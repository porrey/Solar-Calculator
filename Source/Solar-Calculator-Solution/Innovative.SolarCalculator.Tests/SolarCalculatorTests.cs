// ***
// *** Copyright (C) 2013-2018, Daniel M. Porrey. All rights reserved.
// *** Written By Daniel M. Porrey
// ***
// *** This software is provided "AS IS," without a warranty of any kind. ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES, 
// *** INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE OR NON-INFRINGEMENT, ARE HEREBY EXCLUDED. DANIEL M PORREY 
// *** AND ITS LICENSORS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING THIS SOFTWARE 
// *** OR ITS DERIVATIVES. IN NO EVENT WILL DANIEL M PORREY OR ITS LICENSORS BE LIABLE FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR DIRECT, INDIRECT, 
// *** SPECIAL, CONSEQUENTIAL, INCIDENTAL OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING OUT OF THE USE OF 
// *** OR INABILITY TO USE THIS SOFTWARE, EVEN IF DANIEL M PORREY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
// ***
// *** Licensed under Microsoft Public License (Ms-PL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
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
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void JulianCenturyComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.JulianCentury;
			decimal actualValue = solarTimes.JulianCentury;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SunGeometricMeanLongitudeComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.GeomMeanLongSun;
			decimal actualValue = solarTimes.SunGeometricMeanLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SunMeanAnomalyComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.GeomMeanAnomSun;
			decimal actualValue = solarTimes.SunMeanAnomaly;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void EccentricityOfEarthOrbitComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.EccentEarthOrbit;
			decimal actualValue = solarTimes.EccentricityOfEarthOrbit;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SunEquationOfCenterComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.SunEqofCtr;
			decimal actualValue = solarTimes.SunEquationOfCenter;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SunTrueLongitudeComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.SunTrueLong;
			decimal actualValue = solarTimes.SunTrueLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SunApparentLongitudeComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.SunAppLong;
			decimal actualValue = solarTimes.SunApparentLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void MeanEclipticObliquityComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.MeanObliqEcliptic;
			decimal actualValue = solarTimes.MeanEclipticObliquity;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ObliquityCorrectionComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.ObliqCorr;
			decimal actualValue = solarTimes.ObliquityCorrection;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SolarDeclinationComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.SunDeclin;
			decimal actualValue = solarTimes.SolarDeclination;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void VarYComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.Vary;
			decimal actualValue = solarTimes.VarY;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void EquationOfTimeComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.EqofTime;
			decimal actualValue = solarTimes.EquationOfTime;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void HourAngleSunriseComparisonTest(SolarCalculationsTestData item)
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(item);
			decimal expectedValue = item.HaSunrise;
			decimal actualValue = solarTimes.HourAngleSunrise;
			decimal difference = expectedValue - actualValue;

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
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[Test]
		public void CheckSunsetDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunset.Date);
		}

		[Test]
		public void CheckSunriseDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunrise.Date);
		}

		[Test]
		public void CheckSolarNoonDate()
		{
			int numberOfDays = TestDirector.Rnd.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.SolarNoon.Date);
		}
	}
}
