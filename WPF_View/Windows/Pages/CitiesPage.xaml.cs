﻿using BLL.Interface.AdminInterface;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_View.Helpers;
using WPF_View.Windows.CRUD.Cities;

namespace WPF_View.Windows.Pages
{
    /// <summary>
    /// Interaction logic for CitiesPage.xaml
    /// </summary>
    public partial class CitiesPage : Page
    {
        IAdminInterface<City> AdminInterface;
        public CitiesPage()
        {
            InitializeComponent();
            AdminInterface = new AdminInterfaceCities();
        }

        private async void BtnListAll_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            try
            {
                if (LvAll.DataContext != null)
                {
                    return;
                }
                LvAll.DataContext = await AdminInterface.GetEntitiesAsync();
            }
            catch (Exception ex)
            {
                popup = ConfigurePopup.Configure(popup, ex.Message, BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            if (LvAll.SelectedItem != null)
            {
                UpdateCity update = new UpdateCity(LvAll.SelectedItem as City, AdminInterface);
                update.ShowDialog();
            }
            else
            {
                popup = ConfigurePopup.Configure(popup, "Select item first!", LvAll, PlacementMode.Right);
                popup.IsOpen = true;
            }
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            if (LvAll.SelectedItem != null)
            {
                try
                {
                    City c = LvAll.SelectedItem as City;
                    await Task.Run(() => AdminInterface.RemoveAsync(c));
                }
                catch (Exception ex)
                {
                    popup = ConfigurePopup.Configure(popup, ex.Message, BtnDelete, PlacementMode.Bottom);
                    popup.IsOpen = true;
                }
            }
            else
            {
                popup = ConfigurePopup.Configure(popup, "Select item first!", LvAll, PlacementMode.Right);
                popup.IsOpen = true;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCity add = new AddCity(AdminInterface);
            add.ShowDialog();
        }
    }
}
