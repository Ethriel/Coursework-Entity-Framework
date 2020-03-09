using BLL.Interface.Login;
using DAL.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_View.Windows;

namespace WPF_View.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Employee employee;
        Tourist tourist;
        public LoginPage()
        {
            InitializeComponent();
        }
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Window.GetWindow(this);
            UserInteraction ui = new UserInteraction();
            LoginData ld = new LoginData() { Login = login.Text, Password = password.Password };
            string role = ui.GetUserRole(ld);
            switch (role)
            {
                case "Admin":
                    {
                        employee = ui.SignIn(ld).Employees.FirstOrDefault();
                        AdminWindow adminWindow = new AdminWindow() { Employee = employee };
                        adminWindow.Show();
                        mainWindow.Close();
                        break;
                    }
                case "User":
                    {
                        tourist = ui.SignIn(ld).Tourists.FirstOrDefault();
                        CustomerWindow customerWindow = new CustomerWindow() { Tourist = tourist };
                        customerWindow.Show();
                        mainWindow.Close();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
