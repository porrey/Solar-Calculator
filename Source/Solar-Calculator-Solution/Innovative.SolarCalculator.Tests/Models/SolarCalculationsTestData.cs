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
using System;

namespace Innovative.SolarCalculator.Tests
{
	public class SolarCalculationsTestData
	{
		public DateTime Date { get; set; }
		public DateTime Time { get; set; }
		public int TimeZoneOffset { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }
		public decimal JulianDay { get; set; }
		public decimal JulianCentury { get; set; }
		public decimal GeomMeanLongSun { get; set; }
		public decimal GeomMeanAnomSun { get; set; }
		public decimal EccentEarthOrbit { get; set; }
		public decimal SunEqofCtr { get; set; }
		public decimal SunTrueLong { get; set; }
		public decimal SunAppLong { get; set; }
		public decimal MeanObliqEcliptic { get; set; }
		public decimal ObliqCorr { get; set; }
		public decimal SunDeclin { get; set; }
		public decimal Vary { get; set; }
		public decimal EqofTime { get; set; }
		public decimal HaSunrise { get; set; }
		public DateTime SolarNoon { get; set; }
		public DateTime SunriseTime { get; set; }
		public DateTime SunsetTime { get; set; }
		public double SunlightDuration { get; set; }
		public decimal TrueSolarTime { get; set; }
	}
}
