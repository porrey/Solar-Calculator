using System;

namespace Innovative.Geometry.Tests
{
	public class TestData
	{
		static Random Rnd = new Random((int)DateTime.Now.Ticks);

		public TestData()
		{
			this.Angle1 = -720 + ((decimal)Rnd.NextDouble() * (2 * 720));
			this.Angle2 = -720 + ((decimal)Rnd.NextDouble() * (2 * 720));
			this.Radians = this.ToRadians(this.Angle1);
			this.Degrees = this.Angle1 < 0 ? Math.Ceiling(this.Angle1) : Math.Floor(this.Angle1);
			this.DecimalMinutes = (this.Angle1 - this.Degrees) * 60;
			this.Arcminute = this.DecimalMinutes < 0 ? Math.Ceiling(this.DecimalMinutes) : Math.Floor(this.DecimalMinutes);
			this.Arcsecond = (this.DecimalMinutes - this.Arcminute) * 60;
			this.LongFormat = $"{this.Degrees:0}°{Math.Abs(this.Arcminute):0}´{Math.Abs(this.Arcsecond):0}´´";
			this.ShortFormat = this.Angle1.ToString("0°.0000####");
			this.RandomNumber = Rnd.Next(1, 500);
			this.RadiansMultiplied = this.ToRadians(this.Angle1 * this.RandomNumber);
			this.RadiansDivided = this.ToRadians(this.Angle1 / this.RandomNumber);
			this.ReducedDegrees = this.Angle1 - (Math.Floor(this.Angle1 / 360M) * 360M);
			this.TotalMinutes = (this.Degrees * 60M) + this.Arcminute + (this.Arcsecond / 60M);
			this.TotalSeconds = (this.Degrees * 3600) + (this.Arcminute * 60) + this.Arcsecond;
			this.OppositeDirection = this.Angle1 >= 0 ? this.Angle1 + 180 : this.Angle1 - 180;
		}

		public decimal Angle1 { get; protected set; }
		public decimal Angle2 { get; protected set; }
		public decimal Radians { get; protected set; }
		public decimal Degrees { get; protected set; }
		public decimal DecimalMinutes { get; protected set; }
		public decimal Arcminute { get; protected set; }
		public decimal Arcsecond { get; protected set; }
		public string LongFormat { get; protected set; }
		public string ShortFormat { get; protected set; }
		public decimal RandomNumber { get; protected set; }
		public decimal RadiansMultiplied { get; protected set; }
		public decimal RadiansDivided { get; protected set; }
		public decimal ReducedDegrees { get; protected set; }
		public decimal TotalMinutes { get; protected set; }
		public decimal TotalSeconds { get; protected set; }
		public decimal OppositeDirection { get; protected set; }

		private decimal ToRadians(decimal angle)
		{
			return (decimal)Math.PI * angle / 180M;
		}
	}
}