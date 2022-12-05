using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Meat : Product
    {
        private readonly int _standartPercentage;
        public TypeOfMeat Type { get; }
        public Category Category { get; }

        public Meat(string producer, string name, double price, double weight,
            TypeOfMeat type, Category category) : base(producer, name, price, weight)
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
            if (obj is not Meat obj2 || !GetType().Equals(obj2.GetType()))
            {
                return false;
            }
            else
            {
                return base.Equals(obj2) && Type == obj2.Type && Category == obj2.Category;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode() + Price * (int)Type);
        }
    }
}
