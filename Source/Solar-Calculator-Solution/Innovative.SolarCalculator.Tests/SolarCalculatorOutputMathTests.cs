// ***
// *** Copyright (C) 2013-2018, Daniel M. Porrey.  All rights reserved.
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
using System;
using NUnit.Framework;

namespace Innovative.SolarCalculator.Tests
{
	[TestFixture]
	public class SolarCalculatorOutputMathTests
	{
		private Random _random = new Random((int)DateTime.Now.Ticks);

		[Test]
		public void CheckSunsetDate()
		{
			int numberOfDays = _random.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunset.Date);
		}

		[Test]
		public void CheckSunriseDate()
		{
			int numberOfDays = _random.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.Sunrise.Date);
		}

		[Test]
		public void CheckSolarNoonDate()
		{
			int numberOfDays = _random.Next(10, 20);
			DateTime forDate = DateTime.Now.AddDays(numberOfDays);
			SolarTimes solarTimes = new SolarTimes(forDate, 41.9032, -87.6224);
			Assert.AreEqual(solarTimes.ForDate.Date, solarTimes.SolarNoon.Date);
		}
	}
}
