using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Converter;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;
using WeatherForecast.Logic.Service;

namespace WeatherForecast.Logic.ServiceImpl
{
	public class WeatherService : IWeatherService
	{
		public const string WeatherForecastServerName = "http://api.openweathermap.org/data/2.5/";

		private readonly IWeatherServiceInternal _weatherService;

		public WeatherService()
		{
			_weatherService = RestService.For<IWeatherServiceInternal>(WeatherForecastServerName);
		}

		public WeatherService(IWeatherServiceInternal weatherService)
		{
			_weatherService = weatherService;
		}

		public async Task<WeatherData> GetDailyForecastAsync(string city)
		{
			var data = await _weatherService.GetDailyForecastAsync(city);
			var weatherData = data.DeserializeTo<WeatherData>();
			return weatherData;
		}

		public async Task<WeatherData> GetHoursForecastAsync(string city)
		{
			var data = await _weatherService.GetHoursForecastAsync(city);
			var weatherData = data.DeserializeTo<WeatherData>();
			return weatherData;
		}

		public async Task<CurrentWeather> GetCurrentWeatherAsync(string city)
		{
			var data = await _weatherService.GetCurrentWeatherAsync(city);
			var weatherData = data.DeserializeTo<CurrentWeather>();
			return weatherData;
		}
	}
}