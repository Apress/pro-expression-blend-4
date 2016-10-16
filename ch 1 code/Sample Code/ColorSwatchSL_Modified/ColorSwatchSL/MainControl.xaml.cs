using System.Windows.Controls;

namespace ColorSwatchSL
{
	public partial class MainControl : UserControl
	{
		public MainControl()
		{
			// Required to initialize variables
			this.InitializeComponent();
		}

		private void myPolygon_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// Remove the swirl visual effect.
  			LayoutRoot.Effect = null;
		}

		private void myStar_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			// Try adding a different effect!
  			LayoutRoot.Effect = 
    			new System.Windows.Media.Effects.BlurEffect();
		}
	}
}