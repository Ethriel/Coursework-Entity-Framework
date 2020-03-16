using BLL.Interface.AdminInterface;
using BLL.Interface.Interfaces;
using DAL.Model;
using Microsoft.Win32;
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

namespace WPF_View.Windows.CRUD.Hotels
{
    /// <summary>
    /// Interaction logic for AddHotel.xaml
    /// </summary>
    public partial class AddHotel : Window
    {
        List<string> texts;
        IAdminInterface<Hotel> AdminInterface;
        Hotel hotel;
        IAdminInterface<City> AdminInterfaceCities;
        IAdminInterface<Picture> AdminInterfacePictures;
        public AddHotel(IAdminInterface<Hotel> adminInterface)
        {
            InitializeComponent();
            AdminInterface = adminInterface;
            AdminInterfaceCities = new AdminInterfaceCities();
            hotel = new Hotel();
            Tb.DataContext = hotel;
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
                    hotel.Pictures.Add(p);
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
        }

        private async void LoadCities()
        {
            CB.DataContext = await AdminInterfaceCities.GetEntitiesAsync();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            popup = ConfigurePopup.Configure(popup, "Fill all fields first and select picture!", BtnConfirm, PlacementMode.Top);
            popup.IsOpen = false;
            texts.Clear();
            texts.Add((SP.Children[0] as TextBox).Text);
            if (!ListTextBoxesHelper.StringsNotEmpty(texts) || !hotel.Pictures.Any())
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
                    City c = CB.SelectedItem as City;
                    hotel.City = c;
                    try
                    {
                        AdminInterface.Add(hotel);
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
