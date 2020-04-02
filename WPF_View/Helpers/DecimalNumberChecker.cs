using System.Text.RegularExpressions;

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
