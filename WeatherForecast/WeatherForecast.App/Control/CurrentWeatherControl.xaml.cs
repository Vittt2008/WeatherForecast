using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WeatherForecast.Logic.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WeatherForecast.App.Control
{
	public sealed partial class CurrentWeatherControl : UserControl
	{
		public static readonly DependencyProperty CurrentWeatherProperty =
			DependencyProperty.Register(
				"CurrentWeather",
				typeof(CurrentWeatherViewModel),
				typeof(CurrentWeatherControl),
				new PropertyMetadata(null, CurrentWeatherPropertyChangedCallback));


		private static void CurrentWeatherPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var currentWeatherControl = (CurrentWeatherControl)dependencyObject;
			currentWeatherControl.DataContext = (CurrentWeatherViewModel)e.NewValue;
		}

		public CurrentWeatherControl()
		{
			this.InitializeComponent();
		}

		public CurrentWeatherViewModel CurrentWeather
		{
			get { return (CurrentWeatherViewModel)GetValue(CurrentWeatherProperty); }
			set { SetValue(CurrentWeatherProperty, value); }
		}

	}
}
