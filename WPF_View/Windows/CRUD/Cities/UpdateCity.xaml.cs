using BLL.Interface.AdminInterface;
using BLL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_View.Helpers;

namespace WPF_View.Windows.CRUD.Cities
{
    /// <summary>
    /// Interaction logic for UpdateCity.xaml
    /// </summary>
    public partial class UpdateCity : Window
    {
        City City;
        IAdminInterface<City> AdminInterface;
        IAdminInterface<Country> AdminInterfaceCountry;
        List<string> texts;
        public UpdateCity(City city, IAdminInterface<City> adminInterface)
        {
            InitializeComponent();
            City = city;
            AdminInterface = adminInterface;
            AdminInterfaceCountry = new AdminInterfaceCountries();
            SP.DataContext = City;
            texts = new List<string>();
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            popup = ConfigurePopup.Configure(popup, "Fill all fields first!", BtnConfirm, PlacementMode.Top);
            popup.IsOpen = false;
            texts.Clear();
            texts.Add((SP.Children[0] as TextBox).Text);
            if (!ListTextBoxesHelper.StringsNotEmpty(texts))
            {
                popup.IsOpen = true;
            }
            else
            {
                if (CB.SelectedItem != null)
                {
                    City.Country = CB.SelectedItem as Country;
                }
                await Task.Run(() => TryUpdate());
            }
        }
        private async void TryUpdate()
        {
            try
            {
                await Task.Run(() => AdminInterface.UpdateAsync(City.Id, City));
                this.Close();
            }
            catch (Exception ex)
            {
                popup = ConfigurePopup.Configure(popup, ex.Message, BtnConfirm, PlacementMode.Top);
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCountries();
        }
        private async void LoadCountries()
        {
            CB.DataContext = await AdminInterfaceCountry.GetEntitiesAsync();
        }
    }
}
