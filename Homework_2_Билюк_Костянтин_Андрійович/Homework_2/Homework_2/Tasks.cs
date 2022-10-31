using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Tasks
    {
        public void One()
        {
            Matrix matrix = new Matrix();

            Console.WriteLine("DiagonalSnake with changed direction: ");
            matrix.DiagonalSnake(true);

            Console.WriteLine("VerticalSnake: ");
            matrix.VerticalSnake();

            Console.WriteLine("SpiralSnake: ");
            matrix.SpiralSnake();

            Console.WriteLine("RandomFill: ");
            matrix.RandomFill(0, 25);
            Console.WriteLine(matrix);
        }

        public void Two()
        {
            Matrix matrix = new Matrix(8, 8);

            matrix.RandomFill(0, 16);
            matrix.FindLongestSubsequence();
        }

        public void Three()
        {
            Cube cube = new Cube(3);
            cube.RandomFill();
            cube.ІsThereThroughHole();
        }

        public void Four()
        {
            Tensor tensor = new Tensor(4, 2, 5);
            
            int n = 0;
            

            tensor[2, 1, 2] = 999;
            tensor[1, 2, 2] = 999;
            tensor[0, 0, 0] = 999;
            tensor[3, 3, 4] = 999;


            Console.WriteLine(tensor[1, 2, 3]);            
        }
    }
}
