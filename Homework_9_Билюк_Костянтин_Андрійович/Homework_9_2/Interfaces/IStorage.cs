using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9_2
{
    interface IStorage
    {
        public int Length { get; }
        public double TotalWeight { get; }
        public double TotalPrice { get; }
    }
}
