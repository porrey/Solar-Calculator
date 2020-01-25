[![Build Status](https://img.shields.io/travis/porrey/Solar-Calculator/master?style=for-the-badge)](https://travis-ci.com/porrey/Solar-Calculator)

[![Nuget](https://img.shields.io/nuget/v/Angle?label=Angle%20-%20NuGet&style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/Angle?label=Downloads&style=for-the-badge)](https://www.nuget.org/packages/Angle/)

[![Nuget](https://img.shields.io/nuget/v/SolarCalculator?label=Solar%20Calculator%20-%20NuGet&style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/SolarCalculator?label=Downloads&style=for-the-badge)](https://www.nuget.org/packages/SolarCalculator/)

# Solar-Calculator #
Calculates the sunrise and sunset for a given date and location (using GEO coordinates). This library uses the method outlined NOAA Solar Calculations Day spreadsheet found at http://www.esrl.noaa.gov/gmd/grad/solcalc/calcdetails.html.

# Installing #
Add this to your project in Visual Studio using NuGet Package Manager UI and ID **SolarCalculator** or using the Package Manager Console.

    PM> Install-Package SolarCalculator

# Sample Code #

The sample code below shows how to initialize and call the Solar Calculator to get the sunrise and sunset for the given location.

## Sunrise in Chicago ##

    using System;
    using Innovative.SolarCalculator;
    
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

## Sunset in Michigan ##

    // ***
    // *** Geo coordinates of Benton Harbor/Benton Heights in Michigan
    // ***
    TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");              
    SolarTimes solarTimes = new SolarTimes(DateTime.Now, 42.1543, -86.4459);
    DateTime sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), est);
    
    // ***
    // *** Display the sunset
    // ***
    Console.WriteLine($"View the sunset across Lake Michigan from Benton Harbor in Michigan at {sunset.ToLongTimeString()} on {sunset.ToLongDateString()}.");
