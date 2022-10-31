using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    static class Check
    {
        public static void Show(Product product)
        {
            Console.WriteLine(product);
            AddUnderline(product);
        }

        public static void Show(Buy buying)
        {
            Console.WriteLine(buying);
            AddUnderline(buying);
        }

        public static void AddUnderline(object obj)
        {
            var str = obj.ToString();
            for (int i = str.LastIndexOf('F'); i < str.Length + 3; i++)
                Console.Write("-");
            Console.WriteLine("\n");
        }
    }
}
