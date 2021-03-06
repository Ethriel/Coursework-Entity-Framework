﻿using BLL.Interface.Interfaces;
using DAL.Model;
using System.Collections.Generic;
using System.Windows;
using WPF_View.Helpers;
using System.Windows.Controls.Primitives;

namespace WPF_View.Windows.CRUD.Attration
{
    /// <summary>
    /// Interaction logic for AddAttraction.xaml
    /// </summary>
    public partial class AddAttraction : Window
    {
        Attraction Attraction;
        List<string> texts;
        IAdminInterface<Attraction> AdminInterface;
        public AddAttraction(IAdminInterface<Attraction> adminInterface)
        {
            InitializeComponent();
            AdminInterface = adminInterface;
            Attraction = new Attraction();
            SP.DataContext = Attraction;
            popup = ConfigurePopup.Configure(popup, "Fill all the fields first!", BtnConfirm, PlacementMode.Top);
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
            texts = ListTextBoxesHelper.GetText(SP.Children);
            if (ListTextBoxesHelper.StringsNotEmpty(texts))
            {
                if (!DecimalNumberChecker.Check(texts[1]))
                {
                    popup = ConfigurePopup.Configure(popup, "Only decimal numbers in price are allowed in price field!", BtnConfirm, PlacementMode.Top);
                    popup.IsOpen = true;
                    return;
                }
                AdminInterface.Add(Attraction);
                this.Close();
            }
            else
            {
                popup.IsOpen = true;
            }
        }
    }
}
