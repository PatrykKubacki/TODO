using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TODO.Converters {
	public class ColorConverter : IValueConverter {

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

			if ((bool)value)
				return Color.Lime;
			 return Color.Silver;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			return null;
		}
	}
}
