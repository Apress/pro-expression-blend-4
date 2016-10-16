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

namespace InteractiveTeddyBear
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}
		
		private void leftEye_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// Change the color of the eye when clicked. 
			leftEye.Fill = new SolidColorBrush(Colors.Red);
		}
		
		private void rightEar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// Blur the ear when clicked. 
			System.Windows.Media.Effects.BlurEffect blur = 
				new System.Windows.Media.Effects.BlurEffect();
			blur.Radius = 80;			 
			rightEar.Effect = blur;
		}
	}
}