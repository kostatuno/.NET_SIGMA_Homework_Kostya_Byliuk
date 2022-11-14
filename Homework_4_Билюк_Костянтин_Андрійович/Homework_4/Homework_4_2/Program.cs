namespace Homework_4_2
{
    internal class Program
    {
        static void Main()
        {
            OurArray array = new OurArray(30);

            // 1. FrequencyTable

            array.RandomFill(2, 9);
            array.Print();
            /*Console.WriteLine("\n");
            array.FrequencyTable();*/

            // 2.  Дві найдовші підпослідовності

            array.TwoLongestSubsequences();


            Console.ReadKey();
        }
    }
}