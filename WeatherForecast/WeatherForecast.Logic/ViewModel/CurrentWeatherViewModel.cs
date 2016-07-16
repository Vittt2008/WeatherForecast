using System;
using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class CurrentWeatherViewModel
	{
		private readonly float _temperature;
		private readonly DateTime _lastUpdate;
		private readonly int _humidity;
		private readonly float _pressure;
		private Unit _unit;
		private readonly string _weather;

		public string City { get; }
		public string Weather => WeatherFormatter.Capitalize(_weather);
		public string Temperature => Unit == Unit.Metric ? WeatherFormatter.CelciousToCelcious(_temperature) : WeatherFormatter.CelciousToFahrenheit(_temperature);
		public string LastUpdate => WeatherFormatter.FormatLastUpdateDateTime(_lastUpdate);
		public string Humidity => WeatherFormatter.FormatHumidity(_humidity);
		public string Pressure => Unit == Unit.Metric ? WeatherFormatter.HPaToMmHg(_pressure) : WeatherFormatter.HPaToInHg(_pressure);
		public WindViewModel Wind { get; }

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				_unit = value;
				if (Wind != null)
					Wind.Unit = value;
			}
		}

		public CurrentWeatherViewModel(float temperature, DateTime lastUpdate, int humidity, float pressure, string city, string weather, WindViewModel wind)
		{
			_temperature = temperature;
			_lastUpdate = lastUpdate;
			_humidity = humidity;
			_pressure = pressure;
			City = city;
			_weather = weather;
			Wind = wind;
		}
	}
}