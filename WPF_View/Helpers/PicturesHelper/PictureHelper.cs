using BLL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WPF_View.Helpers.PicturesHelper
{
    public class PictureInfo
    {
        public BitmapImage PictureSource { get; set; }
        public string PictureReference { get; set; }
        public int Id { get; set; }
    }
    public class PictureHelper
    {
        public async Task<List<PictureInfo>> GetAllPictures(IAdminInterface<Picture> aip)
        {
            var pics = await aip.GetEntitiesAsync();
            return await Task.Run(() =>
            {
                List<PictureInfo> pictures = new List<PictureInfo>();
                foreach (var pic in pics)
                {
                    var img = GetBitmap(pic.Picture1);
                    if (img != null)
                    {
                        var reference = pic.Picture1;
                        pictures.Add(new PictureInfo() { PictureSource = img, PictureReference = reference, Id = pic.Id });
                    }
                }
                return pictures;
            });
        }
        public async Task<BitmapImage> GetImage(string path)
        {
            BitmapImage bitmap = null;
            return await Task.Run(() =>
            {
                bitmap = GetBitmap(path);
                return bitmap;
            });
        }
        private BitmapImage GetBitmap(string path)
        {
            var defaultPicture = "../../no_img.jpg";
            var defPicInfo = new FileInfo(defaultPicture);
            BitmapImage img = null;
            Uri uri = null;
            try
            {
                uri = new Uri(path);
            }
            catch (Exception ex)
            {
                uri = new Uri(defPicInfo.FullName);
            }
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                img = new BitmapImage(uri);
            }));
            return img;
        }
    }
}
