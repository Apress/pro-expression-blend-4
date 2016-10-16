using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Interactivity;

namespace ColorSwatchSL
{
    public class ListBoxItemSendToTop : TriggerAction<DependencyObject>
    {
		static int ZIndexListBox = 1;

		protected override void OnAttached()
		{
			base.OnAttached();
			FrameworkElement el = this.AssociatedObject as FrameworkElement;
			el.MouseEnter += new MouseEventHandler(this.el_MouseEnter);
			el.MouseLeave += new MouseEventHandler(this.el_MouseLeave);
		}

		protected override void Invoke(object o)
		{
		}

		private void el_MouseLeave(object sender, MouseEventArgs e)
		{
			this.ChangeZIndex(0);
		}
		private void el_MouseEnter(object sender, MouseEventArgs e)
		{
			this.ChangeZIndex(++ZIndexListBox);
			
		}

		private void ChangeZIndex(int zIndex)
		{
			DependencyObject parent = this.AssociatedObject;
			while (parent != null)
			{
				if (parent.GetType() == typeof(ListBoxItem))
				{
					Canvas.SetZIndex((FrameworkElement)parent, zIndex);
					break;
				}
				parent = VisualTreeHelper.GetParent(parent);
			}
		}
    }
}
