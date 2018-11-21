// ***
// *** Copyright (C) 2013-2018, Daniel M. Porrey. All rights reserved.
// *** Written By Daniel M. Porrey
// ***
// *** This software is provided "AS IS," without a warranty of any kind. ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES, 
// *** INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE OR NON-INFRINGEMENT, ARE HEREBY EXCLUDED. DANIEL M PORREY 
// *** AND ITS LICENSORS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING THIS SOFTWARE 
// *** OR ITS DERIVATIVES. IN NO EVENT WILL DANIEL M PORREY OR ITS LICENSORS BE LIABLE FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR DIRECT, INDIRECT, 
// *** SPECIAL, CONSEQUENTIAL, INCIDENTAL OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING OUT OF THE USE OF 
// *** OR INABILITY TO USE THIS SOFTWARE, EVEN IF DANIEL M PORREY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
// ***
// *** Licensed under Microsoft Public License (Ms-PL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
using System.Collections.Generic;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class CsharpExcelTests
	{
		// ***
		// *** Get the test data.
		// ***
		static readonly IEnumerable<ExcelFormulasTestData> TestDataItems = TestDirector.LoadExcelFormulasTestData();

		[Test]
		[TestCaseSource("TestDataItems")]
		public void ExcelModuloComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = ExcelFormulae.Mod(item.Value1, item.Value2);
			CustomAssert.AreEqual(item.Mod, actualValue, TestDirector.ExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelSineComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = Universal.Math.Sin(item.Value1);
			CustomAssert.AreEqual(item.Sin, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelASineComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = Universal.Math.Asin(item.Sin);
			CustomAssert.AreEqual(item.Asin, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelCosineComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = Universal.Math.Cos(item.Value1);
			CustomAssert.AreEqual(item.Cos, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelACosineComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = Universal.Math.Acos(item.Cos);
			CustomAssert.AreEqual(item.Acos, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}

		[Test]
		[TestCaseSource("TestDataItems")]
		public void CsharpExcelTangentComparisons(ExcelFormulasTestData item)
		{
			decimal actualValue = Universal.Math.Tan(item.Value1);
			CustomAssert.AreEqual(item.Tan, actualValue, TestDirector.CSharpExcelDecimalDelta);
		}
	}
}
