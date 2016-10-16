using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PCGamingSketchScreens
{
	public class CircularPanel : Panel
	{
		public enum AlignmentOptions { Left, Center, Right };

		public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(CircularPanel), new PropertyMetadata(CircularPanel.RadiusChanged));
		public static readonly DependencyProperty AngleItemProperty = DependencyProperty.Register("AngleItem", typeof(double), typeof(CircularPanel), new PropertyMetadata(CircularPanel.AngleItemChanged));
		public static readonly DependencyProperty IsAnimatedProperty = DependencyProperty.Register("IsAnimated", typeof(bool), typeof(CircularPanel), new PropertyMetadata(CircularPanel.IsAnimatedChanged));
		public static readonly DependencyProperty AnimationDurationProperty = DependencyProperty.Register("AnimationDuration", typeof(int), typeof(CircularPanel), new PropertyMetadata(CircularPanel.AnimationDurationChanged));
		public static readonly DependencyProperty InitialAngleProperty = DependencyProperty.Register("InitialAngle", typeof(double), typeof(CircularPanel), new PropertyMetadata(CircularPanel.InitialAngleChanged));
		public static readonly DependencyProperty AlignProperty = DependencyProperty.Register("Align", typeof(AlignmentOptions), typeof(CircularPanel), new PropertyMetadata(CircularPanel.AlignChanged));

		private static void RadiusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).Refresh(); }
		private static void AngleItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).Refresh(); }
		private static void IsAnimatedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).OnIsAnimatedChanged(e); }
		private static void AnimationDurationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).Refresh(); }
		private static void InitialAngleChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).Refresh(); }
		private static void AlignChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { ((CircularPanel)sender).Refresh(); }

		[Category("Circular Panel")]
		public double Radius
		{
			get { return (double)this.GetValue(CircularPanel.RadiusProperty); }
			set { this.SetValue(CircularPanel.RadiusProperty, value); }
		}

		[Category("Circular Panel")]
		public double AngleItem
		{
			get { return (double)this.GetValue(CircularPanel.AngleItemProperty); }
			set { this.SetValue(CircularPanel.AngleItemProperty, value); }
		}

		[Category("Circular Panel")]
		public bool IsAnimated
		{
			get { return (bool)this.GetValue(CircularPanel.IsAnimatedProperty); }
			set { this.SetValue(CircularPanel.IsAnimatedProperty, value); }
		}

		[Category("Circular Panel")]
		public int AnimationDuration
		{
			get { return (int)this.GetValue(CircularPanel.AnimationDurationProperty); }
			set { this.SetValue(CircularPanel.AnimationDurationProperty, value); }
		}

		[Category("Circular Panel")]
		public double InitialAngle
		{
			get { return (double)this.GetValue(CircularPanel.InitialAngleProperty); }
			set { this.SetValue(CircularPanel.InitialAngleProperty, value); }
		}

		[Category("Circular Panel")]
		public AlignmentOptions Align
		{
			get { return (AlignmentOptions)this.GetValue(CircularPanel.AlignProperty); }
			set { this.SetValue(CircularPanel.AlignProperty, value); }
		}

		private void OnIsAnimatedChanged(DependencyPropertyChangedEventArgs e)
		{
			this.Animate();
			this.Refresh();
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			Size resultSize = new Size(0, 0);

			foreach (UIElement child in this.Children)
			{
				child.Measure(availableSize);
				resultSize.Width = Math.Max(resultSize.Width, child.DesiredSize.Width);
				resultSize.Height = Math.Max(resultSize.Height, child.DesiredSize.Height);
			}

			resultSize.Width =
				double.IsPositiveInfinity(availableSize.Width) ?
				resultSize.Width : availableSize.Width;

			resultSize.Height =
				double.IsPositiveInfinity(availableSize.Height) ?
				resultSize.Height : availableSize.Height;

			this.Animate();

			return resultSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			this.Refresh();
			return base.ArrangeOverride(finalSize);
		}

		private void Animate()
		{
			if (this.IsAnimated)
			{
				int index = 0;
				foreach (FrameworkElement element in this.Children)
				{
					element.Opacity = 0;
					Storyboard loadStoryboard = new Storyboard();
					int time = this.AnimationDuration * (index + 1);

					DoubleAnimation opacityAnimation = new DoubleAnimation();
					opacityAnimation.From = 0;
					opacityAnimation.To = 1;
					opacityAnimation.BeginTime = new TimeSpan(0, 0, 0, 0, time);
					opacityAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, this.AnimationDuration));
					Storyboard.SetTarget(opacityAnimation, element);
					Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(Opacity)"));
					loadStoryboard.Children.Add(opacityAnimation);

					loadStoryboard.Begin();
					index++;
				}
			}
		}

		private void Refresh()
		{
			int count = 0;
			if (double.IsNaN(this.Width))
			{
				this.Width = 200;
			}
			if (double.IsNaN(this.Height))
			{
				this.Height = 200;
			}

			foreach (FrameworkElement element in this.Children)
			{
				RotateTransform r = new RotateTransform();
				double alignX = 0;
				double alignY = 0;
				switch (this.Align)
				{
					case AlignmentOptions.Left:
						alignX = 0;
						alignY = 0;
						break;
					case AlignmentOptions.Center:
						alignX = element.DesiredSize.Width / 2;
						alignY = element.DesiredSize.Height / 2;
						break;
					case AlignmentOptions.Right:
						alignX = element.DesiredSize.Width;
						alignY = element.DesiredSize.Height;
						break;
				}
				r.CenterX = alignX;
				r.CenterY = alignY;
				r.Angle = (this.AngleItem * count++) - this.InitialAngle;
				element.RenderTransform = r;
				double x = this.Radius * Math.Cos(Math.PI * r.Angle / 180);
				double y = this.Radius * Math.Sin(Math.PI * r.Angle / 180);

				if (!(double.IsNaN(this.Width)) && !(double.IsNaN(this.Height)) && !(double.IsNaN(alignX)) && !(double.IsNaN(alignY)) && !(double.IsNaN(element.DesiredSize.Width)) && !(double.IsNaN(element.DesiredSize.Height)))
				{
					element.Arrange(new Rect(x + this.Width / 2 - alignX, y + this.Height / 2 - alignY, element.DesiredSize.Width, element.DesiredSize.Height));
				}
			}
		}
	}
}