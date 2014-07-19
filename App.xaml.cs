using System.Windows;

namespace NativeToolTip
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnExit(object sender, ExitEventArgs e)
        {
            NativeToolTipControl.Destroy();
        }
    }
}
