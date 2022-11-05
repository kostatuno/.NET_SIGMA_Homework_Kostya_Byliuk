namespace Homework_4_2
{
    internal class Program
    {
        static void Main()
        {
            OurArray array = new OurArray(20);

            // 1. FrequencyTable

            array.RandomFill(2, 8);
            array.Print();
            /*Console.WriteLine("\n");
            array.FrequencyTable();*/

            // 2.  Найдовша підпослідовность

            array.LongestSubsequences();


            Console.ReadKey();
        }
    }
}