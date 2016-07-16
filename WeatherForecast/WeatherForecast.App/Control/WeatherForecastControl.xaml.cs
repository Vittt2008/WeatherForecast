using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using WeatherForecast.Logic.EntityConverter;
using WeatherForecast.Logic.ServiceImpl;
using WeatherForecast.Logic.ViewModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WeatherForecast.App.Control
{
	public sealed partial class WeatherForecastControl : UserControl
	{
		public static readonly DependencyProperty WeatherViewModelProperty =
			DependencyProperty.Register(
				"WeatherViewModel",
				typeof(WeatherForecastViewModel),
				typeof(WeatherForecastControl),
				new PropertyMetadata(null, WeatherViewModelPropertyChangedCallback));

		private static void WeatherViewModelPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var viewModel = e.NewValue as WeatherForecastViewModel;
			if (viewModel == null)
				return;

			var weatherControl = dependencyObject as WeatherForecastControl;
			if (weatherControl == null)
				return;

			weatherControl.DataContext = viewModel;
		}


		public WeatherForecastControl()
		{
			this.InitializeComponent();
		}

		public WeatherForecastViewModel WeatherViewModel
		{
			get { return (WeatherForecastViewModel)GetValue(WeatherViewModelProperty); }
			set { SetValue(WeatherViewModelProperty, value); }
		}
	}
}
