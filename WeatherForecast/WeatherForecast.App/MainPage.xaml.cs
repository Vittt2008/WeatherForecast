using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			//var weatherViewModel = await new InformationService().GetWeatherAsync("Moscow");
			//WeatherForecastControl.WeatherViewModel = weatherViewModel;
		}
	}
}
