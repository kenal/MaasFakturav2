using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Desktop.HelperClass
{
    public class BackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return value != null && (int)value == 1 ;
            if(value != null)
            {
                var intValue = (bool)value;
                if (intValue == true)
                return Brushes.LimeGreen;
                else return Brushes.Red;
            }
            else
                return Brushes.White;
            

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
