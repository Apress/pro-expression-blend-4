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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlendUserControl
{
	/// <summary>
	/// Interaction logic for BubbleThoughsControl.xaml
	/// </summary>
	public partial class BubbleThoughsControl : UserControl
	{
		public BubbleThoughsControl()
		{
			this.InitializeComponent();
		}

		private void callout_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// Move to a new state!
			VisualStateManager.GoToState(this, "MouseDownState", true);
		}
	}
}