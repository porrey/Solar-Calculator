using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Innovative.SolarCalculator.Tests
{
	public static class CustomAssert
	{
		public static void AreEqual(decimal expected, decimal actual, decimal delta)
		{
			decimal difference = Math.Abs(expected) - Math.Abs(actual);

			if (difference > delta)
			{
				string message = string.Format("Expected  {0}, Actual = {1}, Difference = {2} which is greater than the delta of {3}", expected, actual, difference, delta);
				Assert.Fail(message);
			}
		}
	}
}
