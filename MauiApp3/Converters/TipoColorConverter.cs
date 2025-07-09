using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Proyecto3.Converters
{
    public class TipoColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.ToString() == "Ingreso")
                return Colors.Green;
            else
                return Colors.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
