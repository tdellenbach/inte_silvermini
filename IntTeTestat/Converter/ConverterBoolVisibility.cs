using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace IntTeTestat.Converter
{ 
    /// <summary>
    /// Converts a boolean to a Visibility
    /// True = Visible
    /// False = Collapsed
    /// </summary>
    public class ConverterBoolVisibility : IValueConverter
    {

        public bool Invert { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool parameterBool = (bool) value;
            parameterBool = Invert ? !parameterBool : parameterBool;

            if (parameterBool)
                return Visibility.Visible;
            
            return Visibility.Collapsed;
        }

        /// <summary>
        /// Not supported. Throws NotSupportedException.
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();

        }
    }
}
