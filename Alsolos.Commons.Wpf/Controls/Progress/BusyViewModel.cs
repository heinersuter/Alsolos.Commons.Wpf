namespace Alsolos.Commons.Wpf.Controls.Progress
{
    using Alsolos.Commons.Wpf.Mvvm;

    public abstract class BusyViewModel : ViewModel
    {
        protected BusyViewModel()
        {
            BusyHelper = new BusyHelper();
        }

        public BusyHelper BusyHelper { get; private set; }
    }
}
