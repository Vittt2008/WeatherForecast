using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Service
{
	public interface IWeatherService
	{
		Task<WeatherData> GetDailyForecast(string city);

		Task<WeatherData> GetHoursForecast(string city);

		Task<CurrentWeather> GetCurrentWeather(string city);
	}
}