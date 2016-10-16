using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight3DExample
{
	public partial class MainPage : UserControl
	{
		private double xVal = 0;
		private double yVal = 0;
		private double zVal = -15.4;
		
		public MainPage()
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
			PlaneProjection pp = new PlaneProjection();
			pp.RotationX = xVal;
			pp.RotationY = yVal;
			pp.RotationZ = zVal;
			
            if(imgCoCoLoCo != null)
			    this.imgCoCoLoCo.Projection = pp;			
		}
	}
}












