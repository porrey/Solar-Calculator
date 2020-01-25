// ***
// *** Solar Calculator 3.0.0
// *** Copyright(C) 2013-2020, Daniel M. Porrey. All rights reserved.
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
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Innovative.SolarCalculator.Tests")]

namespace Innovative.Geometry
{
	/// <summary>
	/// Defines a type for a geometric angle that allows various ways of setting and converting
	/// the values from and to different modes. Angle inherently is a decimal and can be used in 
	/// place of a decimal when specifically referring to a geometric angle with the value being
	/// the degrees of the angle.
	/// </summary>
	public class Angle : IComparable, IFormattable, IComparable<Angle>, IEquatable<Angle>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the System.Angle class.
		/// </summary>
		public Angle()
		{
		}

		/// <summary>
		/// Initializes a new instance of the System.Angle class to an angle specified in degrees
		/// represented by an integer.
		/// </summary>
		/// <param name="degrees">The value of the angle in degrees.</param>
		public Angle(int degrees)
		{
			this.InternalValue = (decimal)degrees;
		}

		/// <summary>
		/// Initializes a new instance of the System.Angle class to an angle specified in degrees
		/// represented by a decimal.
		/// </summary>
		/// <param name="degrees">The value of the angle in degrees.</param>
		public Angle(decimal degrees)
		{
			this.InternalValue = degrees;
		}

		/// <summary>
		/// Initializes a new instance of the System.Angle class to an angle specified in degrees
		/// represented by a double.
		/// </summary>
		/// <param name="degrees">The value of the angle in degrees.</param>
		public Angle(double degrees)
		{
			this.InternalValue = (decimal)degrees;
		}

		/// <summary>
		/// Initializes a new instance of the System.Angle class to an angle with the whole part
		/// specified in degrees represented by a integer and the decimal part represented in 
		/// Minutes and Seconds of an Arc. This allows an angle represented as 9° 14' 55.8'' to
		/// be initialized.
		/// </summary>
		/// <param name="degrees">The whole value portion of the angle in degrees, e.g., 9 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcminute">The arcminute value, e.g., 14 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcsecond">The arcsecond value, e.g., 55.8 from the angle 9° 14' 55.8''.</param>
		public Angle(int degrees, int arcminute, decimal arcsecond)
		{
			this.InternalValue = Angle.ToDegrees(degrees, arcminute, arcsecond);
		}

		/// <summary>
		/// Initializes a new instance of the System.Angle class to an angle with the whole part
		/// specified in degrees represented by a System.Int32 and the System.Double part represented
		/// in Minutes and Seconds of an Arc. This allows an angle represented as 9° 14' 55.8'' to
		/// be initialized.
		/// </summary>
		/// <param name="degrees">The whole value portion of the angle in degrees, e.g., 9 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcminute">The arcminute value, e.g., 14 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcsecond">The arcsecond value, e.g., 55.8 from the angle 9° 14' 55.8''.</param>
		public Angle(int degrees, int arcminute, double arcsecond)
		{
			this.InternalValue = Angle.ToDegrees(degrees, arcminute, (decimal)arcsecond);
		}
		#endregion

		#region Public Members
		/// <summary>
		/// Gets the whole number portion of the value of
		/// this instance in degrees.
		/// </summary>
		public int Degrees
		{
			get
			{
				return Angle.GetDegrees(this);
			}
		}

		/// <summary>
		/// Gets the arcminute portion of the value of
		/// this instance in degrees.
		/// </summary>
		public int Arcminute
		{
			get
			{
				return Angle.GetArcminute(this);
			}
		}

		/// <summary>
		/// Gets the arcsecond portion of the value of
		/// this instance in degrees.
		/// </summary>
		public decimal Arcsecond
		{
			get
			{
				return Angle.GetArcsecond(this);
			}
		}

		/// <summary>
		/// Returns the value of this instance in Radian units.
		/// </summary>
		public decimal Radians
		{
			get
			{
				return Angle.ToRadians(this.InternalValue);
			}
		}

		/// <summary>
		/// Returns the value of this instance in Radian units by
		/// first multiplying the underlying value of the angle 
		/// (in degrees) by the multiplier before converting the
		/// value to Radian units. Note that this value is NOT
		/// equal to this.Radians * multiplier.
		/// </summary>
		public decimal RadiansMultiplied(decimal multiplier)
		{
			return Angle.ToRadians(this.InternalValue * multiplier);
		}

		/// <summary>
		/// Returns the value of this instance in Radian units by
		/// first dividing the underlying value of the angle 
		/// (in degrees) by the divisor before converting the
		/// value to Radian units. Note that this value is NOT
		/// equal to this.Radians / divisor.
		/// </summary>
		public decimal RadiansDivided(decimal divisor)
		{
			return Angle.ToRadians(this.InternalValue / divisor);
		}

		/// <summary>
		/// Gets the full value of this angle expressed only in
		/// Minutes of arc.
		/// </summary>
		public decimal TotalArcminutes
		{
			get
			{
				return (this.Degrees * 60M) + this.Arcminute + (this.Arcsecond / 60M);
			}
		}

		/// <summary>
		/// Gets the full value of this angle expressed only in
		/// Seconds of arc.
		/// </summary>
		public decimal TotalArcseconds
		{
			get
			{
				return (this.Degrees * 3600M) + (this.Arcminute * 60M) + this.Arcsecond;
			}
		}

		/// <summary>
		/// Normalizes this instance of the angle to between 0 and 360 degrees.
		/// </summary>
		public void Reduce()
		{
			this.InternalValue = Angle.Reduce(this).InternalValue;
		}
		#endregion

		#region Public Overrides
		/// <summary>
		///  Returns a value indicating whether this instance and a specified System.Angle
		/// object represent the same value.
		/// </summary>
		/// <param name="obj">A System.Angle object to compare to this instance.</param>
		/// <returns>True if obj is equal to this instance; False otherwise.</returns>
		public override bool Equals(object obj)
		{
			bool returnValue = false;

			if (obj is Angle)
			{
				Angle compare = obj as Angle;
				returnValue = this.InternalValue.Equals(compare.InternalValue);
			}

			return returnValue;
		}

		/// <summary>
		///Returns the hash code for this instance.
		/// </summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			return this.InternalValue.GetHashCode();
		}
		#endregion

		#region Implicit Conversions
		/// <summary>
		/// Defines an implicit conversion of a System.Angle object to a System.Decimal object.
		/// </summary>
		/// <param name="angle">The object to convert.</param>
		/// <returns>The converted object.</returns>
		public static implicit operator decimal(Angle angle)
		{
			return angle.InternalValue;
		}

		/// <summary>
		/// Defines an implicit conversion of a System.Angle object to a System.Double object.
		/// </summary>
		/// <param name="angle">The object to convert.</param>
		/// <returns>The converted object.</returns>
		public static implicit operator double(Angle angle)
		{
			return Convert.ToDouble(angle.InternalValue);
		}

		/// <summary>
		/// Defines an implicit conversion of a System.Decimal object to a System.Angle object.
		/// </summary>
		/// <param name="degrees">The object to convert.</param>
		/// <returns>The converted object.</returns>
		public static implicit operator Angle(decimal degrees)
		{
			return new Angle(degrees);
		}

		/// <summary>
		/// Defines an implicit conversion of a System.Double object to a System.Angle object.
		/// </summary>
		/// <param name="degrees">The object to convert.</param>
		/// <returns>The converted object.</returns>
		public static implicit operator Angle(double degrees)
		{
			return new Angle(degrees);
		}
		#endregion

		#region Operators
		/// <summary>
		/// Adds two Angles.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>The result of the first Angle being added to the second Angle.</returns>
		public static Angle operator +(Angle a, Angle b)
		{
			return (Angle)(a.InternalValue + b.InternalValue);
		}

		/// <summary>
		/// Subtracts one Angle from another.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>The result of the second Angle being subtracted from the first Angle.</returns>
		public static Angle operator -(Angle a, Angle b)
		{
			return (Angle)(a.InternalValue - b.InternalValue);
		}

		/// <summary>
		/// Multiplies two Angles.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>The result of the first Angle being multiplied by the second Angle.</returns>
		public static Angle operator *(Angle a, Angle b)
		{
			return (Angle)(a.InternalValue * b.InternalValue);
		}

		/// <summary>
		/// Divides two Angles.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>The result of the first Angle being divided by the second Angle.</returns>
		public static Angle operator /(Angle a, Angle b)
		{
			return (Angle)(a.InternalValue / b.InternalValue);
		}

		/// <summary>
		/// Calculates the modulo of two Angles.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>The result of the First Angle mod the Second Angle.</returns>
		public static Angle operator %(Angle a, Angle b)
		{
			return (Angle)(a.InternalValue % b.InternalValue);
		}

		/// <summary>
		/// Increments an Angle by 1 degree.
		/// </summary>
		/// <param name="a">The Angle to increment.</param>
		/// <returns>The result of the Angle being incremented by 1 degree.</returns>
		public static Angle operator ++(Angle a)
		{
			a.InternalValue++;
			return a;
		}

		/// <summary>
		/// Decrements an Angle by 1 degree.
		/// </summary>
		/// <param name="a">The Angle to increment.</param>
		/// <returns>The result of the Angle being decremented by 1 degree.</returns>
		public static Angle operator --(Angle a)
		{
			a.InternalValue--;
			return a;
		}

		/// <summary>
		/// Determines if two Angles are equal.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the two angle are the same, False otherwise.</returns>
		public static bool operator ==(Angle a, Angle b)
		{
			bool returnValue = false;

			if (((object)a) == null && ((object)b) == null)
			{
				returnValue = true;
			}
			else if (((object)a) != null && ((object)b) != null)
			{
				returnValue = a.InternalValue == b.InternalValue;
			}

			return returnValue;
		}

		/// <summary>
		/// Determines if two Angles are not equal.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the two angle are the not same, False otherwise.</returns>
		public static bool operator !=(Angle a, Angle b)
		{
			bool returnValue = true;

			if (((object)a) == null && ((object)b) == null)
			{
				returnValue = false;
			}
			else if (((object)a) != null && ((object)b) != null)
			{
				returnValue = a.InternalValue != b.InternalValue;
			}

			return returnValue;
		}

		/// <summary>
		/// Determines one Angle is greater than another Angle.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the first Angle is greater than the second Angle, False otherwise.</returns>
		public static bool operator >(Angle a, Angle b)
		{
			return a.InternalValue > b.InternalValue;
		}

		/// <summary>
		/// Determines one Angle is greater than or equal to another Angle.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the first Angle is greater than or equal to the second Angle, False otherwise.</returns>
		public static bool operator >=(Angle a, Angle b)
		{
			return a.InternalValue >= b.InternalValue;
		}

		/// <summary>
		/// Determines one Angle is less than another Angle.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the first Angle is less than the second Angle, False otherwise.</returns>
		public static bool operator <(Angle a, Angle b)
		{
			return a.InternalValue < b.InternalValue;
		}

		/// <summary>
		/// Determines one Angle is less than or equal to another Angle.
		/// </summary>
		/// <param name="a">The first Angle.</param>
		/// <param name="b">The second Angle.</param>
		/// <returns>True if the first Angle is less than or equal to the second Angle, False otherwise.</returns>
		public static bool operator <=(Angle a, Angle b)
		{
			return a.InternalValue <= b.InternalValue;
		}

		/// <summary>
		/// Reverses the direction of an Angle by adding 180 degrees.
		/// </summary>
		/// <param name="a">The Angle to reverse.</param>
		/// <returns>The result of the Angle being reversed.</returns>
		public static Angle operator !(Angle a)
		{
			if (a.InternalValue >= 0)
			{
				a.InternalValue += 180M;
			}
			else
			{
				a.InternalValue -= 180M;
			}

			return a;
		}
		#endregion

		#region Static Members
		/// <summary>
		/// Represents the empty Angle. This field is read-only.
		/// </summary>
		public static Angle Empty
		{
			get
			{
				return new Angle(0M);
			}
		}

		/// <summary>
		/// Converts the value of an angle specified in degree, arcminute and arcsecond
		/// values to a decimal-precision floating-point value of the angle. For example
		/// an angle specified as as 9° 14' 55.8'' can be converted to a decimal.
		/// </summary>
		/// <param name="degrees">The whole value portion of the angle in degrees, e.g., 9 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcminute">The arcminute value, e.g., 14 from the angle 9° 14' 55.8''.</param>
		/// <param name="arcsecond">The arcsecond value, e.g., 55.8 from the angle 9° 14' 55.8''.</param>
		/// <returns>The decimal-precision floating-point value of the specified angle.</returns>
		public static decimal ToDegrees(int degrees, int arcminute, decimal arcsecond)
		{
			decimal returnValue = 0M;

			// ***
			// *** Ensure all parameters are the same sing
			// ***
			Angle.NormalDirection(ref degrees, ref arcminute, ref arcsecond);

			// ***
			// *** 15 degrees per hour
			// ***
			returnValue = degrees + (arcminute / 60M) + (arcsecond / 3600M);

			return returnValue;
		}

		/// <summary>
		/// Converts a radian angle to degrees.
		/// </summary>
		/// <param name="radians">The angle in radian units.</param>
		/// <returns>The angle in degree units.</returns>
		public static decimal ToDegrees(decimal radians)
		{
			decimal returnValue = 0M;

			// ***
			// *** Factor = 180 / pi 
			// ***
			returnValue = radians * (180M / Numbers.Pi);

			return returnValue;
		}

		/// <summary>
		/// A radian is the measure of a central angle subtending an arc equal in length to the radius. This method 
		/// converts an angle measured in degrees to radian units.
		/// </summary>
		/// <param name="degrees">The angle in degree units.</param>
		/// <returns>The angle in radian units.</returns>
		public static decimal ToRadians(decimal degrees)
		{
			decimal returnValue = 0M;

			// ***
			// *** Factor = pi / 180 
			// ***
			returnValue = (degrees * Numbers.Pi) / 180M;

			return returnValue;
		}

		/// <summary>
		/// Creates an instance of the System.Angle class from the
		/// specified angle expressed in Radian units.
		/// </summary>
		/// <param name="radians">The angle in radian units.</param>
		/// <returns>A new instance of the System.Angle class.</returns>
		public static Angle FromRadians(decimal radians)
		{
			Angle returnValue = new Angle();

			returnValue = new Angle(Angle.ToDegrees(radians));

			return returnValue;
		}

		/// <summary>
		/// Gets the whole number portion of the value of the given
		/// instance of Angle.
		/// </summary>
		/// <param name="angle">An instance of System.Angle.</param>
		/// <returns>An integer value representing the whole number portion of the angle.</returns>
		public static int GetDegrees(Angle angle)
		{
			int returnValue = 0;

			if ((decimal)angle < 0)
			{
				returnValue = (int)Math.Ceiling((decimal)angle);
			}
			else
			{
				returnValue = (int)Math.Floor((decimal)angle);
			}

			return returnValue;
		}

		/// <summary>
		/// A minute of arc, arcminute, is a unit of angular measurement equal to one sixtieth (1⁄60) of one degree. This method
		/// returns the arcminute portion of the given Angle.
		/// </summary>
		/// <param name="angle">An instance of the System.Angle class.</param>
		/// <returns>The arcminute of the specified angle.</returns>
		public static int GetArcminute(Angle angle)
		{
			int returnValue = 0;

			decimal degreesDecimal = (decimal)angle - (decimal)angle.Degrees;

			if (degreesDecimal < 0)
			{
				returnValue = (int)Math.Ceiling(degreesDecimal * 60M);
			}
			else
			{
				returnValue = (int)Math.Floor(degreesDecimal * 60M);
			}


			return returnValue;
		}

		/// <summary>
		/// A second of arc or arcsecond is one sixtieth (1⁄60) of one arcminute. This method
		/// returns the arcsecond portion of the given Angle.
		/// </summary>
		/// <param name="angle">An instance of the System.Angle class.</param>
		/// <returns>The arcminute of the specified angle.</returns>
		public static decimal GetArcsecond(Angle angle)
		{
			decimal returnValue = 0M;

			decimal degreesDecimal = (decimal)angle - (decimal)angle.Degrees;
			decimal totalMinutes = degreesDecimal * 60;
			decimal secondsDecimal = 0;

			if (totalMinutes < 0)
			{
				secondsDecimal = totalMinutes - Math.Ceiling(totalMinutes);
			}
			else
			{
				secondsDecimal = totalMinutes - Math.Floor(totalMinutes);
			}

			returnValue = Convert.ToDecimal((secondsDecimal) * 60);

			return returnValue;
		}

		/// <summary>
		/// Normalizes an angle to between 0 and 360 degrees.
		/// </summary>
		/// <param name="angle">The angle in degrees to be reduced.</param>
		/// <returns>A representation of the given Angle in degrees where the value is between 0 and 360.</returns>
		public static Angle Reduce(Angle angle)
		{
			Angle returnValue = Angle.Empty;

			returnValue = new Angle((decimal)angle - (Math.Floor((decimal)angle / 360.0M) * 360.0M));

			return returnValue;
		}

		/// <summary>
		/// Converts the string representation of a angle expressed as a number to its 
		/// decimal-precision floating-point number equivalent in degree units.
		/// </summary>
		/// <param name="s">A string that contains a number to convert.</param>
		/// <returns>An instance of System.Angle instantiated with the parsed value.</returns>
		public static Angle Parse(string s)
		{
			Angle returnValue = Angle.Empty;

			if (!Angle.TryParse(s, out returnValue))
			{
				throw new FormatException();
			}

			return returnValue;
		}

		/// <summary>
		/// Converts the string representation of a angle expressed as a number to its 
		/// decimal-precision floating-point number equivalent in degree units. A return 
		/// value indicates whether the conversion succeeded or failed.
		/// </summary>
		/// <param name="s">A string that contains a number to convert.</param>
		/// <param name="result">An instance of System.Angle instantiated with the parsed value.</param>
		/// <returns>True if s was converted successfully; False otherwise.</returns>
		public static bool TryParse(string s, out Angle result)
		{
			bool returnValue = false;
			result = null;

			if (Decimal.TryParse(s, out decimal value))
			{
				result = new Angle(value);
				returnValue = true;
			}

			return returnValue;
		}
		#endregion

		#region Internal Members
		/// <summary>
		/// Represents the internal value of this type. This value is in degrees.
		/// </summary>
		internal decimal InternalValue { get; set; }

		internal static void NormalDirection(ref int degrees, ref int minutes, ref decimal seconds)
		{
			// ***
			// *** If the value for degrees is negative then
			// *** minutes and seconds should be negative. This 
			// *** is due to the fact that these three numbers
			// *** represent one angle and always must have the
			// *** same direction.
			// ***
			if (degrees < 0 || minutes < 0 || seconds < 0)
			{
				degrees = -1 * Math.Abs(degrees);
				minutes = -1 * Math.Abs(minutes);
				seconds = -1 * Math.Abs(seconds);
			}
		}

		internal static void NormalDirection(ref decimal hours, ref int minutes, ref decimal seconds)
		{
			// ***
			// *** If the value for degrees is negative then
			// *** minutes and seconds should be negative. This 
			// *** is due to the fact that these three numbers
			// *** represent one angle and always must have the
			// *** same direction.
			// ***
			if (hours < 0 || minutes < 0 || seconds < 0)
			{
				hours = -1 * Math.Abs(hours);
				minutes = -1 * Math.Abs(minutes);
				seconds = -1 * Math.Abs(seconds);
			}
		}
		#endregion

		#region Formatters
		/// <summary>
		/// Converts the value of this instance to its equivalent string representation.
		/// </summary>
		/// <returns>The string representation of the value of this instance.</returns>
		public override string ToString()
		{
			return this.ToShortFormat();
		}

		/// <summary>
		/// The string representation of the value of this instance using the common
		/// symbol for degrees and a decimal value for the portion that is less than
		/// zero.
		/// </summary>
		/// <returns>The short format string representation of the value of this instance.</returns>
		public string ToShortFormat()
		{
			return this.InternalValue.ToString("0°.0000####");
		}

		/// <summary>
		/// The string representation of the value of this instance displayed in degrees, arcminutes
		/// and arcseonds.
		/// </summary>
		/// <returns>The long format string representation of the value of this instance.</returns>
		public string ToLongFormat()
		{
			return $"{this.Degrees:0}°{Math.Abs(this.Arcminute):0}´{Math.Abs(this.Arcsecond):0}´´";
		}
		#endregion

		#region IComparable
		/// <summary>
		/// Compares this instance with a specified object and indicates
		/// whether this instance precedes, follows, or appears in the same position
		/// as the specified System.Angle.
		/// </summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>A 32-bit signed integer that indicates whether this instance precedes,
		/// follows, or appears in the same position as the value parameter. Value 
		/// Condition Less than zero: This instance precedes obj. Zero: This instance
		/// has the same position as obj. Greater than zero: This instance
		/// follows obj or obj is null.</returns>
		public int CompareTo(object obj)
		{
			int returnValue = 1;

			if (obj is Angle)
			{
				returnValue = this.InternalValue.CompareTo(((Angle)obj).InternalValue);
			}

			return returnValue;
		}
		#endregion

		#region IFormattable
		/// <summary>
		/// Converts the numeric value of this instance to its equivalent string representation
		/// using the specified culture-specific format information.
		/// </summary>
		/// <param name="format">A numeric format string.</param>
		/// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
		/// <returns>The string representation of the value of this instance as specified by format and provider.</returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			string returnValue = String.Empty;

			if (formatProvider != null)
			{
				returnValue = this.InternalValue.ToString(format, formatProvider);
			}
			else
			{
				returnValue = this.InternalValue.ToString(format);
			}

			return returnValue;
		}
		#endregion

		#region IComparable<Angle>
		/// <summary>
		/// Compares this instance with a specified System.Angle object and indicates
		/// whether this instance precedes, follows, or appears in the same position
		/// as the specified System.Angle.
		/// </summary>
		/// <param name="other">The angle to compare with this instance.</param>
		/// <returns>A 32-bit signed integer that indicates whether this instance precedes,
		/// follows, or appears in the same position as the value parameter. Value 
		/// Condition Less than zero: This instance precedes obj. Zero: This instance
		/// has the same position as obj. Greater than zero: This instance
		/// follows other or other is null.</returns>
		public int CompareTo(Angle other)
		{
			int returnValue = 1;

			if (((object)other) != null)
			{
				returnValue = this.InternalValue.CompareTo(other.InternalValue);
			}
			return returnValue;
		}
		#endregion

		#region IEquatable<Angle>
		/// <summary>
		/// Specifies whether this Angle and the specified Angle have the
		/// same value.
		/// </summary>
		/// <param name="other">The Angle to compare to this instance.</param>
		/// <returns>True if the value of the other parameter is the same as this Angle; False otherwise</returns>
		public bool Equals(Angle other)
		{
			bool returnValue = false;

			if (other != null)
			{
				returnValue = this.InternalValue.Equals(other.InternalValue);
			}

			return returnValue;
		}
		#endregion
	}
}