namespace Alsolos.Commons.Wpf.Mvvm.Converters
{
    using System;
    using System.Globalization;

    public class EqualityToValueConverter : ValueConverter
    {
        public object EqualValue { get; set; }

        public object NotEqualValue { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var areEqual = value == parameter;

            return areEqual ? EqualValue : NotEqualValue;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
