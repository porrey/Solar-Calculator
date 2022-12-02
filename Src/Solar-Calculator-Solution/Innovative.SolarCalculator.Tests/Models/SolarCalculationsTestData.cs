//
// Solar Calculator
// Copyright(C) 2013-2022, Daniel M. Porrey. All rights reserved.
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
