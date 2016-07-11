using System.Threading.Tasks;
using Refit;
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

		public async Task<WeatherData> GetDailyForecast(string city)
		{
			var data = await _weatherService.GetDailyForecast(city);
			var weatherData = data.Parse<WeatherData>();
			return weatherData;
		}

		public async Task<WeatherData> GetHoursForecast(string city)
		{
			var data = await _weatherService.GetHoursForecast(city);
			var weatherData = data.Parse<WeatherData>();
			return weatherData;
		}

		public async Task<CurrentWeather> GetCurrentWeather(string city)
		{
			var data = await _weatherService.GetCurrentWeather(city);
			var weatherData = data.Parse<CurrentWeather>();
			return weatherData;
		}
	}
}