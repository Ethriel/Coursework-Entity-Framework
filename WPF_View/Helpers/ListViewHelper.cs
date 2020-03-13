using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_View.Helpers
{
    public static class ListViewHelper
    {
        public static ListView RefreshList(ListView lv, IEnumerable context)
        {
            lv.Dispatcher.Invoke(() => lv.ItemsSource = null);
            lv.Dispatcher.Invoke(() => lv.Items.Clear());
            lv.Dispatcher.Invoke(() => lv.DataContext = null);
            lv.Dispatcher.Invoke(() => lv.DataContext = context);
            lv.Dispatcher.Invoke(() => lv.ItemsSource = context);
            return lv;
        }
    }
}
