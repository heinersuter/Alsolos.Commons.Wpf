namespace Alsolos.Commons.Wpf.UnitTests.Controls.FindInSelector
{
    public class MyItem
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return Name + " (" + Details + ") [" + Number + "]";
        }
    }
}
