// ***
// *** Solar Calculator 3.1.0
// *** Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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
using System;

namespace Innovative.SolarCalculator {
    /// <summary>
    /// Provides methods that mimic functions found in Excel the are either not available
    /// in the .NET framework or have different behavior.
    /// </summary>
    public class ExcelFormulae {
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
        public static double ToExcelDateValue(DateTime value) {
            if (value.Date <= new DateTime(1900, 1, 1)) {
                double d = ToOleAutomationDate(value);
                double c = Math.Floor(d);
                return 1d + (d - c);
            }

            return ToOleAutomationDate(value);
        }

        /// <summary>
        /// An OLE Automation date is implemented as a floating-point number whose integral component is the number of 
        /// days before or after midnight, 30 December 1899, and whose fractional component represents the time on that 
        /// day divided by 24. For example, midnight, 31 December 1899 is represented by 1.0; 6 A.M., 1 January 1900 is 
        /// represented by 2.25; midnight, 29 December 1899 is represented by -1.0; and 6 A.M., 29 December 1899 is 
        /// represented by -1.25. The base OLE Automation Date is midnight, 30 December 1899. The minimum OLE Automation 
        /// date is midnight, 1 January 0100. The maximum OLE Automation Date is the same as DateTime.MaxValue, the last
        /// moment of 31 December 9999. The ToOADate method throws an OverflowException if the current instance represents 
        /// a date that is later than MinValue and earlier than midnight on January1, 0100. However, if the value of the 
        /// current instance is MinValue, the method returns 0.
        /// </summary>
        /// <param name="value">A DateTime value that will be converted to the Ole Automation date.</param>
        /// <returns>Gets a value that represents the Ole Automation date for the given DateTime value.</returns>
        private static double ToOleAutomationDate(DateTime value) => value.Subtract(new DateTime(1899, 12, 30).Date).TotalDays;

        /// <summary>
        /// Gets returns the remainder after a number is divided by a divisor. In Microsoft Excel, the result returned 
        /// by the worksheet MOD function may be different from the result returned by the c# Mod operator. This problem 
        /// occurs if you use the MOD function with either a negative number or a negative divisor, but not both negative.
        /// See http://support.microsoft.com/kb/141178?wa=wsignin1.0 for more information.
        /// </summary>
        /// <param name="number">The numeric value whose remainder you wish to find.</param>
        /// <param name="divisor">The number used to divide the number parameter. If the divisor is 0</param>
        /// <returns></returns>
        public static double Mod(double number, double divisor) {
            if (divisor != 0d) {
                return number - divisor * Math.Floor(number / divisor);
            } else {
                throw new DivideByZeroException("The value for divisor cannot be zero.");
            }
        }
    }
}
