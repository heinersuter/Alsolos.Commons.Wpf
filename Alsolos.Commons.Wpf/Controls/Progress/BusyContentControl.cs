namespace Alsolos.Commons.Wpf.Controls.Progress
{
    using System.Windows;
    using System.Windows.Controls;

    public class BusyContentControl : ContentControl
    {
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register(
            "IsBusy", typeof(bool), typeof(BusyContentControl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            "Message", typeof(string), typeof(BusyContentControl), new PropertyMetadata(default(string)));

        static BusyContentControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BusyContentControl), new FrameworkPropertyMetadata(typeof(BusyContentControl)));
        }

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }
    }
}
