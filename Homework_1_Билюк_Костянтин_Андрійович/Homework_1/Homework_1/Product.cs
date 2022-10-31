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
}
