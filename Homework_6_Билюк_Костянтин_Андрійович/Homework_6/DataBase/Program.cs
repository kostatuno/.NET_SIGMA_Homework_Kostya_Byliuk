using Homework_6;
using System.IO;

namespace DataBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(var db = new ApplicationContext())
            {
                var fileNameArr = new string[]
                {
                    @"D:\.NET Sigma CAMP\Homework_6_Билюк_Костянтин_Андрійович\Homework_6\Homework_6\information 2022\1_quarter.txt",
                    @"D:\.NET Sigma CAMP\Homework_6_Билюк_Костянтин_Андрійович\Homework_6\Homework_6\information 2022\2_quarter.txt",
                    @"D:\.NET Sigma CAMP\Homework_6_Билюк_Костянтин_Андрійович\Homework_6\Homework_6\information 2022\3_quarter.txt",
                    @"D:\.NET Sigma CAMP\Homework_6_Билюк_Костянтин_Андрійович\Homework_6\Homework_6\information 2022\4_quarter.txt",
                };

                
                foreach (var fileName in fileNameArr)
                {
                    var fileInfo = new FileInfo(fileName);
                    var lines = File.ReadAllLines(fileName);
                    for (int i = 2; i < lines.Length; i++)
                    {
                        var splitElements = lines[i].Trim().Split(" | ");
                        db.Customers.Add(new Customer(Convert.ToInt32(splitElements[0]), splitElements[1], splitElements[2],
                                    splitElements[3].ToDateTime(), splitElements[4].ToDouble(),
                                    splitElements[5].ToDateTime(), splitElements[6].ToDouble(),
                                    splitElements[7].ToDateTime(), splitElements[8].ToDouble(), int.Parse(lines[0][9].ToString())));
                    }

                    Console.WriteLine($"[Таблиця 2 заповнена. Елементiв: {lines.Length - 2}]\n");
                    foreach (var item in db.Customers)
                    {
                        Console.WriteLine($"Surname: {item.SurName}, Id: {item.Id}, Quarter: {item.Quarter}");
                    }
                }

                db.SaveChanges();

                
            }
        }
    }
}