using DAL.Model;
using System.Windows;

namespace WPF_View.Windows
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Tourist Tourist { get; set; }
        public CustomerWindow()
        {
            InitializeComponent();
        }
    }
}
