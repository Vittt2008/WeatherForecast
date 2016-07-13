using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WeatherForecast.Logic.EntityConverter;
using WeatherForecast.Logic.ServiceImpl;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WeatherForecast.App.Control
{
	public sealed partial class WeatherForecastControl : UserControl
	{
		public static readonly DependencyProperty CityProperty =
			DependencyProperty.Register(
				"City",
				typeof(string),
				typeof(WeatherForecastControl),
				new PropertyMetadata(null, CityPropertyChangedCallback));

		private static async void CityPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var city = e.NewValue as string;
			if (string.IsNullOrEmpty(city))
				return;
			var weatherControl = dependencyObject as WeatherForecastControl;
			if (weatherControl == null)
				return;

			var weatherService = new WeatherService();
			var flickrService = new PhotoService();

			var currentWeatherTask = weatherService.GetCurrentWeather(city);
			var dailyWeatherTask = weatherService.GetDailyForecast(city);
			var hoursWeatherTask = weatherService.GetHoursForecast(city);
			var flickrPhotoTask = flickrService.GetFlickUrlPhoto(city);

			await Task.WhenAll(currentWeatherTask, dailyWeatherTask, hoursWeatherTask, flickrPhotoTask);

			var weatherData = await currentWeatherTask;
			var dailyWeatherData = await dailyWeatherTask;
			var hoursWeatherData = await hoursWeatherTask;
			var cityPhotoUrl = (await flickrPhotoTask).RandomPhotoUrl;
			var cityImage = !string.IsNullOrEmpty(cityPhotoUrl)
				? await flickrService.GetImageFromUrl(cityPhotoUrl)
				: new BitmapImage(new Uri("ms-appx:///Assets/city_photo.jpg"));

			var currentWeatherViewModel = weatherData.ToViewModel();
			var dailyViewModels = dailyWeatherData.Times.Select(x => x.ToDailyViewModel()).ToList();
			var hoursViewModels = hoursWeatherData.Times.Select(x => x.ToHoursViewModel()).ToList();
			//var hoursModels = hoursViewModels.GroupBy(x => x.Day).ToList();
			dailyViewModels.ForEach(x => x.HoursForecasts = hoursViewModels.Where(y => x.Date == y.Date).ToList());

			weatherControl.CurrentWeatherControl.CurrentWeather = currentWeatherViewModel;
			weatherControl.DailyWeatherList.ItemsSource = dailyViewModels;
			//weatherControl.HoursWeatherList.ItemsSource = hoursViewModels;
			weatherControl.Root.Background = new ImageBrush
			{
				ImageSource = cityImage,
				Stretch = Stretch.UniformToFill
			};

			//CurrentWeatherControl.DataContext = currentWeatherViewModel;
			//CurrentWeatherControl.CityPhotoImage = cityImage;
			//ListView.ItemsSource = dailyWeather.Times.Select(x => x.ToDailyViewModel()).ToList();
			//ListView.ItemsSource = dailyWeather.Times.Select(x => x.ToHoursViewModel()).ToList();

		}

		public WeatherForecastControl()
		{
			this.InitializeComponent();
		}

		public string City
		{
			get { return (string)GetValue(CityProperty); }
			set { SetValue(CityProperty, value); }
		}
	}
}
