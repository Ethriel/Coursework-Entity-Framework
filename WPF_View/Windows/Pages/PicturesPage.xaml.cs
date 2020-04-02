using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BLL.Interface.Interfaces;
using BLL.Interface.AdminInterface;
using DAL.Model;
using WPF_View.Helpers;
using WPF_View.Helpers.PicturesHelper;
using System.Windows.Controls.Primitives;
using WPF_View.Windows.CRUD.Pictures;

namespace WPF_View.Windows.Pages
{
    /// <summary>
    /// Interaction logic for PicturesPage.xaml
    /// </summary>
    public partial class PicturesPage : Page
    {
        IAdminInterface<Picture> AdminInterface;
        public PicturesPage()
        {
            InitializeComponent();
            AdminInterface = new AdminInterfacePictures();
        }

        private async void BtnListAll_Click(object sender, RoutedEventArgs e)
        {
            PictureHelper ph = new PictureHelper();
            try
            {
                if (LvAll.DataContext != null)
                {
                    return;
                }
                var pics = await ph.GetAllPictures(AdminInterface);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    LvAll.DataContext = pics;
                }));
            }
            catch (Exception ex)
            {
                popup = ConfigurePopup.Configure(popup, ex.Message, BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
            }
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (LvAll.SelectedItem != null)
            {
                var p = await AdminInterface.GetAsync((LvAll.SelectedItem as PictureInfo).Id);
                var update = new UpdatePicture(AdminInterface) { Picture = p };
                update.ShowDialog();
            }
            else
            {
                popup = ConfigurePopup.Configure(popup, "Select an item first!", BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
                return;
            }
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
                var p = await AdminInterface.GetAsync((LvAll.SelectedItem as PictureInfo).Id);
                if (p != null)
                {
                    await Task.Run(() => AdminInterface.RemoveAsync(p));
                    await Task.Run(() => RefreshList());
                }
            }
            catch (Exception ex)
            {
                popup = ConfigurePopup.Configure(popup, ex.Message, BtnListAll, PlacementMode.Bottom);
                popup.IsOpen = true;
            }
        }

        private async void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var add = new AddPicture(AdminInterface);
            add.ShowDialog();
            if (add.Picture != null)
            {
                await Task.Run(() => RefreshList());
            }
        }
        private async void RefreshList()
        {
            var pictures = await AdminInterface.GetEntitiesAsync();
            LvAll = ListViewHelper.RefreshList(LvAll, pictures);
        }
    }
}
