// ***
// *** Solar Calculator 3.1.0
// *** Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	/// <summary>
	/// These tests are to demonstrate the inaccuracy of the Math library in
	/// c# so as to point out why the other tests are not looking for exact
	/// comparisons. In most cases these inaccuracies are negligible and the
	/// library still produces accurate results for regular use. For scientific
	/// usage where a high level of accuracy is required, this library is not 
	/// sufficient due to it's dependency the .NET framework. Math libraries exist
	/// that provide better accuracy. Some of these tests will fail but this is not
	/// an indication that this library is not working.
	/// </summary>
	[TestFixture]
	public class CsharpMathTests
	{
		[Test]
		public void CsharpSquareTest()
		{
			decimal baseNumber = 1.0000001M;
			decimal expectedValue = 674530.47074108455938268917802975M; // 674530.4707M;
			decimal actualValue = baseNumber;

			for (int i = 0; i < 27; i++)
			{
				actualValue = (actualValue * actualValue);
			}

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"Taking the square of the number {baseNumber} 27 times should result in {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpBcdMath1Test()
		{
			decimal expectedValue = 0;
			decimal actualValue = 2M + .2M + .2M + .2M + .2M + .2M - 3M;

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"The result of the equation 2 + .2 + .2 + .2 + .2 + .2 - 3 should be {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpBcdMath2Test()
		{
			decimal expectedValue = 0M;
			decimal actualValue = 2M + (5M * .2M) - 3M;

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"The result of the equation 2 + (5 * .02) - 3 should be {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpLoopIncrementTest()
		{
			decimal expectedValue = 100M;
			decimal actualValue = 0M;

			for (decimal i = 0M; i < 100M; i += .1M)
			{
				actualValue = i;
			}

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"The result of incrementing a counter from 0 to 100 by .1 should result in {expectedValue} after 100 steps. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpOneThirdFractionTest()
		{
			decimal expectedValue = 1M;
			decimal actualValue = 3M * (1M / 3M);

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"The result of the equation 3 * (1/3) should be {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpOneThousanthMultiplicationTest()
		{
			decimal baseValue = .1M;
			int expectedValue = 100;
			int actualValue = (int)(1000 * baseValue);

			int difference = expectedValue - actualValue;

			if (difference != 0)
			{
				Assert.Inconclusive($"The result of the equation 1000 * .1 should be {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpNumberOverUnder10Test()
		{
			decimal a = 100M * (decimal)TestDirector.Rnd.NextDouble();
			decimal b = (a / 10M);
			decimal c = 10M * b;

			decimal expectedValue = 0M;
			decimal actualValue = (a - c);

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive($"The result of b = (a / 10), c = (10 * b) and (a - c) should be {expectedValue} (where a is any number). The actual value ({actualValue}) differs by {difference}.");
			}
		}

		[Test]
		public void CsharpSquareRootTest()
		{
			decimal expectedValue = 0M;
			decimal actualValue = Universal.Math.Sqrt(25M) - 5M;

			decimal difference = expectedValue - actualValue;

			if (difference != 0)
			{
				Assert.Inconclusive($"The result of the equation SQRT(25) - 5 should be {expectedValue}. The actual value ({actualValue}) differs by {difference}.");
			}
		}
	}
}
