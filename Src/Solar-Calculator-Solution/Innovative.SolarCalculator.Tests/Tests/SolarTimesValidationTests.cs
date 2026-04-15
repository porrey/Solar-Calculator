// 
// Solar Calculator
// Copyright(C) 2013-2026, Daniel M. Porrey. All rights reserved.
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
using Innovative.Geometry;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class SolarTimesValidationTests
	{
		// -----------------------------------------------------------------------
		// Latitude / Longitude property validation
		// -----------------------------------------------------------------------

		[Test]
		public void Latitude_AboveNinety_ThrowsArgumentOutOfRangeException()
		{
			SolarTimes solarTimes = new();
			Assert.Throws<ArgumentOutOfRangeException>(() => solarTimes.Latitude = new Angle(90.001d));
		}

		[Test]
		public void Latitude_BelowNegativeNinety_ThrowsArgumentOutOfRangeException()
		{
			SolarTimes solarTimes = new();
			Assert.Throws<ArgumentOutOfRangeException>(() => solarTimes.Latitude = new Angle(-90.001d));
		}

		[Test]
		public void Latitude_AtExactBoundary_DoesNotThrow()
		{
			SolarTimes solarTimes = new();
			Assert.DoesNotThrow(() =>
			{
				solarTimes.Latitude = new Angle(90.0d);
				solarTimes.Latitude = new Angle(-90.0d);
			});
		}

		[Test]
		public void Longitude_AboveOneEighty_ThrowsArgumentOutOfRangeException()
		{
			SolarTimes solarTimes = new();
			Assert.Throws<ArgumentOutOfRangeException>(() => solarTimes.Longitude = new Angle(180.001d));
		}

		[Test]
		public void Longitude_BelowNegativeOneEighty_ThrowsArgumentOutOfRangeException()
		{
			SolarTimes solarTimes = new();
			Assert.Throws<ArgumentOutOfRangeException>(() => solarTimes.Longitude = new Angle(-180.001d));
		}

		[Test]
		public void Longitude_AtExactBoundary_DoesNotThrow()
		{
			SolarTimes solarTimes = new();
			Assert.DoesNotThrow(() =>
			{
				solarTimes.Longitude = new Angle(180.0d);
				solarTimes.Longitude = new Angle(-180.0d);
			});
		}

		// -----------------------------------------------------------------------
		// Constructor smoke tests – verify ForDate, Latitude, Longitude, TimeZoneOffset
		// -----------------------------------------------------------------------

		[Test]
		public void DefaultConstructor_SetsForDateToNow()
		{
			DateTimeOffset before = DateTimeOffset.UtcNow;
			SolarTimes solarTimes = new();
			DateTimeOffset after = DateTimeOffset.UtcNow;

			Assert.That(solarTimes.ForDate, Is.GreaterThanOrEqualTo(before));
			Assert.That(solarTimes.ForDate, Is.LessThanOrEqualTo(after));
		}

		[Test]
		public void DateTimeOffsetConstructor_SetsForDate()
		{
			DateTimeOffset expected = new(2024, 6, 21, 12, 0, 0, TimeSpan.FromHours(2));
			SolarTimes solarTimes = new(expected);
			Assert.That(solarTimes.ForDate, Is.EqualTo(expected));
		}

		[Test]
		public void DateTimeOffsetWithAngleConstructor_SetsAllProperties()
		{
			DateTimeOffset forDate = new(2024, 6, 21, 12, 0, 0, TimeSpan.FromHours(5));
			Angle latitude = new(28.6139d);
			Angle longitude = new(77.2090d);

			SolarTimes solarTimes = new(forDate, latitude, longitude);

			Assert.That(solarTimes.ForDate, Is.EqualTo(forDate));
			Assert.That((double)solarTimes.Latitude, Is.EqualTo((double)latitude).Within(0.0001));
			Assert.That((double)solarTimes.Longitude, Is.EqualTo((double)longitude).Within(0.0001));
			Assert.That((double)solarTimes.TimeZoneOffset, Is.EqualTo(5.0).Within(0.001));
		}

		[Test]
		public void DateTimeWithDoubleOffsetAndDoubleCoordinatesConstructor_SetsAllProperties()
		{
			DateTime forDate = new(2024, 6, 21, 12, 0, 0);
			double timeZoneOffset = 5.5;
			double latitude = 28.6139;
			double longitude = 77.2090;

			SolarTimes solarTimes = new(forDate, timeZoneOffset, latitude, longitude);

			Assert.That(solarTimes.ForDate.Date, Is.EqualTo(forDate.Date));
			Assert.That((double)solarTimes.TimeZoneOffset, Is.EqualTo(timeZoneOffset).Within(0.001));
			Assert.That((double)solarTimes.Latitude, Is.EqualTo(latitude).Within(0.0001));
			Assert.That((double)solarTimes.Longitude, Is.EqualTo(longitude).Within(0.0001));
		}

		[Test]
		public void DateTimeWithTimeZoneInfoAndDoubleCoordinatesConstructor_SetsAllProperties()
		{
			TimeZoneInfo berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
			DateTime forDate = new(2024, 6, 21, 0, 0, 0);
			double latitude = 52.50;
			double longitude = 13.35;

			SolarTimes solarTimes = new(forDate, berlin, latitude, longitude);

			Assert.That(solarTimes.ForDate.Date, Is.EqualTo(forDate.Date));
			// UTC+2 (CEST) on June 21
			Assert.That((double)solarTimes.TimeZoneOffset, Is.EqualTo(2.0).Within(0.001));
			Assert.That((double)solarTimes.Latitude, Is.EqualTo(latitude).Within(0.0001));
			Assert.That((double)solarTimes.Longitude, Is.EqualTo(longitude).Within(0.0001));
		}

		[Test]
		public void DateTimeWithTimeZoneInfoAndAngleCoordinatesConstructor_SetsAllProperties()
		{
			TimeZoneInfo berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
			DateTime forDate = new(2024, 6, 21, 0, 0, 0);
			Angle latitude = new(52.50d);
			Angle longitude = new(13.35d);

			SolarTimes solarTimes = new(forDate, berlin, latitude, longitude);

			Assert.That(solarTimes.ForDate.Date, Is.EqualTo(forDate.Date));
			Assert.That((double)solarTimes.TimeZoneOffset, Is.EqualTo(2.0).Within(0.001));
			Assert.That((double)solarTimes.Latitude, Is.EqualTo((double)latitude).Within(0.0001));
			Assert.That((double)solarTimes.Longitude, Is.EqualTo((double)longitude).Within(0.0001));
		}

		[Test]
		public void DateTimeWithDoubleOffsetAndAngleCoordinatesConstructor_SetsAllProperties()
		{
			DateTime forDate = new(2024, 6, 21, 12, 0, 0);
			double timeZoneOffset = 5.5;
			Angle latitude = new(28.6139d);
			Angle longitude = new(77.2090d);

			SolarTimes solarTimes = new(forDate, timeZoneOffset, latitude, longitude);

			Assert.That(solarTimes.ForDate.Date, Is.EqualTo(forDate.Date));
			Assert.That((double)solarTimes.TimeZoneOffset, Is.EqualTo(timeZoneOffset).Within(0.001));
			Assert.That((double)solarTimes.Latitude, Is.EqualTo((double)latitude).Within(0.0001));
			Assert.That((double)solarTimes.Longitude, Is.EqualTo((double)longitude).Within(0.0001));
		}

		// -----------------------------------------------------------------------
		// AtmosphericRefraction – default value and observable effect on sunrise
		// -----------------------------------------------------------------------

		[Test]
		public void AtmosphericRefraction_DefaultValue_Is0Point833Degrees()
		{
			SolarTimes solarTimes = new();
			Assert.That((double)solarTimes.AtmosphericRefraction,
						Is.EqualTo(0.833).Within(0.001));
		}

		[Test]
		public void AtmosphericRefraction_IncreasingValue_EarlierSunrise()
		{
			// Baseline: Sydney in winter (2020-07-21, UTC+10)
			SolarTimes baseline = new()
			{
				Latitude = -33.856837,
				Longitude = 151.215066,
				ForDate = new DateTimeOffset(new DateTime(2020, 7, 21), TimeSpan.FromHours(10))
			};

			SolarTimes higherRefraction = new()
			{
				Latitude = -33.856837,
				Longitude = 151.215066,
				ForDate = new DateTimeOffset(new DateTime(2020, 7, 21), TimeSpan.FromHours(10)),
				AtmosphericRefraction = new Angle(2.0d)
			};

			// A larger atmospheric refraction means the sun appears above the horizon earlier.
			Assert.That(higherRefraction.Sunrise, Is.LessThan(baseline.Sunrise));
		}

		[Test]
		public void AtmosphericRefraction_ZeroValue_LaterSunriseThanDefault()
		{
			SolarTimes withRefraction = new()
			{
				Latitude = -33.856837,
				Longitude = 151.215066,
				ForDate = new DateTimeOffset(new DateTime(2020, 7, 21), TimeSpan.FromHours(10))
			};

			SolarTimes noRefraction = new()
			{
				Latitude = -33.856837,
				Longitude = 151.215066,
				ForDate = new DateTimeOffset(new DateTime(2020, 7, 21), TimeSpan.FromHours(10)),
				AtmosphericRefraction = new Angle(0.0d)
			};

			// With zero refraction the sun must rise (geometrically) later than with the default correction.
			Assert.That(noRefraction.Sunrise, Is.GreaterThan(withRefraction.Sunrise));
		}
	}
}
