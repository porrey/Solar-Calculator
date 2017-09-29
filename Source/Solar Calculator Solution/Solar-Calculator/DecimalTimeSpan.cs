using System;
using System.Collections.Generic;
using System.Text;

namespace Innovative.SolarCalculator
{
	/// <summary>
	/// Provides decimal versions of common TimeSpan methods to make
	/// the code in the library look cleaner and ensure consistency.
	/// </summary>
	public static class DecimalTimeSpan
	{
		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of days, where
		/// the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of days, accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromDays(decimal value)
		{
			return System.TimeSpan.FromDays((double)value);
		}

		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of hours, where
		/// the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of hours accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromHours(decimal value)
		{
			return System.TimeSpan.FromHours((double)value);
		}

		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of minutes,
		/// where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of minutes, accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromMinutes(decimal value)
		{
			return System.TimeSpan.FromMinutes((double)value);
		}
	}
}
