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


            // Створив інтерфейс для ємкостей, таких як cart та storage

            Storage storage1 = new Storage(sugar, seaSugar, chicken, mutton, milk, cheese);
            Storage storage2 = new Storage(seaSugar, chicken, mutton, milk, cheese);
            Storage storage3 = new Storage(sugar, seaSugar, chicken, mutton, milk, cheese); // ідентичний storage1
            Cart cart1 = new Cart(new Buy(mutton, 5), new Buy(cheese, 3), new Buy(sugar, 7));
            Cart cart2 = new Cart(new Buy(mutton, 3), new Buy(cheese, 6), new Buy(sugar, 7));
            Cart cart3 = new Cart(new Buy(mutton, 5), new Buy(cheese, 3), new Buy(sugar, 7)); // ідентичний cart1

            // 1. Equal

            Console.WriteLine(sugar.Equals(cake)); // False
            Console.WriteLine(pork.Equals(pork)); // True
            Console.WriteLine(milk.Equals(null)); // False

            Console.WriteLine(storage1.Equals(storage2)); // False
            Console.WriteLine(storage1.Equals(storage3)); // True

            Console.WriteLine(cart1.Equals(cart2)); // False
            Console.WriteLine(cart1.Equals(cart3)); // True

            // 2. Compare

            Console.WriteLine(sugar.CompareTo(cake));   // Звичайні продукти
            Console.WriteLine(cake.CompareTo(sugar));
            Console.WriteLine(sugar.CompareTo(null));
            
            Console.WriteLine(cake.CompareTo(pork));    // Мясні та молочні продукти
            Console.WriteLine(pork.CompareTo(milk));
            Console.WriteLine(cheese.CompareTo(null));
            
            Console.WriteLine(storage1.CompareTo(null));         // STORAGE
            Console.WriteLine(storage1.CompareTo(storage2));
            Console.WriteLine(storage2.CompareTo(storage1));

            Console.WriteLine(cart1.CompareTo(null));         // CART
            Console.WriteLine(cart1.CompareTo(cart2));
            Console.WriteLine(cart2.CompareTo(cart1));

            // 3. Сортування

            Console.WriteLine(storage1);
            storage1.Sort(nameof(Product.Price)); // Сортування за ціною
            Console.WriteLine(storage1);

            storage1.Sort(nameof(Product.Weight)); // Сортування за вагою
            Console.WriteLine(storage1);






















            // STORAGE...


            //Storage storage = new Storage(sugar, cake, seaSugar, chicken, mutton, pork, milk, cheese, sourСream, sugar);

            //var meatProducts = storage.MeatProducts();          // Мясні продукти з "storage"
            //meatProducts.ChangePrices(110);                       // Змінили ціну
            //meatProducts.Print();                                 // Вивели на екран*/
            //Console.WriteLine(storage);
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