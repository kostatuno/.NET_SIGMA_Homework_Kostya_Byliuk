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

        public void TwoLongestSubsequences()
        {
            var list = new List<int>();
            var firstList = new List<int>();
            var secondList = new List<int>();


            for (int i = 0; i < Length; i++)
            {
                if (i + 1 < Length && _arr[i] + 1 == _arr[i + 1])
                {
                    list.Add(_arr[i]);
                }
                else if (list.Count > 0)
                {
                    list.Add(_arr[i]);
                    if (firstList.Count < list.Count)
                    {
                        firstList.Clear();
                        firstList.AddRange(list);
                    }
                    else if (list.Count <= firstList.Count && !firstList.Equals(list))
                    {
                        secondList.Clear();
                        secondList.AddRange(list);
                    }
                    list.Clear();
                }
            }

            Console.Write("\n\nFirst subsequences: ");
            foreach (var item in firstList)
            {
                Console.Write(item + " ");
            }

            

            Console.Write("\nSecond subsequences: ");
            foreach (var item in secondList)
            {
                Console.Write(item + " ");
            }
        }

        private void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
