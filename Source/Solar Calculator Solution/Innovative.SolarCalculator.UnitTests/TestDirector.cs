// ***
// *** Copyright (C) 2013, Daniel M. Porrey.  All rights reserved.
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
// *** do not use the software. Full license details can be found at https://solarcalculator.codeplex.com/license.
// ***
using System;
using System.Data;

namespace Innovative.SolarCalculator.Tests
{
	public class TestDirector
	{
		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for Excel comparison tests.
		/// </summary>
		public static decimal ExcelDecimalDelta
		{
			get
			{
				// ***   12345678901234567890
				return 0.000000000001M;
			}
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for solar comparison tests.
		/// </summary>
		public static decimal SolarDecimalDelta
		{
			get
			{
				// ***   12345678901234567890
				return 0.000000009M;
			}
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for solar comparison tests.
		/// </summary>
		public static decimal CSharpExcelDecimalDelta
		{
			get
			{
				// ***   12345678901234567890
				return 0.000000001M;
			}
		}

		/// <summary>
		/// Specifies the number of seconds allowed for variation in a
		/// TimeSpan comparison test.
		/// </summary>
		public static TimeSpan TimeSpanDelta
		{
			get
			{
				// ***
				// *** The maximum difference allowed is 500 milliseconds
				// ***
				return TimeSpan.FromMilliseconds(500);
			}
		}

		/// <summary>
		/// Creates a SolarTimes instance for use in tests.
		/// </summary>
		public static SolarTimes SolarTimesInstance(DataRow dataRow)
		{
			SolarTimes returnValue = null;

			if (dataRow.Table.Columns.Contains("Date") &&
				dataRow.Table.Columns.Contains("Time") &&
				dataRow.Table.Columns.Contains("TimeZoneOffset") &&
				dataRow.Table.Columns.Contains("Latitude") &&
				dataRow.Table.Columns.Contains("Longitude"))
			{
				DateTime date = Convert.ToDateTime(dataRow["Date"]);
				DateTime time = Convert.ToDateTime(dataRow["Time"]);
				TimeSpan tzOffset = TimeSpan.FromHours(Convert.ToInt32(dataRow["TimeZoneOffset"]));

				returnValue = new SolarTimes()
				{
					Latitude = Convert.ToDouble(dataRow["Latitude"]),
					Longitude = Convert.ToDouble(dataRow["Longitude"]),
					ForDate = new DateTimeOffset(date.Add(time.TimeOfDay), tzOffset)
				};
			}
			else
			{
				throw new Exception("The DatRow used to create the SolarTimes instance does not contain the necessary columns.");
			}

			return returnValue;
		}
	}
}
