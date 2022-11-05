using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    static class Check
    {
        public static void Show(Cart cart)
        {
            Console.WriteLine(cart);
        }

        public static void Show(Product product)
        {
            Console.WriteLine(product);
        }

        public static void Show(Buy buying)
        {
            Console.WriteLine(buying);
        }
    }
}
