﻿//
// Solar Calculator
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
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
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	public static class CustomAssert
	{
		public delegate void AssertDelegate(string message);

		public static void AreEqual(decimal expected, decimal actual, decimal delta)
		{
			decimal difference = Math.Abs(expected) - Math.Abs(actual);

			if (difference > delta)
			{
				string message = String.Format($"Expected  {expected}, Actual = {actual}, Difference = {difference} which is greater than the delta of {delta}");
				Assert.Fail(message);
			}
		}
	}
}
