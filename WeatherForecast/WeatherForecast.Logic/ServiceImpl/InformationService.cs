using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.EntityConverter;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.ServiceImpl
{
	public class InformationService
	{
		private readonly WeatherService _weatherService;
		private readonly PhotoService _flickrService;

		public InformationService()
		{
			_weatherService = new WeatherService();
			_flickrService = new PhotoService();
		}

		public async Task<WeatherForecastViewModel> GetWeather(string city)
		{
			var currentWeatherTask = _weatherService.GetCurrentWeather(city);
			var dailyWeatherTask = _weatherService.GetDailyForecast(city);
			var hoursWeatherTask = _weatherService.GetHoursForecast(city);
			var flickrPhotoTask = _flickrService.GetFlickUrlPhoto(city);

			await Task.WhenAll(currentWeatherTask, dailyWeatherTask, hoursWeatherTask, flickrPhotoTask);

			var weatherData = await currentWeatherTask;
			var dailyWeatherData = await dailyWeatherTask;
			var hoursWeatherData = await hoursWeatherTask;
			var cityPhotoUrl = (await flickrPhotoTask).RandomPhotoUrl;
			var cityImage = !string.IsNullOrEmpty(cityPhotoUrl)
				? await _flickrService.GetImageFromUrl(cityPhotoUrl)
				: new BitmapImage(new Uri("ms-appx:///Assets/city_photo.jpg"));

			var currentWeatherViewModel = weatherData.ToViewModel();
			var dailyViewModels = dailyWeatherData.Times.Select(x => x.ToDailyViewModel()).ToList();
			var hoursViewModels = hoursWeatherData.Times.Select(x => x.ToHoursViewModel()).ToList();
			dailyViewModels.ForEach(x => x.HoursForecasts = hoursViewModels.Where(y => x.Date == y.Date).ToList());

			var weatherForecastViewModel = new WeatherForecastViewModel
			{
				CityPhoto = cityImage,
				CurrentWeather = currentWeatherViewModel,
				DailyWeather = dailyViewModels
			};
			return weatherForecastViewModel;
		}
	}
}