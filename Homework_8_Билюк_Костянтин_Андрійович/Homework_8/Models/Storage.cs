using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class Storage : IComparer, IComparable, IStorage
    {
        public Dictionary<Product, int> AmountOfProducts = new Dictionary<Product, int>();
        public event Action<string> ErrorOrderHandler;
        public event Action<string, FirmWithOrders> PrintFirmWithOrdersHandler;
        private double _totalWeight;
        private double _totalPrice;
        public List<Product> Products { get; set; }
        public void FindOutAmountOfProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                var key = Products[i] as Product;
                if (!AmountOfProducts.ContainsKey(key))
                    AmountOfProducts[key] = 1;
                else AmountOfProducts[key]++;
            }
        }
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
                return Products[i];
            }
            set
            {
                Products.Insert(i, value);
                UpdateСonclusion();
                if (!AmountOfProducts.ContainsKey(value))
                    AmountOfProducts[value] = 1;
                else AmountOfProducts[value]++;

            }
        }

        public Storage(params Product[] products)
        {
            Products = new List<Product>();
            for (int i = 0; i < products.Length; i++)
            {
                Products.Add((Product)products[i].Clone());
                _totalPrice += products[i].Price;
                _totalWeight += products[i].Weight;
            }
            Length = products.Length;
            FindOutAmountOfProducts();
        }

        public Storage(int length)
        {
            Products = new List<Product>();
            Length = Products.Count;
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
            if (obj is not Storage obj2 || !GetType().Equals(obj2.GetType()))
            {
                return false;
            }
            else
            {
                if (Length != obj2.Length) return false;
                for (int i = 0; i < Length; i++)
                {
                    if (!this[i].Equals(obj2[i])) return false;
                }
                return true;
            }
        }

        public override int GetHashCode()
        {
            if (Length == 0) return base.GetHashCode() << 2;
            return base.GetHashCode() << 2 ^ Convert.ToInt32(this[0].Price);
        }

        public override string ToString()
        {
            if (Length == 0) return "Storage is empty";
            var str = new StringBuilder();
            for (int i = 0; i < Length; i++)
                str.Append($"{i + 1}.{this[i].GetType().Name}:\n{this[i]}\n\n");
            str.Append($"\n\n [ Total Price: {TotalPrice:0.##} {Products[0].Currency}, " +
                $"Total Weight: {TotalWeight:0.000}{Products[0].WeightMeasurement} ]\n\n");
            return str.ToString();
        }

        public void EnterInformationFromUser()
        {
            string input = "";
            var numberFormatInfo = new NumberFormatInfo() { NumberDecimalSeparator = "." };

            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine($"({i + 1})\n");
                Console.WriteLine("1. Enter the firm, name, price and weight of the product");
                Console.Write("Producer: ");
                var producer = Console.ReadLine();
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
                            if (input == "Mutton" || input == "Beef" || input == "Pork" || input == "Chicken") break;
                            TryAgain("What about type of meat? (In stock: Mutton, Beef, Pork, Chicken)");
                        }

                        TypeOfMeat typeOfMeat = (TypeOfMeat)Enum.Parse(typeof(TypeOfMeat), input);

                        this[i] = new Meat(producer, name, price, weight, typeOfMeat, category);
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

                        this[i] = new DairyProducts(producer, name, price, weight, DateTime.Now, DateTime.Parse(input));
                        Console.WriteLine();
                        break;

                    case "Product":
                        this[i] = new Product(producer, name, price, weight);
                        Console.WriteLine();
                        break;
                }
            }
            Console.Clear();
            Print();
        }

        public void Sort(string fieldName)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                for (int j = 0; j < Products.Count - 1; j++)
                {
                    switch (fieldName)
                    {
                        case "Weight":
                            if (Products[j].Weight > Products[j + 1].Weight)
                                (Products[j + 1], Products[j]) = (Products[j], Products[j + 1]);
                            break;
                        case "Price":
                            if (Products[j].Price > Products[j + 1].Price)
                                (Products[j + 1], Products[j]) = (Products[j], Products[j + 1]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        public int Compare(object? x, object? y) // порівнюємо продукти
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

        private void UpdateСonclusion()
        {
            _totalPrice = 0;
            _totalWeight = 0;
            foreach (var product in Products)
            {
                if (product == null) continue;
                _totalPrice += product.Price;
                _totalWeight += product.Weight;
            }
        }

        public void MakeTheOrder(string fileOrder, string resultFilePath)
        {
            var firmWithOrders = StorageManager.ReadOrdersFrom(fileOrder);

            foreach (var firm in firmWithOrders)
            {
                bool answer = false;
                foreach (var orderProduct in firm.OrderProducts)
                {
                    answer = false;
                    foreach (var product in AmountOfProducts)
                    {
                        if (orderProduct.Equals(product.Key)
                            && product.Value >= orderProduct.Count)
                        {
                            answer = true;
                            break;
                        }
                    }
                    if (!answer)
                    {
                        ErrorOrderHandler?.Invoke($"Призупинено. Замовлення вiд Фiрми: \"{firm.Name}\". " +
                            $"Не вiдповiднiсть з продуктом: \"{orderProduct.Name}\", Виробник: \"{orderProduct.Producer}\"");
                        break;
                    }
                }
                if (answer)
                {
                    PrintFirmWithOrdersHandler?.Invoke(resultFilePath, firm);
                    foreach (var orderProduct in firm.OrderProducts)
                    {
                        foreach (var product in AmountOfProducts)
                        {
                            if (orderProduct.Equals(product.Key))
                            {
                                AmountOfProducts[product.Key] -= orderProduct.Count;
                            }
                        }
                    }
                }
            }
        }

        public void RemoveAt(int index) => Products.RemoveAt(index);
        public void Remove(Product product) => Products.Remove(product);
        public void Add(Product product) => Products.Add(product);
    }
}
