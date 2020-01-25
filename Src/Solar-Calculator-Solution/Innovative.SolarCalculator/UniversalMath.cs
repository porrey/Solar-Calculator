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
using System.Collections.Generic;
using System.Text;

namespace Innovative.SolarCalculator
{
	/// <summary>
	/// Provides common .NET static methods that vary between versions.
	/// </summary>
	public static class Universal
	{
		/// <summary>
		/// The Math functions in PORTABLE libraries only accept and return double. All other libraries accept
		/// decimal. The library works in all decimal values. This class provides decimal based Math functions
		/// for all platforms.
		/// </summary>
		public static class Math
		{
			public static decimal Sin(decimal value)
			{
				return (decimal)System.Math.Sin((double)value);
			}

			public static decimal Asin(decimal value)
			{
				return (decimal)System.Math.Asin((double)value);
			}

			public static decimal Tan(decimal value)
			{
				return (decimal)System.Math.Tan((double)value);
			}

			public static decimal Cos(decimal value)
			{
				return (decimal)System.Math.Cos((double)value);
			}

			public static decimal Acos(decimal value)
			{
				return (decimal)System.Math.Acos((double)value);
			}

			public static decimal Sqrt(decimal value)
			{
				return (decimal)System.Math.Sqrt((double)value);
			}
		}
	}
}
