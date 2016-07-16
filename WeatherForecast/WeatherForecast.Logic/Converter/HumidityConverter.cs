using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter
{
	public class HumidityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var humidity = (int)value;
			return string.Format("Humidity {0}%", humidity);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}

		public static string Convert(int humidity)
		{
			return string.Format("Humidity {0}%", humidity);
		}
	}
}