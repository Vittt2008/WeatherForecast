using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
			InitializeComponent();
		}

		public WeatherForecastViewModel WeatherViewModel
		{
			get { return (WeatherForecastViewModel)GetValue(WeatherViewModelProperty); }
			set { SetValue(WeatherViewModelProperty, value); }
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			WeatherViewModel.Unit = WeatherViewModel.Unit == Unit.Metric ? Unit.Imperial : Unit.Metric;
		}
	}
}
