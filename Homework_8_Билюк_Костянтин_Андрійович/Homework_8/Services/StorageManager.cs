using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    class StorageManager
    {
        public static List<Product> Differ(Storage storage, Storage storage2) // Товари є в першому складі і немає в другому.
        {
            var products = new List<Product>();
            bool answer;
            foreach (var product in storage.Products)
            {
                answer = false;
                foreach (var product2 in storage2.Products)
                {
                    if (product.Equals(product2))
                    {
                        answer = true;
                        break;
                    }
                }
                if (!answer)
                {
                    answer = false;
                    products.Add(product);
                    break;
                }
            }
            return products;
        }

        public static List<Product> JointProducts(Storage storage, Storage storage2) // Товари, які є спільними в обох складах.
        {
            var products = new List<Product>();

            foreach (var product in storage.Products)
            {
                foreach (var product2 in storage2.Products)
                {
                    if (product.Equals(product2))
                    {
                        products.Add(product);
                        break;
                    }
                }
            }
            return products;
        }

        public static List<Product> JointProductsWithoutRepeats(Storage storage, Storage storage2) // Спільний список товарів, які є на обох складах, без повторів елементів.
        {
            var products = JointProducts(storage, storage2);
            return new HashSet<Product>(products).ToList();
        }

        public static List<Product> MeatProducts(Storage storage)
        {
            var products = new List<Product>();
            foreach (var product in storage.Products)
            {
                if (product is Meat)
                {
                    products.Add(product);
                }
            }
            return products;
        }

        public static void Print(List<Product> list)
        {
            foreach (var product in list)
            {
                Console.WriteLine(product + "\n");
            }
            Console.WriteLine("------------------done-----------------");
        }

        public static List<FirmWithOrders> ReadOrdersFrom(string fileOrder)
        {
            var file = new FileInfo(fileOrder);
            var lines = File.ReadAllLines(fileOrder);
            var firmWithOrders = new List<FirmWithOrders>();
            var firmWithOrder = new FirmWithOrders();

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Substring(0, 5) == "Firm:")
                {
                    firmWithOrder.Name = lines[i].Substring(6);
                    continue;
                }
                var elements = lines[i].Trim().Split("|");
                if (lines[i] != "------")
                    firmWithOrder.OrderProducts.Add(new OrderProduct(elements[0], elements[1], Convert.ToInt32(elements[2])));
                else
                {
                    firmWithOrders.Add(firmWithOrder);
                    firmWithOrder = new FirmWithOrders();   
                }
            }
            return firmWithOrders;
        }

        public static void WriteReadyOrderTo(string resultFilePath, FirmWithOrders firm)
        {
            var file = new FileStream(resultFilePath, FileMode.Append);
            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine($"[ORDER from \"{firm.Name}\"]");
                foreach (var orderProduct in firm.OrderProducts)
                {
                    sw.WriteLine(orderProduct);
                }
                sw.WriteLine("\n");
            }
        }
    }
}

