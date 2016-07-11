using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter.Temperature
{
	public class CelsiusConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var celciousString = string.Format("{0:##.##}°C", value);
			return celciousString;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			var celciousString = value as string;
			if (string.IsNullOrEmpty(celciousString))
				return 0;
			celciousString = celciousString.Replace("°C", string.Empty);
			var celcious = float.Parse(celciousString);
			return celcious;
		}
	}
}