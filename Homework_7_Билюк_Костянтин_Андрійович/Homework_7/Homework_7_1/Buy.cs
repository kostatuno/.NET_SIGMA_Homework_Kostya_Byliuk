using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_7_1
{
    class Buy : Product
    {
        private Product _product;
        private double _finalPrice;
        private double _finalWeight;
        private int _count;

        public Product Product
        {
            get { return _product; }
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

        public Buy(Buy purchase) : base(purchase)
        {
            _product = purchase._product;
            Count = purchase.Count;
            _finalPrice = purchase.FinalPrice;
            _finalWeight = purchase.FinalWeight;
        }

        public Buy(string name, double price, double weight, int count) : base(name, price, weight)
        {
            _product = new Product(name, price, weight);
            Count = count;
            _finalPrice = Count * price;
            _finalWeight = Count * weight;
        }

        public Buy(Product product, int count) : base(product)
        {
            _product = (Product)product.Clone();
            Count = count;
            _finalPrice = Count * product.Price;
            _finalWeight = Count * product.Weight;
        }

        public override string ToString()
        {
            return $"{_product}\n\"Count = {Count}\"  \"FinalPrice {FinalPrice:0.##} {Currency}\",  \"FinalWeigth {FinalWeight:0.###}{WeightMeasurement}\"";
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
                if (!_product.Equals(obj2._product)) return false;
                return (this.Count == obj2.Count && this.FinalPrice == obj2.FinalPrice && this.FinalWeight == obj2.FinalWeight);
            }
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(FinalPrice);
        }

        public override void ConvertCurrencyTo(Currency currency)
        {
            switch (currency)
            {
                case Currency.USD:
                    switch (Currency)
                    {
                        case Currency.UAH:
                            _finalPrice = Math.Round(_finalPrice * 0.027, 2);
                            Currency = currency;
                            break;
                        case Currency.EUR:
                            _finalPrice = Math.Round(_finalPrice * 0.98, 2);
                            Currency = currency;
                            break;
                    }
                    break;
                case Currency.EUR:
                    switch (Currency)
                    {
                        case Currency.USD:
                            _finalPrice = Math.Round(_finalPrice * 1.03, 2);
                            Currency = currency;
                            break;
                        case Currency.UAH:
                            _finalPrice = Math.Round(_finalPrice * 0.028, 2);
                            Currency = currency;
                            break;
                    }
                    break;
                case Currency.UAH:
                    switch (Currency)
                    {
                        case Currency.USD:
                            _finalPrice = Math.Round(_finalPrice * 36.87, 2);
                            Currency = currency;
                            break;
                        case Currency.EUR:
                            _finalPrice = Math.Round(_finalPrice * 35.96, 2);
                            Currency = currency;
                            break;
                    }
                    break;
            }
        }

        public override void ConvertMeasurementTo(WeightMeasurement measurementW)
        {
            switch (measurementW)
            {
                case WeightMeasurement.lb:
                    if (WeightMeasurement == WeightMeasurement.kg)
                    {
                        _finalWeight = Math.Round((_finalWeight * 2.204), 3);
                        WeightMeasurement = measurementW;
                    }
                    break;
                case WeightMeasurement.kg:
                    if (WeightMeasurement == WeightMeasurement.lb)
                    {
                        _finalWeight = Math.Round((_finalWeight * 0.453), 3);
                        WeightMeasurement = measurementW;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
