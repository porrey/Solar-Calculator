// ***
// *** Copyright (C) 2013-2017, Daniel M. Porrey.  All rights reserved.
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
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Innovative.SolarCalculator.Tests
{
	[TestClass]
	public class CsharpExcelTests
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
		[TestCategory("C#/Excel Comparison Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "ExcelFormulas$", DataAccessMethod.Sequential)]
		public void CsharpExcelSineComparisons()
		{
			decimal value1 = Convert.ToDecimal(this.TestContext.DataRow["VALUE1"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["SIN"]);

			decimal actualValue = Universal.Math.Sin(value1);
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[TestMethod]
		[TestCategory("C#/Excel Comparison Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "ExcelFormulas$", DataAccessMethod.Sequential)]
		public void CsharpExcelASineComparisons()
		{
			decimal value1 = Convert.ToDecimal(this.TestContext.DataRow["VALUE1"]);
			decimal sin = Convert.ToDecimal(this.TestContext.DataRow["SIN"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["ASIN"]);

			decimal actualValue = Universal.Math.Asin(sin);
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[TestMethod]
		[TestCategory("C#/Excel Comparison Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "ExcelFormulas$", DataAccessMethod.Sequential)]
		public void CsharpExcelCosineComparisons()
		{
			decimal value1 = Convert.ToDecimal(this.TestContext.DataRow["VALUE1"]);
			decimal value2 = Convert.ToDecimal(this.TestContext.DataRow["VALUE2"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["COS"]);

			decimal actualValue = Universal.Math.Cos(value1);
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[TestMethod]
		[TestCategory("C#/Excel Comparison Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "ExcelFormulas$", DataAccessMethod.Sequential)]
		public void CsharpExcelACosineComparisons()
		{
			decimal value1 = Convert.ToDecimal(this.TestContext.DataRow["VALUE1"]);
			decimal value2 = Convert.ToDecimal(this.TestContext.DataRow["VALUE2"]);
			decimal cos = Convert.ToDecimal(this.TestContext.DataRow["COS"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["ACOS"]);

			decimal actualValue = Universal.Math.Acos(cos);
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[TestMethod]
		[TestCategory("C#/Excel Comparison Tests")]
		[DeploymentItem("NOAA Solar Calculations Test Data.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NOAA Solar Calculations Test Data.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "ExcelFormulas$", DataAccessMethod.Sequential)]
		public void CsharpExcelTangentComparisons()
		{
			decimal value1 = Convert.ToDecimal(this.TestContext.DataRow["VALUE1"]);
			decimal value2 = Convert.ToDecimal(this.TestContext.DataRow["VALUE2"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["TAN"]);

			decimal actualValue = Universal.Math.Tan(value1);
			decimal difference = expectedValue - actualValue;

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}
	}
}
