using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.Annotations;

namespace WeatherForecast.Logic.ViewModel
{
	public class WeatherForecastViewModel : BaseViewModel
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
				if (_unit == value)
					return;

				_unit = value;
				OnPropertyChanged(nameof(Unit));

				if (CurrentWeather != null)
				{
					CurrentWeather.Unit = value;
					OnPropertyChanged(nameof(CurrentWeather));
				}

				if (DailyWeather != null)
				{
					DailyWeather?.ForEach(x => x.Unit = value);
					OnPropertyChanged(nameof(DailyWeather));
				}
			}
		}
	}
}