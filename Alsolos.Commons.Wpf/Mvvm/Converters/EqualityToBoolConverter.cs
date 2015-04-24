namespace Alsolos.Commons.Wpf.Mvvm.Converters
{
    using System;
    using System.Globalization;

    public class EqualityToBoolConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var areEqual = value == parameter;

            return areEqual;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
