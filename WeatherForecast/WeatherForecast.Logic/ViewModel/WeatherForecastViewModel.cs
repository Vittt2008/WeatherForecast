using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.Annotations;
using WeatherForecast.Logic.Entity;

namespace WeatherForecast.Logic.ViewModel
{
	public class WeatherForecastViewModel : BaseViewModel
	{
		private Unit _unit;
		private BitmapImage _cityPhoto;
		private CurrentWeatherViewModel _currentWeather;
		private List<DailyForecastViewModel> _dailyWeather;

		public BitmapImage CityPhoto
		{
			get { return _cityPhoto; }
			set
			{
				if (_cityPhoto == value)
					return;

				_cityPhoto = value;
				OnPropertyChanged(nameof(CityPhoto));
			}
		}

		public CurrentWeatherViewModel CurrentWeather
		{
			get { return _currentWeather; }
			set
			{
				if (_currentWeather == value)
					return;

				_currentWeather = value;
				OnPropertyChanged(nameof(CurrentWeather));
			}
		}

		public List<DailyForecastViewModel> DailyWeather
		{
			get { return _dailyWeather; }
			set
			{
				if (_dailyWeather == value)
					return;

				_dailyWeather = value;
				OnPropertyChanged(nameof(DailyWeather));
			}
		}

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

		public ICommand ChangeUnitCommand => new DelegateCommand(data => Unit = Unit == Unit.Metric ? Unit.Imperial : Unit.Metric);

		public void UpdateWeatherInfo(WeatherForecastInfo newViewModel)
		{
			CityPhoto = newViewModel.CityPhoto;
			CurrentWeather = newViewModel.CurrentWeather;
			DailyWeather = newViewModel.DailyWeather;
		}
	}
}