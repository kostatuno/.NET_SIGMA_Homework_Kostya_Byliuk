using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }

        public Cinema()
        {
        }

        public Cinema(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Address:{Address}";
        }
    }
}
