namespace Alsolos.Commons.Wpf.UnitTests.Controls.FindInSelector {
    using System.Windows.Controls;

    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void OnSelectorSelectionChanged(object sender, SelectionChangedEventArgs e) {
            var dataGrid = (DataGrid)sender;
            if (dataGrid.SelectedItem != null) {
                dataGrid.ScrollIntoView(dataGrid.SelectedItem);
            }
        }
    }
}
