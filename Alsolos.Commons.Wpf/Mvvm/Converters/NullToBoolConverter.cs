namespace Alsolos.Commons.Wpf.Mvvm.Converters
{
    using System;
    using System.Globalization;

    public class NullToBoolConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isNull = value == null;

            if (parameter != null)
            {
                isNull = !isNull;
            }

            return isNull;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
