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
			DateTime dateTime;
			DateTime.TryParse(from, out dateTime);
			From = dateTime;

			dateTime = default(DateTime);
			DateTime.TryParse(to, out dateTime);
			To = dateTime;
		}

		public bool IsEmpty => From == default(DateTime) && To == default(DateTime);

		public override string ToString()
		{
			return $"From {From} to {To}";
		}
	}
}