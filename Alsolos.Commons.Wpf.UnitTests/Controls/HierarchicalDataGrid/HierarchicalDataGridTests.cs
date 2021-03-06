﻿namespace Alsolos.Commons.Wpf.UnitTests.Controls.HierarchicalDataGrid
{
    using System.Collections.Generic;
    using System.Linq;
    using Alsolos.Commons.Wpf.Controls.HierarchicalDataGrid;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HierarchicalDataGridTests
    {
        [Ignore]
        [TestMethod]
        public void OpenWindowTest()
        {
            new MainWindow().ShowDialog();
        }

        [TestMethod]
        public void ExpandCollapseTest()
        {
            var wrappers = CreateWrappers();
            var grid = CreateGrid(wrappers);
            Assert.AreEqual(2, grid.Items.Count);

            wrappers.First().IsExpanded = true;
            Assert.AreEqual(3, grid.Items.Count);

            wrappers.First().IsExpanded = false;
            Assert.AreEqual(2, grid.Items.Count);
        }

        [TestMethod]
        public void SelectItemTest()
        {
            var wrappers = CreateWrappers();
            var grid = CreateGrid(wrappers);
            Assert.AreEqual(2, grid.Items.Count);

            grid.SelectedItem = wrappers.First();
            Assert.AreEqual(1, grid.SelectedItems.Count);
        }

        private static HierarchicalDataGridItemWrapperCollection CreateWrappers()
        {
            var items = new[] {
                new Item { Children = new IHierarchicalDataGridItem[] { new Item { Children = new IHierarchicalDataGridItem[0] }, } },
                new Item { Children = new IHierarchicalDataGridItem[] { new Item { Children = new IHierarchicalDataGridItem[0] }, } },
            };

            var wrappers = new HierarchicalDataGridItemWrapperCollection(items);
            return wrappers;
        }

        private static HierarchicalDataGrid CreateGrid(HierarchicalDataGridItemWrapperCollection wrappers)
        {
            var grid = new HierarchicalDataGrid
            {
                ItemsSource = wrappers
            };
            return grid;
        }

        private class Item : IHierarchicalDataGridItem
        {
            public IList<IHierarchicalDataGridItem> Children { get; set; }
        }
    }
}
