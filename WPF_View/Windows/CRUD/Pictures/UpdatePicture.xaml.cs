using BLL.Interface.Interfaces;
using DAL.Model;
using Microsoft.Win32;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WPF_View.Helpers;
using WPF_View.Helpers.PicturesHelper;

namespace WPF_View.Windows.CRUD.Pictures
{
    /// <summary>
    /// Interaction logic for UpdatePicture.xaml
    /// </summary>
    public partial class UpdatePicture : Window
    {
        IAdminInterface<Picture> adminInterfacePictures;
        string picRef;
        string defPicture;
        public Picture Picture { get; set; }
        public UpdatePicture(IAdminInterface<Picture> adminInterfacePictures)
        {
            InitializeComponent();
            this.adminInterfacePictures = adminInterfacePictures;
        }

        private void BtnSetPicture_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Tb.Text) && !Tb.Text.Equals(defPicture))
            {
                picRef = Tb.Text;
            }
            else
            {
                var od = new OpenFileDialog();
                popup.IsOpen = false;
                od.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
                if ((bool)od.ShowDialog())
                {
                    picRef = od.FileName;
                }
                else
                {
                    popup = ConfigurePopup.Configure(popup, "No picture was selected", BtnSetPicture, PlacementMode.Top);
                    popup.IsOpen = true;
                    return;
                }
            }
            Picture.Picture1 = picRef;
            SetPicture();
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (picRef.Equals(defPicture))
            {
                this.Close();
            }
            if (!string.IsNullOrWhiteSpace(picRef))
            {
                try
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        Picture.Picture1 = picRef;
                    }));
                    await Task.Run(() => adminInterfacePictures.UpdateAsync(Picture.Id, Picture));
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Tb.DataContext = Picture;
            SetPicture();
            defPicture = Picture.Picture1;
            picRef = defPicture;
        }
        private async void SetPicture()
        {
            PictureHelper ph = new PictureHelper();
            var bitmap = await ph.GetImage(Picture.Picture1);
            Dispatcher.Invoke(new Action(() =>
            {
                PicImg.Source = null;
                PicImg.Source = bitmap;
            }));
        }

        private void BtnSetPicture_MouseEnter(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            (btn.ToolTip as ToolTip).IsOpen = true;
        }

        private void BtnSetPicture_MouseLeave(object sender, MouseEventArgs e)
        {
            var btn = sender as Button;
            (btn.ToolTip as ToolTip).IsOpen = true;
        }
    }
}
