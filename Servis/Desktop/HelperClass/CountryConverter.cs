using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace Desktop.HelperClass
{
    public class CountryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
        object parameter, CultureInfo culture)
        {
            string urImage = AppDomain.CurrentDomain.BaseDirectory + "Images\\Countries\\" + value.ToString() + ".png";
            return urImage;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
