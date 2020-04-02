using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WPF_View.Helpers
{
    public static class ListTextBoxesHelper
    {
        public static List<string> GetText(UIElementCollection collection)
        {
            var list = (from TextBox c in collection
                        select c).ToList();
            var texts = (from t in list
                         select t.Text).ToList();
            return texts;
        }
        public static bool StringsNotEmpty(List<string> texts)
        {
            foreach (var t in texts)
            {
                if (string.IsNullOrWhiteSpace(t))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
