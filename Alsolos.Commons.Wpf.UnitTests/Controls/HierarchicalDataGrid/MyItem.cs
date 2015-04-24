namespace Alsolos.Commons.Wpf.UnitTests.Controls.HierarchicalDataGrid
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid;
    using Alsolos.Commons.Wpf.Mvvm;

    [DebuggerDisplay("{Name}")]
    public class MyItem : BackingFieldsHolder, IHierarchicalDataGridItem
    {
        public MyItem()
        {
            SubItems = new List<MyItem>();
        }

        public string Name
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        public string Text
        {
            get { return BackingFields.GetValue<string>(); }
            set { BackingFields.SetValue(value); }
        }

        public int Number
        {
            get { return BackingFields.GetValue<int>(); }
            set { BackingFields.SetValue(value); }
        }

        public IList<MyItem> SubItems { get; set; }

        public IList<IHierarchicalDataGridItem> Children
        {
            get
            {
                return SubItems.Cast<IHierarchicalDataGridItem>().ToList();
            }
        }
    }
}
