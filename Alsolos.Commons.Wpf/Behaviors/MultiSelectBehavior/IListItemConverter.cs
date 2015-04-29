namespace Alsolos.Commons.Wpf.Behaviors.MultiselectBehavior
{
    public interface IListItemConverter
    {
        object Convert(object masterListItem);

        object ConvertBack(object targetListItem);
    }
}