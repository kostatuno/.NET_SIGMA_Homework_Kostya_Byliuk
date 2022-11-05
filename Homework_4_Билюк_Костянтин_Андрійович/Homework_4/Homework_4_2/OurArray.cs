using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_4_2
{
    class OurArray
    {
        private int[] _arr;
        public int Length { get; private set; }

        public OurArray(int size)
        {
            Length = size;
            _arr = new int[Length];
        }

        public void Print()
        {
            for (int i = 0; i < _arr.Length; i++)
            {
                Console.Write(_arr[i] + " ");
            }
        }

        public int this [int a]
        {
            get { return _arr[a]; }
            set { _arr[a] = value; }
        }

        public void RandomFill(int minValue, int maxValue)
        {
            Random random = new Random();
            for (int i = 0; i < _arr.Length; i++)
                _arr[i] = random.Next(minValue, maxValue);
        }

        public void FrequencyTable()
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();  
            foreach (var item in _arr)
            {
                if (!dic.ContainsKey(item)) dic[item] = 0;
                dic[item]++;
            }

            Console.WriteLine("Number\tQuantity:\n");
            foreach (var e in dic)
            {
                
                Console.WriteLine($"{e.Key,2}\t{e.Value,2}");
            }
        }

        public void LongestSubsequences()
        {
            var arr = new int[1];
            var list = new List<int>();

            for (int i = 1; i < Length; i++)
            {
                
                if (_arr[i - 1] + 1 == _arr[i])
                {
                    list.Add(_arr[i - 1]);
                    list.Add(_arr[i]);
                }
                else list.Clear();

                if (list.Count >= arr.Length)
                {
                    arr = new int[list.Count];
                    for (int j = 0; j < arr.Length; j++)
                    {
                        arr[j] = list[j];
                    }
                    
                }
            }

            Console.Write("\n\nLongest subsequences: ");
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }
    }
}
