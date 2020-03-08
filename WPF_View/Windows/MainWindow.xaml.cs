using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DAL.Interface.Customer;
using DAL.Interface.Admin;
using BLL.Interface.AdminInterface;
using BLL.Interface.CustomerInterface;
using DAL.Model;
using BLL.Interface.Login;

namespace WPF_View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Tourist tourist;
        Employee employee;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            UserInteraction ui = new UserInteraction();
            LoginData ld = new LoginData() { Login = login.Text, Password = password.Text };
            string role = ui.GetUserRole(ld);
            switch (role)
            {
                case "Admin":
                    {
                        
                        break;
                    }
                case "User":
                    {
                        tourist = ui.SignIn(ld);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
