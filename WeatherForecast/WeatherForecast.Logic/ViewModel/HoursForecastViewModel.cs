using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using WeatherForecast.Logic.Annotations;
using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class HoursForecastViewModel:INotifyPropertyChanged
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		private Unit _unit;
		private readonly float _temperature;
		private readonly WindViewModel _wind;
		private readonly float _pressure;
		private readonly int _humidity;
		private readonly string _weather;

		public string Weather => WeatherFormatter.Capitalize(_weather);
		public DateTime DateFrom { get; }
		public DateTime DateTo { get; }
		public string Temperature => Unit == Unit.Metric ? WeatherFormatter.CelciousToCelcious(_temperature) : WeatherFormatter.CelciousToFahrenheit(_temperature);
		public string Wind => _wind.FullInfo;
		public string Pressure => Unit == Unit.Metric ? WeatherFormatter.HPaToMmHg(_pressure) : WeatherFormatter.HPaToInHg(_pressure);
		public string Humidity => WeatherFormatter.FormatHumidity(_humidity);
		public DateTime Date => DateFrom.Date;
		public string Hours => $"{DateFrom.ToString("t")} - {DateTo.ToString("t")}";

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

				if (_wind == null)
					return;

				_wind.Unit = value;
				OnPropertyChanged(nameof(Wind));
			}
		}

		public HoursForecastViewModel(float temperature, WindViewModel wind, float pressure, int humidity, string weather, DateTime dateFrom, DateTime dateTo)
		{
			_temperature = temperature;
			_wind = wind;
			_pressure = pressure;
			_humidity = humidity;
			_weather = weather;
			DateFrom = dateFrom;
			DateTo = dateTo;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}