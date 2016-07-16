using System.Threading.Tasks;
using Refit;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Service
{
	public interface IWeatherServiceInternal
	{
		[Get("/forecast/daily?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetDailyForecastAsync([AliasAs("q")] string city);

		[Get("/forecast?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetHoursForecastAsync([AliasAs("q")] string city);

		[Get("/weather?mode=xml&appid=eb557a07b4881ed2676fd4fa55d646a2&units=metric")]
		Task<string> GetCurrentWeatherAsync([AliasAs("q")] string city);
	}
}