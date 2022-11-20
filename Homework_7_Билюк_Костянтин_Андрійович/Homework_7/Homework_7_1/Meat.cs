using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    class Meat : Product
    {
        private readonly int _standartPercentage;
        public TypeOfMeat Type { get; }
        public Category Category { get; }

        public Meat(string name, double price, double weight, 
            TypeOfMeat type, Category category) : base(name, price, weight)
        {
            Type = type;
            Category = category;
            _standartPercentage = (int)Category;
        }

        public Meat(Product product, TypeOfMeat type, Category category) : base(product)
        {
            Type = type;
            Category = category;
            _standartPercentage = (int)Category;
        }

        public override void ChangePrice(double percentageValueOfPrice)
        {
            base.ChangePrice(percentageValueOfPrice);
            base.ChangePrice(_standartPercentage);
        }

        public override string ToString()
        {
            return base.ToString() + $" \nType: {Type}, Category: {Category}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Meat obj2 || !(this.GetType().Equals(obj2.GetType())))
            {
                return false;
            }
            else
            {
                return base.Equals(obj2) && this.Type == obj2.Type && this.Category == obj2.Category;
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(Price * (int)Type);
        }
    }
}
