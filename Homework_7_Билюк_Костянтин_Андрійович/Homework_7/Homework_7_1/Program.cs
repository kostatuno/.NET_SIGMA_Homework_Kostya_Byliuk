using System.IO;

namespace Homework_4_1
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

            
            
            Storage storageA = new Storage(milk, sourСream, chicken, cheese);
            Storage storageA2 = new Storage(3);

            Storage storageBС = new Storage(milk, sourСream, chicken, cheese);
            Storage storageBС2 = new Storage(sourСream, cheese, chicken, milk);

            Console.WriteLine(storageA.CompareTo(storageA2)); // a           
            Console.WriteLine(storageBС.Equals(storageBС2)); // b, с                 
        }

        // CompareTo повертає порівняння, яке перевіряється к-стю товарів в складі.
        // Equal дізнається, чи склади рівні в контексті товарів, незалежно від порядку іх зберігання 
    }
}