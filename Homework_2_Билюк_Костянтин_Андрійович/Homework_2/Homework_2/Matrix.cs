using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
   
    class Matrix
    {
        public Matrix()
        {
            Console.Write("Input your width and height: \nWidth: ");
            Width = int.Parse(Console.ReadLine());
            Console.Write(" Height: ");
            Height = int.Parse(Console.ReadLine());
            arr = new int[width, height];
            Console.WriteLine("");
        }
        public Matrix(int width, int height)
        {
            Width = width;
            Height = height;
            arr = new int[width, height];
        }

        public int this[int a, int b]
        {
            get => arr[a, b];
            set => arr[a, b] = value;
        }

        private readonly int[,] arr;

        private int width;
        private int height;


        public int Width
        {
            get { return width; }
            set
            {
                if (0 > value) width = 0;
                width = value;
            }
        }

        public int Height
        {
            get { return height; }
            set
            {
                if (0 > value) height = 0;
                height = value;
            }
        }

        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public void Fill()
        {
            for (int i = 0, k = 1; i < Width; i++)
            {
                for (int j = 0; j < Height; j++, k++)
                {
                    arr[i, j] = k;
                }
            }
        }

        public void RandomFill(int minValue, int maxValue)
        {
            var random = new Random();

            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    arr[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        public void DiagonalSnake(bool changeDirection = false)
        {
            int size = Width;
            for (int diff = 1 - size, curr = 1; diff <= size - 1; diff++)
            {
                for (int i = 0; i < size; i++)
                {
                    int j = i - diff;

                    if (j < 0 || j >= size)
                        continue;
                    if (((diff + size + 1) % 2) != 0)
                        if (changeDirection) arr[size - 1 - j, i] = curr++;
                        else arr[i, size - 1 - j] = curr++;
                    else
                        if (changeDirection) arr[i, size - 1 - j] = curr++;
                        else arr[size - 1 - j, i] = curr++;
                }
            }
            

            Print();
        }

        public void VerticalSnake(bool changeDirection = false)
        {
            int width = Width, height = Height;
            if (changeDirection) Swap(ref width, ref height);
            
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (changeDirection) arr[j, i] = ((j % 2) == 0 
                            ? i : (width - i - 1)) + 1 + j * width;
                    else arr[i, j] = ((j % 2) == 0
                            ? i : (width - i - 1)) + 1 + j * width;
                }
            }

            Print();
        }

        public void SpiralSnake(bool changeDirection = false)
        {
            int width = Width, height = Height;
            if (changeDirection) Swap(ref width, ref height);

            int row = 0, col = 0;
            int dx = 1, dy = 0;
            int dirChanges = 0, visits = width;

            for (int i = 0; i < arr.Length; i++)
            {
                if (changeDirection) arr[row, col] = i + 1;
                else arr[col, row] = i + 1;

                if (--visits == 0)
                {
                    visits = width * (dirChanges % 2) +
                        height * ((dirChanges + 1) % 2) - (dirChanges / 2 - 1) - 2;
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }
                col += dx;
                row += dy;
            }
            Print();
        }

        public void Print(bool coloration = false)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (coloration)
                    {
                        Console.BackgroundColor = (ConsoleColor)arr[i, j];
                        Console.Write(@"   ", arr[i, j]);
                        Console.ResetColor();
                    }
                    else Console.Write(@"{0,2} ", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        public void FindLongestSubsequence()
        {
            int countLenMax = 1;
            int kStartMax = 0;
            int kEndMax = 0;
            int countLen = 1;
            int kStart = 0;
            int kEnd = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j + 1 != arr.GetLength(1) && arr[i,j] == arr[i, j + 1])
                    {
                        countLen++;
                        if (countLen > 2)
                        {
                            kEnd = countLen + kStart - 1;
                            continue;
                        }
                        kStart = j;
                        kEnd = countLen + kStart - 1;
                    }
                    else
                    {
                        if (countLen >= countLenMax)
                        {
                            countLenMax = countLen;
                            kStartMax = kStart;
                            kEndMax = kEnd;
                            countLen = 1;
                            kStart = 0;
                            kEnd = 0;
                            continue;
                        }
                        countLen = 1;
                        kStart = 0;
                        kEnd = 0;
                    }   
                }
            }

            Print(true);
            Console.WriteLine("Lenght: " + countLenMax);
            Console.WriteLine("StartIndex: " + kStartMax);
            Console.WriteLine("LastIndex: " + kEndMax);
            Console.WriteLine();
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    str += string.Format(@"{0,2} ", arr[i, j]);
                }
                str += "\n";
            }
            return str;
        }
    }
}
