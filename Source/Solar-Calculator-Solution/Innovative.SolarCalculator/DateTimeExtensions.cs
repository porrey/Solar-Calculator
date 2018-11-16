// ***
// *** Copyright (C) 2013-2018, Daniel M. Porrey.  All rights reserved.
// *** Written By Daniel M. Porrey
// ***
// *** This software is provided "AS IS," without a warranty of any kind. ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES, 
// *** INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE OR NON-INFRINGEMENT, ARE HEREBY EXCLUDED. DANIEL M PORREY 
// *** AND ITS LICENSORS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING THIS SOFTWARE 
// *** OR ITS DERIVATIVES. IN NO EVENT WILL DANIEL M PORREY OR ITS LICENSORS BE LIABLE FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR DIRECT, INDIRECT, 
// *** SPECIAL, CONSEQUENTIAL, INCIDENTAL OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING OUT OF THE USE OF 
// *** OR INABILITY TO USE THIS SOFTWARE, EVEN IF DANIEL M PORREY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
// ***
// *** Licensed under Microsoft Reciprocal License (Ms-RL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
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
