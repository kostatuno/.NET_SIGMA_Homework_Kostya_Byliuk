﻿using System.IO;

namespace Homework_7_1
{
    class Program
    {
        static void Main()
        {
            Product sugar = new Product("Sugar", 2.99, 1);
            Product cake = new Product("Cake", 6.99, 0.850);
            Product seaSugar = new Product("Sea sugar", 2.99, 1);

            Product chicken = new Meat("Chicken", 11.99, 1, TypeOfMeat.Chicken, Category.First);
            Product mutton = new Meat("Mutton", 13.99, 0.850, TypeOfMeat.Mutton, Category.High);
            Product pork = new Meat("Pork", 12.99, 1, TypeOfMeat.Pork, Category.First);

            Product milk = new DairyProducts("Milk", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            Product milk2 = new DairyProducts("Milk", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            Product cheese = new DairyProducts("Cheese", 5.99, 0.4, new DateTime(2022, 8, 5), new DateTime(2022, 11, 17));
            Product sourСream = new DairyProducts("Sour cream", 6.99, 0.550, new DateTime(2021, 10, 5), new DateTime(2022, 12, 02));


            

            Storage storageBC = new Storage(milk, sourСream, mutton, chicken, mutton, seaSugar, milk, mutton, mutton);
            Storage storageBC2 = new Storage(sourСream, mutton, mutton, seaSugar, milk, mutton);

            StorageManager.Print(StorageManager.MeatProducts(storageBC));
            StorageManager.Print(StorageManager.Differ(storageBC, storageBC2));
            StorageManager.Print(StorageManager.JointProducts(storageBC, storageBC2));
            StorageManager.Print(StorageManager.JointProductsWithoutRepeats(storageBC, storageBC2));




        }
    }
}