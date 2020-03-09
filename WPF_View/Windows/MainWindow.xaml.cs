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
            if (tag.Equals("Exit"))
            {
                this.Close();
            }
            else
            {
                PagesFrame.Source = new Uri(tag, UriKind.Relative);
                PagesGrid.Visibility = Visibility.Visible;
                MainGrid.Visibility = Visibility.Collapsed;
                this.Width = 300;
                this.Height = 250;
            }
        }
    }
}
