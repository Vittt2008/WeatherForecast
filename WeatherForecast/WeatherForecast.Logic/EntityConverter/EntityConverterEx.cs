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
	}
}