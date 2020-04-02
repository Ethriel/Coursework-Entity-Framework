using BLL.Interface.AdminInterface;
using BLL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WPF_View.Helpers;
using WPF_View.Windows.CRUD;
using WPF_View.Windows.CRUD.Countries;

namespace WPF_View.Windows.Pages
{
    /// <summary>
    /// Interaction logic for CountriesPage.xaml
    /// </summary>
    public partial class CountriesPage : Page
    {
        IAdminInterface<Country> AdminInterface;
        public CountriesPage()
        {
            InitializeComponent();
            AdminInterface = new AdminInterfaceCountries();
        }

        private async void BtnListAll_Click(object sender, RoutedEventArgs e)
        {
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

        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvAll.SelectedItem != null)
            {
                try
                {
                    var c = LvAll.SelectedItem as Country;
                    var res = await RemoveEntity.Remove<Country>(AdminInterface, c);
                    if (res)
                    {
                        await Task.Run(() => RefreshList());
                    }
                    //await Task.Run(() => AdminInterface.RemoveAsync(c));
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

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddCountry(AdminInterface);
            add.ShowDialog();
            if (add.Country != null)
            {
                await Task.Run(() => RefreshList());
            }
        }
        private async void RefreshList()
        {
            var cities = await AdminInterface.GetEntitiesAsync();
            LvAll = ListViewHelper.RefreshList(LvAll, cities);
        }
    }
}
