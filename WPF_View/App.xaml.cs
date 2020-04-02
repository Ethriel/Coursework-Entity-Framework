using System.Windows;
using DAL.Helpers;

namespace WPF_View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ContextHelper.DisposeContext();
        }
    }
}
