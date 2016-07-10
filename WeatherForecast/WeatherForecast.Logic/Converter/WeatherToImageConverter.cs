using System;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using WeatherForecast.Logic.Entity.Forecast;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Converter
{
	public class WeatherToImageConverter : IValueConverter
	{
		public const string BrokenClouds = "broken clouds";
		public const string ClearSky = "clear sky";
		public const string FewClouds = "few clouds";
		public const string HeavyIntensityRain = "heavy intensity rain";
		public const string LightRain = "light rain";
		public const string ModerateRain = "moderate rain";
		public const string OvercastClouds = "overcast clouds";
		public const string ScatteredClouds = "scattered clouds";

		public const string ImageFormat = "ms-appx:///Assets/Weather/{0}";

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var weather = string.Empty;
			var time = value as Time;
			if (time != null)
				weather = time.Symbol.Name;

			var currentWeather = value as CurrentWeather;
			if (currentWeather != null)
				weather = currentWeather.Weather.Value;

			if (string.IsNullOrEmpty(weather))
				return null;

			switch (weather)
			{
				case BrokenClouds:
					weather = string.Format(ImageFormat, "cloudy2.png");
					break;
				case ClearSky:
					weather = string.Format(ImageFormat, "sunny.png");
					break;
				case FewClouds:
					weather = string.Format(ImageFormat, "cloudy3.png");
					break;
				case HeavyIntensityRain:
					weather = string.Format(ImageFormat, "tstorm3.png");
					break;
				case LightRain:
					weather = string.Format(ImageFormat, "shower1.png");
					break;
				case ModerateRain:
					weather = string.Format(ImageFormat, "shower2.png");
					break;
				case OvercastClouds:
					weather = string.Format(ImageFormat, "cloudy5.png");
					break;
				case ScatteredClouds:
					weather = string.Format(ImageFormat, "fog.png");
					break;
				default:
					weather = string.Format(ImageFormat, "dunno.png");
					break;
			}

			return new BitmapImage(new Uri(weather));
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}