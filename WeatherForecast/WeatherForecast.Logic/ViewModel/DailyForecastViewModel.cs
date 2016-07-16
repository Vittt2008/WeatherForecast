using System;
using System.Collections.Generic;
using System.Globalization;
using WeatherForecast.Logic.Converter.Temperature;

namespace WeatherForecast.Logic.ViewModel
{
	public class DailyForecastViewModel
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		private Unit _unit;
		private readonly float _temperatureDay;
		private readonly float _temperatureNight;

		public string Weather { get; }
		public DateTime Date { get; }
		public string TemperatureDay => Unit == Unit.Metric ? CelsiusConverter.Convert(_temperatureDay) : FahrenheitConverter.Convert(_temperatureDay);
		public string TemperatureNight => Unit == Unit.Metric ? CelsiusConverter.Convert(_temperatureNight) : FahrenheitConverter.Convert(_temperatureNight);

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				_unit = value;
				HoursForecasts?.ForEach(x => x.Unit = value);
			}
		}

		public List<HoursForecastViewModel> HoursForecasts { get; set; }

		public string Day => Date.ToString("ddd dd", Culture);

		public DailyForecastViewModel(float temperatureDay, float temperatureNight, string weather, DateTime date)
		{
			_temperatureDay = temperatureDay;
			_temperatureNight = temperatureNight;
			Weather = weather;
			Date = date;
		}
	}
}