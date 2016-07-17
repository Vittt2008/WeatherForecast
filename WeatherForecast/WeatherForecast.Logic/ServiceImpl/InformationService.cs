using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.Entity;
using WeatherForecast.Logic.EntityConverter;
using WeatherForecast.Logic.Service;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.ServiceImpl
{
	public class InformationService
	{
		private readonly IWeatherService _weatherService;
		private readonly IPhotoService _flickrService;

		public InformationService()
		{
			_weatherService = new WeatherService();
			_flickrService = new PhotoService();
		}

		public InformationService(IWeatherService weatherService, IPhotoService photoService)
		{
			_weatherService = weatherService;
			_flickrService = photoService;
		}

		public async Task<WeatherForecastInfo> GetWeatherAsync(string city)
		{
			var currentWeatherTask = _weatherService.GetCurrentWeatherAsync(city);
			var dailyWeatherTask = _weatherService.GetDailyForecastAsync(city);
			var hoursWeatherTask = _weatherService.GetHoursForecastAsync(city);
			var flickrPhotoTask = _flickrService.GetFlickUrlPhotoAsync(city);

			await Task.WhenAll(currentWeatherTask, dailyWeatherTask, hoursWeatherTask, flickrPhotoTask);

			var weatherData = await currentWeatherTask;
			var dailyWeatherData = await dailyWeatherTask;
			var hoursWeatherData = await hoursWeatherTask;
			var cityPhotoUrl = (await flickrPhotoTask).RandomPhotoUrl;
			var cityImage = !string.IsNullOrEmpty(cityPhotoUrl)
				? await _flickrService.GetImageFromUrlAsync(cityPhotoUrl)
				: new BitmapImage(new Uri("ms-appx:///Assets/city_photo.jpg"));

			var currentWeatherViewModel = weatherData.ToViewModel();
			var dailyViewModels = dailyWeatherData.Times.Select(x => x.ToDailyViewModel()).ToList();
			var hoursViewModels = hoursWeatherData.Times.Select(x => x.ToHoursViewModel()).ToList();
			dailyViewModels.ForEach(x => x.HoursForecasts = hoursViewModels.Where(y => x.Date == y.Date).ToList());

			var weatherForecast = new WeatherForecastInfo
			{
				CityPhoto = cityImage,
				CurrentWeather = currentWeatherViewModel,
				DailyWeather = dailyViewModels
			};
			return weatherForecast;
		}
	}
}