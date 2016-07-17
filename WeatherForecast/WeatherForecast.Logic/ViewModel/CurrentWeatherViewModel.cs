using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WeatherForecast.Logic.Annotations;
using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class CurrentWeatherViewModel : BaseViewModel
	{
		private readonly float _temperature;
		private readonly DateTime _lastUpdate;
		private readonly int _humidity;
		private readonly float _pressure;

		private Unit _unit;

		public string City { get; }
		public string Weather { get; }
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
				if (_unit == value)
					return;

				_unit = value;

				OnPropertyChanged(nameof(Unit));
				OnPropertyChanged(nameof(Temperature));
				OnPropertyChanged(nameof(Pressure));

				if (Wind == null)
					return;

				Wind.Unit = value;
				OnPropertyChanged(nameof(Wind));
			}
		}

		public CurrentWeatherViewModel(float temperature, DateTime lastUpdate, int humidity, float pressure, string city, string weather, WindViewModel wind)
		{
			_temperature = temperature;
			_lastUpdate = lastUpdate;
			_humidity = humidity;
			_pressure = pressure;
			City = city;
			Weather = WeatherFormatter.Capitalize(weather);
			Wind = wind;
		}
	}
}