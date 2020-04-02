using BLL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using WPF_View.Helpers;

namespace WPF_View.Windows.CRUD.Countries
{
    /// <summary>
    /// Interaction logic for AddCountry.xaml
    /// </summary>
    public partial class AddCountry : Window
    {
        IAdminInterface<Country> AdminInterface;
        public Country Country { get; private set; }
        public AddCountry(IAdminInterface<Country> adminInterface)
        {
            InitializeComponent();
            AdminInterface = adminInterface;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb.Text))
            {
                popup = ConfigurePopup.Configure(popup, "Enter country name first!", BtnConfirm, PlacementMode.Top);
                popup.IsOpen = true;
                return;
            }
            else
            {
                Country = new Country() { CountryName = Tb.Text };
                try
                {
                    AdminInterface.Add(Country);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
