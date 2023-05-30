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
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class CsharpExcelTests
	{
		//
		// Get the test data.
		//
		static readonly IEnumerable<CsharpExcelTestData> TestDataItems = TestDirector.LoadCsharpExcelTestData();

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ExcelModuloComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = ExcelFormulae.Mod(item.Value1, item.Value2);
			CustomAssert.AreEqual(item.Mod, actualValue, TestDirector.ExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelSineComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = Universal.Math.Sin(item.Value1);
			CustomAssert.AreEqual(item.Sin, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelASineComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = Universal.Math.Asin(item.Sin);
			CustomAssert.AreEqual(item.Asin, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelCosineComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = Universal.Math.Cos(item.Value1);
			CustomAssert.AreEqual(item.Cos, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelACosineComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = Universal.Math.Acos(item.Cos);
			CustomAssert.AreEqual(item.Acos, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelTangentComparisons(CsharpExcelTestData item)
		{
			decimal actualValue = Universal.Math.Tan(item.Value1);
			CustomAssert.AreEqual(item.Tan, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}
	}
}
