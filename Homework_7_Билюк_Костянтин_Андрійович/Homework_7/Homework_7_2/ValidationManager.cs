using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7_2
{
    static class ValidationManager
    {
        public static void MakeByConsole(Card card)
        {
            Console.WriteLine($"Number: {card.Number}");
            if (!Validation.LuhnAlg(card))
                Console.WriteLine("INVALID");
            else
            {
                Validation.GetCardType(card);
                Console.WriteLine(card.Type);
            }
            Console.ReadKey();
        }
    }
}
