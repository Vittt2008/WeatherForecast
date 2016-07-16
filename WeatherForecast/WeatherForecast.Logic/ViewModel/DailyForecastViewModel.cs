using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using WeatherForecast.Logic.Annotations;
using WeatherForecast.Logic.Converter;

namespace WeatherForecast.Logic.ViewModel
{
	public class DailyForecastViewModel : INotifyPropertyChanged
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		private Unit _unit;
		private readonly float _temperatureDay;
		private readonly float _temperatureNight;
		private readonly string _weather;

		public string Weather => WeatherFormatter.Capitalize(_weather);
		public DateTime Date { get; }
		public string TemperatureDay => Unit == Unit.Metric ? WeatherFormatter.CelciousToCelcious(_temperatureDay) : WeatherFormatter.CelciousToFahrenheit(_temperatureDay);
		public string TemperatureNight => Unit == Unit.Metric ? WeatherFormatter.CelciousToCelcious(_temperatureNight) : WeatherFormatter.CelciousToFahrenheit(_temperatureNight);
		public string Day => Date.ToString("ddd dd", Culture);
		public List<HoursForecastViewModel> HoursForecasts { get; set; }

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				if (_unit == value)
					return;

				_unit = value;
				OnPropertyChanged(nameof(Unit));
				OnPropertyChanged(nameof(TemperatureDay));
				OnPropertyChanged(nameof(TemperatureNight));

				if (HoursForecasts == null)
					return;

				HoursForecasts.ForEach(x => x.Unit = value);
				OnPropertyChanged(nameof(HoursForecasts));
			}
		}

		public DailyForecastViewModel(float temperatureDay, float temperatureNight, string weather, DateTime date)
		{
			_temperatureDay = temperatureDay;
			_temperatureNight = temperatureNight;
			_weather = weather;
			Date = date;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}