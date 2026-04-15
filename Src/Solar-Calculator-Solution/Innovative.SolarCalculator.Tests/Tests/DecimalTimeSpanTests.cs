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
    [TestFixture]
    public class DecimalTimeSpanTests
    {
        [Test]
        public void FromDays_OneFull_ReturnsOneDayTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromDays(1M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromDays(1.0)));
        }

        [Test]
        public void FromDays_HalfDay_ReturnsTwelveHours()
        {
            TimeSpan result = DecimalTimeSpan.FromDays(0.5M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromHours(12.0)));
        }

        [Test]
        public void FromDays_Zero_ReturnsZeroTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromDays(0M);
            Assert.That(result, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void FromHours_OneHour_ReturnsOneHourTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromHours(1M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromHours(1.0)));
        }

        [Test]
        public void FromHours_OneAndHalf_ReturnsNinetyMinutes()
        {
            TimeSpan result = DecimalTimeSpan.FromHours(1.5M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(90.0)));
        }

        [Test]
        public void FromHours_Zero_ReturnsZeroTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromHours(0M);
            Assert.That(result, Is.EqualTo(TimeSpan.Zero));
        }

        [Test]
        public void FromMinutes_OneMinute_ReturnsOneMinuteTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromMinutes(1M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromMinutes(1.0)));
        }

        [Test]
        public void FromMinutes_SixtyMinutes_ReturnsOneHour()
        {
            TimeSpan result = DecimalTimeSpan.FromMinutes(60M);
            Assert.That(result, Is.EqualTo(TimeSpan.FromHours(1.0)));
        }

        [Test]
        public void FromMinutes_Zero_ReturnsZeroTimeSpan()
        {
            TimeSpan result = DecimalTimeSpan.FromMinutes(0M);
            Assert.That(result, Is.EqualTo(TimeSpan.Zero));
        }
    }
}
