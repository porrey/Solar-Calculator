![GitHub Workflow Status (with branch)](https://img.shields.io/github/actions/workflow/status/porrey/Solar-Calculator/.github/workflows/dotnet.yml?style=for-the-badge)

[![Nuget](https://img.shields.io/nuget/v/Angle?label=Angle%20-%20NuGet&style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/Angle?label=Downloads&style=for-the-badge)](https://www.nuget.org/packages/Angle/)

[![Nuget](https://img.shields.io/nuget/v/SolarCalculator?label=Solar%20Calculator%20-%20NuGet&style=for-the-badge)
![Nuget](https://img.shields.io/nuget/dt/SolarCalculator?label=Downloads&style=for-the-badge)](https://www.nuget.org/packages/SolarCalculator/)

# Solar Calculator

A .NET library that calculates solar events — sunrise, sunset, dawn, dusk, solar noon, and more — for any date and geographic location. The implementation is a faithful C# port of the [NOAA Solar Calculations Day spreadsheet](http://www.esrl.noaa.gov/gmd/grad/solcalc/calcdetails.html), whose formulas are drawn from *Astronomical Algorithms* by Jean Meeus.

## Packages

Two NuGet packages are published from this repository:

| Package | NuGet ID | Description |
|---|---|---|
| Solar Calculator | [`SolarCalculator`](https://www.nuget.org/packages/SolarCalculator/) | Sunrise, sunset, and all related solar time calculations |
| Angle | [`Angle`](https://www.nuget.org/packages/Angle/) | General-purpose geometric angle value type (also used internally by SolarCalculator) |

## Installing

Add the package to your project via the NuGet Package Manager UI or the Package Manager Console:

```
PM> Install-Package SolarCalculator
```

Or with the .NET CLI:

```
dotnet add package SolarCalculator
```

To use the `Angle` type independently:

```
PM> Install-Package Angle
```

## Quick Start

```csharp
using System;
using Innovative.SolarCalculator;

// Geo coordinates of Oak Street Beach in Chicago, IL
TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
SolarTimes solarTimes = new SolarTimes(DateTime.Now.Date, cst, 41.9032, -87.6224);

DateTime sunrise = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), cst);
DateTime sunset  = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), cst);

Console.WriteLine($"Sunrise: {sunrise.ToLongTimeString()}");
Console.WriteLine($"Sunset:  {sunset.ToLongTimeString()}");
```

## Solar Events

`SolarTimes` exposes eight solar-event properties, all returned as `DateTime` in local time:

| Property | Description | Sun angle |
|---|---|---|
| `DawnAstronomical` | Astronomical dawn | 18° below horizon |
| `DawnNautical` | Nautical dawn | 12° below horizon |
| `DawnCivil` | Civil dawn | 6° below horizon |
| `Sunrise` | Sunrise | At horizon (with atmospheric refraction) |
| `Sunset` | Sunset | At horizon (with atmospheric refraction) |
| `DuskCivil` | Civil dusk | 6° below horizon |
| `DuskNautical` | Nautical dusk | 12° below horizon |
| `DuskAstronomical` | Astronomical dusk | 18° below horizon |

Additional time properties:

| Property | Type | Description |
|---|---|---|
| `SolarNoon` | `DateTime` | Time when the sun reaches its highest point |
| `SunlightDuration` | `TimeSpan` | Total duration of sunlight for the day |

## Constructors

`SolarTimes` provides several constructors to suit different scenarios:

```csharp
// Default — uses DateTime.Now and default (zero) coordinates
var st = new SolarTimes();

// Date only (set Latitude/Longitude properties separately)
var st = new SolarTimes(DateTimeOffset.Now);

// Date + coordinates (UTC offset comes from the DateTimeOffset)
var st = new SolarTimes(DateTimeOffset.Now, latitude, longitude);

// Date + explicit UTC offset in hours + coordinates (e.g. -6.0 for CST)
var st = new SolarTimes(DateTime.Now, -6.0, latitude, longitude);

// Date + TimeZoneInfo + coordinates  ← recommended for DST-safe results
var st = new SolarTimes(DateTime.Now, TimeZoneInfo.Local, latitude, longitude);
```

Latitude and longitude can be supplied as `double`, `decimal`, or `Angle` values. Latitude must be in the range **−90° to +90°** and longitude in the range **−180° to +180°** (east is positive).

## Time Zone and DST Handling

Solar times are calculated using the UTC offset embedded in the `ForDate` property. When you supply a `DateTime` directly (without an offset), the library derives the UTC offset from the `TimeZoneInfo` you provide, using noon of the calendar day. This avoids the common pitfall of capturing the wrong offset on Daylight Saving Time transition days, where midnight and noon can have different offsets.

```csharp
// Safe on DST transition days
TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
SolarTimes solarTimes = new SolarTimes(DateTime.Now.Date, tz, 41.9032, -87.6224);
```

The returned `DateTime` values are in local time as determined by the running machine. Use `TimeZoneInfo.ConvertTimeFromUtc` to convert to the time zone of the coordinates:

```csharp
DateTime sunriseLocal = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunrise.ToUniversalTime(), tz);
```

## Polar Day and Polar Night

In arctic and antarctic regions, the sun may never set (Polar Day) or never rise (Polar Night). Check these conditions before using `Sunrise` and `Sunset`:

| Property | Type | Description |
|---|---|---|
| `IsPolarDay` | `bool` | `true` when the sun does not set (sunlight duration ≈ 24 h) |
| `IsPolarNight` | `bool` | `true` when the sun does not rise (sunlight duration ≈ 0 h) |

Sentinel values returned when a polar condition is detected:

| Condition | `Sunrise` | `Sunset` |
|---|---|---|
| Polar Day | `DateTime.MinValue` | `DateTime.MaxValue` |
| Polar Night | `DateTime.MaxValue` | `DateTime.MinValue` |

```csharp
if (solarTimes.IsPolarDay)
{
    Console.WriteLine("The sun does not set today.");
}
else if (solarTimes.IsPolarNight)
{
    Console.WriteLine("The sun does not rise today.");
}
else
{
    Console.WriteLine($"Sunrise: {solarTimes.Sunrise.ToLongTimeString()}");
    Console.WriteLine($"Sunset:  {solarTimes.Sunset.ToLongTimeString()}");
}
```

## Advanced Solar Properties

All intermediate values used in the NOAA spreadsheet formulas are exposed as public properties, making the full calculation chain inspectable:

| Property | Type | Description |
|---|---|---|
| `SolarAzimuth` | `Angle` | Compass direction of the sun |
| `SolarElevation` | `Angle` | Altitude of the sun above the horizon (uncorrected) |
| `SolarElevationCorrected` | `Angle` | Solar elevation corrected for atmospheric refraction |
| `SolarZenith` | `Angle` | Angle between the sun and the zenith (90° − elevation) |
| `SolarDeclination` | `Angle` | Angular distance of the sun from the equatorial plane |
| `EquationOfTime` | `decimal` | Difference between solar time and clock time (minutes) |
| `HourAngleSunrise` | `Angle` | Hour angle at sunrise |
| `JulianDay` | `decimal` | Julian Day Number for the date |
| `JulianCentury` | `decimal` | Julian century (J2000.0 epoch) |
| `AtmosphericRefraction` | `Angle` | Refraction correction applied at the horizon (default 0.833°) |

## Complete Example

The following example shows all eight solar events for Oak Street Beach in Chicago:

```csharp
using System;
using Innovative.SolarCalculator;

TimeZoneInfo cst = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
SolarTimes st = new SolarTimes(DateTime.Now.Date, cst, 41.9032, -87.6224);

DateTime ToLocal(DateTime dt) => TimeZoneInfo.ConvertTimeFromUtc(dt.ToUniversalTime(), cst);

Console.WriteLine($"Astronomical Dawn : {ToLocal(st.DawnAstronomical).ToLongTimeString()}");
Console.WriteLine($"Nautical Dawn     : {ToLocal(st.DawnNautical).ToLongTimeString()}");
Console.WriteLine($"Civil Dawn        : {ToLocal(st.DawnCivil).ToLongTimeString()}");
Console.WriteLine($"Sunrise           : {ToLocal(st.Sunrise).ToLongTimeString()}");
Console.WriteLine($"Solar Noon        : {ToLocal(st.SolarNoon).ToLongTimeString()}");
Console.WriteLine($"Sunset            : {ToLocal(st.Sunset).ToLongTimeString()}");
Console.WriteLine($"Civil Dusk        : {ToLocal(st.DuskCivil).ToLongTimeString()}");
Console.WriteLine($"Nautical Dusk     : {ToLocal(st.DuskNautical).ToLongTimeString()}");
Console.WriteLine($"Astronomical Dusk : {ToLocal(st.DuskAstronomical).ToLongTimeString()}");
Console.WriteLine($"Sunlight Duration : {st.SunlightDuration:hh\\:mm\\:ss}");
```

## The `Angle` Type

The `Angle` package provides a `decimal`-based geometric angle value type in the `Innovative.Geometry` namespace. It is used throughout `SolarTimes` for all angle-valued properties and can also be used independently.

### Constructors

```csharp
Angle a1 = new Angle(45.0);          // from double degrees
Angle a2 = new Angle(45m);           // from decimal degrees
Angle a3 = new Angle(9, 14, 55.8);   // from degrees, arcminutes, arcseconds
```

`Angle` also supports implicit conversions from/to `double`, `decimal`, and `int`, so it can be assigned directly from numeric literals:

```csharp
Angle a = 45.5;    // implicit from double
double d = a;      // implicit to double
```

### Key Members

| Member | Description |
|---|---|
| `Degrees` | Whole-number degree component |
| `Arcminute` | Arcminute component (0–59) |
| `Arcsecond` | Arcsecond component |
| `Radians` | Value in radians |
| `TotalArcminutes` | Full angle expressed in arcminutes |
| `TotalArcseconds` | Full angle expressed in arcseconds |
| `RadiansMultiplied(factor)` | Radians of `degrees × factor` |
| `RadiansDivided(divisor)` | Radians of `degrees ÷ divisor` |
| `Reduce()` | Normalises the angle to [0°, 360°) |
| `Angle.FromRadians(value)` | Factory: construct from radians |
| `Angle.Empty` | Sentinel representing 0° |

### Arithmetic Operators

`Angle` supports `+`, `-`, `*`, `/`, `%`, `++`, `--`, and all comparison operators (`==`, `!=`, `<`, `>`, `<=`, `>=`).

## Supported Frameworks

Both packages multi-target the following frameworks:

```
netstandard2.0  netstandard2.1
net40  net45  net461
netcoreapp3.1
net5.0  net6.0  net8.0  net9.0  net10.0
```

## Release Notes

| Version | Changes |
|---|---|
| **3.6.1** | Fix DST transition day sunrise/sunset offset bug. Removed .NET 7 target. |
| **3.6.0** | Added .NET 10.0 support. Removed `netstandard1.3` support. |
| **3.5.0** | Added .NET 9.0 support. |
| **3.4.0** | Added .NET 8.0 support. |
| **3.3.0** | Added `IsPolarDay` and `IsPolarNight` (contributed by Nickztar). |
| **3.2.1** | Added README to NuGet package. |
| **3.2.0** | Added .NET 7.0 support. |
| **3.1.0** | Added .NET 5.0 and .NET 6.0 support. |
| **3.0.6** | Added Astronomical, Nautical, and Civil Dawn/Dusk times (contributed by rbdavison). |
| **3.0.3** | Added missing documentation. |
| **3.0.2** | Added source code and symbol integration to the NuGet package. |
| **3.0.1** | Changed license to LGPL-3.0-or-later. |
| **3.0.0** | Added multi-framework support. |
| **2.0.3** | Added azimuth calculation (contributed by GeorgeHahn). |
| **2.0.0** | Converted to .NET Standard; moved to GitHub. |
| **1.0.5** | Added the `Angle` class. |
| **1.0.4** | Changed `ForDate` to `DateTimeOffset` to handle time zones correctly. |

## License

This library is licensed under the [GNU Lesser General Public License v3.0 or later (LGPL-3.0-or-later)](https://www.gnu.org/licenses/lgpl-3.0.html).

Copyright © 2013–2026 Daniel M. Porrey.
