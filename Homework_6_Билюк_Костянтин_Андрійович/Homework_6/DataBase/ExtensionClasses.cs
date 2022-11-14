using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public static class ExstensionParseForDateTime
    {
        public static DateTime? ToDateTime(this string str)
        {
            if (str == "null")
            {
                return null;
            }
            return Convert.ToDateTime(str);
        }
    }

    public static class ExstensionParseForDouble
    {
        public static double? ToDouble(this string str)
        {
            if (str == "null")
            {
                return null;
            }
            return Convert.ToDouble(str);
        }
    }
}
