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

		public static readonly DependencyProperty CityPhotoProperty =
			DependencyProperty.Register(
				"CityPhoto",
				typeof(string),
				typeof(CurrentWeatherControl),
				new PropertyMetadata(null, CityPhotoPropertyChangedCallback));

		public static readonly DependencyProperty CityPhotoImageProperty =
			DependencyProperty.Register(
				"CityPhotoImage",
				typeof(BitmapImage),
				typeof(CurrentWeatherControl),
				new PropertyMetadata(null, CityPhotoImagePropertyChangedCallback));

		private static void CurrentWeatherPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var currentWeatherControl = (CurrentWeatherControl)dependencyObject;
			currentWeatherControl.DataContext = (CurrentWeatherViewModel)e.NewValue;
		}

		private static void CityPhotoPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var currentWeatherControl = (CurrentWeatherControl)dependencyObject;
			var url = e.NewValue as string;
			if (string.IsNullOrEmpty(url))
				return;

			currentWeatherControl.rootContainer.Background = new ImageBrush
			{
				ImageSource = new BitmapImage(new Uri(url)),
				Stretch = Stretch.UniformToFill
			};

			currentWeatherControl.opacityContainer.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
		}

		private static void CityPhotoImagePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var currentWeatherControl = (CurrentWeatherControl)dependencyObject;
			var bitmap = e.NewValue as BitmapImage;
			if (bitmap == null)
				return;

			currentWeatherControl.rootContainer.Background = new ImageBrush
			{
				ImageSource = bitmap,
				Stretch = Stretch.UniformToFill
			};

			currentWeatherControl.opacityContainer.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
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

		public string CityPhoto
		{
			get { return (string)GetValue(CityPhotoProperty); }
			set { SetValue(CityPhotoProperty, value); }
		}

		public BitmapImage CityPhotoImage
		{
			get { return (BitmapImage)GetValue(CityPhotoImageProperty); }
			set { SetValue(CityPhotoImageProperty, value); }
		}

	}
}
