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
