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
        public const double UAH_PERE_KILOWATT = 1.44;
        public static void PrintReport(Table table, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine("\n[REPORT]");
                writer.WriteLine($"Кв.\t | \tПрізвище\t" +
                    $" | \tЗняття за {table[0].TakingFirstMonth:MMMM}\t | \t" +
                    $"Показник за {table[0].TakingFirstMonth:MMMM}\t " +
                    $"| \tЗняття за {table[0].TakingSecondMonth:MMMM}\t " +
                    $"| \tПоказник за {table[0].TakingSecondMonth:MMMM}\t " +
                    $"| \tЗняття за {table[0].TakingThirdMonth:MMMM}\t " +
                    $"| \tПоказник за {table[0].TakingThirdMonth:MMMM}");
                for (int i = 0; i < table.Length; i++)
                {
                    writer.WriteLine($"{table[i].ApartmentNumber}\t | \t{table[i].SurName}\t\t " +
                        $"| \t{table[i].TakingFirstMonth:dd.MM.yy}\t\t\t | \t{table[i].FirstMonthIndicator}" +
                        $"\t\t\t\t | \t{table[i].TakingSecondMonth:dd.MM.yy}\t\t\t | \t{table[i].SecondMonthIndicator}" +
                        $"\t\t\t\t\t | \t{table[i].TakingThirdMonth:dd.MM.yy}\t\t\t | \t{table[i].ThirdMonthIndicator}");
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
                writer.WriteLine($"Кв.\t | \tПрізвище\t" +
                    $" | \tЗняття за {customer.TakingFirstMonth:MMMM}\t | \t" +
                    $"Показник за {customer.TakingFirstMonth:MMMM}\t " +
                    $"| \tЗняття за {customer.TakingSecondMonth:MMMM}\t " +
                    $"| \tПоказник за {customer.TakingSecondMonth:MMMM}\t " +
                    $"| \tЗняття за {customer.TakingThirdMonth:MMMM}\t " +
                    $"| \tПоказник за {customer.TakingThirdMonth:MMMM}");
                writer.WriteLine($"{customer.ApartmentNumber}\t | \t{customer.SurName}\t\t " +
                        $"| \t{customer.TakingFirstMonth:dd.MM.yy}\t\t\t | \t{customer.FirstMonthIndicator}" +
                        $"\t\t\t\t | \t{customer.TakingSecondMonth:dd.MM.yy}\t\t\t | \t{customer.SecondMonthIndicator}" +
                        $"\t\t\t\t\t | \t{customer.TakingThirdMonth:dd.MM.yy}\t\t\t | \t{customer.ThirdMonthIndicator}");
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
                writer.WriteLine($"Прізвище\t | \tКв.\t | \tЗаборгованість (UAH)");
                writer.WriteLine($"{table[customer].SurName}\t\t | \t{table[customer].ApartmentNumber}\t | \t{table[customer].Arrears:#.##}");
            }
            Console.WriteLine("Iнформацiя про квартиру з найбiльшой заборгованiстю: Надруковано\n");
        }

        public static void FindBadConsumers(Table table, string pathResult)
        {
            var fileStream = new FileStream(pathResult, FileMode.Append);
            using (var writer = new StreamWriter(fileStream))
            {
                writer.WriteLine($"\n[Bad cunsomers]");
                writer.WriteLine($"Кв.\t | \tПрізвище\t" +
                    $" | \tЗняття за {table[0].TakingFirstMonth:MMMM}\t | \t" +
                    $"Показник за {table[0].TakingFirstMonth:MMMM}\t " +
                    $"| \tЗняття за {table[0].TakingSecondMonth:MMMM}\t " +
                    $"| \tПоказник за {table[0].TakingSecondMonth:MMMM}\t " +
                    $"| \tЗняття за {table[0].TakingThirdMonth:MMMM}\t " +
                    $"| \tПоказник за {table[0].TakingThirdMonth:MMMM}");
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i].FirstMonthIndicator == 0 ||
                        table[i].SecondMonthIndicator == 0 ||
                        table[i].ThirdMonthIndicator == 0)
                    {
                        writer.WriteLine($"{table[i].ApartmentNumber}\t | \t{table[i].SurName}\t\t " +
                        $"| \t{table[i].TakingFirstMonth:dd.MM.yy}\t\t\t | \t{table[i].FirstMonthIndicator}" +
                        $"\t\t\t\t | \t{table[i].TakingSecondMonth:dd.MM.yy}\t\t\t | \t{table[i].SecondMonthIndicator}" +
                        $"\t\t\t\t\t | \t{table[i].TakingThirdMonth:dd.MM.yy}\t\t\t | \t{table[i].ThirdMonthIndicator}");
                    }
                }
            }
            Console.WriteLine("Iнформацiя про квартиру, яка не використовувала: Надруковано\n");
        }
    }
}
