using System;
using Windows.UI.Xaml.Data;

namespace WeatherForecast.Logic.Converter
{
	public class LastUpdateConverter:IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var datetime = (DateTime)value;
			return string.Format("Last update: {0}", datetime.ToString("HH:mm:ss dd.MM.yyyy"));
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return null;
		}
	}
}