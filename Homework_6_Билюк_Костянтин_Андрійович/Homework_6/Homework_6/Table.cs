using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var customer = new Customer();
                customer.ApartmentNumber = Convert.ToInt32(splitElements[0]);
                customer.Address = splitElements[1];
                customer.SurName = splitElements[2];
                try
                {
                    customer.TakingFirstMonth = DateTime.Parse(splitElements[3]);
                }
                catch
                {
                    customer.TakingFirstMonth = null;
                }
                try
                {
                    customer.TakingSecondMonth = DateTime.Parse(splitElements[5]);
                }
                catch
                {
                    customer.TakingSecondMonth = null;
                }
                try
                {
                    customer.TakingThirdMonth = DateTime.Parse(splitElements[7]);
                }
                catch
                {
                    customer.TakingThirdMonth = null;
                }

                try
                {
                    customer.FirstMonthIndicator = Convert.ToDouble(splitElements[4]);
                }
                catch
                {
                    customer.FirstMonthIndicator = null;
                }
                try
                {
                    customer.SecondMonthIndicator = Convert.ToDouble(splitElements[6]);
                }
                catch
                {
                    customer.SecondMonthIndicator = null;
                }
                try
                {
                    customer.ThirdMonthIndicator = Convert.ToDouble(splitElements[8]);
                }
                catch
                {
                    customer.ThirdMonthIndicator = null;
                }

                if (customer.FirstMonthIndicator != null)
                    customer.AllKilowatt += customer.FirstMonthIndicator.Value;
                if (customer.SecondMonthIndicator != null)
                    customer.AllKilowatt += customer.SecondMonthIndicator.Value;
                if (customer.ThirdMonthIndicator != null)
                    customer.AllKilowatt += customer.ThirdMonthIndicator.Value;
                customer.Arrears = customer.AllKilowatt * Accounting.UAH_PERE_KILOWATT;

                Customers.Add(customer);

                /*Customers.Add(new Customer(Convert.ToInt32(splitElements[0]), splitElements[1], splitElements[2],
                            DateTime.Parse(splitElements[3]), Convert.ToDouble(splitElements[4]),
                            DateTime.Parse(splitElements[5]), Convert.ToDouble(splitElements[6]),
                            DateTime.Parse(splitElements[7]), Convert.ToDouble(splitElements[8])));*/
            }
            Console.WriteLine($"[Таблиця заповнена. Елементiв: {lines.Length - 2}]\n"); ;
        }

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
