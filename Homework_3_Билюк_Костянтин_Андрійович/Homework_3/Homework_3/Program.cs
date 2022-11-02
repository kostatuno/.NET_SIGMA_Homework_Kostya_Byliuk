using System.IO;

namespace Homework_3
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

            

            Storage storage = new Storage(sugar, cake, seaSugar, chicken, mutton, pork, milk, cheese, sourСream);

            /*var meatProducts = storage.MeatProducts();          // Мясні продукти з "storage"
            meatProducts.ChangePrices(110);                       // Змінили ціну
            meatProducts.Print();                                 // Вивели на екран*/

            //storage.ChangePrices(110);                  // Змінити ціни для всіх продуктів на певний відсоток
            //storage.Print();                            // Вивели на екран

            //Console.WriteLine(storage);                 // Також вивели на экран 

            //storage.EnterInformationFromUser();         // Наповнення інформацією даних у режимі діалогу з користувачем

            /*Storage storage22 = new Storage(4);          // Ініціалізували подібно звичайному масиву
            storage2[0] = milk;
            storage2[1] = cheese;
            storage2[2] = mutton;
            storage2[3] = chicken;*/

            //Storage storage1 = new Storage(sugar, cake, seaSugar, chicken, mutton, pork, milk, cheese, sourСream);
            //Storage storage2 = new Storage(sugar, cake, seaSugar, chicken, mutton, pork, milk, cheese, sourСream);
            //Console.WriteLine(storage1.Equals(storage2)); // True

            //Console.WriteLine(milk.Equals(cheese)); // False
            //Console.WriteLine(milk.Equals(milk2)); // Однакові продукти, різна назва змінних, буде True

            /*Check.Show(cheese);
            Check.Show(pork);
            Check.Show(sugar);*/
        }
    }
}