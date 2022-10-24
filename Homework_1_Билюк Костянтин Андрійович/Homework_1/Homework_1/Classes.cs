using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_1
{
    class Product
    {
        public Product(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Weight = product.Weight;
        }

        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        private string Name { get; set; }
        protected double Price { get; set; }
        private double Weight { get; set; }

        public override string ToString()
        {
            return string.Format($"Name = {Name}, Price = {Price}$, Weight = {Weight}kg");
        }
    }

    class Buy : Product
    {
        public Buy(Buy purchase) : base(purchase.Product)
        {
            Count = purchase.Count;
        }

        public Buy(Product product, int count) : base(product)
        {
            Count = count;
            Product = product;
        }

        protected int Count { get; set; }
        protected Product Product { get; }
        public double FinalPrice => Count * Price; 

        public override string ToString()
        {
            return string.Format($"{Product}, Count = {Count}\n \"FinalPrice {FinalPrice}$\"");
        }
    }

    class Check : Buy
    {
        public Check(Buy buying) : base(buying)
        {
            Show(buying);
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
