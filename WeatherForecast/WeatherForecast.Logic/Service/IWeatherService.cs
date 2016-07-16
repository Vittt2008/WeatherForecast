using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Service
{
	public interface IWeatherService
	{
		Task<WeatherData> GetDailyForecastAsync(string city);

		Task<WeatherData> GetHoursForecastAsync(string city);

		Task<CurrentWeather> GetCurrentWeatherAsync(string city);
	}
}