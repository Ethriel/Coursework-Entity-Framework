using BLL.Interface.Login;
using DAL.Model;
using System;
using System.Linq;
using System.Windows;

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
            SetDefaultAdmin();
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
        private void SetDefaultAdmin()
        {
            login.Text = "jhongreen@gmail.com";
            password.Password = "qwerty";
        }
        private void SetDefaultUser()
        {
            login.Text = "greggreen@gmail.com";
            password.Password = "1";
        }
    }
}
