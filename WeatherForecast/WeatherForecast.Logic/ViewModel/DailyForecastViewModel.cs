using System;
using System.Globalization;

namespace WeatherForecast.Logic.ViewModel
{
	public class DailyForecastViewModel
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		public string Weather { get; set; }
		public DateTime Date { get; set; }
		public float TemperatureDay { get; set; }
		public float TemperatureNight { get; set; }

		public string Day => Date.ToString("ddd dd", Culture);
	}
}