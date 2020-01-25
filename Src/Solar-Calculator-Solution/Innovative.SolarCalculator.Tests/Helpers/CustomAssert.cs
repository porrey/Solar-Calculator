// ***
// *** Solar Calculator 3.0.0
// *** Copyright(C) 2013-2020, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU General Public License as published by
// *** the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// *** GNU General Public License for more details.
// *** 
// *** You should have received a copy of the GNU General Public License
// *** along with this program.If not, see<http://www.gnu.org/licenses/>.
// *** 
using System;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	public static class CustomAssert
	{
		public static void AreEqual(decimal expected, decimal actual, decimal delta)
		{
			decimal difference = Math.Abs(expected) - Math.Abs(actual);

			if (difference > delta)
			{
				string message = String.Format("Expected  {0}, Actual = {1}, Difference = {2} which is greater than the delta of {3}", expected, actual, difference, delta);
				Assert.Fail(message);
			}
		}
	}
}
