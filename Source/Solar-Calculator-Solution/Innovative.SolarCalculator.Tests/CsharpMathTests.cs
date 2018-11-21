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
			decimal expectedValue = 674530.4707M;
			decimal actualValue = baseNumber;

			for (int i = 0; i < 27; i++)
			{
				actualValue = (actualValue * actualValue);
			}

			decimal difference = expectedValue - actualValue;

			if (difference != 0M)
			{
				Assert.Inconclusive("Taking the square of the number {0} 27 times should result in {1}. The actual value ({2}) differs by {3}.", baseNumber, expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of the equation 2 + .2 + .2 + .2 + .2 + .2 - 3 should be {0}. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of the equation 2 + (5 * .02) - 3 should be {0}. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of incrementing a counter from 0 to 100 by .1 should result in {0} after 100 steps. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of the equation 3 * (1/3) should be {0}. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of the equation 1000 * .1 should be {0}. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of b = (a / 10), c = (10 * b) and (a - c) should be {0} (where a is any number). The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
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
				Assert.Inconclusive("The result of the equation SQRT(25) - 5 should be {0}. The actual value ({1}) differs by {2}.", expectedValue, actualValue, difference);
			}
		}
	}
}
