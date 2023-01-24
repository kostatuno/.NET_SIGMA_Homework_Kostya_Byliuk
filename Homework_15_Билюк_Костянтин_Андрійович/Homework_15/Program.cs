using Homework_15.Data;
using Homework_15.Models;

namespace Homework_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ApplicationDbContext())
            {
                Console.WriteLine("there's connection with db");
            }       
        }
    }
}