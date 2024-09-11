//
// Solar Calculator
// Copyright(C) 2013-2023, Daniel M. Porrey. All rights reserved.
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
using Innovative.Geometry;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class AngleTests
	{
		//
		// Create random test data.
		//
		static readonly IEnumerable<AngleTestData> TestDataItems = TestDirector.LoadAngleTestData();

		#region Constructor Tests
		[Test]
		public void AngleEmptyConstructorTest()
		{
			Angle target = new Angle();
			Assert2.AreEqual(0D, (double)target);
			Assert2.AreEqual(0M, (decimal)target);
			Assert2.AreEqual(0, target.Degrees);
			Assert2.AreEqual(0, target.Arcminute);
			Assert2.AreEqual(0M, target.Arcsecond);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleIntegerConstructorTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Angle);
			Angle target = new Angle(degrees);
			Assert2.AreEqual(degrees, target.Degrees);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleDecimalConstructorTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);

			Angle target = new Angle(item.Angle);

			Assert2.AreEqual(degrees, target.Degrees);
			Assert2.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(item.Arcsecond, target.Arcsecond, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleDoubleConstructorTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			double doubleDegrees = Convert.ToDouble(item.Angle);

			Angle target = new Angle(doubleDegrees);

			Assert2.AreEqual(degrees, target.Degrees);
			Assert2.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(item.Arcsecond, target.Arcsecond, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleThreePartDecimalConstructorTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);

			Angle target = new Angle(degrees, arcminute, item.Arcsecond);

			CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void AngleThreePartDoubleConstructorTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			double doubleDegrees = Convert.ToDouble(item.Angle);

			Angle target = new Angle(degrees, arcminute, item.Arcsecond);

			Assert2.AreEqual(doubleDegrees, (double)target, TestDirector.MathDoubleDelta);
		}
		#endregion

		#region Public Member Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void DegreesTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);

			Angle target = new Angle(item.Angle);
			Assert2.AreEqual(degrees, target.Degrees);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ArcminuteTest(AngleTestData item)
		{
			int arcMinute = Convert.ToInt32(item.Arcminute);

			Angle target = new Angle(item.Angle);
			Assert2.AreEqual(arcMinute, target.Arcminute);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ArcsecondTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			CustomAssert.AreEqual(item.Arcsecond, target.Arcsecond, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			CustomAssert.AreEqual(item.Radians, target.Radians, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansMultipliedTest(AngleTestData item)
		{
			decimal radiansMultiplied = item.RadiansMultiplied;
			int multiplier = Convert.ToInt32(item.RandomNumber);

			Angle target = new Angle(item.Angle);
			decimal actual = target.RadiansMultiplied(multiplier);

			CustomAssert.AreEqual(radiansMultiplied, actual, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void RadiansDividedTest(AngleTestData item)
		{
			decimal radiansDivided = item.RadiansDivided;
			int divider = Convert.ToInt32(item.RandomNumber);

			Angle target = new Angle(item.Angle);
			decimal actual = target.RadiansDivided(divider);

			CustomAssert.AreEqual(radiansDivided, actual, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TotalArcminutesTest(AngleTestData item)
		{
			decimal totalMinutes = item.TotalMinutes;

			Angle target = new Angle(item.Angle);
			CustomAssert.AreEqual(totalMinutes, target.TotalArcminutes, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TotalArcsecondsTest(AngleTestData item)
		{
			decimal totalSeconds = item.TotalSeconds;

			Angle target = new Angle(item.Angle);
			CustomAssert.AreEqual(totalSeconds, target.TotalArcseconds, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ReduceTest(AngleTestData item)
		{
			decimal reduced = item.ReducedDegrees;

			Angle target = new Angle(item.Angle);
			target.Reduce();
			Assert2.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(reduced, (decimal)target, TestDirector.MathDecimalDelta);
		}
		#endregion

		#region Public Override Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void EqualsTest(AngleTestData item)
		{
			Angle target0 = new Angle(item.Angle);
			object target1 = new Angle(item.Angle + 100);
			bool areNotEqual = !target0.Equals(target1);
			Assert2.IsTrue(areNotEqual);

			Angle target2 = new Angle(item.Angle);
			object target3 = new Angle(item.Angle);
			bool areEqual = target2.Equals(target3);
			Assert2.IsTrue(areEqual);
		}

		[Test]
		public void NullEqualsTest()
		{
			Angle target = new Angle();
			object obj = null;
			bool actual = target.Equals(obj);
			Assert2.IsFalse(actual);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetHashCodeTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			Assert2.AreEqual(item.Angle.GetHashCode(), target.GetHashCode());
		}
		#endregion

		#region Implicit Conversion Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitAngleToDecimalTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);

			object actual = (decimal)target;
			Assert2.IsTrue(actual is decimal);
			CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitAngleToDoubleTest(AngleTestData item)
		{
			double doubleDegrees = Convert.ToDouble(item.Angle);
			Angle target = new Angle(doubleDegrees);

			object actual = (double)target;
			Assert2.IsTrue(actual is double);
			Assert2.AreEqual(doubleDegrees, (double)target, TestDirector.MathDoubleDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitDecimalToAngleTest(AngleTestData item)
		{
			object target = (Angle)item.Angle;
			Assert2.IsTrue(target is Angle);
			CustomAssert.AreEqual(item.Angle, (decimal)((Angle)target), TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ImplicitDoubleToAngleTest(AngleTestData item)
		{
			double doubleDegrees = Convert.ToDouble(item.Angle);
			object target = (Angle)doubleDegrees;
			Assert2.IsTrue(target is Angle);
			Assert2.AreEqual(doubleDegrees, (double)((Angle)target), TestDirector.MathDoubleDelta);
		}
		#endregion

		#region Operator Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void AdditionOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			Angle target = firstAngle + secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue + secondAngle.InternalValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void SubtractionOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			Angle target = firstAngle - secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue - secondAngle.InternalValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void MultiplicationOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			Angle target = firstAngle * secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue * secondAngle.InternalValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void DivisionOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			Angle target = firstAngle / secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue / secondAngle.InternalValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ModuloOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			Angle target = firstAngle % secondAngle;
			CustomAssert.AreEqual(firstAngle.InternalValue % secondAngle.InternalValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void IncrementOperatorTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);

			decimal expectedValue = target.InternalValue + 1;
			target++;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void DecrementOperatorTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);

			decimal expectedValue = target.InternalValue - 1;
			target--;

			CustomAssert.AreEqual(expectedValue, (decimal)target.InternalValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void EqualOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle == secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue == secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NotEqualOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle != secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue != secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GreaterThanOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle > secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue > secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GreaterThanOrEqualToOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle >= secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue >= secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void LessThanOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle < secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue < secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void LessThanOrEqualToOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);
			Angle secondAngle = item.Angle;

			bool target = firstAngle <= secondAngle;
			Assert2.AreEqual(firstAngle.InternalValue <= secondAngle.InternalValue, target);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NotOperatorTest(AngleTestData item)
		{
			Angle firstAngle = new Angle(item.Angle);

			decimal oppositeDirection = item.OppositeDirection;
			Angle secondAngle = new Angle(oppositeDirection);

			Angle target = !firstAngle;

			CustomAssert.AreEqual(secondAngle.InternalValue, target.InternalValue, TestDirector.MathDecimalDelta);
		}
		#endregion

		#region Static Member Tests
		[Test]
		public void EmptyTest()
		{
			Angle target = Angle.Empty;
			Assert2.AreEqual(0D, (double)target);
			Assert2.AreEqual(0M, (decimal)target);
			Assert2.AreEqual(0, target.Degrees);
			Assert2.AreEqual(0, target.Arcminute);
			Assert2.AreEqual(0M, target.Arcsecond);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToDegreesFromThreePartsTest(AngleTestData item)
		{
			decimal radians = item.Radians;
			decimal expectedValue = item.Angle;

			decimal actualValue = Angle.ToDegrees(radians);

			CustomAssert.AreEqual(expectedValue, actualValue, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToDegreesFromRadiansTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			

			Angle target = Angle.ToDegrees(degrees, arcminute, arcsecond);
			CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToRadiansTest(AngleTestData item)
		{
			decimal radians = item.Radians;
			decimal target = Angle.ToRadians(item.Angle);

			CustomAssert.AreEqual(radians, target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void FromRadiansTest(AngleTestData item)
		{
			decimal radians = item.Radians;
			int degrees = Convert.ToInt32(item.Degrees);
			int arcminute = Convert.ToInt32(item.Arcminute);
			decimal arcsecond = item.Arcsecond;
			
			Angle target = Angle.FromRadians(radians);

			CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
			Assert2.AreEqual(degrees, target.Degrees);
			Assert2.AreEqual(arcminute, target.Arcminute);
			CustomAssert.AreEqual(arcsecond, target.Arcsecond, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetDegreesTest(AngleTestData item)
		{
			int degrees = Convert.ToInt32(item.Degrees);
			
			Angle target = new Angle(item.Angle);
			Assert2.AreEqual(degrees, Angle.GetDegrees(target));
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetArcminuteTest(AngleTestData item)
		{
			int arcminute = Convert.ToInt32(item.Arcminute);

			int actual = Angle.GetArcminute(item.Angle);
			Assert2.AreEqual(arcminute, actual);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void GetArcsecondTest(AngleTestData item)
		{
			decimal actual = Angle.GetArcsecond(item.Angle);
			CustomAssert.AreEqual(item.Arcsecond, actual, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void StaticReduceTest(AngleTestData item)
		{
			Angle target = Angle.Reduce(item.Angle);
			Assert2.IsTrue(target.Degrees <= 360);
			CustomAssert.AreEqual(item.ReducedDegrees, (decimal)target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ParseTest(AngleTestData item)
		{
			Angle target = Angle.Parse(item.Angle.ToString());
			CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void TryParseTest(AngleTestData item)
		{
			if (Angle.TryParse(item.Angle.ToString(), out Angle target))
			{
				CustomAssert.AreEqual(item.Angle, (decimal)target, TestDirector.MathDecimalDelta);
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
		public void InternalValueTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			Assert2.AreEqual(item.Angle, target.InternalValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NormalDirectionDegreesMintesSecondsTest(AngleTestData item)
		{
			int degrees1 = -1 * Math.Abs(Convert.ToInt32(item.Degrees));
			degrees1 = degrees1 == 0 ? degrees1 = -1 : degrees1;
			int minutes1 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(item.Arcsecond);
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref degrees1, ref minutes1, ref seconds1);
			Assert2.IsTrue(degrees1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			int degrees2 = Math.Abs(Convert.ToInt32(item.Degrees));
			degrees2 = degrees2 == 0 ? degrees2 = -1 : degrees2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(item.Arcsecond);
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref degrees2, ref minutes2, ref seconds2);
			Assert2.IsTrue(degrees2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			int degrees3 = Math.Abs(Convert.ToInt32(item.Degrees));
			degrees3 = degrees3 == 0 ? degrees3 = -1 : degrees3;
			int minutes3 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(item.Arcsecond);
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref degrees3, ref minutes3, ref seconds3);
			Assert2.IsTrue(degrees3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void NormalDirectionHoursMinutesSecondsTest(AngleTestData item)
		{
			decimal hours1 = -1 * Math.Abs(item.Degrees);
			hours1 = hours1 == 0 ? hours1 = -1 : hours1;
			int minutes1 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes1 = minutes1 == 0 ? minutes1 = -1 : minutes1;
			decimal seconds1 = Math.Abs(item.Arcsecond);
			seconds1 = seconds1 == 0 ? seconds1 = -1 : seconds1;
			Angle.NormalDirection(ref hours1, ref minutes1, ref seconds1);
			Assert2.IsTrue(hours1 <= 0 && minutes1 <= 0 && seconds1 <= 0);

			decimal hours2 = Math.Abs(item.Degrees);
			hours2 = hours2 == 0 ? hours2 = -1 : hours2;
			int minutes2 = -1 * Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes2 = minutes2 == 0 ? minutes2 = -1 : minutes2;
			decimal seconds2 = Math.Abs(item.Arcsecond);
			seconds2 = seconds2 == 0 ? seconds2 = -1 : seconds2;
			Angle.NormalDirection(ref hours2, ref minutes2, ref seconds2);
			Assert2.IsTrue(hours2 <= 0 && minutes2 <= 0 && seconds2 <= 0);

			decimal hours3 = Math.Abs(item.Degrees);
			hours3 = hours3 == 0 ? hours3 = -1 : hours3;
			int minutes3 = Math.Abs(Convert.ToInt32(item.Arcminute));
			minutes3 = minutes3 == 0 ? minutes3 = -1 : minutes3;
			decimal seconds3 = -1 * Math.Abs(item.Arcsecond);
			seconds3 = seconds3 == 0 ? seconds3 = -1 : seconds3;
			Angle.NormalDirection(ref hours3, ref minutes3, ref seconds3);
			Assert2.IsTrue(hours3 <= 0 && minutes3 <= 0 && seconds3 <= 0);
		}
		#endregion

		#region Formatter Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToStringTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			string actualValue = target.ToString();

			Assert2.AreEqual(item.ShortFormat, actualValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToShortFormatTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			string actualValue = target.ToShortFormat();

			Assert2.AreEqual(item.ShortFormat, actualValue);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ToLongFormatTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			string actualValue = target.ToLongFormat();

			Assert2.AreEqual(item.LongFormat, actualValue);
		}
		#endregion

		#region IComparable Test
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IComparableTest(AngleTestData item)
		{
			Angle target0 = new Angle(item.Angle);
			object target1 = new Angle(item.Angle + 100);
			int result1 = target0.CompareTo(target1);
			Assert2.AreEqual(-1, result1);

			Angle target2 = new Angle(item.Angle);
			object target3 = new Angle(item.Angle - 100);
			int result2 = target2.CompareTo(target3);
			Assert2.AreEqual(1, result2);

			Angle target4 = new Angle(item.Angle);
			object target5 = new Angle(item.Angle);
			int result3 = target4.CompareTo(target5);
			Assert2.AreEqual(0, result3);
		}

		[Test]
		public void NullIComparableTest()
		{
			Angle target = new Angle();
			object obj = null;
			int expected = 1;
			int actual;
			actual = target.CompareTo(obj);
			Assert2.AreEqual(expected, actual);
		}
		#endregion

		#region IFormattable Test
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IFormattableTest(AngleTestData item)
		{
			Angle target = new Angle(item.Angle);
			string actualValue = target.ToShortFormat();

			Assert2.AreEqual(item.ShortFormat, actualValue);
		}
		#endregion

		#region IComparable<Angle> Tests
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IComparableAngleTest(AngleTestData item)
		{
			Angle target0 = new Angle(item.Angle);
			Angle target1 = new Angle(item.Angle + 100);
			int result1 = target0.CompareTo(target1);
			Assert2.AreEqual(-1, result1);

			Angle target2 = new Angle(item.Angle);
			Angle target3 = new Angle(item.Angle - 100);
			int result2 = target2.CompareTo(target3);
			Assert2.AreEqual(1, result2);

			Angle target4 = new Angle(item.Angle);
			Angle target5 = new Angle(item.Angle);
			int result3 = target4.CompareTo(target5);
			Assert2.AreEqual(0, result3);
		}

		[Test]
		public void NullIComparableAngleTest()
		{
			Angle target = new Angle();
			Angle other = null;
			int expected = 1;
			int actual;
			actual = target.CompareTo(other);
			Assert2.AreEqual(expected, actual);
		}
		#endregion

		#region IEquatable<Angle> Test
		[Test]
		[TestCaseSource("TestDataItems")]
		public void IEquatableTest(AngleTestData item)
		{
			Angle target0 = new Angle(item.Angle);
			Angle target1 = new Angle(item.Angle + 100);
			bool areNotEqual = !target0.Equals(target1);
			Assert2.IsTrue(areNotEqual);

			Angle target2 = new Angle(item.Angle);
			Angle target3 = new Angle(item.Angle);
			bool areEqual = target2.Equals(target3);
			Assert2.IsTrue(areEqual);
		}
		#endregion
	}
}