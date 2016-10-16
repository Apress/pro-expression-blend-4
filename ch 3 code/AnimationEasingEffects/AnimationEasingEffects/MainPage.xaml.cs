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

namespace AnimationEasingEffects
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
		}

		private void ellipse_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Storyboard sb = (Storyboard)this.Resources["DropAndBounceBall"];
			sb.Begin();
		}

		private void myTriangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Storyboard sb = (Storyboard)this.Resources["RubberbandTriangle"];
			sb.Begin();		
		}

		private void myPoly_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			Storyboard sb = (Storyboard)this.Resources["HoverAndCrashPoly"];
			sb.Begin();
		}
	}
}