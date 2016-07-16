using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter.Temperature
{
	public class FahrenheitConverter : IValueConverter
	{
		public const float FahrenheitOffset = 32f;
		public const float FahrenheitFactor = 1.8f;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var celcius = (float)value;
			var fahrenheit = celcius * FahrenheitFactor + FahrenheitOffset;
			var fahrenheitString = string.Format("{0:##.##}°F", fahrenheit);
			return fahrenheitString;
		}


		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			var fahrenheitString = value as string;
			if (string.IsNullOrEmpty(fahrenheitString))
				return 0;
			fahrenheitString = fahrenheitString.Replace("°F", string.Empty);
			var fahrenheit = float.Parse(fahrenheitString);
			var celcious = (fahrenheit - FahrenheitOffset) / FahrenheitFactor;
			return celcious;
		}

		public static string Convert(float temperature)
		{
			var fahrenheit = temperature * FahrenheitFactor + FahrenheitOffset;
			var fahrenheitString = string.Format("{0:##.##}°F", fahrenheit);
			return fahrenheitString;
		}
	}
}