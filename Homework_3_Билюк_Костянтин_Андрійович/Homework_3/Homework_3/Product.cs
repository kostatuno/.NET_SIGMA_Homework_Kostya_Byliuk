using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_3
{
    class Product : ICloneable
    {
        protected string Name { get; }
        private double _price;
        private double _weight;
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price should be a positive number");
                _price = value;
            }
        }
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weight should be a positive number");
                _weight = value;
            }
        }

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

        public virtual void ChangePrice(double percentageValueOfPrice)
        {
            Price = Math.Round((Price * (percentageValueOfPrice * 0.01)), 2);
        }

        public override string ToString()
        {
            return string.Format($"Name = {Name}, Price = {Price}$, Weight = {Weight}kg");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Product obj2 || !(this.GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                return (this.Name == obj2.Name && this.Price == obj2.Price && this.Weight == obj2.Weight);
            }
        }

        public static bool Equals(object? obj, object? obj2)
        {
            if (obj == obj2) return true;
            if (obj == null || obj2 == null) return false;
            else return obj.Equals(obj2);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(Price);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}