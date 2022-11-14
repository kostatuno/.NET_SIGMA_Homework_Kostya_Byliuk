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
                var fileName = @"C:\Users\ADMIN\OneDrive\Desktop\Новая папка (2)\Homework_6\Homework_6\information 2022\1_quarter.txt";
                var fileInfo = new FileInfo(fileName);
                var lines = File.ReadAllLines(fileName);

                for (int i = 2; i < lines.Length; i++)
                {
                    
                    var splitElements = lines[i].Trim().Split(" | ");
                    db.Quarter1.Add(new Customer(Convert.ToInt32(splitElements[0]), splitElements[1], splitElements[2],
                                splitElements[3].ToDateTime(), splitElements[4].ToDouble(),
                                splitElements[5].ToDateTime(), splitElements[6].ToDouble(),
                                splitElements[7].ToDateTime(), splitElements[8].ToDouble()));
                }

                fileName = @"C:\Users\ADMIN\OneDrive\Desktop\Новая папка (2)\Homework_6\Homework_6\information 2022\2_quarter.txt";
                fileInfo = new FileInfo(fileName);
                lines = File.ReadAllLines(fileName);

                for (int i = 2; i < lines.Length; i++)
                {
                    var splitElements = lines[i].Trim().Split(" | ");
                    db.Quarter2.Add(new Customer(Convert.ToInt32(splitElements[0]), splitElements[1], splitElements[2],
                                splitElements[3].ToDateTime(), splitElements[4].ToDouble(),
                                splitElements[5].ToDateTime(), splitElements[6].ToDouble(),
                                splitElements[7].ToDateTime(), splitElements[8].ToDouble()));
                }
                db.SaveChanges();
                Console.WriteLine($"[Таблиця 1 заповнена. Елементiв: {lines.Length - 2}]\n");

                foreach (var item in db.Quarter1)
                {
                    Console.WriteLine($"Surname: {item.SurName}, Id: {item.Id}");
                }

                Console.WriteLine($"[Таблиця 2 заповнена. Елементiв: {lines.Length - 2}]\n");
                foreach (var item in db.Quarter2)
                {
                    Console.WriteLine($"Surname: {item.SurName}, Id: {item.Id}");
                }
            }
        }
    }
}