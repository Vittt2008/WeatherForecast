using System;
using Windows.UI.Xaml.Data;
using WeatherForecast.Logic.Entity.Weather;
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

		public static string ConvertWind(WindViewModel wind)
		{
			var metresPerSecondString = string.Format("{0} {1:##.#} m/s {2}° {3}", wind.Name, wind.Value, wind.DirectionValue, wind.DirectionName);
			return metresPerSecondString;
		}

		public static string ConvertWindValue(WindViewModel wind)
		{
			var metresPerSecondString = string.Format("{0:##.#} m/s {1}° {2}", wind.Value, wind.DirectionValue, wind.DirectionName);
			return metresPerSecondString;
		}

		public static string ConvertWind(Wind wind)
		{
			var metresPerSecondString = string.Format("{0} {1:##.#} m/s {2}° {3}", wind.Speed.Name, wind.Speed.Value, wind.Direction.Value, wind.Direction.Name);
			return metresPerSecondString;
		}

		public static string ConvertWindValue(Wind wind)
		{
			var metresPerSecondString = string.Format("{0:##.#} m/s {1}° {2}", wind.Speed.Value, wind.Direction.Value, wind.Direction.Name);
			return metresPerSecondString;
		}
	}
}