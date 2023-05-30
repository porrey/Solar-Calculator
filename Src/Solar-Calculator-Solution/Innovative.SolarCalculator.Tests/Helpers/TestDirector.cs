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
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

namespace Innovative.SolarCalculator.Tests
{
	public class TestDirector
	{
		public static Random Rnd = new Random((int)DateTime.Now.Ticks);

		public static IEnumerable<SolarCalculationsTestData> LoadSolarCalculatorTestData()
		{
			IEnumerable<SolarCalculationsTestData> returnValue = null;

			string contents = File.ReadAllText(@"Data/SolarCalculationsTestData.csv");

			//
			//
			//
			returnValue = (from tbl in TestDirector.ParseCsv(contents)
						   select new SolarCalculationsTestData()
						   {
							   Date = DateTime.Parse(tbl["Date"], new CultureInfo("en-US")),
							   Time = DateTime.Parse(tbl["Time"], new CultureInfo("en-US")),
							   TimeZoneOffset = Convert.ToInt32(tbl["TimeZoneOffset"], new CultureInfo("en-US")),
							   Latitude = Convert.ToDecimal(tbl["Latitude"], new CultureInfo("en-US")),
							   Longitude = Convert.ToDecimal(tbl["Longitude"], new CultureInfo("en-US")),
							   JulianDay = Convert.ToDecimal(tbl["JulianDay"], new CultureInfo("en-US")),
							   JulianCentury = Convert.ToDecimal(tbl["JulianCentury"], new CultureInfo("en-US")),
							   GeomMeanLongSun = Convert.ToDecimal(tbl["GeomMeanLongSun"], new CultureInfo("en-US")),
							   GeomMeanAnomSun = Convert.ToDecimal(tbl["GeomMeanAnomSun"], new CultureInfo("en-US")),
							   EccentEarthOrbit = Convert.ToDecimal(tbl["EccentEarthOrbit"], new CultureInfo("en-US")),
							   SunEqofCtr = Convert.ToDecimal(tbl["SunEqofCtr"], new CultureInfo("en-US")),
							   SunTrueLong = Convert.ToDecimal(tbl["SunTrueLong"], new CultureInfo("en-US")),
							   SunAppLong = Convert.ToDecimal(tbl["SunAppLong"], new CultureInfo("en-US")),
							   MeanObliqEcliptic = Convert.ToDecimal(tbl["MeanObliqEcliptic"], new CultureInfo("en-US")),
							   ObliqCorr = Convert.ToDecimal(tbl["ObliqCorr"], new CultureInfo("en-US")),
							   SunDeclin = Convert.ToDecimal(tbl["SunDeclin"], new CultureInfo("en-US")),
							   Vary = Convert.ToDecimal(tbl["vary"], new CultureInfo("en-US")),
							   EqofTime = Convert.ToDecimal(tbl["EqofTime"], new CultureInfo("en-US")),
							   HaSunrise = Convert.ToDecimal(tbl["HaSunrise"], new CultureInfo("en-US")),
							   SolarNoon = DateTime.Parse(tbl["SolarNoon"], new CultureInfo("en-US")),
							   SunriseTime = DateTime.Parse(tbl["SunriseTime"], new CultureInfo("en-US")),
							   SunsetTime = DateTime.Parse(tbl["SunsetTime"], new CultureInfo("en-US")),
							   SunlightDuration = Convert.ToDouble(tbl["SunlightDuration"], new CultureInfo("en-US")),
							   TrueSolarTime = Convert.ToDecimal(tbl["TrueSolarTime"], new CultureInfo("en-US"))
						   }).ToArray();

			return returnValue;
		}

		public static IEnumerable<DateValueTestData> LoadDateValueTestData()
		{
			IEnumerable<DateValueTestData> returnValue = null;

			string contents = File.ReadAllText(@"Data/DateValueTestData.csv");

			//
			//
			//
			returnValue = (from tbl in TestDirector.ParseCsv(contents)
						   select new DateValueTestData()
						   {
							   Date = DateTime.Parse(tbl["Date"], new CultureInfo("en-US")),
							   DateValue = Convert.ToDecimal(tbl["DateValue"], new CultureInfo("en-US"))
						   }).ToArray();

			return returnValue;
		}

		public static IEnumerable<CsharpExcelTestData> LoadCsharpExcelTestData()
		{
			IEnumerable<CsharpExcelTestData> returnValue = null;

			string contents = File.ReadAllText(@"Data/CsharpExcelTestData.csv");

			//
			//
			//
			returnValue = (from tbl in TestDirector.ParseCsv(contents)
						   select new CsharpExcelTestData()
						   {
							   Value1 = Convert.ToDecimal(tbl["Value1"], new CultureInfo("en-US")),
							   Value2 = Convert.ToDecimal(tbl["Value2"], new CultureInfo("en-US")),
							   Value3 = Convert.ToDecimal(tbl["Value3"], new CultureInfo("en-US")),
							   Radians = Convert.ToDecimal(tbl["Radians"], new CultureInfo("en-US")),
							   Degrees = Convert.ToDecimal(tbl["Degrees"], new CultureInfo("en-US")),
							   Mod = Convert.ToDecimal(tbl["Mod"], new CultureInfo("en-US")),
							   Sin = Convert.ToDecimal(tbl["Sin"], new CultureInfo("en-US")),
							   Asin = Convert.ToDecimal(tbl["Asin"], new CultureInfo("en-US")),
							   Cos = Convert.ToDecimal(tbl["Cos"], new CultureInfo("en-US")),
							   Acos = Convert.ToDecimal(tbl["Acos"], new CultureInfo("en-US")),
							   Tan = Convert.ToDecimal(tbl["Tan"], new CultureInfo("en-US"))
						   }).ToArray();

			return returnValue;
		}

		public static IEnumerable<AngleTestData> LoadAngleTestData()
		{
			IEnumerable<AngleTestData> returnValue = null;

			string contents = File.ReadAllText(@"Data/AngleTestData.csv");

			//
			//
			//
			returnValue = (from tbl in TestDirector.ParseCsv(contents)
						   select new AngleTestData()
						   {
							   Angle = Convert.ToDecimal(tbl["Angle2"], new CultureInfo("en-US")),
							   Radians = Convert.ToDecimal(tbl["Radians"], new CultureInfo("en-US")),
							   Degrees = Convert.ToDecimal(tbl["Degrees"], new CultureInfo("en-US")),
							   DecimalMinutes = Convert.ToDecimal(tbl["DecimalMinutes"], new CultureInfo("en-US")),
							   Arcminute = Convert.ToDecimal(tbl["Arcminute"], new CultureInfo("en-US")),
							   Arcsecond = Convert.ToDecimal(tbl["Arcsecond"], new CultureInfo("en-US")),
							   LongFormat = tbl["LongFormat"],
							   ShortFormat = tbl["ShortFormat"],
							   RandomNumber = Convert.ToDecimal(tbl["RandomNumber"], new CultureInfo("en-US")),
							   RadiansMultiplied = Convert.ToDecimal(tbl["RadiansMultiplied"], new CultureInfo("en-US")),
							   RadiansDivided = Convert.ToDecimal(tbl["RadiansDivided"], new CultureInfo("en-US")),
							   ReducedDegrees = Convert.ToDecimal(tbl["ReducedDegrees"], new CultureInfo("en-US")),
							   TotalMinutes = Convert.ToDecimal(tbl["TotalMinutes"], new CultureInfo("en-US")),
							   TotalSeconds = Convert.ToDecimal(tbl["TotalSeconds"], new CultureInfo("en-US")),
							   OppositeDirection = Convert.ToDecimal(tbl["OppositeDirection"], new CultureInfo("en-US"))
						   }).ToArray();

			return returnValue;
		}

		/// <summary>
		/// Creates a SolarTimes instance for use in tests from an instance
		/// of SolarCalculatorTestData.
		/// </summary>
		public static SolarTimes SolarTimesInstance(SolarCalculationsTestData item)
		{
			SolarTimes returnValue = null;

			TimeSpan tzOffset = TimeSpan.FromHours(item.TimeZoneOffset);

			returnValue = new SolarTimes()
			{
				Latitude = Convert.ToDouble(item.Latitude),
				Longitude = Convert.ToDouble(item.Longitude),
				ForDate = new DateTimeOffset(item.Date.Add(item.Time.TimeOfDay), tzOffset)
			};

			return returnValue;
		}

		public static IList<Dictionary<string, string>> ParseCsv(string contents)
		{
			IList<Dictionary<string, string>> returnValue = new List<Dictionary<string, string>>();

			//
			// Get the test data file from the resources and
			// separate it into multiple lines.
			//
			string[] lines = contents.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

			//
			// Filter out invalid data. The spreadsheet uses random data to generate certain field values
			// and it may contain invalid data. The line of data is cast into an string array. The first
			// row contains the column names.
			//
			IEnumerable<string[]> items = from tbl1 in lines
										  where !tbl1.Contains("#")
										  select tbl1.Split(new char[] { ',' });

			//
			// Get the column headers and data rows into two separate sets.
			//
			string[] columnHeaders = items.First();
			string[][] rows = items.Skip(1).ToArray();

			//
			//
			//
			for (int i = 0; i < rows.Count(); i++)
			{
				Dictionary<string, string> row = new Dictionary<string, string>();

				for (int j = 0; j < columnHeaders.Count(); j++)
				{
					row.Add(columnHeaders[j], rows[i][j]);
				}

				returnValue.Add(row);
			}

			return returnValue;
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for Excel comparison tests.
		/// </summary>
		public static decimal ExcelDecimalDelta
		{
			get
			{
				//   12345678901234567890
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
				//   12345678901234567890
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
				//   12345678901234567890
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
				//
				// The maximum difference allowed is 500 milliseconds
				//
				return TimeSpan.FromMilliseconds(500);
			}
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type decimal
		/// for math comparison tests.
		/// </summary>		
		public static decimal MathDecimalDelta
		{
			get
			{
				//
				//   123456789012
				return 0.0000001M;
			}
		}

		/// <summary>
		/// Specifies the precision when comparing data values of type double
		/// for math comparison tests.
		/// </summary>		
		public static double MathDoubleDelta
		{
			get
			{
				//
				//   123456789012
				return 0.0000001D;
			}
		}

		/// <summary>
		/// Converts an Angle to Radians during tests.
		/// </summary>
		/// <param name="angle">The angle in degrees.</param>
		/// <returns>The angle in radians.</returns>
		public static decimal ToRadians(decimal angle)
		{
			return (decimal)Math.PI * angle / 180M;
		}
	}
}
