using System;
using Windows.UI.Xaml.Data;
using WeatherForecast.Logic.ViewModel;

namespace WeatherForecast.Logic.Converter
{
	public class UnitToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var unit = value as Unit? ?? Unit.Metric;
			return unit != Unit.Metric;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			var boolean = value as bool? ?? true;
			return boolean ? Unit.Imperial : Unit.Metric;
		}
	}
}