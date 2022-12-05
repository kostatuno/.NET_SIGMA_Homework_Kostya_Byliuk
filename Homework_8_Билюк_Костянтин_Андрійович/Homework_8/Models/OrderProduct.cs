using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public class OrderProduct
    {
        public string Producer { get; private set; }
        public string Name { get; private set; }
        public int Count { get; private set; }
        public OrderProduct(string producer, string name, int count)
        {
            Producer = producer;
            Name = name;
            Count = count;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Product obj2 )
            {
                return false;
            }
            else
            {
                return Producer.ToLower() == obj2.Producer.ToLower() && Name.ToLower() == obj2.Name.ToLower();
            }
        }

        public override string ToString()
        {
            return $"Producer: {Producer}, Name: {Name}, Count: {Count}";  
        }
    }
}
