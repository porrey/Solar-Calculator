# Architecture

This document describes the structure, design decisions, and key components of the Solar Calculator solution.

---

## Overview

Solar Calculator is a .NET class library that computes solar events (sunrise, sunset, dawn, dusk, solar noon, etc.) for a given date and geographic location. The implementation is a faithful C# port of the [NOAA Solar Calculations Day spreadsheet](http://www.esrl.noaa.gov/gmd/grad/solcalc/calcdetails.html), whose formulas are in turn drawn from *Astronomical Algorithms* by Jean Meeus.

Two independent NuGet packages are produced from this repository:

| Package | NuGet ID | Purpose |
|---|---|---|
| Solar Calculator | `SolarCalculator` | Sunrise/sunset and related solar time calculations |
| Angle | `Angle` | General-purpose geometric angle value type |

---

## Repository Layout

```
Solar-Calculator/
├── README.md                            # Usage guide and sample code
├── ARCHITECTURE.md                      # This file
├── Images/                              # Package icons (Solar-Calculator.png, Angle.png)
├── NOAA Spreadsheet/                    # Original NOAA Excel reference spreadsheet
└── Src/
    ├── NuGet.Publish.cmd                # Manual NuGet publish helper script
    └── Solar-Calculator-Solution/
        ├── Solar-Calculator-Solution.sln
        ├── Innovative.SolarCalculator/       # Core library → SolarCalculator NuGet package
        ├── Innovative.Geometry.Angle/        # Supporting library → Angle NuGet package
        ├── Innovative.SolarCalculator.Tests/ # NUnit test suite
        └── Example/                          # Console application demonstrating usage
```

---

## Projects

### `Innovative.SolarCalculator` — Core Library

**Namespace:** `Innovative.SolarCalculator`  
**NuGet ID:** `SolarCalculator`  
**License:** LGPL-3.0-or-later

The main public surface is the `SolarTimes` class. Callers instantiate it with a date and geographic coordinates and then read computed properties.

#### `SolarTimes`

Each property maps directly to a named column in the NOAA spreadsheet (noted in XML doc comments as "Spreadsheet Column X"). Properties are computed lazily and build on one another in a deterministic chain:

```
ForDate / Latitude / Longitude / TimeZoneOffset
    │
    ▼
TimePastLocalMidnight → JulianDay → JulianCentury
    │
    ├─ SunGeometricMeanLongitude (col I)
    ├─ SunMeanAnomaly            (col J)
    ├─ EccentricityOfEarthOrbit  (col K)
    ├─ SunEquationOfCenter       (col L)
    ├─ SunTrueLongitude          (col M)
    ├─ SunApparentLongitude      (col P)
    ├─ MeanEclipticObliquity     (col Q)
    ├─ ObliquityCorrection       (col R)
    ├─ SolarDeclination          (col T)
    ├─ VarY                      (col U)
    ├─ EquationOfTime            (col V)
    ├─ HourAngleSunrise          (col W)
    ├─ SolarNoon                 (col X)
    ├─ Sunrise / Sunset          (cols Y / Z)
    ├─ SunlightDuration          (col AA)
    ├─ TrueSolarTime             (col AB)
    ├─ HourAngleDegrees          (col AC)
    ├─ SolarZenith               (col AD)
    ├─ SolarElevation            (col AE)
    ├─ AtmosphericRefractionCorrection
    ├─ SolarElevationCorrected   (col AF)
    └─ SolarAzimuth              (col AG)
```

Dawn/Dusk variants (Astronomical, Nautical, Civil) use the same solar-noon anchor but substitute different horizon angles:

| Event | Sun angle below horizon |
|---|---|
| Civil dawn/dusk | 6° |
| Nautical dawn/dusk | 12° |
| Astronomical dawn/dusk | 18° |

**Polar edge cases** — `IsPolarDay` and `IsPolarNight` are derived from `SunlightDuration`. When either condition is true, `Sunrise` and `Sunset` return sentinel values (`DateTime.MinValue` / `DateTime.MaxValue`) rather than meaningless computed times.

#### Supporting files

| File | Purpose |
|---|---|
| `ExcelFormulae.cs` | Replicates Excel worksheet functions (`DATEVALUE`, `MOD`) that behave differently from their C# equivalents, required to faithfully reproduce the NOAA spreadsheet formulas |
| `UniversalMath.cs` | Thin `decimal`-based wrappers around `System.Math` (Sin, Cos, Tan, Asin, Acos, Sqrt). Necessary because some target frameworks only expose `double` overloads |
| `DecimalTimeSpan.cs` | Converts between `decimal` day-fractions (as used in spreadsheet arithmetic) and `TimeSpan` |
| `DateTimeExtensions.cs` | Helper extension methods for `DateTime` |

#### Numerical precision

All intermediate values are stored as `decimal` rather than `double`. This avoids cumulative floating-point drift across the long chain of trigonometric operations and preserves the precision of the original spreadsheet. `Universal.Math` bridges between the `decimal` domain and `System.Math`'s `double` trig functions.

#### Multi-targeting

Both library projects target the same framework list:

```
netstandard2.0  netstandard2.1
net40  net45  net461
netcoreapp3.1
net5.0  net6.0  net7.0  net8.0  net9.0  net10.0
```

---

### `Innovative.Geometry.Angle` — Angle Value Type

**Namespace:** `Innovative.Geometry`  
**NuGet ID:** `Angle`  
**License:** LGPL-3.0-or-later

A standalone, general-purpose value type for geometric angles that is published as a separate package and referenced by `Innovative.SolarCalculator`.

#### `Angle`

- Stores the value internally as `decimal` degrees.
- Provides implicit conversions from/to `double`, `decimal`, and `int`, so existing code that uses plain numeric types is not broken.
- Key members:

| Member | Description |
|---|---|
| `Degrees` | Value in degrees |
| `Radians` | Value converted to radians |
| `RadiansMultiplied(factor)` | Radians × factor (avoids temporary `Angle` allocations in formulas) |
| `RadiansDivided(divisor)` | Radians ÷ divisor |
| `FromRadians(value)` | Factory: construct from a radian value |
| `ToDegrees(value)` | Static conversion |
| `ReducedDegrees` | Angle normalised to [0°, 360°) |
| `Arcminute` / `Arcsecond` | Sub-degree components |
| `TotalMinutes` / `TotalSeconds` | Whole-angle expressed in minutes/seconds |
| `OppositeDirection` | Angle + 180° |
| `Empty` | Static sentinel representing an uninitialised angle (0°) |

#### `MathExtensions`

Extension methods on `decimal` and `double` for radian/degree conversions, used internally.

---

### `Innovative.SolarCalculator.Tests` — Test Suite

**Framework:** NUnit 4, targeting `net10.0`

Tests are data-driven: expected values are stored in CSV files derived directly from the NOAA Excel spreadsheet and are loaded at test startup by `TestDirector`.

#### Test data files (`Data/`)

| File | Covers |
|---|---|
| `SolarCalculationsTestData.csv` | All intermediate solar calculation properties |
| `AngleTestData.csv` | `Angle` type conversions and operations |
| `CsharpExcelTestData.csv` | `ExcelFormulae` (MOD, trig functions) |
| `DateValueTestData.csv` | `ExcelFormulae.ToExcelDateValue` |

#### Test classes (`Tests/`)

| Class | What it tests |
|---|---|
| `SolarCalculatorTests` | Every `SolarTimes` computed property against spreadsheet expected values |
| `AngleTests` | `Angle` type members |
| `CsharpExcelTests` | `ExcelFormulae` methods |
| `ExcelDateTests` | `ToExcelDateValue` |

#### Test infrastructure (`Helpers/`)

| Class | Role |
|---|---|
| `TestDirector` | Loads CSV test data; creates `SolarTimes` instances from test rows; defines per-category numeric tolerances |
| `CustomAssert` | Tolerance-aware decimal/TimeSpan assertion helpers |
| `TestDecorator` | NUnit `[TestCaseSource]` formatting helpers |

**Numeric tolerances used in assertions:**

| Category | Tolerance |
|---|---|
| Solar calculations | 9 × 10⁻⁹ |
| Excel formula replication | 1 × 10⁻⁹ |
| Excel date values | 1 × 10⁻¹² |
| Math functions | 1 × 10⁻⁷ |
| Time comparisons | ±500 ms |

---

### `Example` — Console Application

A minimal runnable demo showing all eight solar events for two Midwest US locations (Oak Street Beach, Chicago IL and Benton Harbor, MI). Demonstrates:

- Constructing `SolarTimes` with a `DateTime` and decimal lat/long.
- Converting the returned local `DateTime` to a named time zone via `TimeZoneInfo.ConvertTimeFromUtc`.

---

## CI / CD

GitHub Actions workflow (`.github/workflows/dotnet.yml`) runs on every push and pull request to `master`:

1. **Restore** — `dotnet restore`
2. **Build** — `dotnet build --no-restore`
3. **Test** — `dotnet test --no-build`

The workflow runs on `ubuntu-latest` using .NET 9 SDK. NuGet packages are published manually via `Src/NuGet.Publish.cmd`.

---

## Dependency Graph

```
Innovative.SolarCalculator.Tests
    ├── Innovative.SolarCalculator
    │       └── Innovative.Geometry.Angle
    └── Innovative.Geometry.Angle

Example
    └── Innovative.SolarCalculator
            └── Innovative.Geometry.Angle
```

`Innovative.Geometry.Angle` has no project dependencies; it is a leaf library.

---

## Design Principles

- **Spreadsheet fidelity** — Every formula maps to a named column in the NOAA spreadsheet. XML doc comments cite the column letter, making it easy to cross-reference computed properties against the source.
- **Transparency** — All intermediate values are exposed as public properties so callers can inspect any step of the calculation.
- **Decimal arithmetic** — `decimal` is used throughout the calculation chain to avoid double-precision drift across chained trig operations.
- **Wide framework support** — Both libraries multi-target from `net40` through `net10.0` and both `netstandard` profiles, maximising compatibility without separate codebases.
- **Data-driven testing** — Test expectations are the actual values produced by the NOAA spreadsheet, not independently derived figures, ensuring the library remains a true port.
