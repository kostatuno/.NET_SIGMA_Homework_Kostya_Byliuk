using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_5
{
    class Cart
    {
        public int Length { get; }
        private List<Buy> _purchases { get; set; }
        public Currency Currency { get; set; }
        public WeightMeasurement WeightMeasurement { get; set; }


        public Buy this[int i]
        {
            get { return _purchases[i]; }
            set { _purchases[i] = value; }
        }

        public Cart(List<Buy> purchases)
        {
            _purchases = purchases;
            Length = purchases.Count;
        }
        public Cart(params Buy[] products)
        {
            Currency = products[0].Product.Currency;
            WeightMeasurement = products[0].Product.WeightMeasurement;
            _purchases = new List<Buy>();
            Length = products.Length;
            for (int i = 0; i < products.Length; i++)
            {
                _purchases.Add(products[i]);
            }
            CheckCurrency();
            CheckWeightMeasurement();
        }

        public void ChangeCurrencyTo(Currency currency)
        {
            Currency = currency;
            foreach (var purchase in _purchases)
            {
                purchase.Product.ConvertCurrencyTo(currency);
                purchase.ConvertCurrencyTo(currency);
            }
        }

        public void ChangeWeightMeasurementTo(WeightMeasurement weightMeasurement)
        {
            WeightMeasurement = weightMeasurement;
            foreach (var purchase in _purchases)
            {
                purchase.Product.ConvertMeasurementTo(weightMeasurement);
                purchase.ConvertMeasurementTo(weightMeasurement);
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Cart obj2 || !(this.GetType().Equals(obj2.GetType())))
            {
                return false;
            }
            else
            {
                if (this.Length != obj2.Length) return false;
                for (int i = 0; i < Length; i++)
                {
                    if (!_purchases[i].Equals(obj2._purchases[i])) return false;
                }
                return (this.Currency == obj2.Currency && this.WeightMeasurement == obj2.WeightMeasurement);
            }
        }

        public override string ToString()
        {
            if (_purchases.Count == 0) return "Cart is empty";
            var str = new StringBuilder();
            for (int i = 0; i < _purchases.Count; i++)
                str.Append($"{i + 1}.{_purchases[i].GetType().Name}:\n{_purchases[i]}\n\n");

            double totalPrice = 0, totalWeight = 0;
            foreach (var purchase in _purchases)
            {
                totalPrice += purchase.FinalPrice;
                totalWeight += purchase.FinalWeight;
            }
            str.Append($"\n[ Total Price: {totalPrice:0.##} {Currency}, Total Weight: {totalWeight:0.000}{WeightMeasurement} ]\n");
            return str.ToString();
        }

        private void CheckCurrency()
        {
            for (int i = 0; i < _purchases.Count; i++)
            {
                if (_purchases[i].Product.Currency != _purchases[0].Product.Currency)
                    _purchases[i].Product.ConvertCurrencyTo(_purchases[0].Product.Currency);
            }
        }

        private void CheckWeightMeasurement()
        {
            for (int i = 0; i < _purchases.Count; i++)
            {
                if (_purchases[i].Product.WeightMeasurement != _purchases[0].Product.WeightMeasurement)
                    _purchases[i].Product.ConvertMeasurementTo(_purchases[0].Product.WeightMeasurement);
            }
        }
    }
}
