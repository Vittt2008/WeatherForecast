using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter.Pressure
{
	public class MmHgConverter : IValueConverter
	{
		public const float HPaToMmHgFactor = 0.7500637554192f;

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var hPa = (float)value;
			var mmHg = hPa * HPaToMmHgFactor;
			var mmHgString = string.Format("Pressure {0:###} mm Hg", mmHg);
			return mmHgString;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			var mmHgString = value as string;
			if (string.IsNullOrEmpty(mmHgString))
				return 0;
			mmHgString = mmHgString.Replace(" mm Hg", string.Empty).Replace("Pressure ", string.Empty);
			var mmHg = float.Parse(mmHgString);
			var hPa = mmHg / HPaToMmHgFactor;
			return hPa;
		}

		public static string Convert(float hPa)
		{
			var mmHg = hPa * HPaToMmHgFactor;
			var mmHgString = string.Format("Pressure {0:###} mm Hg", mmHg);
			return mmHgString;
		}
	}
}