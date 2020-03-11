using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WPF_View.Helpers
{
    public static class ConfigurePopup
    {
        public static Popup Configure(Popup popup, string text, UIElement target, PlacementMode placement)
        {
            (popup.Child as TextBlock).Text = text;
            popup.PlacementTarget = target;
            popup.Placement = placement;
            return popup;
        }
    }
}
