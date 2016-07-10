using System;

namespace WeatherForecast.Logic.ViewModel
{
	public class CurrentWeatherViewModel
	{
		public string City { get; set; }
		public string Weather { get; set; }
		public float Temperature { get; set; }
		public DateTime LastUpdate { get; set; }
		public float Humidity { get; set; }
		public float Pressure { get; set; }
		public WindViewModel Wind { get; set; }
	}
}