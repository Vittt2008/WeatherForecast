using System;

namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class DailyTime
	{
		public DateTime Day { get; set; }

		public DailyTime()
		{
		}

		public DailyTime(string day)
		{
			Day = DateTime.Parse(day);
		}
	}
}