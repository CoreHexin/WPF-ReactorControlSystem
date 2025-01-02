﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ReactorControlSystem.Core.Converters
{
    public abstract class ConverterBase<T> : MarkupExtension, IValueConverter 
        where T : class, new()
    {
        private static T _converter;

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ??= new T();
        }
    }
}