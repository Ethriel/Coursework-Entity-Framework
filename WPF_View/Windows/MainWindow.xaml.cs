using System.Windows;
using System.Windows.Controls;

namespace WPF_View.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            string content = b.Content.ToString();
            switch (content)
            {
                case "Login":
                    {
                        LoginWindow login = new LoginWindow();
                        login.Show();
                        break;
                    }
                case "Register":
                    {
                        RegisterWindow register = new RegisterWindow();
                        register.Show();
                        break;
                    }
                case "Exit":
                    {
                        break;
                    }
                default:
                    return;
            }
            this.Close();
        }
    }
}
