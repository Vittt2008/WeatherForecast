using System;

namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class HoursTime
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }

		public DateTime LocalFrom => From.ToLocalTime();
		public DateTime LocalTo => To.ToLocalTime();

		public HoursTime()
		{
		}

		public HoursTime(DateTime from, DateTime to)
		{
			From = from;
			To = to;
		}

		public bool IsEmpty => From == default(DateTime) && To == default(DateTime);

		public override string ToString()
		{
			return $"From {LocalFrom} to {LocalTo}";
		}
	}
}