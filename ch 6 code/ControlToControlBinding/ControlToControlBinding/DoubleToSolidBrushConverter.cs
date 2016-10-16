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

namespace ControlToControlBinding
{
	public class DoubleToSolidBrushConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter,
                              System.Globalization.CultureInfo culture)
        {
			double d = (double)value;
			byte v = (byte)d;
			
			Color color = new Color();
			color.A = 255;
			color.G = v;
			
			return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                                  System.Globalization.CultureInfo culture)
        {
            return null;
        }

	}
}