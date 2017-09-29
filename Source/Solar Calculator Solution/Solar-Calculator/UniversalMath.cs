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
