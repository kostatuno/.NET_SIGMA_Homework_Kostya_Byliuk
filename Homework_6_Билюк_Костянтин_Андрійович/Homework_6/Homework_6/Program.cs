using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Homework_6
{
    /*
     Намагався створити бд для роботи, але не вистачало знань поки що, тому довелось залишитись на співпраці з текстовим файлом.
     Такі важливі класи як Customer та Extensions залишились в проекті з непрацюючою бд, на основну роботу з .txt не впливає
     */
    class Program
    {
        static void Main()
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            var entryDirectory = GetEntryDirectory(currentDirectory);

            var quarterFileName = new string[]
            {
                $"{entryDirectory.FullName}\\information 2022\\1_quarter.txt",
                $"{entryDirectory.FullName}\\information 2022\\2_quarter.txt",
                $"{entryDirectory.FullName}\\information 2022\\3_quarter.txt",
                $"{entryDirectory.FullName}\\information 2022\\4_quarter.txt",
            };

            var fileNameResult = $"{entryDirectory}\\information 2022\\result.txt";
            
            Table table = new Table();
            table.CreateByTxtFile(quarterFileName[3]);

            Accounting.PrintReport(table, fileNameResult);               // Звіт
            Accounting.ApartmentInformation(table[2], fileNameResult); //   Інформація про квартиру
            Accounting.FindTheMostArrears(table, fileNameResult); //        Інформація про квартиру з найбільшою заборгованістю
            Accounting.FindBadConsumers(table, fileNameResult); //          Інформація про квартиру, яка не використовувала електроенергію
        }

        private static DirectoryInfo GetEntryDirectory(string currentDirectory, int i = 0)
        {
            var entryDirectory = Directory.GetParent(currentDirectory);
            if (i == 2) return entryDirectory;
            return GetEntryDirectory(entryDirectory.FullName, i + 1);
        }
    }    
}

