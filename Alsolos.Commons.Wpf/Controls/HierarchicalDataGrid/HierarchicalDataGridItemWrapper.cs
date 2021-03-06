﻿namespace Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid
{
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using Alsolos.Commons.Wpf.Mvvm;

    [DebuggerDisplay("{Value}")]
    public class HierarchicalDataGridItemWrapper : BackingFieldsHolder
    {
        private HierarchicalDataGridItemWrapper(IHierarchicalDataGridItem item, HierarchicalDataGridItemWrapper parent)
        {
            Value = item;
            Parent = parent;
            Level = Parent != null ? Parent.Level + 1 : 0;
            IsExpanded = false;
            IsParentExpanded = Parent == null || Parent.IsExpanded;
            Children = new ObservableCollection<HierarchicalDataGridItemWrapper>();
        }

        public IHierarchicalDataGridItem Value { get; private set; }

        public HierarchicalDataGridItemWrapper Parent { get; private set; }

        public int Level { get; private set; }

        public ObservableCollection<HierarchicalDataGridItemWrapper> Children { get; private set; }

        public bool IsExpanded
        {
            get { return BackingFields.GetValue<bool>(); }
            set
            {
                if (BackingFields.SetValue(value))
                {
                    SetIsParentExpandedToAllSubItemsRecursively(value);
                }
            }
        }

        public bool IsParentExpanded
        {
            get { return BackingFields.GetValue<bool>(); }
            set { BackingFields.SetValue(value); }
        }

        public static HierarchicalDataGridItemWrapper CreateRecursively(IHierarchicalDataGridItem item)
        {
            return CreateRecursively(item, null);
        }

        public static HierarchicalDataGridItemWrapper CreateRecursively(IHierarchicalDataGridItem item, HierarchicalDataGridItemWrapper parent)
        {
            var wrapper = new HierarchicalDataGridItemWrapper(item, parent);
            foreach (var childItem in item.Children)
            {
                var childWrapper = CreateRecursively(childItem, wrapper);
                wrapper.Children.Add(childWrapper);
            }
            return wrapper;
        }

        public void ExpandRecursively()
        {
            IsExpanded = true;
            foreach (var child in Children)
            {
                child.ExpandRecursively();
            }
        }

        public void CollapseRecursively()
        {
            IsExpanded = false;
            foreach (var child in Children)
            {
                child.CollapseRecursively();
            }
        }

        private void SetIsParentExpandedToAllSubItemsRecursively(bool isExpanded)
        {
            foreach (var child in Children)
            {
                child.IsParentExpanded = isExpanded;
                if (isExpanded)
                {
                    child.SetIsParentExpandedToAllSubItemsRecursively(child.IsExpanded);
                }
                else
                {
                    child.SetIsParentExpandedToAllSubItemsRecursively(false);
                }
            }
        }
    }
}
