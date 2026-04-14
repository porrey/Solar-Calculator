//
// Solar Calculator
// Copyright(C) 2013-2025, Daniel M. Porrey. All rights reserved.
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
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
    /// <summary>
    /// Regression tests for issue #10: On DST transition days, sunrise/sunset calculations were
    /// off by one hour when a DateTime at midnight was used because the UTC offset captured at
    /// midnight differs from the offset in effect for the rest of the day after the transition.
    ///
    /// The fix is to use the TimeZoneInfo-based constructors, which internally derive the UTC
    /// offset from noon of the requested calendar day, avoiding the DST ambiguity.
    /// </summary>
    [TestFixture]
    public class DstTransitionTests
    {
        // Allow up to 2 minutes of deviation from the reference values.
        private static readonly TimeSpan Tolerance = TimeSpan.FromMinutes(2);

        // -----------------------------------------------------------------------
        // Berlin / Europe (fall-back: Oct 31 2021, clocks go from UTC+2 to UTC+1)
        // Reference values computed with the correct UTC+1 offset.
        // -----------------------------------------------------------------------

        [Test]
        public void Berlin_FallBack_Day_TimeZoneInfo_Angle_GivesCorrectSunrise()
        {
            // Oct 31 2021 – Berlin DST ends (UTC+2 → UTC+1). A midnight DateTime still
            // carries the pre-transition offset (+2) when converted naively. The
            // TimeZoneInfo constructor uses noon to pick the correct offset (+1).
            var berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
            var date = new DateTime(2021, 10, 31, 0, 0, 0); // midnight

            var solarTimes = new SolarTimes(date, berlin, 52.50, 13.35);

            var expected = new DateTime(2021, 10, 31, 7, 0, 36);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void Berlin_FallBack_Day_TimeZoneInfo_Angle_GivesCorrectSunset()
        {
            var berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
            var date = new DateTime(2021, 10, 31, 0, 0, 0);

            var solarTimes = new SolarTimes(date, berlin, 52.50, 13.35);

            var expected = new DateTime(2021, 10, 31, 16, 39, 44);
            TimeSpan difference = (solarTimes.Sunset.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunset ≈ {expected.TimeOfDay}, got {solarTimes.Sunset.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void Berlin_FallBack_Day_SunriseIsInCorrectHour()
        {
            // Without the fix, sunrise on Oct 31 (fall-back) would appear as ~08:00 (off by 1 h).
            // With the fix it should be in the 07:xx range.
            var berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
            var date = new DateTime(2021, 10, 31, 0, 0, 0);

            var solarTimes = new SolarTimes(date, berlin, 52.50, 13.35);

            Assert.That(solarTimes.Sunrise.Hour, Is.EqualTo(7),
                $"Sunrise hour should be 7 (UTC+1 after DST ends), got {solarTimes.Sunrise.Hour}");
        }

        [Test]
        public void Berlin_DayBeforeFallBack_Sunrise_IsCorrect()
        {
            // Oct 30 2021 – still on summer time (UTC+2). Reference: ~07:58 local.
            var berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
            var date = new DateTime(2021, 10, 30, 0, 0, 0);

            var solarTimes = new SolarTimes(date, berlin, 52.50, 13.35);

            var expected = new DateTime(2021, 10, 30, 7, 58, 42);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void Berlin_DayAfterFallBack_Sunrise_IsCorrect()
        {
            // Nov 1 2021 – winter time (UTC+1). Reference: ~07:02 local.
            var berlin = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
            var date = new DateTime(2021, 11, 1, 0, 0, 0);

            var solarTimes = new SolarTimes(date, berlin, 52.50, 13.35);

            var expected = new DateTime(2021, 11, 1, 7, 2, 26);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        // -----------------------------------------------------------------------
        // US Central (spring-forward: Mar 13 2022, clocks go from UTC-6 to UTC-5)
        // Reference values computed with the correct UTC-5 offset.
        // -----------------------------------------------------------------------

        [Test]
        public void USCentral_SpringForward_Day_TimeZoneInfo_Double_GivesCorrectSunrise()
        {
            // Mar 13 2022 – US Central DST begins (UTC-6 → UTC-5). Midnight still carries
            // the pre-transition offset (-6). The TimeZoneInfo constructor uses noon to pick
            // the correct offset (-5).
            var chicago = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            var date = new DateTime(2022, 3, 13, 0, 0, 0);

            var solarTimes = new SolarTimes(date, chicago, 44.927481, -93.306843);

            var expected = new DateTime(2022, 3, 13, 7, 29, 46);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void USCentral_SpringForward_Day_TimeZoneInfo_Double_GivesCorrectSunset()
        {
            var chicago = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            var date = new DateTime(2022, 3, 13, 0, 0, 0);

            var solarTimes = new SolarTimes(date, chicago, 44.927481, -93.306843);

            var expected = new DateTime(2022, 3, 13, 19, 15, 43);
            TimeSpan difference = (solarTimes.Sunset.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunset ≈ {expected.TimeOfDay}, got {solarTimes.Sunset.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void USCentral_SpringForward_Day_SunriseIsInCorrectHour()
        {
            // Without the fix, sunrise would appear as ~06:29 (off by 1 h, using -6 offset).
            // With the fix it should be in the 07:xx range.
            var chicago = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            var date = new DateTime(2022, 3, 13, 0, 0, 0);

            var solarTimes = new SolarTimes(date, chicago, 44.927481, -93.306843);

            Assert.That(solarTimes.Sunrise.Hour, Is.EqualTo(7),
                $"Sunrise hour should be 7 (UTC-5 after DST starts), got {solarTimes.Sunrise.Hour}");
        }

        [Test]
        public void USCentral_DayBeforeSpringForward_Sunrise_IsCorrect()
        {
            // Mar 12 2022 – still on standard time (UTC-6). Reference: ~06:31 local.
            var chicago = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            var date = new DateTime(2022, 3, 12, 0, 0, 0);

            var solarTimes = new SolarTimes(date, chicago, 44.927481, -93.306843);

            var expected = new DateTime(2022, 3, 12, 6, 31, 32);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        [Test]
        public void USCentral_DayAfterSpringForward_Sunrise_IsCorrect()
        {
            // Mar 14 2022 – daylight saving time (UTC-5). Reference: ~07:27 local.
            var chicago = TimeZoneInfo.FindSystemTimeZoneById("America/Chicago");
            var date = new DateTime(2022, 3, 14, 0, 0, 0);

            var solarTimes = new SolarTimes(date, chicago, 44.927481, -93.306843);

            var expected = new DateTime(2022, 3, 14, 7, 27, 55);
            TimeSpan difference = (solarTimes.Sunrise.TimeOfDay - expected.TimeOfDay).Duration();
            Assert.That(difference, Is.LessThanOrEqualTo(Tolerance),
                $"Expected sunrise ≈ {expected.TimeOfDay}, got {solarTimes.Sunrise.TimeOfDay}, difference {difference}");
        }

        // -----------------------------------------------------------------------
        // Verify the double timeZoneOffset constructor supports fractional offsets
        // (fixes the int → double promotion: e.g. India Standard Time = UTC+5.5)
        // -----------------------------------------------------------------------

        [Test]
        public void FractionalTimeZoneOffset_Constructor_IsAccepted()
        {
            // India Standard Time is UTC+5:30 (5.5 hours). Passing 5.5 would have failed
            // to compile before the int→double fix.
            var date = new DateTime(2024, 6, 21, 12, 0, 0);
            var solarTimes = new SolarTimes(date, 5.5, 28.6139, 77.2090); // New Delhi

            Assert.That(solarTimes.TimeZoneOffset, Is.EqualTo(5.5m).Within(0.001m),
                "TimeZoneOffset should be 5.5 for UTC+5:30");
        }
    }
}
