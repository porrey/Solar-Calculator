using System;
using Innovative.SolarCalculator;

namespace Example
{
	class Program
	{
		static void Main(string[] args)
		{
			ShowSunrise();
			ShowSunset();
		}

		public static void ShowSunrise()
		{
			// ***
			// *** Geo coordinates of Oak Street Beach in Chicago, IL
			// ***
			// *** NOTE: the .Date is not necessary but is included to demonstrate that time input 
			// *** does not affect the output. Time will be returned in the current time zone so it 
			// *** will need to be adjusted to the time zone where the coordinates are from (there 
			// *** are services that can be used to get time zone from a latitude and longitude position).
			// ***
			TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
			SolarTimes solarTimes = new SolarTimes(DateTime.Now.Date, 41.9032, -87.6224);
			DateTime sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);

			// ***
			// *** Display the sunrise
			// ***
			Console.WriteLine($"View the sunrise across Lake Michigan from Oak Street Beach in Chicago at {sunrise.ToLongTimeString()} on {sunrise.ToLongDateString()}.");
		}

		public static void ShowSunset()
		{
			// ***
			// *** Geo coordinates of Benton Harbor/Benton Heights in Michigan
			// ***
			TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
			SolarTimes solarTimes = new SolarTimes(DateTime.Now, 42.1543, -86.4459);
			DateTime sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), est);

			// ***
			// *** Display the sunset
			// ***
			Console.WriteLine($"View the sunset across Lake Michigan from Benton Harbor in Michigan at {sunset.ToLongTimeString()} on {sunset.ToLongDateString()}.");
		}
	}
}
