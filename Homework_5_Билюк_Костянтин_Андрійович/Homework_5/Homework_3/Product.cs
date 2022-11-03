using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_5
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
                _price = Math.Round(value, 2);
            }
        }

        public Currency Currency { get; set; }
        public WeightMeasurement WeightMeasurement { get; set; }

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Weight should be a positive number");
                _weight = Math.Round(value, 3);
            }
        }

        public Product(Product product)
        {
            Name = product.Name;
            Price = product.Price;
            Weight = product.Weight;
            Currency = product.Currency;
            WeightMeasurement = product.WeightMeasurement;
        }

        public Product(string name, double price, double weight,
            Currency currency = Currency.USD, WeightMeasurement measurementW = WeightMeasurement.kg)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Currency = currency;
            WeightMeasurement = measurementW;
        }

        public virtual void ConvertCurrencyTo(Currency currency)
        {
            switch (currency)
            {
                case Currency.USD:
                    switch (Currency)
                    {
                        case Currency.UAH:
                            _price = Math.Round(_price * 0.027, 2);
                            Currency = currency;
                            break;
                        case Currency.EUR:
                            _price = Math.Round(_price * 0.98, 2);
                            Currency = currency;
                            break;
                    }
                    break;
                case Currency.EUR:
                    switch (Currency)
                    {
                        case Currency.USD:
                            _price = Math.Round(_price * 1.03, 2);
                            Currency = currency;
                            break;
                        case Currency.UAH:
                            _price = Math.Round(_price * 0.028, 2);
                            Currency = currency;
                            break;
                    }
                    break;
                case Currency.UAH:
                    switch (Currency)
                    {
                        case Currency.USD:
                            _price = Math.Round(_price * 36.87, 2);
                            Currency = currency;
                            break;
                        case Currency.EUR:
                            _price = Math.Round(_price * 35.96, 2);
                            Currency = currency;
                            break;
                    }
                    break;
            }
        }

        public virtual void ConvertMeasurementTo(WeightMeasurement measurementW)
        {
            switch (measurementW)
            {
                case WeightMeasurement.lb:
                    if (WeightMeasurement == WeightMeasurement.kg)
                    {
                        _weight = Math.Round((_weight * 2.204), 3);
                        WeightMeasurement = measurementW;
                    }
                    break;
                case WeightMeasurement.kg:
                    if (WeightMeasurement == WeightMeasurement.lb)
                    {
                        _weight = Math.Round((_weight * 0.453), 3);
                        WeightMeasurement = measurementW;
                    }
                    break;
                default:
                    break;
            }
        }

        public virtual void ChangePrice(double percentageValueOfPrice)
        {
            Price = Math.Round((Price * (percentageValueOfPrice * 0.01)), 2);
        }

        public override string ToString()
        {
            return string.Format($"Name = {Name}, Price = {Price:0.##} {Currency}, Weight = {Weight:0.###}{WeightMeasurement}");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Product obj2 || !(this.GetType().Equals(obj.GetType())))
            {
                return false;
            }
            else
            {
                return (this.Name == obj2.Name && this.Price == obj2.Price && this.Weight == obj2.Weight &&
                    this.Currency == obj2.Currency && this.WeightMeasurement == obj2.WeightMeasurement);
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