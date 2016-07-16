using System;
using System.Globalization;
using WeatherForecast.Logic.Converter;
using WeatherForecast.Logic.Converter.Pressure;
using WeatherForecast.Logic.Converter.Temperature;

namespace WeatherForecast.Logic.ViewModel
{
	public class HoursForecastViewModel
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		private Unit _unit;
		private readonly float _temperature;
		private readonly WindViewModel _wind;
		private readonly float _pressure;
		private readonly int _humidity;
		
		public string Weather { get; }
		public DateTime DateFrom { get; }
		public DateTime DateTo { get; }
		public string Temperature =>Unit == Unit.Metric? CelsiusConverter.Convert(_temperature) : FahrenheitConverter.Convert(_temperature);
		public string Wind => _wind.ToString();
		public string Pressure => Unit == Unit.Metric ? MmHgConverter.Convert(_pressure) : InHgConverter.Convert(_pressure);
		public string Humidity => HumidityConverter.Convert(_humidity);

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				_unit = value;
				if (_wind != null)
					_wind.Unit = value;
			}
		}

		public DateTime Date => DateFrom.Date;
		public string Hours => $"{DateFrom.ToString("t")} - {DateTo.ToString("t")}";

		public HoursForecastViewModel(float temperature, WindViewModel wind, float pressure, int humidity, string weather, DateTime dateFrom, DateTime dateTo)
		{
			_temperature = temperature;
			_wind = wind;
			_pressure = pressure;
			_humidity = humidity;
			Weather = weather;
			DateFrom = dateFrom;
			DateTo = dateTo;
		}
	}
}