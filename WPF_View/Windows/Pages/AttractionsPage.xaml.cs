using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BLL.Interface.Interfaces;
using BLL.Interface.AdminInterface;
using DAL.Model;
using System.Windows.Controls.Primitives;
using WPF_View.Windows.CRUD.Attration;
using WPF_View.Helpers;

namespace WPF_View.Windows.Pages
{
    /// <summary>
    /// Interaction logic for AttractionsPage.xaml
    /// </summary>
    public partial class AttractionsPage : Page
    {
        IAdminInterface<Attraction> AdminInterface;
        public AttractionsPage()
        {
            InitializeComponent();
            AdminInterface = new AdminInterfaceAttractions();
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
                UpdateAttraction update = new UpdateAttraction(LvAll.SelectedItem as Attraction, AdminInterface);
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
                    Attraction a = LvAll.SelectedItem as Attraction;
                    await Task.Run(() => AdminInterface.RemoveAsync(a));
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
            AddAttraction add = new AddAttraction(AdminInterface);
            add.ShowDialog();
        }
    }
}
