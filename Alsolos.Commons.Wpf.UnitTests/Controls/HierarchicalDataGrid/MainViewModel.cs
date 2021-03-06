﻿namespace Alsolos.Commons.Wpf.UnitTests.Controls.HierarchicalDataGrid
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid;
    using Alsolos.Commons.Wpf.Mvvm;

    public class MainViewModel : ViewModel
    {
        private static readonly Random _random = new Random();

        public MainViewModel()
        {
            Items = new HierarchicalDataGridItemWrapperCollection {
                CreateItem("A"), 
                CreateItem("B"), 
                CreateItem("C")
            };
            RaisePropertyChanged(() => Items);
        }

        public DelegateCommand MoveSelectionCommand
        {
            get { return BackingFields.GetCommand(MoveSelection); }
        }

        public DelegateCommand AddSelectionCommand
        {
            get { return BackingFields.GetCommand(AddSelection); }
        }

        public DelegateCommand SelectAllCommand
        {
            get { return BackingFields.GetCommand(SelectAll); }
        }

        public DelegateCommand ClearSelectionCommand
        {
            get { return BackingFields.GetCommand(ClearSelection); }
        }

        public DelegateCommand DeleteCommand
        {
            get { return BackingFields.GetCommand(Delete); }
        }

        public DelegateCommand AddRootCommand
        {
            get { return BackingFields.GetCommand(AddRoot); }
        }

        public DelegateCommand AddChildCommand
        {
            get { return BackingFields.GetCommand(AddChild); }
        }

        public HierarchicalDataGridItemWrapperCollection Items { get; private set; }

        public ObservableCollection<HierarchicalDataGridItemWrapper> SelectedItems
        {
            get { return BackingFields.GetValue(() => new ObservableCollection<HierarchicalDataGridItemWrapper>()); }
        }

        public string RestrictivFilterText
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Items.SetRestrictiveFilter(wrapper => Filter(wrapper, value));
                }
                else
                {
                    Items.SetRestrictiveFilter(null);
                }
            }
        }

        public string TolerantFilterText
        {
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Items.SetTolerantFilter(wrapper => Filter(wrapper, value));
                }
                else
                {
                    Items.SetTolerantFilter(null);
                }
            }
        }

        private static bool Filter(HierarchicalDataGridItemWrapper wrapper, string value)
        {
            var item = (MyItem)wrapper.Value;
            return item.Name.Contains(value) || item.Name.Contains(value) || item.Number.ToString(CultureInfo.InvariantCulture).Contains(value);
        }

        private void MoveSelection()
        {
            if (!SelectedItems.Any())
            {
                SelectedItems.Add(Items.FirstOrDefault());
                return;
            }
            var index = Items.IndexOf(SelectedItems.First());
            index = (index + 1) % Items.Count;
            SelectedItems.Clear();
            SelectedItems.Add(Items[index]);
        }

        private void AddSelection()
        {
            foreach (var item in Items)
            {
                if (!SelectedItems.Contains(item))
                {
                    SelectedItems.Add(item);
                    return;
                }
            }
        }

        private void SelectAll()
        {
            foreach (var item in Items)
            {
                if (!SelectedItems.Contains(item))
                {
                    SelectedItems.Add(item);
                }
            }
        }

        private void ClearSelection()
        {
            SelectedItems.Clear();
        }

        private void Delete()
        {
            foreach (var wrapper in SelectedItems.ToList())
            {
                Items.Remove(wrapper);
            }
        }

        private void AddRoot()
        {
            Items.Add(new MyItem { Name = "Root" + Items.Count, Text = GetRandomText(), Number = GetRandomNumber() });
        }

        private void AddChild()
        {
            if (SelectedItems.Count != 1)
            {
                return;
            }
            var parent = SelectedItems.Single();
            var item = new MyItem { Name = "Child" + Items.Count, Text = GetRandomText(), Number = GetRandomNumber() };
            Items.Add(item, parent);
        }

        private static MyItem CreateItem(string name)
        {
            var item1 = new MyItem { Name = name, Text = GetRandomText(), Number = GetRandomNumber() };

            var item1SubItem1 = new MyItem { Name = name + "1", Text = GetRandomText(), Number = GetRandomNumber() };

            var item1SubItem1SubItem1 = new MyItem { Name = name + "1.1", Text = GetRandomText(), Number = GetRandomNumber() };

            var item1SubItem1SubItem1SubItem1 = new MyItem { Name = name + "1.1.1", Text = GetRandomText(), Number = GetRandomNumber() };
            item1SubItem1SubItem1.SubItems.Add(item1SubItem1SubItem1SubItem1);
            item1SubItem1.SubItems.Add(item1SubItem1SubItem1);

            var item1SubItem1SubItem2 = new MyItem { Name = name + "1.2", Text = GetRandomText(), Number = GetRandomNumber() };
            item1SubItem1.SubItems.Add(item1SubItem1SubItem2);
            item1.SubItems.Add(item1SubItem1);

            var item1SubItem2 = new MyItem { Name = name + "2", Text = GetRandomText(), Number = GetRandomNumber() };

            var item1SubItem2SubItem1 = new MyItem { Name = name + "2.1", Text = GetRandomText(), Number = GetRandomNumber() };
            item1SubItem2.SubItems.Add(item1SubItem2SubItem1);

            var item1SubItem2SubItem2 = new MyItem { Name = name + "2.2", Text = GetRandomText(), Number = GetRandomNumber() };
            item1SubItem2.SubItems.Add(item1SubItem2SubItem2);
            item1.SubItems.Add(item1SubItem2);

            return item1;
        }

        private static string GetRandomText()
        {
            var num = _random.Next(0, 26); // Zero to 25
            var letter = (char)('A' + num);
            return letter.ToString(CultureInfo.InvariantCulture);
        }

        private static int GetRandomNumber()
        {
            return _random.Next(0, 100); // Zero to 25
        }
    }
}
