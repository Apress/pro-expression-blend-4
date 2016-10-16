using System;
using System.Windows;

namespace ColorSwatchSL
{
	public partial class App : Application 
	{
		public App() 
		{
			this.Startup += this.OnStartup;
			this.UnhandledException += this.Application_UnhandledException;

			this.InitializeComponent();
		}

		private void OnStartup(object sender, StartupEventArgs e) 
		{
			// Load the main control here
			this.RootVisual = new MainControl();
		}

		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (!System.Diagnostics.Debugger.IsAttached)
			{
				e.Handled = true;

				try
				{
					string errorMsg = e.ExceptionObject.Message + @"\n" + e.ExceptionObject.StackTrace;
					errorMsg = errorMsg.Replace("\"", "\\\"").Replace("\r\n", @"\n");

					System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight 3 Application: " + errorMsg + "\");");
				}
				catch (Exception)
				{
				}
			}
		}
	}
}