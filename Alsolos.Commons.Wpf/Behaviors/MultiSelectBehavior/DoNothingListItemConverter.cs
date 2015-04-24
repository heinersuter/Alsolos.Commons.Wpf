namespace Alsolos.Commons.Wpf.Behaviors.MultiselectBehavior
{
    public class DoNothingListItemConverter : IListItemConverter
    {
        public object Convert(object masterListItem)
        {
            return masterListItem;
        }

        public object ConvertBack(object targetListItem)
        {
            return targetListItem;
        }
    }
}