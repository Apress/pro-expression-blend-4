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

namespace Transformations
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

		private void btnFlip_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			 myShape.LayoutTransform  = new ScaleTransform(-1, 1);
		}

		private void btnRotate_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			myShape.LayoutTransform = new RotateTransform(180);
		}

		private void btnSkew_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			myShape.LayoutTransform  = new SkewTransform(40, -20);
		}
	}
}