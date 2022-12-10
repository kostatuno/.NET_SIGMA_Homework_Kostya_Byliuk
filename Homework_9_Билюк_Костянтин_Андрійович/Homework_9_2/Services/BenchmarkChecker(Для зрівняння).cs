using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Homework_9_2
{
    [MemoryDiagnoser]
    [RankColumn]
    public class BenchmarkCheckerForProducts
    {
        Storage storage = new Storage(new Product("Повна чаша", "Цукор", 2.99, 1),
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
        
        [Benchmark]
        public void RandomPivot()
        {
            storage.QuickSort(new Random().Next(0, storage.Length));
        }

        [Benchmark]
        public void FirstPivot()
        {
            storage.QuickSort(0);
        }

        [Benchmark]
        public void LastPivot()
        {
            storage.QuickSort(storage.Products.Count - 1);
        }

        [Benchmark]
        public void MiddlePivot()
        {
            storage.QuickSort((storage.Products.Count - 1) / 2);
        }
    }
}
