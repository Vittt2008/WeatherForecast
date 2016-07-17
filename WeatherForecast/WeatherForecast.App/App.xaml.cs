﻿using System;
using System.Diagnostics;
using System.Globalization;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.ApplicationInsights;

namespace WeatherForecast.App
{
	/// <summary>
	/// Обеспечивает зависящее от конкретного приложения поведение, дополняющее класс Application по умолчанию.
	/// </summary>
	sealed partial class App : Application
	{
		private static readonly CultureInfo Culture = new CultureInfo("en-US");

		/// <summary>
		/// Инициализирует одноэлементный объект приложения.  Это первая выполняемая строка разрабатываемого
		/// кода; поэтому она является логическим эквивалентом main() или WinMain().
		/// </summary>
		public App()
		{
			WindowsAppInitializer.InitializeAsync(
				WindowsCollectors.Metadata |
				WindowsCollectors.Session);
			InitializeComponent();
			Suspending += OnSuspending;
			UnhandledException += OnUnhandledException;
		}

		/// <summary>
		/// Вызывается при обычном запуске приложения пользователем.  Будут использоваться другие точки входа,
		/// например, если приложение запускается для открытия конкретного файла.
		/// </summary>
		/// <param name="e">Сведения о запросе и обработке запуска.</param>
		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{

#if DEBUG
			if (Debugger.IsAttached)
			{
				DebugSettings.EnableFrameRateCounter = true;
			}
#endif

			Frame rootFrame = Window.Current.Content as Frame;

			// Не повторяйте инициализацию приложения, если в окне уже имеется содержимое,
			// только обеспечьте активность окна
			if (rootFrame == null)
			{
				// Создание фрейма, который станет контекстом навигации, и переход к первой странице
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: Загрузить состояние из ранее приостановленного приложения
				}

				// Размещение фрейма в текущем окне
				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{
				// Если стек навигации не восстанавливается для перехода к первой странице,
				// настройка новой страницы путем передачи необходимой информации в качестве параметра
				// параметр
				rootFrame.Navigate(typeof(MainPage), e.Arguments);
			}
			// Обеспечение активности текущего окна
			Window.Current.Activate();
		}

		/// <summary>
		/// Вызывается в случае сбоя навигации на определенную страницу
		/// </summary>
		/// <param name="sender">Фрейм, для которого произошел сбой навигации</param>
		/// <param name="e">Сведения о сбое навигации</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// Вызывается при приостановке выполнения приложения.  Состояние приложения сохраняется
		/// без учета информации о том, будет ли оно завершено или возобновлено с неизменным
		/// содержимым памяти.
		/// </summary>
		/// <param name="sender">Источник запроса приостановки.</param>
		/// <param name="e">Сведения о запросе приостановки.</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Сохранить состояние приложения и остановить все фоновые операции
			deferral.Complete();
		}

		private async void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			e.Handled = true;
			var dialog = new MessageDialog(e.Exception.ToString(), e.Message);
			var result = await dialog.ShowAsync();
		}
	}
}
