using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter
{
	public class CapitalizeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var nonCapitalize = value as string;
			if (string.IsNullOrEmpty(nonCapitalize))
				return string.Empty;
			return Capitalize(nonCapitalize);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value as string ?? string.Empty;
		}

		private string Capitalize(string value)
		{
			var array = value.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		}
	}
}