namespace Homework_7_2
{
    internal class Program
    {
        static void Main()
        {
            Card card = new Card("371449635398431");
            Card card2 = new Card("378734493671000");
            Card card3 = new Card("5555555555554444");
            Card card4 = new Card("5195105105104199");
            Card card5 = new Card("4111111111111111");
            Card card6 = new Card("4441114429512005");
            
            ValidationManager.MakeByConsole(card);
            ValidationManager.MakeByConsole(card2);
            ValidationManager.MakeByConsole(card3);
            ValidationManager.MakeByConsole(card4);
            ValidationManager.MakeByConsole(card5);
            ValidationManager.MakeByConsole(card6);
        }
    }
}