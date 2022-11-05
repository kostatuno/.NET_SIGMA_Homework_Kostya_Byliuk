using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_1
{
    class Storage : IComparer, IComparable, IStorage
    {
        private double _totalWeight;
        private double _totalPrice;
        private Product[] _products { get; set; }
        public int Length { get; }

        public double TotalWeight
        {
            get { return _totalWeight; }
            private set { _totalWeight = value; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            private set { _totalPrice = value; }
        }

        public Product this[int i]
        {
            get 
            {
                return _products[i];
            }
            set 
            {
                _products[i] = value;   
            }
        }
        
        public Storage(params Product[] products)
        {
            _products = new Product[products.Length];
            for (int i = 0; i < _products.Length; i++)
            {
                _products[i] = (Product)products[i].Clone();
                _totalPrice += products[i].Price;
                _totalWeight += products[i].Weight;
            }
            Length = products.Length;
        }

        public Storage(int length)
        {
            _products = new Product[length];
            Length = length;
        }

        public Storage MeatProducts()
        {
            int lengthMeatStorage = 0;
            foreach (var product in _products)
                if (product is Meat) lengthMeatStorage++;
            var meatProducts = new Storage(lengthMeatStorage);
            for (int i = 0, j = 0; i < this.Length; i++)
            {
                while (j < lengthMeatStorage)
                {
                    if (this[i] is Meat)
                    {
                        meatProducts[j] = (Product)this[i].Clone();
                        j++;
                        break;
                    }
                    break;
                }
            }
            return meatProducts;
        }

        public void ChangePrices(double percentageValueOfAllPrices)
        {
            for (int i = 0; i < Length; i++)
                this[i].ChangePrice(percentageValueOfAllPrices);
            UpdateСonclusion();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Storage obj2 || !(this.GetType().Equals(obj2.GetType())))
            {
                return false;
            }
            else
            {
                if (this.Length != obj2.Length) return false;
                for (int i = 0; i < Length; i++)
                {
                    if (!this[i].Equals(obj2[i])) return false;
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            if (Length == 0) return (base.GetHashCode() << 2);
            return (base.GetHashCode() << 2) ^ Convert.ToInt32(this[0].Price);
        }

        public override string ToString()
        {
            if (Length == 0) return "Storage is empty";
            var str = new StringBuilder();
            for (int i = 0; i < Length; i++)
                str.Append($"{i+1}.{this[i].GetType().Name}:\n{this[i]}\n\n");
            str.Append($"\n\n [ Total Price: {TotalPrice:0.##} {_products[0].Currency}, " +
                $"Total Weight: {TotalWeight:0.000}{_products[0].WeightMeasurement} ]\n\n");
            return str.ToString();
        }

        public void EnterInformationFromUser()
        {
            string input = "";
            var numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "."};

            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"({i + 1})\n");
                Console.WriteLine("1. Enter the name, price and weight of the product");
                
                Console.Write("Name: ");
                var name = Console.ReadLine();
                Console.Write(" Price ($): ");
                var price = Convert.ToDouble(Console.ReadLine(), numberFormatInfo);
                Console.Write("  Weight (kg): ");
                var weight = Convert.ToDouble(Console.ReadLine(), numberFormatInfo);
                Console.WriteLine();

                Console.WriteLine("2. What interests you: Meat, DiaryProduct, Product");
                while (true)
                {
                    input = Console.ReadLine();
                    if (input == "Meat" || input == "DiaryProduct" || input == "Product") break;
                    TryAgain("What interests you: Meat, DiaryProduct, Product");
                }

                switch (input)
                {
                    case "Meat":
                        Console.WriteLine("\n3.Meat category? (In stock: High, First, Second)");
                        while (true)
                        {
                            input = Console.ReadLine();
                            if (input == "High" || input == "First" || input == "Second") break;
                            TryAgain("Meat category? (In stock: High, First, Second)");
                        }

                        Category category = (Category)Enum.Parse(typeof(Category), input);

                        Console.WriteLine("\n4.What about type of meat? (In stock: Mutton, Beef, Pork, Chicken)");
                        while (true)
                        {
                            input = Console.ReadLine();
                            if (input == "Mutton" || input == "Beef" || input == "Pork" || input == "Chicken" ) break;
                            TryAgain("What about type of meat? (In stock: Mutton, Beef, Pork, Chicken)");
                        }

                        TypeOfMeat typeOfMeat = (TypeOfMeat)Enum.Parse(typeof(TypeOfMeat), input);

                        this[i] = new Meat(name, price, weight, typeOfMeat, category);
                        Console.WriteLine();
                        break;

                    case "DiaryProduct":
                        Console.WriteLine("\n3.Expiration. What is the end date? (Format dd mm yyyy)");
                        while (true)
                        {
                            input = Console.ReadLine();
                            if (DateTime.TryParse(input, out DateTime to)) break;
                            TryAgain("Expiration. What is the end date? (Format dd mm yyyy)");
                        }

                        this[i] = new DairyProducts(name, price, weight, DateTime.Now, DateTime.Parse(input));
                        Console.WriteLine();
                        break;

                    case "Product":
                        this[i] = new Product(name, price, weight);
                        Console.WriteLine();
                        break;
                }
            }
            Console.Clear();
            Print();
        }

        public void Sort(string fieldName)
        {
            for (int i = 0; i < _products.Length; i++)
            {
                for (int j = 0; j < _products.Length - 1; j++)
                {
                    switch (fieldName)
                    {
                        case "Weight":
                            if (_products[j].Weight > _products[j + 1].Weight)
                                Swap(ref _products[j + 1], ref _products[j]);
                            break;
                        case "Price":
                            if (_products[j].Price > _products[j + 1].Price)
                                Swap(ref _products[j + 1], ref _products[j]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        
        public int Compare(object? x, object? y) // сравнивать продукты
        {
            var obj = x as Product;
            var obj2 = y as Product;
            if (y == null) return 1;
            else if (x == null) return -1;
            return obj.CompareTo(obj2);
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Storage obj2)
            {
                return 1;
            }
            return TotalPrice.CompareTo(obj2.TotalPrice);
        }

        private void TryAgain(string question)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine("Incorrect input. Try again");
            Console.WriteLine(question);
        }

        private void Swap<T> (ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        private void UpdateСonclusion()
        {
            _totalPrice = 0;
            _totalWeight = 0;
            foreach (var product in _products)
            {
                _totalPrice += product.Price;
                _totalWeight += product.Weight;
            }
        }
    }
}
