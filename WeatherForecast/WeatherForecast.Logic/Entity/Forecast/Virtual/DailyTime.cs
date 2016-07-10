using System;
using Windows.Web.Syndication;

namespace WeatherForecast.Logic.Entity.Forecast.Virtual
{
	public class DailyTime
	{
		public DateTime Day { get; set; }
		public DateTime LocalDay => Day.ToLocalTime();

		public DailyTime()
		{
		}

		public DailyTime(DateTime day)
		{
			Day = day;
		}

		public bool IsEmpty => Day == default(DateTime);

		public override string ToString()
		{
			return LocalDay.ToString();
		}
	}
}