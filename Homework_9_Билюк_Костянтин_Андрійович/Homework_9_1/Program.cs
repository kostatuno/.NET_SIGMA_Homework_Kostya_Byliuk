using Microsoft.VisualBasic;
using System.Text;
using System.Xml.Linq;

namespace Homework_9_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var informationFile = new FileStream("INFORMATION.txt", FileMode.Open);
            var resultFile = new FileStream("RESULT.txt", FileMode.OpenOrCreate);

            using (var sr = new StreamReader(informationFile))
            using (var sw = new StreamWriter(resultFile))
            {
                foreach (var element in sr.ReadLine()
                    .Split(' ')
                    .Select(x => int.Parse(x))
                    .ToArray()
                    .MergeSort()
                    .Select(x => Convert.ToString(x))
                    .ToArray())
                {
                    sw.Write(element + " ");
                }
            }
        }


        
    }
}