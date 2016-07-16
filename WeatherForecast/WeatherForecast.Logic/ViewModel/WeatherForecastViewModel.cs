using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media.Imaging;

namespace WeatherForecast.Logic.ViewModel
{
	public class WeatherForecastViewModel
	{
		private Unit _unit;
		public BitmapImage CityPhoto { get; set; }
		public CurrentWeatherViewModel CurrentWeather { get; set; }
		public List<DailyForecastViewModel> DailyWeather { get; set; }

		public Unit Unit
		{
			get { return _unit; }
			set
			{
				_unit = value;
				if (CurrentWeather != null)
					CurrentWeather.Unit = value;
				DailyWeather?.ForEach(x => x.Unit = value);
			}
		}
	}
}