using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.EntityConverter
{
	public static class EntityConverterEx
	{
		public static CurrentWeatherViewModel ToViewModel(this CurrentWeather currentWeather)
		{
			var viewModel = new CurrentWeatherViewModel(
				currentWeather.Temperature.Value,
				currentWeather.LastUpdate.LocalTime,
				currentWeather.Humidity.Value,
				currentWeather.Pressure.Value,
				currentWeather.City.ToString(),
				currentWeather.Weather.Value,
				new WindViewModel
				{
					Name = currentWeather.Wind.Speed.Name,
					Value = currentWeather.Wind.Speed.Value,
					DirectionName = currentWeather.Wind.Direction.Name,
					DirectionValue = currentWeather.Wind.Direction.Value
				});
			return viewModel;
		}

		public static DailyForecastViewModel ToDailyViewModel(this Time time)
		{
			var viewModel = new DailyForecastViewModel(
				time.Temperature.Day,
				time.Temperature.Night,
				time.Symbol.Name,
				time.Day);
			return viewModel;
		}

		public static HoursForecastViewModel ToHoursViewModel(this Time time)
		{
			var viewModel = new HoursForecastViewModel(
				time.Temperature.Value,
				new WindViewModel
				{
					Name = time.WindSpeed.Name,
					Value = time.WindSpeed.Mps,
					DirectionName = time.WindDirection.Name,
					DirectionValue = time.WindDirection.Deg
				},
				time.Pressure.Value,
				time.Humidity.Value,
				time.Symbol.Name,
				time.HoursTime.LocalFrom,
				time.HoursTime.LocalTo);
			return viewModel;
		}
	}
}