// ***
// *** Copyright (C) 2013-2018, Daniel M. Porrey.  All rights reserved.
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
using System.Linq;
using NUnit.Framework;

namespace Innovative.Geometry.Tests
{
	[TestFixture]
	public class AngleTests
	{
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

		static readonly IEnumerable<TestData> TestDataItems = Enumerable.Range(0, 100).Select(_ => new TestData()).ToList();

		#region Constructor Tests
		[Test]
		public void AngleEmptyConstructorTest()
		{
			Angle target = new Angle();
			Assert.AreEqual(0D, (double)target);
			Assert.AreEqual(0M, (decimal)target);
			Assert.AreEqual(0, target.Degrees);
			Assert.AreEqual(0, target.Arcminute);
			Assert.AreEqual(0M, target.Arcsecond);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleIntegerConstructorTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Angle1);
			Angle target = new Angle(degrees);
			Assert.AreEqual(degrees, target.Degrees);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleDecimalConstructorTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			decimal decimalDegrees = item.Angle1;

			Angle target = new Angle(decimalDegrees);

			Assert.AreEqual(degrees, target.Degrees);
			Assert.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleDoubleConstructorTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			double doubleDegrees = Convert.ToDouble(item.Angle1);

			Angle target = new Angle(doubleDegrees);

			Assert.AreEqual(degrees, target.Degrees);
			Assert.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleThreePartDecimalConstructorTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			decimal decimalDegrees = item.Angle1;

			Angle target = new Angle(degrees, arcminute, arcsecond);

			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleThreePartDoubleConstructorTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			double doubleDegrees = Convert.ToDouble(item.Angle1);

			Angle target = new Angle(degrees, arcminute, arcsecond);

			Assert.AreEqual(doubleDegrees, (double)target, AngleTests.MathDoubleDelta);
		}
		#endregion

		#region Public Member Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void DegreesTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			int degrees = Convert.ToInt32(item.Degrees);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(degrees, target.Degrees);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ArcminuteTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			int arcMinute = Convert.ToInt32(item.Arcminute);

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(arcMinute, target.Arcminute);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ArcsecondTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal arcSeconds = item.Arcsecond;

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(arcSeconds, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal radians = item.Radians;

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(radians, target.Radians, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansMultipliedTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal radiansMultiplied = item.RadiansMultiplied;
			int multiplier = Convert.ToInt32(item.RandomNumber);

			Angle target = new Angle(decimalDegrees);
			decimal actual = target.RadiansMultiplied(multiplier);

			CustomAssert.AreEqual(radiansMultiplied, actual, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansDividedTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal radiansDivided = item.RadiansDivided;
			int divider = Convert.ToInt32(item.RandomNumber);

			Angle target = new Angle(decimalDegrees);
			decimal actual = target.RadiansDivided(divider);

			CustomAssert.AreEqual(radiansDivided, actual, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TotalArcminutesTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal totalMinutes = item.TotalMinutes;

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(totalMinutes, target.TotalArcminutes, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TotalArcsecondsTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal totalSeconds = item.TotalSeconds;

			Angle target = new Angle(decimalDegrees);
			CustomAssert.AreEqual(totalSeconds, target.TotalArcseconds, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ReduceTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal reduced = item.ReducedDegrees;

			Angle target = new Angle(decimalDegrees);
			target.Reduce();
			Assert.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(reduced, (decimal)target, AngleTests.MathDecimalDelta);
		}
		#endregion

		#region Public Override Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void EqualsTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle target0 = new Angle(decimalDegrees);
			object target1 = new Angle(decimalDegrees + 100);
			bool areNotEqual = !target0.Equals(target1);
			Assert.IsTrue(areNotEqual);

			Angle target2 = new Angle(decimalDegrees);
			object target3 = new Angle(decimalDegrees);
			bool areEqual = target2.Equals(target3);
			Assert.IsTrue(areEqual);
		}

		[Test]
		public void NullEqualsTest()
		{
			Angle target = new Angle();
			object obj = null;
			bool actual = target.Equals(obj);
			Assert.IsFalse(actual);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetHashCodeTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(decimalDegrees.GetHashCode(), target.GetHashCode());
		}
		#endregion

		#region Implicit Conversion Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitAngleToDecimalTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle target = new Angle(decimalDegrees);

			object actual = (decimal)target;
			Assert.IsTrue(actual is decimal);
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitAngleToDoubleTest(TestData item)
		{
			double doubleDegrees = Convert.ToDouble(item.Angle1);
			Angle target = new Angle(doubleDegrees);

			object actual = (double)target;
			Assert.IsTrue(actual is double);
			Assert.AreEqual(doubleDegrees, (double)target, AngleTests.MathDoubleDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitDecimalToAngleTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			object target = (Angle)decimalDegrees;
			Assert.IsTrue(target is Angle);
			CustomAssert.AreEqual(decimalDegrees, (decimal)((Angle)target), AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitDoubleToAngleTest(TestData item)
		{
			double doubleDegrees = Convert.ToDouble(item.Angle1);
			object target = (Angle)doubleDegrees;
			Assert.IsTrue(target is Angle);
			Assert.AreEqual(doubleDegrees, (double)((Angle)target), AngleTests.MathDoubleDelta);
		}
		#endregion

		#region Operator Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void AdditionOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			Angle target = firstAngle + secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue + secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SubtractionOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			Angle target = firstAngle - secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue - secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void MultiplicationOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			Angle target = firstAngle * secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue * secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void DivisionOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			Angle target = firstAngle / secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue / secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ModuloOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			Angle target = firstAngle % secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue % secondAngle.InternalValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void IncrementOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle target = new Angle(decimalDegrees);

			decimal expectedValue = target.InternalValue + 1;
			target++;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void DecrementOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle target = new Angle(decimalDegrees);

			decimal expectedValue = target.InternalValue - 1;
			target--;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void EqualOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle == secondAngle;
			Assert.AreEqual(firstAngle.InternalValue == secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NotEqualOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle != secondAngle;
			Assert.AreEqual(firstAngle.InternalValue != secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GreaterThanOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle > secondAngle;
			Assert.AreEqual(firstAngle.InternalValue > secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GreaterThanOrEqualToOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle >= secondAngle;
			Assert.AreEqual(firstAngle.InternalValue >= secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void LessThanOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle < secondAngle;
			Assert.AreEqual(firstAngle.InternalValue < secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void LessThanOrEqualToOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);
			Angle secondAngle = item.Angle2;

			bool target = firstAngle <= secondAngle;
			Assert.AreEqual(firstAngle.InternalValue <= secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NotOperatorTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			Angle firstAngle = new Angle(decimalDegrees);

			decimal oppositeDirection = item.OppositeDirection;
			Angle secondAngle = new Angle(oppositeDirection);

			Angle target = !firstAngle;

			CustomAssert.AreEqual(secondAngle.InternalValue, target.InternalValue, AngleTests.MathDecimalDelta);
		}
		#endregion

		#region Static Member Tests
		[Test]
		public void EmptyTest()
		{
			Angle target = Angle.Empty;
			Assert.AreEqual(0D, (double)target);
			Assert.AreEqual(0M, (decimal)target);
			Assert.AreEqual(0, target.Degrees);
			Assert.AreEqual(0, target.Arcminute);
			Assert.AreEqual(0M, target.Arcsecond);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToDegreesFromThreePartsTest(TestData item)
		{
			decimal radians = item.Radians;
			decimal expectedValue = item.Angle1;

			decimal actualValue = Angle.ToDegrees(radians);

			CustomAssert.AreEqual(expectedValue, actualValue, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToDegreesFromRadiansTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			decimal decimalDegrees = item.Angle1;

			Angle target = Angle.ToDegrees(degrees, arcminute, arcsecond);
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToRadiansTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal radians = item.Radians;

			decimal target = Angle.ToRadians(decimalDegrees);

			CustomAssert.AreEqual(radians, target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void FromRadiansTest(TestData item)
		{
			decimal radians = item.Radians;
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			decimal decimalDegrees = item.Angle1;

			Angle target = Angle.FromRadians(radians);

			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
			Assert.AreEqual(degrees, target.Degrees);
			Assert.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetDegreesTest(TestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			decimal decimalDegrees = item.Angle1;

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(degrees, Angle.GetDegrees(target));
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetArcminuteTest(TestData item)
		{
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal decimalDegrees = item.Angle1;

			int actual = Angle.GetArcminute(decimalDegrees);
			Assert.AreEqual(arcminute, actual);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetArcsecondTest(TestData item)
		{
			decimal arcsecond = item.Arcsecond;
			decimal decimalDegrees = item.Angle1;

			decimal actual = Angle.GetArcsecond(decimalDegrees);
			CustomAssert.AreEqual(arcsecond, actual, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void StaticReduceTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
			decimal reduced = item.ReducedDegrees;

			Angle target = Angle.Reduce(decimalDegrees);
			Assert.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(reduced, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ParseTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			Angle target = Angle.Parse(decimalDegrees.ToString());
			CustomAssert.AreEqual(decimalDegrees, (decimal)target, AngleTests.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TryParseTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			if (Angle.TryParse(decimalDegrees.ToString(), out Angle target))
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
		[Test]
		[TestCaseSource("TestDataItems")]
		public void InternalValueTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			Angle target = new Angle(decimalDegrees);
			Assert.AreEqual(decimalDegrees, target.InternalValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NormalDirectionDegreesMintesSecondsTest(TestData item)
		{
			int degrees1 = -1 * Math.Abs(Convert.ToInt32(item.Degrees));
			degrees1 = degrees1 == 0 ? degrees1 = -1 : degrees1;
			int minutes1 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(item.Arcsecond);
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref degrees1, ref minutes1, ref seconds1);
			Assert.IsTrue(degrees1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			int degrees2 = Math.Abs(Convert.ToInt32(item.Degrees));
			degrees2 = degrees2 == 0 ? degrees2 = -1 : degrees2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(item.Arcsecond);
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref degrees2, ref minutes2, ref seconds2);
			Assert.IsTrue(degrees2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			int degrees3 = Math.Abs(Convert.ToInt32(item.Degrees));
			degrees3 = degrees3 == 0 ? degrees3 = -1 : degrees3;
			int minutes3 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(item.Arcsecond);
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref degrees3, ref minutes3, ref seconds3);
			Assert.IsTrue(degrees3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NormalDirectionHoursMinutesSecondsTest(TestData item)
		{
			decimal hours1 = -1 * Math.Abs(item.Degrees);
			hours1 = hours1 == 0 ? hours1 = -1 : hours1;
			int minutes1 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(item.Arcsecond);
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref hours1, ref minutes1, ref seconds1);
			Assert.IsTrue(hours1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			decimal hours2 = Math.Abs(item.Degrees);
			hours2 = hours2 == 0 ? hours2 = -1 : hours2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(item.Arcsecond);
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref hours2, ref minutes2, ref seconds2);
			Assert.IsTrue(hours2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			decimal hours3 = Math.Abs(item.Degrees);
			hours3 = hours3 == 0 ? hours3 = -1 : hours3;
			int minutes3 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(item.Arcsecond);
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref hours3, ref minutes3, ref seconds3);
			Assert.IsTrue(hours3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}
		#endregion

		#region Formatter Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToStringTest(TestData item)
		{
			Angle target = new Angle(item.Angle1);
			string actualValue = target.ToString();

			Assert.AreEqual(item.ShortFormat, actualValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToShortFormatTest(TestData item)
		{
			Angle target = new Angle(item.Angle1);
			string actualValue = target.ToShortFormat();

			Assert.AreEqual(item.ShortFormat, actualValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToLongFormatTest(TestData item)
		{
			Angle target = new Angle(item.Angle1);
			string actualValue = target.ToLongFormat();

			Assert.AreEqual(item.LongFormat, actualValue);
		}
		#endregion

		#region IComparable Test
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IComparableTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			Angle target0 = new Angle(decimalDegrees);
			object target1 = new Angle(decimalDegrees + 100);
			int result1 = target0.CompareTo(target1);
			Assert.AreEqual(-1, result1);

			Angle target2 = new Angle(decimalDegrees);
			object target3 = new Angle(decimalDegrees - 100);
			int result2 = target2.CompareTo(target3);
			Assert.AreEqual(1, result2);

			Angle target4 = new Angle(decimalDegrees);
			object target5 = new Angle(decimalDegrees);
			int result3 = target4.CompareTo(target5);
			Assert.AreEqual(0, result3);
		}

		[Test]
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
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IFormattableTest(TestData item)
		{
			Angle target = new Angle(item.Angle1);
			string actualValue = target.ToShortFormat();

			Assert.AreEqual(item.ShortFormat, actualValue);
		}
		#endregion

		#region IComparable<Angle> Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IComparableAngleTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;

			Angle target0 = new Angle(decimalDegrees);
			Angle target1 = new Angle(decimalDegrees + 100);
			int result1 = target0.CompareTo(target1);
			Assert.AreEqual(-1, result1);

			Angle target2 = new Angle(decimalDegrees);
			Angle target3 = new Angle(decimalDegrees - 100);
			int result2 = target2.CompareTo(target3);
			Assert.AreEqual(1, result2);

			Angle target4 = new Angle(decimalDegrees);
			Angle target5 = new Angle(decimalDegrees);
			int result3 = target4.CompareTo(target5);
			Assert.AreEqual(0, result3);
		}

		[Test]
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
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IEquatableTest(TestData item)
		{
			decimal decimalDegrees = item.Angle1;
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