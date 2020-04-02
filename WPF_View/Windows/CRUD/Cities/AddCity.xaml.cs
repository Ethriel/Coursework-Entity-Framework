using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DAL.Model;
using BLL.Interface.AdminInterface;
using WPF_View.Helpers;
using System.Windows.Controls.Primitives;

namespace WPF_View.Windows.CRUD.Cities
{
    /// <summary>
    /// Interaction logic for AddCity.xaml
    /// </summary>
    public partial class AddCity : Window
    {
        List<string> texts;
        IAdminInterface<City> AdminInterface;
        City city;
        IAdminInterface<Country> AdminInterfaceCountry;
        public AddCity(IAdminInterface<City> adminInterface)
        {
            InitializeComponent();
            AdminInterface = adminInterface;
            AdminInterfaceCountry = new AdminInterfaceCountries();
            city = new City();
            Tb.DataContext = city;
            texts = new List<string>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCountries();
        }
        private async void LoadCountries()
        {
            CB.DataContext = await AdminInterfaceCountry.GetEntitiesAsync();
        }
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
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
                if (CB.SelectedItem == null)
                {
                    popup = ConfigurePopup.Configure(popup, "Select an item!", CB, PlacementMode.Right);
                    popup.IsOpen = true;
                }
                else
                {
                    Country c = CB.SelectedItem as Country;
                    city.Country = c;
                    try
                    {
                        AdminInterface.Add(city);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        popup = ConfigurePopup.Configure(popup, ex.Message, BtnConfirm, PlacementMode.Top);
                        popup.IsOpen = true;
                    }
                }
            }
        }
    }
}
