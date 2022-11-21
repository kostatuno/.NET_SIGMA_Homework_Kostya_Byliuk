using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public static class Accounting
    {
        public static void PrintReport(Table table, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("\n[REPORT]");
                writer.WriteLine($"{"Кв.", -5} | {"Прізвище", -15}" +
                    $" | {$"Зняття за {table[0].TakingFirstMonth:MMMM}", -20} | " +
                    $"{$"Показник за {table[0].TakingFirstMonth:MMMM}", -20} " +
                    $"| {$"Зняття за {table[0].TakingSecondMonth:MMMM}", -20} " +
                    $"| {$"Показник за {table[0].TakingSecondMonth:MMMM}", -20} " +
                    $"| {$"Зняття за {table[0].TakingThirdMonth:MMMM}", -20} " +
                    $"| {$"Показник за {table[0].TakingThirdMonth:MMMM}", -20}");
                for (int i = 0; i < table.Length; i++)
                {
                    writer.WriteLine(table[i]);
                }
                writer.WriteLine();
            }
            Console.WriteLine("Звiт: Надруковано\n");
        }

        public static void ApartmentInformation(Customer customer, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"\n[Information about apartment {customer.ApartmentNumber}]");
                writer.WriteLine($"{"Кв.",-5} | {"Прізвище",-15}" +
                    $" | {$"Зняття за {customer.TakingFirstMonth:MMMM}",-20} | " +
                    $"{$"Показник за {customer.TakingFirstMonth:MMMM}",-20} " +
                    $"| {$"Зняття за {customer.TakingSecondMonth:MMMM}",-20} " +
                    $"| {$"Показник за {customer.TakingSecondMonth:MMMM}",-20} " +
                    $"| {$"Зняття за {customer.TakingThirdMonth:MMMM}",-20} " +
                    $"| {$"Показник за {customer.TakingThirdMonth:MMMM}",-20}");
                writer.WriteLine(customer);
            }
            Console.WriteLine("Iнформацiя про квартиру: Надруковано\n");
        }

        public static void FindTheMostArrears(Table table, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                double maxPrice = table[0].Arrears;
                int customer = 0;

                for (int i = 0; i < table.Length; i++)
                {
                    if (i + 1 < table.Length)
                    {
                        if (maxPrice < table[i].Arrears)
                        {
                            maxPrice = table[i].Arrears;
                            customer = i;
                        }

                    }
                }
                writer.WriteLine($"\n[The most arrears in {table[customer].ApartmentNumber} apartment]");
                writer.WriteLine($"{"Прізвище", -15} | {"Кв.", -5} | {"Заборгованість (UAH)", -20}");
                writer.WriteLine($"{table[customer].SurName, -15} | {table[customer].ApartmentNumber, -5} | {table[customer].Arrears, -20:#.##}");
            }
            Console.WriteLine("Iнформацiя про квартиру з найбiльшой заборгованiстю: Надруковано\n");
        }

        public static void FindBadConsumers(Table table, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"\n[Bad cunsomers]");
                writer.WriteLine($"{"Кв.",-5} | {"Прізвище",-15}" +
                    $" | {$"Зняття за {table[0].TakingFirstMonth:MMMM}",-20} | " +
                    $"{$"Показник за {table[0].TakingFirstMonth:MMMM}",-20} " +
                    $"| {$"Зняття за {table[0].TakingSecondMonth:MMMM}",-20} " +
                    $"| {$"Показник за {table[0].TakingSecondMonth:MMMM}",-20} " +
                    $"| {$"Зняття за {table[0].TakingThirdMonth:MMMM}",-20} " +
                    $"| {$"Показник за {table[0].TakingThirdMonth:MMMM}",-20}");
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].FirstMonthIndicator == 0 ||
                        table[i].SecondMonthIndicator == 0 ||
                        table[i].ThirdMonthIndicator == 0)
                    {
                        writer.WriteLine(table[i]);
                    }
                }
            }
            Console.WriteLine("Iнформацiя про квартиру, яка не використовувала електроенергiю: Надруковано\n");
        }
    }
}
