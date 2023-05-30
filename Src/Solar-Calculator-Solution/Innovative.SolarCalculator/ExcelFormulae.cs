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
	/// Provides methods that mimic functions found in Excel the are either not available
	/// in the .NET framework or have different behavior.
	/// </summary>
	public class ExcelFormulae
	{
		/// <summary>
		/// The DATEVALUE function converts a date that is stored as text to a serial number that Excel recognizes as a date. 
		/// For example, the formula = DATEVALUE("1/1/2008") returns 39448, the serial number of the date 1/1/2008.
		/// Note The serial number returned by the DATEVALUE function can vary from the preceding example, depending 
		/// on your computer's system date settings.
		/// The DATEVALUE function is helpful in cases where a worksheet contains dates in a text format that you want 
		/// to filter, sort, or format as dates, or use in date calculations.
		/// </summary>
		/// <param name="value">A DateTime value that will be converted to the DateValue.</param>
		/// <returns>Gets a value that represents the Excel DateValue for the given DateTime value.</returns>
		public static decimal ToExcelDateValue(DateTime value)
		{
			decimal returnValue = 0;

			if (value.Date <= new DateTime(1900, 1, 1))
			{
				decimal d = value.ToOleAutomationDate();
				decimal c = (decimal)Math.Floor((double)d);
				returnValue = 1M + (d - c);
			}
			else
			{
				returnValue = value.ToOleAutomationDate();
			}

			return returnValue;
		}

		/// <summary>
		/// Gets returns the remainder after a number is divided by a divisor. In Microsoft Excel, the result returned 
		/// by the worksheet MOD function may be different from the result returned by the c# Mod operator. This problem 
		/// occurs if you use the MOD function with either a negative number or a negative divisor, but not both negative.
		/// See http://support.microsoft.com/kb/141178?wa=wsignin1.0 for more information.
		/// </summary>
		/// <param name="number">The numeric value whose remainder you wish to find.</param>
		/// <param name="divisor">The number used to divide the number parameter. If the divisor is 0</param>
		/// <returns></returns>
		public static decimal Mod(decimal number, decimal divisor)
		{
			decimal returnValue = 0M;

			if (divisor != 0M)
			{
				returnValue = number - divisor * (decimal)Math.Floor((double)(number / divisor));
			}
			else
			{
				throw new DivideByZeroException("The value for divisor cannot be zero.");
			}

			return returnValue;
		}
	}
}
