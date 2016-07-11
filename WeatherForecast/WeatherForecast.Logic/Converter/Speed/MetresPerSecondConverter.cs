using System;
using Windows.UI.Xaml.Data;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.Converter.Speed
{
	public class MetresPerSecondConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var wind = (WindViewModel)value;
			var metresPerSecondString = string.Format("{0:##.#} m/s {1}° {2}", wind.Value, wind.DirectionValue, wind.DirectionName);
			return metresPerSecondString;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}