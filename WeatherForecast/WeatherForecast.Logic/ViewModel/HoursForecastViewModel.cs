using System;
using System.Globalization;

namespace WeatherForecast.Logic.ViewModel
{
	public class HoursForecastViewModel
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		public string Weather { get; set; }
		public DateTime DateFrom { get; set; }
		public DateTime DateTo { get; set; }
		public float Temperature { get; set; }
		public WindViewModel Wind { get; set; }
		public float Pressure { get; set; }
		public int Humidity { get; set; }

		public string Hours => $"{DateFrom.ToString("t")} - {DateTo.ToString("t")}";
	}
}