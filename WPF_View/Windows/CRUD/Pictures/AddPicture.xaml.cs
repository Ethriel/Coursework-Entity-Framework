using BLL.Interface.Interfaces;
using DAL.Model;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WPF_View.Helpers;
using WPF_View.Helpers.PicturesHelper;

namespace WPF_View.Windows.CRUD.Pictures
{
    /// <summary>
    /// Interaction logic for AddPicture.xaml
    /// </summary>
    public partial class AddPicture : Window
    {
        IAdminInterface<Picture> adminInterfacePictures;
        string picLink;
        public Picture Picture { get; set; }
        public AddPicture(IAdminInterface<Picture> adminInterfacePictures)
        {
            InitializeComponent();
            this.adminInterfacePictures = adminInterfacePictures;
        }

        private void BtnSelectPicture_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb.Text))
            {
                picLink = Tb.Text;
            }
            else
            {
                var od = new OpenFileDialog();
                popup.IsOpen = false;
                od.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
                if ((bool)od.ShowDialog())
                {
                    picLink = od.FileName;
                }
                else
                {
                    popup = ConfigurePopup.Configure(popup, "No picture was selected", BtnSelectPicture, PlacementMode.Top);
                    popup.IsOpen = true;
                    return;
                }
            }
            SetPicture();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(picLink))
            {
                try
                {
                    Picture = new Picture() { Picture1 = picLink };
                    adminInterfacePictures.Add(Picture);
                    this.Close();
                }
                catch (Exception ex)
                {
                    popup = ConfigurePopup.Configure(popup, ex.Message, BtnConfirm, PlacementMode.Top);
                    popup.IsOpen = true;
                }
            }
            else
            {
                popup = ConfigurePopup.Configure(popup, "No picture was selected", BtnConfirm, PlacementMode.Top);
                popup.IsOpen = true;
            }
        }
        private async void SetPicture()
        {
            PictureHelper ph = new PictureHelper();
            var bitmap = await ph.GetImage(picLink);
            Dispatcher.Invoke(new Action(() =>
            {
                PicImg.Source = null;
                PicImg.Source = bitmap;
            }));
        }
        private void BtnSetPicture_MouseEnter(object sender, MouseEventArgs e)
        {
            ((sender as Button).ToolTip as ToolTip).IsOpen = true;
        }

        private void BtnSetPicture_MouseLeave(object sender, MouseEventArgs e)
        {
            ((sender as Button).ToolTip as ToolTip).IsOpen = true;
        }
    }
}
