namespace Alsolos.Commons.Wpf.Controls
{
    using System.Windows;
    using System.Windows.Controls;

    public class ProportionalColumnsPanel : Grid
    {
        public ProportionalColumnsPanel()
        {
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Loaded -= OnLoaded;

            ColumnDefinitions.Clear();
            for (var childIndex = 0; childIndex < Children.Count; childIndex++)
            {
                var child = Children[childIndex];
                child.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
                var columnDefinition = new ColumnDefinition { Width = new GridLength(child.DesiredSize.Width, GridUnitType.Star) };
                ColumnDefinitions.Add(columnDefinition);
                SetColumn(child, childIndex);
            }
        }
    }
}
