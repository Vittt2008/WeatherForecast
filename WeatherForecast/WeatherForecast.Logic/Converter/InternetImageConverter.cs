using System;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace WeatherForecast.Logic.Converter
{
	public class InternetImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var url = value as string;
			return null;
			//url = "https://pp.vk.me/c631817/v631817060/36aee/MQsTgw8HECk.jpg";
			var bitmap = new BitmapImage(new Uri(url));
			var brush = new ImageBrush { ImageSource = bitmap };
			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new System.NotImplementedException();
		}
	}
}