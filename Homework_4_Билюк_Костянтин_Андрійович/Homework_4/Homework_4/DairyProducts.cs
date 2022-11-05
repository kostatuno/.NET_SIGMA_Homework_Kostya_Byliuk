using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    class DairyProducts : Product
    {
        private double _expiration;
        private readonly int _standartPercentage;
        public double Expiration
        {
            get { return _expiration; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Expiration should be a positive number");
                _expiration = value;
            }
        }
        public DateTime From { get; }
        public DateTime To { get; }

        public DairyProducts(string name, double price, double weight, 
            DateTime from, DateTime to) : base(name, price, weight)
        {
            From = from;
            To = to;
            Expiration = Math.Round((To - From).TotalDays);
            _standartPercentage = 100 + (int)(Expiration * 0.1);
        }

        public DairyProducts(Product product, DateTime from, DateTime to) : base(product)
        {
            From = from;
            To = to;
            Expiration = Math.Round((To - From).TotalDays);
            _standartPercentage = 100 + (int)(Expiration * 0.1);
        }

        public override void ChangePrice(double percentageValueOfPrice)
        {
            base.ChangePrice(percentageValueOfPrice);
            base.ChangePrice(_standartPercentage);
        }

        public override string ToString()
        {
            return base.ToString() + $" \nExpiration: {Expiration} days (from: {From}, to: {To})";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not DairyProducts obj2 || !(this.GetType().Equals(obj2.GetType())))
            {
                return false;
            }
            else
            {
                return base.Equals(obj2) && this.From == obj2.From && this.To == obj2.To;
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(Expiration);
        }
    }
}
