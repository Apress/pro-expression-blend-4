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

namespace Wpf3DExample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private double xVal = 0;
		private double yVal = 0;
		private double zVal = -15.4;
		
		public MainWindow()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

		private void sliderXChange_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			// Change the X look direction.
			xVal = e.NewValue;
			ChangeCamera();
		}

		private void sliderYChange_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			// Change the Y look direction.
			yVal = e.NewValue;
			ChangeCamera();
		}

		private void sliderZChange_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
		{
			// Change the Z look direction.
			zVal = e.NewValue;
			ChangeCamera();
		}
		
		private void ChangeCamera()
		{
			this.my3DCamera.Position = new System.Windows.Media.Media3D.Point3D(-xVal, -yVal, -zVal);
			this.my3DCamera.LookDirection = new System.Windows.Media.Media3D.Vector3D(xVal, yVal, zVal);			
		}
	}
}