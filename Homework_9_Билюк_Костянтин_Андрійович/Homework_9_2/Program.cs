using BenchmarkDotNet.Running;

namespace Homework_9_2
{
    /*

        Запускаємо в Release та оцікуємо. По завершенню буде вибудована таблиця з трьох методів, які ми перевіряємо,
        вони находяться в класі BenchmarkCheckerForProducts.
        
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Storage storage = new Storage(new Product("Повна чаша", "Цукор", 2.99, 1),
                new Product("Повна чаша", "Цукор", 51.99, 1),
                new Product("Повна чаша", "Цукор", 92.99, 1),
                new Product("Повна чаша", "Цукор", 99.99, 1),
                new Product("Повна чаша", "Цукор", 105.99, 1),
                new Product("Повна чаша", "Цукор", 23.99, 1),
                new Product("Повна чаша", "Цукор", 25.99, 1),
                new Product("Повна чаша", "Цукор", 212.99, 1),
                new Product("Повна чаша", "Цукор", 232.99, 1),
                new Product("Повна чаша", "Цукор", 221.99, 1),
                new Product("Повна чаша", "Цукор", 294.99, 1),
                new Product("Повна чаша", "Цукор", 2112.99, 1),
                new Product("Повна чаша", "Цукор", 41.99, 1),
                new Product("Повна чаша", "Цукор", 44.99, 1),
                new Product("Повна чаша", "Цукор", 42.99, 1),
                new Product("Повна чаша", "Цукор", 456.99, 1),
                new Product("Повна чаша", "Цукор", 123.99, 1),
                new Product("Повна чаша", "Цукор", 12.99, 1),
                new Product("Повна чаша", "Цукор", 52.99, 1),
                new Product("Повна чаша", "Цукор", 12.99, 1),
                new Product("Повна чаша", "Цукор", 58.99, 1),
                new Product("Повна чаша", "Цукор", 102.99, 1),
                new Product("Повна чаша", "Цукор", 3.99, 1));

            StorageManager.Print(storage.Products);
            storage.QuickSort(new Random().Next(0, storage.Length));
            storage.QuickSort(0);
            storage.QuickSort(storage.Products.Count - 1);
            StorageManager.Print(storage.Products);*/

            BenchmarkRunner.Run<BenchmarkCheckerForProducts>(); 


        }
    }
}