using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.Entity
{
	public class WeatherForecastInfo
	{
		public BitmapImage CityPhoto { get; set; }
		public CurrentWeatherViewModel CurrentWeather { get; set; }
		public List<DailyForecastViewModel> DailyWeather { get; set; }
	}
}