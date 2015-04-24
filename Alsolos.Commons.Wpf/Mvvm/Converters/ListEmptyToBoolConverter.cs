namespace Alsolos.Commons.Wpf.Mvvm.Converters
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;

    public class ListEmptyToBoolConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var list = value as IEnumerable;
            var isEmpty = list == null || !list.Cast<object>().Any();

            if (parameter != null)
            {
                isEmpty = !isEmpty;
            }

            return isEmpty;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
