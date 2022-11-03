using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_3
{
    class Buy // прибрав наслідування
    {
        private List<Product> _purchases;
        private double _finalPrice;
        private double _finalWeight;
        private int _count;

        public Buy(params Product[] products)
        {
            _purchases = new List<Product>();
            Count = products.Length;
            for (int i = 0; i < Count; ++i)
            {
                _purchases.Add(products[i]);
                _finalPrice += products[i].Price;
                _finalWeight += products[i].Weight;
            }
        }

        public Buy(string name, double price, double weight, int count)
        {
            _purchases = new List<Product>();
            _purchases.Add(new Product(name, price, weight));
            Count = count;
            _finalPrice = Count * price;
            _finalWeight = Count * weight;
        }

        public Buy(Product product, int count)
        {
            _purchases = new List<Product>();
            _purchases.Add(product);
            Count = count;
            _finalPrice = Count * product.Price;
            _finalWeight = Count * product.Weight;
        }

        protected int Count
        {
            get { return _count; }
            set
            {
                if (value < 0) throw new ArgumentException("Count must not be negative");
                _count = value;
            }
        }
        protected List<Product> Purchases
        {
            get { return _purchases; }
        }
        public double FinalPrice
        {
            get { return _finalPrice; }
            set
            {
                if (value < 0) throw new ArgumentException("FinalPrice must not be negative");
                _finalPrice = value;
            }
        }
        public double FinalWeight
        {
            get { return _finalWeight; }
            set
            {
                if (value < 0) throw new ArgumentException("FinalWeight must not be negative");
                _finalWeight = value;
            }
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            for (int i = 0; i < _purchases.Count; i++)
            {
                str.Append($"({i + 1}) {_purchases[i]}\n\n");
            }

            str.Append($"\"Count = {Count}\"  \"FinalPrice {FinalPrice}$\",  \"FinalWeigth {FinalWeight:0.###}kg\"");
            return str.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Buy obj2 || !(this.GetType().Equals(obj2.GetType())))
            {
                return false;
            }
            else
            {
                if (this.Count != obj2.Count) return false;
                for (int i = 0; i < Count; i++)
                {
                    if (!_purchases[i].Equals(obj2._purchases[i])) return false;
                }
                return (this.Count == obj2.Count && this.FinalPrice == obj2.FinalPrice && this.FinalWeight == obj2.FinalWeight);
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(FinalPrice);
        }

        public Buy(Buy purchase)
        {
            _purchases = purchase._purchases;
            Count = purchase.Count;
            _finalPrice = purchase.FinalPrice;
            _finalWeight = purchase.FinalWeight;
        }
    }
}