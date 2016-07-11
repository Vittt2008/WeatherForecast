using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WeatherForecast.App
{
	public class CustomTextBox : TextBox
	{
		public static readonly DependencyProperty CustomTextProperty = 
			DependencyProperty.Register(
				"CustomText",
				typeof(string), 
				typeof(CustomTextBox), 
				new PropertyMetadata(string.Empty, PropertyChangedCallback));

		private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var customTextBox = (CustomTextBox)dependencyObject;
			customTextBox.Text = (string) e.NewValue;
		}

		public string CustomText
		{
			get
			{
				return (string)GetValue(CustomTextProperty);
			}
			set
			{
				SetValue(CustomTextProperty, value);
			}
		}
	}
}