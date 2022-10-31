using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_1
{
    class Buy : Product
    {
        public Buy(Buy purchase) : base(purchase.Product)
        {
            Count = purchase.Count;
        }

        public Buy(Product product, int count) : base(product)
        {
            Count = count;
            Product = product;
        }

        protected int Count { get; set; }
        protected Product Product { get; }
        public double FinalPrice => Count * Price;

        public override string ToString()
        {
            return string.Format($"{Product}, Count = {Count}\n \"FinalPrice {FinalPrice}$\"");
        }
    }
}
