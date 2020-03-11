using BLL.Interface.Interfaces;
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

namespace WPF_View.Windows.CRUD.Cities
{
    /// <summary>
    /// Interaction logic for UpdateCity.xaml
    /// </summary>
    public partial class UpdateCity : Window
    {
        public UpdateCity(City city, IAdminInterface<City> adminInterface)
        {
            InitializeComponent();
        }
    }
}
