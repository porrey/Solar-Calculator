// ***
// *** Copyright (C) 2013-2017, Daniel M. Porrey.  All rights reserved.
// *** Written By Daniel M. Porrey
// ***
// *** This software is provided "AS IS," without a warranty of any kind. ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS AND WARRANTIES, 
// *** INCLUDING ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE OR NON-INFRINGEMENT, ARE HEREBY EXCLUDED. DANIEL M PORREY 
// *** AND ITS LICENSORS SHALL NOT BE LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING OR DISTRIBUTING THIS SOFTWARE 
// *** OR ITS DERIVATIVES. IN NO EVENT WILL DANIEL M PORREY OR ITS LICENSORS BE LIABLE FOR ANY LOST REVENUE, PROFIT OR DATA, OR FOR DIRECT, INDIRECT, 
// *** SPECIAL, CONSEQUENTIAL, INCIDENTAL OR PUNITIVE DAMAGES, HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY, ARISING OUT OF THE USE OF 
// *** OR INABILITY TO USE THIS SOFTWARE, EVEN IF DANIEL M PORREY HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. 
// ***
// *** Licensed under Microsoft Reciprocal License (Ms-RL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
using System;
using System.Collections.Generic;
using System.Text;

namespace Innovative.SolarCalculator
{
	/// <summary>
	/// Provides common .NET static methods that vary between versions.
	/// </summary>
	public static class Universal
	{
		/// <summary>
		/// The Math functions in PORTABLE libraries only accept and return double. All other libraries accept
		/// decimal. The library works in all decimal values. This class provides decimal based Math functions
		/// for all platforms.
		/// </summary>
		public static class Math
		{
			public static decimal Sin(decimal value)
			{
				return (decimal)System.Math.Sin((double)value);
			}

			public static decimal Asin(decimal value)
			{
				return (decimal)System.Math.Asin((double)value);
			}

			public static decimal Tan(decimal value)
			{
				return (decimal)System.Math.Tan((double)value);
			}

			public static decimal Cos(decimal value)
			{
				return (decimal)System.Math.Cos((double)value);
			}

			public static decimal Acos(decimal value)
			{
				return (decimal)System.Math.Acos((double)value);
			}

			public static decimal Sqrt(decimal value)
			{
				return (decimal)System.Math.Sqrt((double)value);
			}
		}
	}
}
