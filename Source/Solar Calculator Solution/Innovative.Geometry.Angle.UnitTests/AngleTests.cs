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
// *** Licensed under Microsoft Public License (Ms-PL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Innovative.Geometry.Tests
{
	[TestClass]
	public class AngleTests
	{
		private Random _rnd = new Random();

		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for math comparison tests.
		/// </summary>		
		public static decimal MathDecimalDelta
		{
			get
			{
				// ***
				// ***   123456789012
				return 0.00000001M;
			}
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type double
		/// for math comparison tests.
		/// </summary>		
		public static double MathDoubleDelta
		{
			get
			{
				// ***
				// ***   123456789012
				return 0.0000001D;
			}
		}

		public TestContext TestContext { get; set; }

		/// <summary>
		/// Gets a random Angle between -720 and +720
		/// </summary>
		/// <returns></returns>
		public Angle GetRandomAngle()
		{
			return new Angle(-720 + (_rnd.NextDouble() * (720 * 2)));
		}

		#region Constructor Tests
		[TestMethod]
		[TestCategory("Constructor Tests")]
		public void AngleEmptyConstructorTest()
		{
			Angle target = new Angle();
			Assert.AreEqual(0D, (double)target);
			Assert.AreEqual(0M, (decimal)target);
			Assert.AreEqual(0, target.Degrees);
			Assert.AreEqual(0, target.Arcminute);
			Assert.AreEqual(0M, target.Arcsecond);
		}

		[TestMethod]
		[TestCategory("Constructor Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AngleIntegerConstructorTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Angle"]);
			Angle target = new Angle(degrees);
			Assert.AreEqual<int>(degrees, target.Degrees);
		}

		[TestMethod]
		[TestCategory("Constructor Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AngleDecimalConstructorTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = new Angle(decimalDegrees);

			Assert.AreEqual<int>(degrees, target.Degrees);
			Assert.AreEqual<int>(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Constructor Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AngleDoubleConstructorTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			double doubleDegrees = Convert.ToDouble(this.TestContext.DataRow["Angle"]);

			Angle target = new Angle(doubleDegrees);

			Assert.AreEqual<int>(degrees, target.Degrees);
			Assert.AreEqual<int>(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Constructor Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AngleThreePartDecimalConstructorTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]); ;

			Angle target = new Angle(degrees, arcminute, arcsecond);

			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Constructor Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AngleThreePartDoubleConstructorTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			double doubleDegrees = Convert.ToDouble(this.TestContext.DataRow["Angle"]); ;

			Angle target = new Angle(degrees, arcminute, arcsecond);

			Assert.AreEqual(doubleDegrees, (double)target, AngleTests.MathDoubleDelta);
		}
		#endregion

		#region Public Member Tests
		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void DegreesTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual<int>(degrees, target.Degrees);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ArcminuteTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			int arcMinute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual<int>(arcMinute, target.Arcminute);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ArcsecondTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal arcSeconds = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(arcSeconds, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void RadiansTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal radians = Convert.ToDecimal(this.TestContext.DataRow["Radians"]);

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(radians, target.Radians, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void RadiansMultipliedTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal radiansMultiplied = Convert.ToDecimal(this.TestContext.DataRow["RadiansMultiplied"]);
			int multiplier = Convert.ToInt32(this.TestContext.DataRow["Multiplier"]);

			Angle target = new Angle(decimalDegrees);
			decimal actual = target.RadiansMultiplied(multiplier);

			CustomAssert.AreEqual(radiansMultiplied, actual, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void RadiansDividedTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal radiansDivided = Convert.ToDecimal(this.TestContext.DataRow["RadiansDivided"]);
			int divider = Convert.ToInt32(this.TestContext.DataRow["Multiplier"]);

			Angle target = new Angle(decimalDegrees);
			decimal actual = target.RadiansDivided(divider);

			CustomAssert.AreEqual(radiansDivided, actual, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void TotalArcminutesTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal totalMinutes = Convert.ToDecimal(this.TestContext.DataRow["TotalMinutes"]);

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(totalMinutes, target.TotalArcminutes, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void TotalArcsecondsTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal totalSeconds = Convert.ToDecimal(this.TestContext.DataRow["TotalSeconds"]);

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(totalSeconds, target.TotalArcseconds, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ReduceTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal reduced = Convert.ToDecimal(this.TestContext.DataRow["ReducedDegrees"]);

			Angle target = new Angle(decimalDegrees);
			target.Reduce();
			Assert.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(reduced, (decimal)target, AngleTests.MathDecimalDelta);
		}
		#endregion

		#region Public Override Tests
		[TestMethod]
		[TestCategory("Public Override Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void EqualsTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle target0 = new Angle(decimalDegrees);
			object target1 = new Angle(decimalDegrees + 100);
			bool areNotEqual = !target0.Equals(target1);
			Assert.IsTrue(areNotEqual);

			Angle target2 = new Angle(decimalDegrees);
			object target3 = new Angle(decimalDegrees);
			bool areEqual = target2.Equals(target3);
			Assert.IsTrue(areEqual);
		}

		[TestMethod]
		[TestCategory("Public Override Tests")]
		public void NullEqualsTest()
		{
			Angle target = new Angle();
			object obj = null;
			bool actual = target.Equals(obj);
			Assert.IsFalse(actual);
		}

		[TestMethod]
		[TestCategory("Public Override Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GetHashCodeTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(decimalDegrees.GetHashCode(), target.GetHashCode());
		}
		#endregion

		#region Implicit Conversion Tests
		[TestMethod]
		[TestCategory("Implicit Conversion Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ImplicitAngleToDecimalTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle target = new Angle(decimalDegrees);

			object actual = (decimal)target;
			Assert.IsTrue(actual is decimal);
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Implicit Conversion Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ImplicitAngleToDoubleTest()
		{
			double doubleDegrees = Convert.ToDouble(this.TestContext.DataRow["Angle"]);
			Angle target = new Angle(doubleDegrees);

			object actual = (double)target;
			Assert.IsTrue(actual is double);
			Assert.AreEqual(doubleDegrees, (double)target, AngleTests.MathDoubleDelta);
		}

		[TestMethod]
		[TestCategory("Implicit Conversion Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ImplicitDecimalToAngleTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			object target = (Angle)decimalDegrees;
			Assert.IsTrue(target is Angle);
			CustomAssert.AreEqual(decimalDegrees, (decimal)((Angle)target), AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Implicit Conversion Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ImplicitDoubleToAngleTest()
		{
			double doubleDegrees = Convert.ToDouble(this.TestContext.DataRow["Angle"]);
			object target = (Angle)doubleDegrees;
			Assert.IsTrue(target is Angle);
			Assert.AreEqual(doubleDegrees, (double)((Angle)target), AngleTests.MathDoubleDelta);
		}
		#endregion

		#region Operator Tests
		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void AdditionOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			Angle target = firstAngle + secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue + secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void SubtractionOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			Angle target = firstAngle - secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue - secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void MultiplicationOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			Angle target = firstAngle * secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue * secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void DivisionOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			Angle target = firstAngle / secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue / secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ModuloOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			Angle target = firstAngle % secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue % secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void IncrementOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle target = new Angle(decimalDegrees);

			decimal expectedValue = target.InternalValue + 1;
			target++;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void DecrementOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle target = new Angle(decimalDegrees);

			decimal expectedValue = target.InternalValue - 1;
			target--;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void EqualOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle == secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue == secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void NotEqualOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle != secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue != secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GreaterThanOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle > secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue > secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GreaterThanOrEqualToOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle >= secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue >= secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void LessThanOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle < secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue < secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void LessThanOrEqualToOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = this.GetRandomAngle();

			bool target = firstAngle <= secondAngle;
			Assert.AreEqual<bool>(firstAngle.InternalValue <= secondAngle.InternalValue, target);
		}

		[TestMethod]
		[TestCategory("Operator Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void NotOperatorTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle firstAngle = new Angle(decimalDegrees);

			decimal oppositeDirection = Convert.ToDecimal(this.TestContext.DataRow["OppositeDirection"]);
			Angle secondAngle = new Angle(oppositeDirection);

			Angle target = !firstAngle;

			CustomAssert.AreEqual(secondAngle.InternalValue, target.InternalValue, AngleTests.MathDecimalDelta);
		}
		#endregion

		#region Static Member Tests
		[TestMethod]
		[TestCategory("Static Member Tests")]
		public void EmptyTest()
		{
			Angle target = Angle.Empty;
			Assert.AreEqual(0D, (double)target);
			Assert.AreEqual(0M, (decimal)target);
			Assert.AreEqual(0, target.Degrees);
			Assert.AreEqual(0, target.Arcminute);
			Assert.AreEqual(0M, target.Arcsecond);
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToDegreesFromThreePartsTest()
		{
			decimal radians = Convert.ToDecimal(this.TestContext.DataRow["Radians"]);
			decimal expectedValue = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			decimal actualValue = Angle.ToDegrees(radians);

			CustomAssert.AreEqual(expectedValue, actualValue, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToDegreesFromRadiansTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = Angle.ToDegrees(degrees, arcminute, arcsecond);
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToRadiansTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal radians = Convert.ToDecimal(this.TestContext.DataRow["Radians"]);

			decimal target = Angle.ToRadians(decimalDegrees);

			CustomAssert.AreEqual(radians, target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void FromRadiansTest()
		{
			decimal radians = Convert.ToDecimal(this.TestContext.DataRow["Radians"]);
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = Angle.FromRadians(radians);

			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
			Assert.AreEqual<int>(degrees, target.Degrees);
			Assert.AreEqual<int>(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GetDegreesTest()
		{
			int degrees = Convert.ToInt32(this.TestContext.DataRow["Degrees"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual<int>(degrees, Angle.GetDegrees(target));
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GetArcminuteTest()
		{
			int arcminute = Convert.ToInt32(this.TestContext.DataRow["Minutes"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			int actual = Angle.GetArcminute(decimalDegrees);
			Assert.AreEqual<int>(arcminute, actual);
		}

		[TestMethod]
		[TestCategory("Static Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void GetArcsecondTest()
		{
			decimal arcsecond = Convert.ToDecimal(this.TestContext.DataRow["Seconds"]);
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			decimal actual = Angle.GetArcsecond(decimalDegrees);
			CustomAssert.AreEqual(arcsecond, actual, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Public Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void StaticReduceTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			decimal reduced = Convert.ToDecimal(this.TestContext.DataRow["ReducedDegrees"]);

			Angle target = Angle.Reduce(decimalDegrees);
			Assert.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(reduced, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ParseTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = Angle.Parse(decimalDegrees.ToString());
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void TryParseTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = null;
			if (Angle.TryParse(decimalDegrees.ToString(), out target))
			{
				CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
			}
			else
			{
				Assert.Fail("Could not parse value.");
			}
		}
		#endregion

		#region Internal Member Tests
		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void InternalValueTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(decimalDegrees, target.InternalValue);
		}

		[TestMethod]
		[TestCategory("Internal Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void NormalDirectionDegreesMintesSecondsTest()
		{
			int degrees1 = -1 * Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Degrees"]));
			degrees1 = degrees1 == 0 ? degrees1 = -1 : degrees1;
			int minutes1 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref degrees1, ref minutes1, ref seconds1);
			Assert.IsTrue(degrees1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			int degrees2 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Degrees"]));
			degrees2 = degrees2 == 0 ? degrees2 = -1 : degrees2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref degrees2, ref minutes2, ref seconds2);
			Assert.IsTrue(degrees2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			int degrees3 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Degrees"]));
			degrees3 = degrees3 == 0 ? degrees3 = -1 : degrees3;
			int minutes3 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref degrees3, ref minutes3, ref seconds3);
			Assert.IsTrue(degrees3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}

		[TestMethod]
		[TestCategory("Internal Member Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void NormalDirectionHoursMinutesSecondsTest()
		{
			decimal hours1 = -1 * Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Degrees"]));
			hours1 = hours1 == 0 ? hours1 = -1 : hours1;
			int minutes1 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref hours1, ref minutes1, ref seconds1);
			Assert.IsTrue(hours1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			decimal hours2 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Degrees"]));
			hours2 = hours2 == 0 ? hours2 = -1 : hours2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref hours2, ref minutes2, ref seconds2);
			Assert.IsTrue(hours2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			decimal hours3 = Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Degrees"]));
			hours3 = hours3 == 0 ? hours3 = -1 : hours3;
			int minutes3 = Math.Abs(Convert.ToInt32(this.TestContext.DataRow["Minutes"]));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(Convert.ToDecimal(this.TestContext.DataRow["Seconds"]));
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref hours3, ref minutes3, ref seconds3);
			Assert.IsTrue(hours3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}
		#endregion

		#region Formatter Tests
		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToStringTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			string shortFormat = Convert.ToString(this.TestContext.DataRow["ShortFormat"]);

			Angle target = new Angle(decimalDegrees);
			string actualValue = target.ToString();

			Assert.AreEqual(shortFormat, actualValue);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToShortFormatTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			string shortFormat = Convert.ToString(this.TestContext.DataRow["ShortFormat"]);

			Angle target = new Angle(decimalDegrees);
			string actualValue = target.ToShortFormat();

			Assert.AreEqual(shortFormat, actualValue);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void ToLongFormatTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			string longFormat = Convert.ToString(this.TestContext.DataRow["LongFormat"]);

			Angle target = new Angle(decimalDegrees);
			string actualValue = target.ToLongFormat();

			Assert.AreEqual(longFormat, actualValue);
		}
		#endregion

		#region IComparable Test
		[TestMethod]
		[TestCategory("IComparable Test")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void IComparableTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target0 = new Angle(decimalDegrees);
			object target1 = new Angle(decimalDegrees + 100);
			int result1 = target0.CompareTo(target1);
			Assert.AreEqual<int>(-1, result1);

			Angle target2 = new Angle(decimalDegrees);
			object target3 = new Angle(decimalDegrees - 100);
			int result2 = target2.CompareTo(target3);
			Assert.AreEqual<int>(1, result2);

			Angle target4 = new Angle(decimalDegrees);
			object target5 = new Angle(decimalDegrees);
			int result3 = target4.CompareTo(target5);
			Assert.AreEqual<int>(0, result3);
		}

		[TestMethod]
		[TestCategory("IComparable Test")]
		public void NullIComparableTest()
		{
			Angle target = new Angle();
			object obj = null;
			int expected = 1;
			int actual;
			actual = target.CompareTo(obj);
			Assert.AreEqual(expected, actual);
		}
		#endregion

		#region IFormattable Test
		[TestMethod]
		[TestCategory("Angle Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void IFormattableTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			string shortFormat = Convert.ToString(this.TestContext.DataRow["ShortFormat"]);
			string longFormat = Convert.ToString(this.TestContext.DataRow["LongFormat"]);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(shortFormat, target.ToString("0°.0000####", CultureInfo.CurrentCulture));
		}
		#endregion

		#region IComparable<Angle> Tests
		[TestMethod]
		[TestCategory("IComparable Test")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void IComparableAngleTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);

			Angle target0 = new Angle(decimalDegrees);
			Angle target1 = new Angle(decimalDegrees + 100);
			int result1 = target0.CompareTo(target1);
			Assert.AreEqual<int>(-1, result1);

			Angle target2 = new Angle(decimalDegrees);
			Angle target3 = new Angle(decimalDegrees - 100);
			int result2 = target2.CompareTo(target3);
			Assert.AreEqual<int>(1, result2);

			Angle target4 = new Angle(decimalDegrees);
			Angle target5 = new Angle(decimalDegrees);
			int result3 = target4.CompareTo(target5);
			Assert.AreEqual<int>(0, result3);
		}

		[TestMethod]
		[TestCategory("Angle Tests")]
		public void NullIComparableAngleTest()
		{
			Angle target = new Angle();
			Angle other = null;
			int expected = 1;
			int actual;
			actual = target.CompareTo(other);
			Assert.AreEqual(expected, actual);
		}
		#endregion

		#region IEquatable<Angle> Test
		[TestMethod]
		[TestCategory("Public Override Tests")]
		[DeploymentItem("AngleTestData.xlsx")]
		[DataSource("System.Data.OleDb", "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=AngleTestData.xlsx;Extended Properties=\"Excel 12.0;HDR=YES\"", "Angles$", DataAccessMethod.Sequential)]
		public void IEquatableTest()
		{
			decimal decimalDegrees = Convert.ToDecimal(this.TestContext.DataRow["Angle"]);
			Angle target0 = new Angle(decimalDegrees);
			Angle target1 = new Angle(decimalDegrees + 100);
			bool areNotEqual = !target0.Equals(target1);
			Assert.IsTrue(areNotEqual);

			Angle target2 = new Angle(decimalDegrees);
			Angle target3 = new Angle(decimalDegrees);
			bool areEqual = target2.Equals(target3);
			Assert.IsTrue(areEqual);
		}
		#endregion
	}
}