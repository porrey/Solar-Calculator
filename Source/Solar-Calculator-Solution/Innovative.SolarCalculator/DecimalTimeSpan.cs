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
// *** Licensed under Microsoft Reciprocal License (Ms-RL)
// *** This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, 
// *** do not use the software. Full license details can be found at https://raw.githubusercontent.com/porrey/Solar-Calculator/master/LICENSE.
// ***
using System;

namespace Innovative.SolarCalculator
{
	/// <summary>
	/// Provides decimal versions of common TimeSpan methods to make
	/// the code in the library look cleaner and ensure consistency.
	/// </summary>
	public static class DecimalTimeSpan
	{
		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of days, where
		/// the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of days, accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromDays(decimal value)
		{
			return System.TimeSpan.FromDays((double)value);
		}

		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of hours, where
		/// the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of hours accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromHours(decimal value)
		{
			return System.TimeSpan.FromHours((double)value);
		}

		/// <summary>
		/// Returns a System.TimeSpan that represents a specified number of minutes,
		/// where the specification is accurate to the nearest millisecond.
		/// </summary>
		/// <param name="value">A number of minutes, accurate to the nearest millisecond.</param>
		/// <returns>An object that represents value.</returns>
		public static TimeSpan FromMinutes(decimal value)
		{
			return System.TimeSpan.FromMinutes((double)value);
		}
	}
}
