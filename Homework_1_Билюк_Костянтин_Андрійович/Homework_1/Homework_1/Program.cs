using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product cake = new Product("Cake", 7.99, 0.850);
            Product meal = new Product("Meal", 12.99, 1);

            Buy purchase = new Buy(cake, 2);
            Buy purchase2 = new Buy(meal, 4);

            Check.Show(purchase);
            Check.Show(purchase2);
            Check.Show(new Buy(new Product("Pizza", 6.99, 0.670), 4));

            Check.Show(cake);
            Check.Show(meal);
        }
    }
}
