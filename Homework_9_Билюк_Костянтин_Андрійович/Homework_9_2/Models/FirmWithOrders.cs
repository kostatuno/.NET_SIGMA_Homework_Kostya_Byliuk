using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9_2
{
    class FirmWithOrders
    {
        public List<OrderProduct> OrderProducts;
        public string Name { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is not FirmWithOrders obj2 || !GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Name == obj2.Name;
            }
        }

        public FirmWithOrders(string name, params OrderProduct[] orderProducts)
        {
            Name = name;
            OrderProducts = new List<OrderProduct>();
            for (int i = 0; i < orderProducts.Length; i++)
            {
                OrderProducts.Add(orderProducts[i]);
            }
        }

        public FirmWithOrders(string name)
        {
            Name = name;
            OrderProducts = new List<OrderProduct>();
        }

        public FirmWithOrders() => OrderProducts = new List<OrderProduct>();
        public override string ToString()
        {
            return $"Firm: {Name}, order for {OrderProducts.Count} products";
        }
    }
}
