namespace Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid
{
    using System;
    using System.Globalization;
    using System.Windows;
    using Alsolos.Commons.Wpf.Mvvm.Converters;

    public class LevelToMarginConverter : ValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
            {
                return new Thickness(0);
            }
            var level = (int)value;
            return new Thickness(level * 12, 0, 0, 0);
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
