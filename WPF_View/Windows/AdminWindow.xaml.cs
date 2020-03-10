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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public Employee Employee { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text = (sender as Button).Content.ToString();
            switch (text)
            {
                case "Attractions":
                case "Cities":
                case "Countries":
                case "Hotels":
                case "Pictures":
                case "Tours":
                    {
                        PagesFrame.Source = new Uri($"Pages/{text}Page.xaml", UriKind.Relative);
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
