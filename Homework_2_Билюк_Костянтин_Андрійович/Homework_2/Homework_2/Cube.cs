using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Cube
    {
        int[,,] cube;
        
        public int Size { get; }
        public Cube(int size)
        {
            Size = size;
            cube = new int[size, size, size];
        }

        public int this[int x, int y, int z]
        {
            get { return cube[x, y, z]; }
            set { cube[x, y, z] = value; }
        }

        public void RandomFill()
        {
            Random random = new Random();
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        cube[x, y, z] = random.Next(0, 2);
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("White(a cube): 1, Gray(a cavity): 0\n");
            for (int x = 0; x < Size; x++)
            {
                Console.WriteLine("{0} layer: ", x + 1);
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        if (cube[x, y, z] == 1) Console.BackgroundColor = ConsoleColor.White;
                        else Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(@"  ");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("");
            } 
        }

        public void ІsThereThroughHole()
        {
            Print();
            int cZ = 0, cX = 0, cY = 0;
            bool answerX = false, answerY = false, answerZ = false;

            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    for (int z = 0; z < Size; z++)
                    {
                        if (cube[x, y, z] == 0) cZ++;
                        if (cube[x, z, y] == 0) cY++;
                        if (cube[z, y, x] == 0) cX++;
                    }
                    if (cZ == Size) answerZ = true;
                    else cZ = 0;

                    if (cY == Size) answerY = true;
                    else cY = 0;

                    if (cX == Size) answerZ = true;
                    else cX = 0;
                }
            }

            if (answerX || answerY || answerZ) Console.WriteLine("There is a through hole in the cube\n");
            else Console.WriteLine("There isn't a through hole in the cube\n");
            Console.ReadKey();
        }
    }
}
