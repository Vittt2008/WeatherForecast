using System;
using Windows.Web.Syndication;

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
			DateTime dateTime;
			DateTime.TryParse(day, out dateTime);
			Day = dateTime;
		}

		public bool IsEmpty => Day == default(DateTime);

		public override string ToString()
		{
			return $"Day {Day}";
		}
	}
}