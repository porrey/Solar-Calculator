// ***
// *** Solar Calculator 3.0.0
// *** Copyright(C) 2013-2020, Daniel M. Porrey. All rights reserved.
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
			/// <summary>
			/// Returns the sine of the specified angle.
			/// </summary>
			/// <param name="value">An angle, measured in radians.</param>
			/// <returns>The sine of value.</returns>
			public static decimal Sin(decimal value)
			{
				return (decimal)System.Math.Sin((double)value);
			}

			/// <summary>
			/// Returns the angle whose sine is the specified number.
			/// </summary>
			/// <param name="value">A number representing a sine, where value must be greater
			/// than or equal to -1, but less than or equal to 1.</param>
			/// <returns>An angle, θ, measured in radians.</returns>
			public static decimal Asin(decimal value)
			{
				return (decimal)System.Math.Asin((double)value);
			}

			/// <summary>
			/// Returns the tangent of the specified angle.
			/// </summary>
			/// <param name="value">An angle, measured in radians.</param>
			/// <returns>The tangent of value.</returns>
			public static decimal Tan(decimal value)
			{
				return (decimal)System.Math.Tan((double)value);
			}

			/// <summary>
			/// Returns the cosine of the specified angle.
			/// </summary>
			/// <param name="value">An angle, measured in radians.</param>
			/// <returns>The cosine of value.</returns>
			public static decimal Cos(decimal value)
			{
				return (decimal)System.Math.Cos((double)value);
			}

			/// <summary>
			/// Returns the angle whose cosine is the specified number.
			/// </summary>
			/// <param name="value">A number representing a cosine, where value must be greater than or equal to -1,
			/// but less than or equal to 1.</param>
			/// <returns>An angle, θ, measured in radians.</returns>
			public static decimal Acos(decimal value)
			{
				return (decimal)System.Math.Acos((double)value);
			}

			/// <summary>
			/// Returns the square root of a specified number.
			/// </summary>
			/// <param name="value">The number whose square root is to be found.</param>
			/// <returns>The positive square root of value.</returns>
			public static decimal Sqrt(decimal value)
			{
				return (decimal)System.Math.Sqrt((double)value);
			}
		}
	}
}
