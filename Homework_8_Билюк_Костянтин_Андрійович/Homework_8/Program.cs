using System.IO;

namespace Homework_8
{
    class Program
    {
        static void Main()
        {
            Product cream = new DairyProducts("Простоквашино", "Вершки", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            
            Product sugar = new Product("Повна чаша", "Цукор", 2.99, 1);
            Product sugar2 = new Product("Розумний вибір", "Цукор", 2.99, 1);
            Product sugar3 = new Product("DIAMANT", "Цукор", 2.99, 1);
            
            Product cake = new Product("Наша лінія", "Торт", 6.99, 0.850);
            Product cake2 = new Product("Roshen", "Торт", 6.99, 0.850);
            Product cake3 = new Product("Tarta", "Торт", 6.99, 0.850);
            
            Product chicken = new Meat("Бащинский", "Філе куряче", 11.99, 1, TypeOfMeat.Chicken, Category.First);
            
            Product pork = new Meat("Вербена", "Свинина", 12.99, 1, TypeOfMeat.Pork, Category.First);
            Product pork2 = new Meat("Гурман", "Свинина", 12.99, 1, TypeOfMeat.Pork, Category.First);
            Product pork3 = new Meat("Наша лінія", "Свинина", 12.99, 1, TypeOfMeat.Pork, Category.First);
            
            Product butter = new DairyProducts("Простоквашино", "Масло", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            Product butter2 = new DairyProducts("Яготинське", "Масло", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            Product butter3 = new DairyProducts("Білоцерківське", "Масло", 6.99, 0.550, new DateTime(2022, 10, 5), new DateTime(2022, 12, 02));
            
            Product leaven = new DairyProducts("Простоквашино", "Закваска", 5.99, 0.4, new DateTime(2022, 8, 5), new DateTime(2022, 11, 17));
            Product leaven2 = new DairyProducts("Яготинська", "Закваска", 5.99, 0.4, new DateTime(2022, 8, 5), new DateTime(2022, 11, 17));
            Product leaven3 = new DairyProducts("Vivo", "Закваска", 5.99, 0.4, new DateTime(2022, 8, 5), new DateTime(2022, 11, 17));

            Storage storage = new Storage(pork, pork, pork, pork, pork, pork,
                butter, butter,
                leaven, leaven, leaven,
                chicken, chicken,
                sugar, sugar, sugar,
                butter, butter);

            storage.ErrorOrderHandler += (message) => Console.WriteLine(message);
            storage.PrintFirmWithOrdersHandler += (message, orderList) => StorageManager.WriteReadyOrderTo(message, orderList);
            storage.IdentifyСompatibilityForProducts(".txt_files/related_products.txt");
            storage.MakeTheOrder(".txt_files/list_of_orders.txt", ".txt_files/result.txt");
        }    
    }
}