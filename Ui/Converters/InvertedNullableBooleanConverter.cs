using System;
using System.Globalization;
using System.Windows.Data;

namespace Kaczmarek.BeersCatalogue.Ui.Converters
{
    [ValueConversion(typeof(bool), typeof(bool))]
    public class InvertedNullableBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)(value ?? false);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
