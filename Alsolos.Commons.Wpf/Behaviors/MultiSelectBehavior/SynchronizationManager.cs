namespace Alsolos.Commons.Wpf.Behaviors.MultiselectBehavior
{
    using System;
    using System.Collections;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;

    public class SynchronizationManager
    {
        private readonly Selector _multiSelector;
        private TwoListSynchronizer _synchronizer;

        public SynchronizationManager(Selector selector)
        {
            _multiSelector = selector;
        }

        public void StartSynchronizingList()
        {
            var list = MultiselectBehaviour.GetSelectedItems(_multiSelector);

            if (list != null)
            {
                _synchronizer = new TwoListSynchronizer(GetSelectedItemsCollection(_multiSelector), list);
                _synchronizer.StartSynchronizing();
            }
        }

        public void StopSynchronizing()
        {
            _synchronizer.StopSynchronizing();
        }

        public static IList GetSelectedItemsCollection(Selector selector)
        {
            var multiSelector = selector as MultiSelector;
            if (multiSelector != null)
            {
                return multiSelector.SelectedItems;
            }
            var listBox = selector as ListBox;
            if (listBox != null)
            {
                return listBox.SelectedItems;
            }
            throw new InvalidOperationException("Target object has no SelectedItems property to bind.");
        }
    }
}