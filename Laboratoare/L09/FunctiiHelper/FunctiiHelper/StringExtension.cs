using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctiiHelper
{
    public static class StringExtension
    {
        public static string CipCriptare(this string str, string cheie)
        {
            var arrayText = str.ToArray();
            string result = string.Empty;
            foreach (var ch in arrayText)
            {
                result += ch + cheie;
            }
            return result;
        }
    }
}
