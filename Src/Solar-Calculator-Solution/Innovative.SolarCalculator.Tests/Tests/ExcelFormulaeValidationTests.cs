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
    public class ExcelFormulaeValidationTests
    {
        [Test]
        public void Mod_ZeroDivisor_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => ExcelFormulae.Mod(42M, 0M));
        }

        [Test]
        public void Mod_NegativeNumber_PositiveDivisor_ReturnsPositiveRemainder()
        {
            // Excel MOD(-3, 2) = 1 (not -1 as C# % would return)
            decimal result = ExcelFormulae.Mod(-3M, 2M);
            Assert.That(result, Is.EqualTo(1M).Within(0.0000001M));
        }

        [Test]
        public void Mod_PositiveNumber_NegativeDivisor_ReturnsNegativeRemainder()
        {
            // Excel MOD(3, -2) = -1
            decimal result = ExcelFormulae.Mod(3M, -2M);
            Assert.That(result, Is.EqualTo(-1M).Within(0.0000001M));
        }
    }
}
