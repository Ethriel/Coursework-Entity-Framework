﻿using BLL.Interface.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using WPF_View.Helpers;
using System.Windows.Controls.Primitives;

namespace WPF_View.Windows.CRUD.Attration
{
    /// <summary>
    /// Interaction logic for UpdateAttraction.xaml
    /// </summary>
    public partial class UpdateAttraction : Window
    {
        Attraction Attraction;
        List<string> texts;
        IAdminInterface<Attraction> AdminInterface;
        public UpdateAttraction(Attraction attraction, IAdminInterface<Attraction> adminInterface)
        {
            InitializeComponent();
            Attraction = attraction;
            AdminInterface = adminInterface;
        }

        private async void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            popup = ConfigurePopup.Configure(popup, "Fill all the fields first!", BtnConfirm, PlacementMode.Top);
            popup.IsOpen = false;
            texts = ListTextBoxesHelper.GetText(SP.Children);
            if (ListTextBoxesHelper.StringsNotEmpty(texts))
            {
                try
                {
                    if (!DecimalNumberChecker.Check(texts[1]))
                    {
                        popup = ConfigurePopup.Configure(popup, "Only decimal numbers in price are allowed in price field!", BtnConfirm, PlacementMode.Top);
                        popup.IsOpen = true;
                        return;
                    }
                    await Task.Run(() => AdminInterface.UpdateAsync(Attraction.Id, Attraction));
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
                popup.IsOpen = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SP.DataContext = Attraction;
        }
    }
}
