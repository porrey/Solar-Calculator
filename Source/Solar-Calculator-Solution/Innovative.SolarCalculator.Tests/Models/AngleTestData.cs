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
	public class AngleTestData
	{
		public decimal Angle { get; set; }
		public decimal Radians { get; set; }
		public decimal Degrees { get; set; }
		public decimal DecimalMinutes { get; set; }
		public decimal Arcminute { get; set; }
		public decimal Arcsecond { get; set; }
		public string LongFormat { get; set; }
		public string ShortFormat { get; set; }
		public decimal RandomNumber { get; set; }
		public decimal RadiansMultiplied { get; set; }
		public decimal RadiansDivided { get; set; }
		public decimal ReducedDegrees { get; set; }
		public decimal TotalMinutes { get; set; }
		public decimal TotalSeconds { get; set; }
		public decimal OppositeDirection { get; set; }
	}
}