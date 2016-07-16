using System;
using Windows.UI.Xaml.Data;
using WeatherForecast.Logic.Entity.Weather;
using WeatherForecast.Logic.ViewModel;

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

		public static string ConvertWind(WindViewModel wind)
		{
			var metresPerSecond = wind.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0} {1:##.##} mph {2}° {3}", wind.Name, milesPerHour, wind.DirectionValue, wind.DirectionName);
			return milesPerHourString;
		}

		public static string ConvertWindValue(WindViewModel wind)
		{
			var metresPerSecond = wind.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0:##.##} mph {1}° {2}", milesPerHour, wind.DirectionValue, wind.DirectionName);
			return milesPerHourString;
		}

		public static string ConvertWind(Wind wind)
		{
			var metresPerSecond = wind.Speed.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0} {1:##.##} mph {2}° {3}", wind.Speed.Name, milesPerHour, wind.Direction.Value, wind.Direction.Name);
			return milesPerHourString;
		}

		public static string ConvertWindValue(Wind wind)
		{
			var metresPerSecond = wind.Speed.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0:##.##} mph {1}° {2}", milesPerHour, wind.Direction.Value, wind.Direction.Name);
			return milesPerHourString;
		}
	}
}