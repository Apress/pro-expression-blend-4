using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BlendDrawingTools
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

		private void InsideAShape(object sender, System.Windows.Input.MouseEventArgs e)
		{
			// Make the currently selected shape appear to be semi-transparent.
			((UIElement)sender).Opacity = .5;
		}

		private void OutsideAShape(object sender, System.Windows.Input.MouseEventArgs e)
		{
			// Reset.
			((UIElement)sender).Opacity = 1;
		}
	}
}