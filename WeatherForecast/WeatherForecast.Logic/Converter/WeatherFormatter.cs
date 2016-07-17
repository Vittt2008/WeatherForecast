using System;
using System.Globalization;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.Converter
{
	public class WeatherFormatter
	{
		public static readonly CultureInfo Culture = new CultureInfo("en-US");

		public const float HPaToInHgFactor = 0.0295300586467f;
		public const float HPaToMmHgFactor = 0.7500637554192f;
		public const float MetresPerSecondToMilesPerHourFactor = 2.23694f;
		public const float FahrenheitOffset = 32f;
		public const float FahrenheitFactor = 1.8f;

		public static string HPaToInHg(float hPa)
		{
			var inHg = hPa * HPaToInHgFactor;
			var inHgString = string.Format("Pressure {0:##.##} in Hg", inHg);
			return inHgString;
		}

		public static string HPaToMmHg(float hPa)
		{
			var mmHg = hPa * HPaToMmHgFactor;
			var mmHgString = string.Format("Pressure {0:###} mm Hg", mmHg);
			return mmHgString;
		}

		public static string WindFullInfoMps(WindViewModel wind)
		{
			var metresPerSecondString = string.Format("{0} {1:##.#} m/s {2:###}° {3}", wind.Name, wind.Value, wind.DirectionValue, wind.DirectionName);
			return metresPerSecondString;
		}

		public static string WindShortInfoMps(WindViewModel wind)
		{
			var metresPerSecondString = string.Format("{0:##.#} m/s {1:###}° {2}", wind.Value, wind.DirectionValue, wind.DirectionName);
			return metresPerSecondString;
		}

		public static string WindFullInfoMph(WindViewModel wind)
		{
			var metresPerSecond = wind.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0} {1:##.##} mph {2:###}° {3}", wind.Name, milesPerHour, wind.DirectionValue, wind.DirectionName);
			return milesPerHourString;
		}

		public static string WindShortInfoMph(WindViewModel wind)
		{
			var metresPerSecond = wind.Value;
			var milesPerHour = metresPerSecond * MetresPerSecondToMilesPerHourFactor;
			var milesPerHourString = string.Format("{0:##.##} mph {1:###}° {2}", milesPerHour, wind.DirectionValue, wind.DirectionName);
			return milesPerHourString;
		}

		public static string CelciousToCelcious(float temperature)
		{
			var celciousString = string.Format("{0:##}°C", temperature);
			return celciousString;
		}

		public static string CelciousToFahrenheit(float temperature)
		{
			var fahrenheit = temperature * FahrenheitFactor + FahrenheitOffset;
			var fahrenheitString = string.Format("{0:###}°F", fahrenheit);
			return fahrenheitString;
		}

		public static string FormatHumidity(int humidity)
		{
			return string.Format("Humidity {0}%", humidity);
		}

		public static string FormatLastUpdateDateTime(DateTime dateTime)
		{
			return string.Format("Last update: {0}", dateTime.ToString("HH:mm:ss dd.MM.yyyy"));
		}

		public static string Capitalize(string value)
		{
			if (string.IsNullOrEmpty(value))
				return string.Empty;

			var array = value.ToCharArray();
			array[0] = char.ToUpper(array[0]);
			return new string(array);
		}
	}
}