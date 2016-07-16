using System;
using WeatherForecast.Logic.Converter;
using WeatherForecast.Logic.Converter.Pressure;
using WeatherForecast.Logic.Converter.Temperature;

namespace WeatherForecast.Logic.ViewModel
{
	public class CurrentWeatherViewModel
	{
		private readonly float _temperature;
		private readonly DateTime _lastUpdate;
		private readonly int _humidity;
		private readonly float _pressure;
		private Unit _unit;

		public string City { get; }
		public string Weather { get; }
		public string Temperature => Unit == Unit.Metric ? CelsiusConverter.Convert(_temperature) : FahrenheitConverter.Convert(_temperature);
		public string LastUpdate => LastUpdateConverter.Convert(_lastUpdate);
		public string Humidity => HumidityConverter.Convert(_humidity);
		public string Pressure => Unit == Unit.Metric ? MmHgConverter.Convert(_pressure) : InHgConverter.Convert(_pressure);
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
			Weather = weather;
			Wind = wind;
		}
	}
}