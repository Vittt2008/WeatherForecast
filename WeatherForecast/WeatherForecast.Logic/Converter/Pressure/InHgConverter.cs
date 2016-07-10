using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter.Pressure
{
	public class InHgConverter : IValueConverter
	{
		public const float HPaToInHgFactor = 0.0295300586467f;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var hPa = (float)value;
			var inHg = hPa * HPaToInHgFactor;
			var inHgString = string.Format("Pressure {0:##.##} in Hg", inHg);
			return inHgString;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			var inHgString = value as string;
			if (string.IsNullOrEmpty(inHgString))
				return 0;
			inHgString = inHgString.Replace(" in Hg", string.Empty).Replace("Pressure ", string.Empty);
			var inHg = float.Parse(inHgString);
			var hPa = inHg / HPaToInHgFactor;
			return hPa;
		}
	}
}