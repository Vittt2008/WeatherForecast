using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Service
{
	public interface IWeatherServiceInternal
	{
		[Get("/forecast/daily?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetDailyForecast([AliasAs("q")] string city);

		[Get("/forecast?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetHoursForecast([AliasAs("q")] string city);

		[Get("/weather?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetCurrentWeather([AliasAs("q")] string city);
	}
}