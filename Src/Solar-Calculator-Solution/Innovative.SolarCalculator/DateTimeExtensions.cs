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
namespace System
{
	/// <summary>
	/// Provides extensions used to convert date time values used in Excel and Ole Automation.
	/// </summary>
	public static class DateTimeExtensions
	{
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
		public static decimal ToOleAutomationDate(this DateTime value)
		{
			return (decimal)value.Subtract(new DateTime(1899, 12, 30).Date).TotalDays;
		}
	}
}
