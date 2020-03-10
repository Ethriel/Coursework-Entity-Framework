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
            string tag = b.Tag.ToString();
            switch (tag)
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
