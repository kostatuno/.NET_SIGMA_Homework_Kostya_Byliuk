using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Homework_6
{

    class Program
    {
        /*
        Це мабудь найнеуспішніша із моіх домашніх робіт вам, мені так багато хотілось би пофіксити, але світло та 2 дні безуспішних вивчень entity framework вирішили по іншому
        Чому мова за entity, тому що мені хотілось підключити базу даних та створити ці всі таблички у зручному форматі, на жаль у мене не вийшло, що і очевидно:), тому прийшлось щось
        робити за півдня, як приклад - ось весь код. В мене обовязково вийде якось підключити бд, я впевнений в цьому. Не знаю чому я це пишу, мені потрібно було це прописати в коментарі:)
        так як знаю, що все однозначно буде виходити, але не відразу. До роботи.  
         */

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

            Accounting.PrintReport(table, fileNameResult);
            Accounting.ApartmentInformation(table[2], fileNameResult); 
            Accounting.FindTheMostArrears(table, fileNameResult);
            Accounting.FindBadConsumers(table, fileNameResult); 
        }

        public static DirectoryInfo GetEntryDirectory(string currentDirectory, int i = 0)
        {
            var entryDirectory = Directory.GetParent(currentDirectory);
            if (i == 2) return entryDirectory;
            return GetEntryDirectory(entryDirectory.FullName, i + 1);
        }
    }    
}

