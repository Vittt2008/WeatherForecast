using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;

namespace WeatherForecast.App
{
	public class DragInCanvasbehavior: Behavior<UIElement>
	{
		private Canvas canvas;

		protected override void OnAttached()
		{
			base.OnAttached();

			// Присоединение обработчиков событий            
			this.AssociatedObject.PointerPressed += AssociatedObject_MouseLeftButtonDown;
			this.AssociatedObject.PointerMoved += AssociatedObject_MouseMove;
			this.AssociatedObject.PointerReleased += AssociatedObject_MouseLeftButtonUp;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			// Удаление обработчиков событий
			this.AssociatedObject.PointerPressed -= AssociatedObject_MouseLeftButtonDown;
			this.AssociatedObject.PointerMoved -= AssociatedObject_MouseMove;
			this.AssociatedObject.PointerReleased -= AssociatedObject_MouseLeftButtonUp;
		}

		// Отслеживание перетаскивания элемента
		private bool isDragging = false;

		// Запись точной позиции, в которой нажата кнопка
		private PointerPoint mouseOffset;

		private void AssociatedObject_MouseLeftButtonDown(object sender, PointerRoutedEventArgs e)
		{
			// Поиск canvas
			if (canvas == null)
				canvas = VisualTreeHelper.GetParent(this.AssociatedObject) as Canvas;

			// Режим перетаскивания
			isDragging = true;

			// Получение позиции нажатия относительно элемента
			mouseOffset = e.GetCurrentPoint(AssociatedObject);

			// Захват мыши
			AssociatedObject.CapturePointer(e.Pointer);
		}

		private void AssociatedObject_MouseMove(object sender, PointerRoutedEventArgs e)
		{
			if (isDragging)
			{
				// Получение позиции элемента относительно Canvas
				var point = e.GetCurrentPoint(canvas);

				// Move the element.
				AssociatedObject.SetValue(Canvas.TopProperty, point.Position.Y - mouseOffset.Position.Y);
				AssociatedObject.SetValue(Canvas.LeftProperty, point.Position.X - mouseOffset.Position.X);
			}
		}

		private void AssociatedObject_MouseLeftButtonUp(object sender, PointerRoutedEventArgs e)
		{
			if (isDragging)
			{
				AssociatedObject.ReleasePointerCapture(e.Pointer);
				isDragging = false;
			}
		}
	}
}