using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace PCGamingSketchScreens
{
	public class WheelSpinner : Behavior<FrameworkElement>
	{
		public static readonly DependencyProperty IncrementAmountProperty = DependencyProperty.Register("IncrementAmount", typeof(double), typeof(WheelSpinner), new PropertyMetadata(6.0));
		public static readonly DependencyProperty EasingProperty = DependencyProperty.Register("Easing", typeof(double), typeof(WheelSpinner), new PropertyMetadata(.3));

		private RotateTransform rotation;
		private double destinationAngle = 0;

		public double IncrementAmount
		{
			get { return (double)this.GetValue(WheelSpinner.IncrementAmountProperty); }
			set { this.SetValue(WheelSpinner.IncrementAmountProperty, value); }
		}

		public double Easing
		{
			get { return (double)this.GetValue(WheelSpinner.EasingProperty); }
			set { this.SetValue(WheelSpinner.EasingProperty, value); }
		}

		protected override void OnAttached()
		{
			base.OnAttached();

			this.rotation = new RotateTransform();
			this.AssociatedObject.RenderTransform = this.rotation;

			this.AssociatedObject.MouseWheel += this.HandleMouseWheel;
			CompositionTarget.Rendering += this.HandleTick;
		}

		protected override void OnDetaching()
		{
			base.OnDetaching();

			this.AssociatedObject.MouseWheel -= this.HandleMouseWheel;
			CompositionTarget.Rendering -= this.HandleTick;
		}

		private void HandleMouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (sender == this.AssociatedObject)
			{
				if (e.Delta > 0)
				{
					this.destinationAngle += this.IncrementAmount;
				}
				else if (e.Delta < 0)
				{
					this.destinationAngle -= this.IncrementAmount;
				}
			}
		}

		private void HandleTick(object sender, EventArgs e)
		{
			this.rotation.Angle += (destinationAngle - this.rotation.Angle) * this.Easing;
		}
	}
}
