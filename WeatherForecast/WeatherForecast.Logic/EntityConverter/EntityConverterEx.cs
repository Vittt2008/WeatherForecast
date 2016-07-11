using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.EntityConverter
{
	public static class EntityConverterEx
	{
		public static CurrentWeatherViewModel ToViewModel(this CurrentWeather currentWeather)
		{
			var viewModel = new CurrentWeatherViewModel
			{
				City = currentWeather.City.ToString(),
				Humidity = currentWeather.Humidity.Value,
				LastUpdate = currentWeather.LastUpdate.LocalTime,
				Pressure = currentWeather.Pressure.Value,
				Temperature = currentWeather.Temperature.Value,
				Weather = currentWeather.Weather.Value,
				Wind = new WindViewModel
				{
					Name = currentWeather.Wind.Speed.Name,
					Value = currentWeather.Wind.Speed.Value,
					DirectionName = currentWeather.Wind.Direction.Name,
					DirectionValue = currentWeather.Wind.Direction.Value
				}
			};
			return viewModel;
		}

		public static DailyForecastViewModel ToDailyViewModel(this Time time)
		{
			var viewModel = new DailyForecastViewModel
			{
				Weather = time.Symbol.Name,
				Date = time.Day,
				TemperatureDay = time.Temperature.Day,
				TemperatureNight = time.Temperature.Night
			};
			return viewModel;
		}

		public static HoursForecastViewModel ToHoursViewModel(this Time time)
		{
			var viewModel = new HoursForecastViewModel()
			{
				Weather = time.Symbol.Name,
				DateFrom = time.HoursTime.LocalFrom,
				DateTo = time.HoursTime.LocalTo,
				Temperature = time.Temperature.Value,
				Wind = new WindViewModel
				{
					Name = time.WindSpeed.Name,
					Value = time.WindSpeed.Mps,
					DirectionName = time.WindDirection.Name,
					DirectionValue = time.WindDirection.Deg
				},
				Pressure = time.Pressure.Value,
				Humidity = time.Humidity.Value
			};
			return viewModel;
		}
	}
}