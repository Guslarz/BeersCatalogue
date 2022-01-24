﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Kaczmarek.BeersCatalogue.Ui.Converters
{
    internal class ConditionsAndConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                if (!(bool)value)
                {
                    return false;
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
