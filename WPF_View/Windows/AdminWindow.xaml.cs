using DAL.Model;
using System;
using System.Windows;
using System.Windows.Controls;

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
                        TbPage.Text = $"{text} page";
                        TbPage.Visibility = Visibility.Visible;
                        PagesFrame.Focus();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
