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
using System.Windows.Shapes;

namespace WPF_View.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Employee employee;
        Tourist tourist;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private async void confirm_Click(object sender, RoutedEventArgs e)
        {
            TbPopup.Text = "Fill all the fields first!";
            UserInteraction ui = new UserInteraction();
            if (!string.IsNullOrWhiteSpace(login.Text) && !string.IsNullOrWhiteSpace(password.Password))
            {
                popup.IsOpen = false;
                LoginData ld = new LoginData() { Login = login.Text, Password = password.Password };
                try
                {
                    string role = await ui.GetUserRole(ld);
                    switch (role)
                    {
                        case "Admin":
                            {
                                var u = await ui.SignIn(ld);
                                employee = u.Employees.FirstOrDefault();
                                AdminWindow adminWindow = new AdminWindow() { Employee = employee };
                                adminWindow.Show();
                                break;
                            }
                        case "User":
                            {
                                var u = await ui.SignIn(ld);
                                tourist = u.Tourists.FirstOrDefault();
                                CustomerWindow customerWindow = new CustomerWindow() { Tourist = tourist };
                                customerWindow.Show();
                                break;
                            }
                        default:
                            return;
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    TbPopup.Text = ex.Message;
                    popup.IsOpen = true;
                }

            }
            else
            {
                popup.IsOpen = true;
            }
        }
    }
}
