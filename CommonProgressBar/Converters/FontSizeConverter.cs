using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CommonProgressBar.Converters
{
    class FontSizeConverter : IValueConverter
    {
            public double Scale { get; set; }
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                double scale = GetIntegerValue(parameter, Scale);
                double size = GetIntegerValue(value, 120);
                return size / scale;
            }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
            double scale = GetIntegerValue(parameter, Scale);
            double size = GetIntegerValue(value, 20);
                return size * scale;
            }
        
        private double GetIntegerValue(object parameter, double defaultValue)
            {
                double s = defaultValue;
                if (parameter != null)
                {
                    try
                    {
                        s = System.Convert.ToInt32(parameter);
                    }
                    catch
                    {
                        throw new Exception("Size converter parameter not right");
                    }
                }
                return s;
            }
        
    }
}
