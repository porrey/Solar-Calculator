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
    public class DateTimeExtensionsTests
    {
        // OLE Automation epoch: 30 December 1899 = 0.0
        // 31 December 1899 = 1.0
        // 1 January 1900   = 2.0  (Excel incorrectly treats 1900 as a leap year,
        //                          so Excel's serial 1 = Jan 1 1900, 2 = Jan 2 1900 …
        //                          but ToOleAutomationDate is a straight day count
        //                          from 30 Dec 1899, matching .NET's OA convention.)

        [Test]
        public void ToOleAutomationDate_Epoch_ReturnsZero()
        {
            // 30 December 1899 is the OLE epoch → 0
            DateTime epoch = new DateTime(1899, 12, 30);
            decimal result = epoch.ToOleAutomationDate();
            Assert.That(result, Is.EqualTo(0M));
        }

        [Test]
        public void ToOleAutomationDate_NextDay_ReturnsOne()
        {
            // 31 December 1899 → 1
            DateTime nextDay = new DateTime(1899, 12, 31);
            decimal result = nextDay.ToOleAutomationDate();
            Assert.That(result, Is.EqualTo(1M));
        }

        [Test]
        public void ToOleAutomationDate_Jan1_1900_ReturnsTwo()
        {
            // 1 January 1900 → 2
            DateTime jan1 = new DateTime(1900, 1, 1);
            decimal result = jan1.ToOleAutomationDate();
            Assert.That(result, Is.EqualTo(2M));
        }

        [Test]
        public void ToOleAutomationDate_KnownModernDate_MatchesDotNetOA()
        {
            // Cross-check against DateTime.ToOADate() for a modern date.
            DateTime date = new DateTime(2024, 6, 21);
            decimal expected = (decimal)date.ToOADate();
            decimal actual   = date.ToOleAutomationDate();
            Assert.That(actual, Is.EqualTo(expected).Within(0.000001M));
        }

        [Test]
        public void ToOleAutomationDate_WithTimeComponent_ReturnsFractionalValue()
        {
            // Noon on 30 December 1899 should be 0.5
            DateTime noon = new DateTime(1899, 12, 30, 12, 0, 0);
            decimal result = noon.ToOleAutomationDate();
            Assert.That(result, Is.EqualTo(0.5M).Within(0.000001M));
        }
    }
}
