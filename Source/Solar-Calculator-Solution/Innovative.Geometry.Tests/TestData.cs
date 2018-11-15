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
			this.Minutes = this.DecimalMinutes < 0 ? Math.Ceiling(this.DecimalMinutes) : Math.Floor(this.DecimalMinutes);
			this.Seconds = (this.DecimalMinutes - this.Minutes) * 60;
			this.LongFormat = $"{this.Degrees}°{Math.Abs(this.Minutes):0}´{Math.Abs(this.Seconds):0}´´";
			this.ShortFormat = $"{this.Angle1:0°.0000####}";
			this.RandomNumber = Rnd.Next(1, 500);
			this.RadiansMultiplied = this.ToRadians(this.Angle1 * this.RandomNumber);
			this.RadiansDivided = this.ToRadians(this.Angle1 / this.RandomNumber);
			this.ReducedDegrees = this.Angle1 - (Math.Floor(this.Angle1 / 360M) * 360M);
			this.TotalMinutes = (this.Degrees * 60M) + this.Minutes + (this.Seconds / 60M);
			this.TotalSeconds = (this.Degrees * 3600) + (this.Minutes * 60) + this.Seconds;
			this.OppositeDirection = this.Angle1 >= 0 ? this.Angle1 + 180 : this.Angle1 - 180;
		}

		public decimal Angle1 { get; protected set; }
		public decimal Angle2 { get; protected set; }
		public decimal Radians { get; protected set; }
		public decimal Degrees { get; protected set; }
		public decimal DecimalMinutes { get; protected set; }
		public decimal Minutes { get; protected set; }
		public decimal Seconds { get; protected set; }
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
