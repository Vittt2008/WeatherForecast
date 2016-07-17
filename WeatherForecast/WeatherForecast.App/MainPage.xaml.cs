using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WeatherForecast.Logic.ServiceImpl;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherForecast.App
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void PageLoaded(object sender, RoutedEventArgs e)
		{
			await UpdateWeatherAsync();
		}

		private async void CityNameOnLostFocus(object sender, RoutedEventArgs e)
		{
			await UpdateWeatherAsync();
		}

		private async void CityNameOnKeyDown(object sender, KeyRoutedEventArgs e)
		{
			if (e.Key == VirtualKey.Enter)
			{
				e.Handled = true;
				await UpdateWeatherAsync();
			}
		}

		private async Task UpdateWeatherAsync()
		{
			if (string.IsNullOrEmpty(CityName.Text))
				return;
			
			var weatherInfo = await new InformationService().GetWeatherAsync(CityName.Text);
			WeatherForecastControl.WeatherInfo = weatherInfo;
		}
	}
}
