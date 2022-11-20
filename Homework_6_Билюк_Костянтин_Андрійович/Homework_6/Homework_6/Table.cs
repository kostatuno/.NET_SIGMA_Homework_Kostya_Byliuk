using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataBase;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Homework_6
{
    public class Table
    {
        public uint Length
        {
            get { return (uint)Customers.Count; }
        }

        public List<Customer> Customers = new List<Customer>();
        public void CreateByTxtFile(string path)
        {
            var fileInfo = new FileInfo(path);
            var lines = File.ReadAllLines(path);
            
            for (int i = 2; i < lines.Length; i++)
            {
                var splitElements = lines[i].Trim().Split(" | ");
                Customers.Add(new Customer(Convert.ToInt32(splitElements[0]), splitElements[1], splitElements[2],
                            splitElements[3].ToDateTime(), splitElements[4].ToDouble(),
                            splitElements[5].ToDateTime(), splitElements[6].ToDouble(),
                            splitElements[7].ToDateTime(), splitElements[8].ToDouble(), Convert.ToInt32(lines[0][10])));
            }
            Console.WriteLine($"[Таблиця заповнена. Елементiв: {lines.Length - 2}]\n"); ;
        }

        /*public void CreateByDb(ApplicationContext db)
        {
        // Не зміг поки що реалізувати
        }*/

        public Table()
        {
            Console.WriteLine("[Ви створили пусту таблицю]\n");
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < Customers.Count; i++)
            {
                strBuilder.Append($"({i+1})\n"+ Customers[i] + "\n\n");
            }
            return strBuilder.ToString();
        }

        public Customer this[int a]
        {
            get { return Customers[a]; }
            set { Customers[a] = value; }
        }
    }
}
