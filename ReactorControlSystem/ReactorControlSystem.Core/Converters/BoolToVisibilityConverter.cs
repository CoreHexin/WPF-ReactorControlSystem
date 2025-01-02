using System;
using System.Globalization;
using System.Windows;

namespace ReactorControlSystem.Core.Converters
{
    public class BoolToVisibilityConverter : ConverterBase<BoolToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            return Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
