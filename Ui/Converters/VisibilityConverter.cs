﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Kaczmarek.BeersCatalogue.Ui.Converters
{

    [ValueConversion(typeof(object), typeof(Visibility))]
    public class VisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
