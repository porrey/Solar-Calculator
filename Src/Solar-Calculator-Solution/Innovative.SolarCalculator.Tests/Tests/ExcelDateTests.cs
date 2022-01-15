// ***
// *** Solar Calculator 3.1.0
// *** Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
// *** 
// *** This program is free software: you can redistribute it and/or modify
// *** it under the terms of the GNU Lesser General Public License as published
// *** by the Free Software Foundation, either version 3 of the License, or
// *** (at your option) any later version.
// *** 
// *** This program is distributed in the hope that it will be useful,
// *** but WITHOUT ANY WARRANTY; without even the implied warranty of
// *** MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// *** GNU Lesser General Public License for more details.
// *** 
// *** You should have received a copy of the GNU Lesser General Public License
// *** along with this program. If not, see http://www.gnu.org/licenses/.
// *** 
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class ExcelDateTests
	{
		// ***
		// *** Get the test data.
		// ***
		static readonly IEnumerable<DateValueTestData> TestDataItems = TestDirector.LoadDateValueTestData();

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ExcelDateValueTest(DateValueTestData item)
		{
			decimal actualValue = ExcelFormulae.ToExcelDateValue(item.Date);
			CustomAssert.AreEqual(item.DateValue, actualValue, TestDirector.ExcelDecimalDelta);
		}
	}
}
