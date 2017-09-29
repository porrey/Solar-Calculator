// ***
// *** Copyright (C) 2013, Daniel M. Porrey.  All rights reserved.
// *** Written By Daniel M. Porrey
// ***
// *** This software is provided "AS IS," without a warranty of any kind. ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES, 
// *** INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE OR NON-INFRINGEMENT, ARE HEREBY EXCLUDED. DANIEL M PORREY 
// *** AND ITS LICENSORS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING THIS SOFTWARE 
// *** OR ITS DERIVATIVES. IN NO EVENT WILL DANIEL M PORREY OR ITS LICENSORS BE LIABLE FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR DIRECT, INDIRECT, 
// *** SPECIAL, CONSEQUENTIAL, INCIDENTAL OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING OUT OF THE USE OF 
// *** OR INABILITY TO USE THIS SOFTWARE, EVEN IF DANIEL M PORREY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
// ***
// *** Licensed under Microsoft Reciprocal License (Ms-RL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://solarcalculator.codeplex.com/license.
// ***
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Innovative.SolarCalculator.Tests
{
	[TestClass]
	public class SolarCalculatorTests
	{
		private TestContext _testContext = null;

		public TestContext TestContext
		{
			get
			{
				return _testContext;
			}
			set
			{
				_testContext = value;
			}
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void JulianDayComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["JulianDay"]);
			decimal actualValue = solarTimes.JulianDay;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void JulianCenturyComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["JulianCentury"]);
			decimal actualValue = solarTimes.JulianCentury;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunGeometricMeanLongitudeComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["GeomMeanLongSun"]);
			decimal actualValue = solarTimes.SunGeometricMeanLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunMeanAnomalyComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["GeomMeanAnomSun"]);
			decimal actualValue = solarTimes.SunMeanAnomaly;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void EccentricityOfEarthOrbitComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["EccentEarthOrbit"]);
			decimal actualValue = solarTimes.EccentricityOfEarthOrbit;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunEquationOfCenterComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["SunEqofCtr"]);
			decimal actualValue = solarTimes.SunEquationOfCenter;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunTrueLongitudeComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["SunTrueLong"]);
			decimal actualValue = solarTimes.SunTrueLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunApparentLongitudeComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["SunAppLong"]);
			decimal actualValue = solarTimes.SunApparentLongitude;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void MeanEclipticObliquityComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["MeanObliqEcliptic"]);
			decimal actualValue = solarTimes.MeanEclipticObliquity;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void ObliquityCorrectionComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["ObliqCorr"]);
			decimal actualValue = solarTimes.ObliquityCorrection;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SolarDeclinationComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["SunDeclin"]);
			decimal actualValue = solarTimes.SolarDeclination;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void VarYComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["vary"]);
			decimal actualValue = solarTimes.VarY;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void EquationOfTimeComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["EqofTime"]);
			decimal actualValue = solarTimes.EquationOfTime;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void HourAngleSunriseComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["HaSunrise"]);
			decimal actualValue = solarTimes.HourAngleSunrise;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SolarNoonComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			DateTime expectedValue = Convert.ToDateTime(this.TestContext.DataRow["SolarNoon"]);
			DateTime actualValue = solarTimes.SolarNoon;
			TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

			if (difference > TestDirector.TimeSpanDelta)
			{
				Assert.Fail(string.Format("The Solar Noon (Column X) calculation does not match Excel. The difference is {0}", difference));
			}
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunriseComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			DateTime expectedValue = Convert.ToDateTime(this.TestContext.DataRow["SunriseTime"]);
			DateTime actualValue = solarTimes.Sunrise;
			TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

			if (difference > TestDirector.TimeSpanDelta)
			{
				Assert.Fail(string.Format("The Sunrise (Column Y) calculation does not match Excel. The difference is {0}", difference));
			}
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunsetComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			DateTime expectedValue = Convert.ToDateTime(this.TestContext.DataRow["SunsetTime"]);
			DateTime actualValue = solarTimes.Sunset;
			TimeSpan difference = expectedValue.TimeOfDay.Subtract(actualValue.TimeOfDay);

			if (difference > TestDirector.TimeSpanDelta)
			{
				Assert.Fail(string.Format("The Sunset (Column Z) calculation does not match Excel. The difference is {0}", difference));
			}
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void SunlightDurationComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			TimeSpan expectedValue = TimeSpan.FromMinutes(Convert.ToDouble(this.TestContext.DataRow["SunlightDuration"]));
			TimeSpan actualValue = solarTimes.SunlightDuration;
			TimeSpan difference = expectedValue - actualValue;

			if (difference > TestDirector.TimeSpanDelta)
			{
				Assert.Fail(string.Format("The Sunlight Duration (Column AA) calculation does not match Excel. The difference is {0}", difference));
			}
		}

		[TestMethod]
		[TestCategory("Solar Calculation Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Calculations$", DataAccessMethod.Sequential)]
		public void TrueSolarTimeComparisonTest()
		{
			SolarTimes solarTimes = TestDirector.SolarTimesInstance(this.TestContext.DataRow);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["TrueSolarTime"]);
			decimal actualValue = solarTimes.TrueSolarTime;
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.SolarDecimalDelta);
		}
	}
}
