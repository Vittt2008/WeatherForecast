using System;
using Windows.UI.Xaml.Data;
using WeatherForecast.Logic.Entity.Weather;

namespace WeatherForecast.Logic.Converter.Speed
{
	public class MilesPerHourConverter : IValueConverter
	{
		public const float MetresPerSecondToMilesPerHourFactor = 2.23694f;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var wind = (Wind)value;
			var metresPerSecond = (float)wind.Speed.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0:##.##} mph {1}° {2}", milesPerHour, wind.Direction.Value, wind.Direction.Name);
			return milesPerHourString;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}