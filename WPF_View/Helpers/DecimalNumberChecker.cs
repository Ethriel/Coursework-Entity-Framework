using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPF_View.Helpers
{
    public static class DecimalNumberChecker
    {
        public static bool Check(string num)
        {
            string pattern = @"(^[0-9]+?)([.][0-9]{1,3})?$";
            bool res = Regex.IsMatch(num, pattern);
            return res;
        }
    }
}
