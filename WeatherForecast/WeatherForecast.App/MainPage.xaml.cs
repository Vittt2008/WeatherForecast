using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Profile;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using WeatherForecast.Logic;
using WeatherForecast.Logic.Entity.Weather;
using WeatherForecast.Logic.EntityConverter;
using WeatherForecast.Logic.ServiceImpl;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherForecast.App
{
	/// <summary>
	/// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		private Dictionary<uint, UIElement> myEllipses = new Dictionary<uint, UIElement>();
		public MainPage()
		{
			this.InitializeComponent();
		}

		private async void BtClickOnClick(object sender, RoutedEventArgs e)
		{
			var res1 = AnalyticsInfo.DeviceForm;
			var res2 = AnalyticsInfo.VersionInfo.DeviceFamily;
			try
			{
				var service = new WeatherService();
				var data = await service.GetCurrentWeather("Moscow");
			}
			catch (Exception exception)
			{
				var message = exception.Message;
			}
		}

		private void Cnv_OnPointerPressed(object sender, PointerRoutedEventArgs e)
		{
			// Создаем новый овал 
			try
			{
				Ellipse ellipse = new Ellipse();
				ellipse.Width = 30;
				ellipse.Height = 30;
				ellipse.Stroke = new SolidColorBrush(Colors.White);
				ellipse.Fill = new SolidColorBrush(Colors.Gold);

				// Помещаем овал в точку касания
				var tp = e.GetCurrentPoint(cnv);
				Canvas.SetTop(ellipse, tp.Position.Y);
				Canvas.SetLeft(ellipse, tp.Position.X);

				// Сохраняем овал в словаре
				myEllipses[e.Pointer.PointerId] = ellipse;

				// Отражаем овал в канве
				cnv.Children.Add(ellipse);
			}
			catch (Exception exception)
			{
				var message = exception.Message;
			}
		}

		private void Cnv_OnPointerReleased(object sender, PointerRoutedEventArgs e)
		{
			try
			{
				UIElement el = myEllipses[e.Pointer.PointerId];
				cnv.Children.Remove(el);
				myEllipses.Remove(e.Pointer.PointerId);
			}
			catch (Exception exception)
			{
				var message = exception.Message;
			}
		}

		private void Cnv_OnPointerMoved(object sender, PointerRoutedEventArgs e)
		{
			try
			{
				if (!myEllipses.ContainsKey(e.Pointer.PointerId))
					return;

				UIElement ellipse = myEllipses[e.Pointer.PointerId];

				// Перемещаем овал в новую точку
				var tp = e.GetCurrentPoint(cnv);
				Canvas.SetTop(ellipse, tp.Position.Y);
				Canvas.SetLeft(ellipse, tp.Position.X);
			}
			catch (Exception exception)
			{
				var message = exception.Message;
			}
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			var service = new WeatherService();
			var data = await service.GetCurrentWeather("Moscow");
			var viewModel = data.ToViewModel();
			//var file = File.ReadAllText("CurrentWeather.xml");
			//var data = file.Parse<CurrentWeather>();
			CurrentWeatherControl.DataContext = viewModel;
			//Something();
		}

		private async void Something()
		{
			var service = new WeatherService();
			var city = new List<string>
			{
				"Moscow",
				"St. Peterburg",
				"London",
				"Paris",
				"New-York",
				"Barcelona",
				"Madrid",
				"Sochi",
				"Berlin",
				"Amsterdam"
			};
			var tasks = city.Select(x => service.GetHoursForecast(x)).ToArray();
			var result = await Task.WhenAll(tasks);
			var symbols = result.SelectMany(x => x.Times).Select(x => x.Symbol.Name).Distinct().OrderBy(x=>x).ToList();
		}
	}
}
