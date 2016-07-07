using System;

namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class HoursTime
	{
		public DateTime From { get; set; }
		public DateTime To { get; set; }

		public HoursTime()
		{
		}

		public HoursTime(string from, string to)
		{
			From = DateTime.Parse(from);
			To = DateTime.Parse(to);
		}
	}
}