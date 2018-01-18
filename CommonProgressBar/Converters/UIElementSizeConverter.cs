using System;
using System.Globalization;
using System.Windows.Data;

namespace CommonProgressBar.Converters
{
    public class UIElementSizeConverter : IValueConverter
    {
        public int Scale { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int scale = GetIntegerValue(parameter, Scale);
            int size = GetIntegerValue(value, 120);
            return size / scale;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int scale = GetIntegerValue(parameter, Scale);
            int size = GetIntegerValue(value, 20);
            return size * scale;
        }

        private int GetIntegerValue(object parameter, int defaultValue)
        {
            int s = defaultValue;
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
