using BLL.Interface.Interfaces;
using BLL.Interface.AdminInterface;
using DAL.Model;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPF_View.Helpers;
using System.Windows.Controls.Primitives;
using WPF_View.Windows.CRUD.Hotels;

namespace WPF_View.Windows.Pages
{
    /// <summary>
    /// Interaction logic for HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        IAdminInterface<Hotel> AdminInterface;
        public HotelsPage()
        {
            InitializeComponent();
            AdminInterface = new AdminInterfaceHotels();
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

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (LvAll.SelectedItem == null)
            {
                popup = ConfigurePopup.Configure(popup, "Select an item first!", BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
                return;
            }
            UpdateHotel update = new UpdateHotel(AdminInterface) { Hotel = (LvAll.SelectedItem as Hotel) };
            update.ShowDialog();
            await Task.Run(() => RefreshList());
        }

        private async void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvAll.SelectedItem == null)
            {
                popup = ConfigurePopup.Configure(popup, "Select an item first!", BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
                return;
            }
            try
            {
                await Task.Run(() => AdminInterface.RemoveAsync(LvAll.SelectedItem as Hotel));
                await Task.Run(() => RefreshList());
            }
            catch (Exception ex)
            {
                popup = ConfigurePopup.Configure(popup, ex.Message, BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
            }
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddHotel add = new AddHotel(AdminInterface);
            add.ShowDialog();
            await Task.Run(() => RefreshList());
        }
        private async void RefreshList()
        {
            var hotels = await AdminInterface.GetEntitiesAsync();
            LvAll = ListViewHelper.RefreshList(LvAll, hotels);
        }
    }
}
