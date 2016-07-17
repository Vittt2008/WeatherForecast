using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WeatherForecast.Logic.Entity;
using WeatherForecast.Logic.ServiceImpl;
using WeatherForecast.Logic.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WeatherForecast.App.Control
{
	public sealed partial class WeatherForecastControl : UserControl
	{
		public static readonly DependencyProperty WeatherViewModelProperty =
			DependencyProperty.Register(
				"WeatherViewModel",
				typeof(WeatherForecastViewModel),
				typeof(WeatherForecastControl),
				new PropertyMetadata(null, WeatherViewModelPropertyChangedCallback));

		private static void WeatherViewModelPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var viewModel = e.NewValue as WeatherForecastViewModel;
			if (viewModel == null)
				return;

			var weatherControl = dependencyObject as WeatherForecastControl;
			if (weatherControl == null)
				return;

			weatherControl.DataContext = viewModel;
		}


		public WeatherForecastControl()
		{
			InitializeComponent();
			WeatherViewModel = new WeatherForecastViewModel();
		}

		private WeatherForecastViewModel WeatherViewModel
		{
			get { return (WeatherForecastViewModel)GetValue(WeatherViewModelProperty); }
			set { SetValue(WeatherViewModelProperty, value); }
		}

		public void UpdateWeatherInfo(WeatherForecastInfo weatherForecastInfo)
		{
			WeatherViewModel.UpdateWeatherInfo(weatherForecastInfo);
		}

		public WeatherForecastInfo WeatherInfo
		{
			get
			{
				return new WeatherForecastInfo
				{
					CityPhoto = WeatherViewModel.CityPhoto,
					CurrentWeather = WeatherViewModel.CurrentWeather,
					DailyWeather = WeatherViewModel.DailyWeather
				};
			}
			set
			{
				if (value == null)
					return;
				WeatherViewModel.UpdateWeatherInfo(value);
			}
		}
	}
}
