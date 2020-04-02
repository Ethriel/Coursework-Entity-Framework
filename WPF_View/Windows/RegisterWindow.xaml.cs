using BLL.Interface.Login;
using DAL.Model;
using System.Windows;

namespace WPF_View.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        Tourist tourist;
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            UserInteraction ui = new UserInteraction();
        }
    }
}
