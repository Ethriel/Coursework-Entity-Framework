using BLL.Interface.AdminInterface;
using BLL.Interface.Interfaces;
using DAL.Model;
using Microsoft.Win32;
using System.Windows.Controls.Primitives;
using WPF_View.Helpers;
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

namespace WPF_View.Windows.CRUD.Hotels
{
    /// <summary>
    /// Interaction logic for UpdateHotel.xaml
    /// </summary>
    public partial class UpdateHotel : Window
    {
        List<string> texts;
        IAdminInterface<Hotel> AdminInterface;
        public Hotel Hotel { get; set; }
        IAdminInterface<City> AdminInterfaceCities;
        IAdminInterface<Picture> AdminInterfacePictures;
        public UpdateHotel(IAdminInterface<Hotel> adminInterface)
        {
            InitializeComponent();
            AdminInterface = adminInterface;
            AdminInterfaceCities = new AdminInterfaceCities();
            texts = new List<string>();
            AdminInterfacePictures = new AdminInterfacePictures();
        }

        private async void BtnAddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            popup.IsOpen = false;
            od.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
            if ((bool)od.ShowDialog())
            {
                Picture pic = new Picture() { Picture1 = od.FileName };
                try
                {
                    AdminInterfacePictures.Add(pic);
                    var p = await (AdminInterfacePictures as AdminInterfacePictures).GetByReferenceAsync(od.FileName);
                    Hotel.Pictures.Add(p);
                }
                catch (Exception ex)
                {
                    popup = ConfigurePopup.Configure(popup, ex.Message, BtnConfirm, PlacementMode.Top);
                    popup.IsOpen = true;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCities();
            Tb.DataContext = Hotel;
        }

        private async void LoadCities()
        {
            CB.DataContext = await AdminInterfaceCities.GetEntitiesAsync();
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            popup = ConfigurePopup.Configure(popup, "Fill all fields first and select picture!", BtnConfirm, PlacementMode.Top);
            popup.IsOpen = false;
            texts.Clear();
            texts.Add((SP.Children[0] as TextBox).Text);
            if (!ListTextBoxesHelper.StringsNotEmpty(texts) || !Hotel.Pictures.Any())
            {
                popup.IsOpen = true;
            }
            else
            {
                City c = CB.SelectedItem as City;
                Hotel.City = c;
                try
                {
                    await Task.Run(() => AdminInterface.UpdateAsync(Hotel.Id, Hotel));
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
