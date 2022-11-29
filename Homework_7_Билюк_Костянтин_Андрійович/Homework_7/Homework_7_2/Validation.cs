using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7_2
{
    class Validation
    {
        public static void GetCardType(Card card)
        {
            var keyNumbers = card.Number.Substring(0, 2);
            if (card.Number.Length == 15)
            {
                if (keyNumbers == "34" || keyNumbers == "37")
                {
                    card.Type = CardType.AmericanExpress;
                }
                else
                    throw new Exception("The card the card does not have a valid number in global payment systems");
            }
            else if (card.Number[0] == '4')
            {
                if (card.Number.Length == 13 || card.Number.Length == 16)
                {
                    card.Type = CardType.Visa;
                }
                else
                    throw new Exception("The card the card does not have a valid number in global payment systems");
            }
            else if (card.Number.Length == 16)
            {
                switch (keyNumbers)
                {
                    case "51":
                        card.Type = CardType.MasterCard;
                        break;
                    case "52":
                        card.Type = CardType.MasterCard;
                        break;
                    case "53":
                        card.Type = CardType.MasterCard;
                        break;
                    case "54":
                        card.Type = CardType.MasterCard;
                        break;
                    case "55":
                        card.Type = CardType.MasterCard;
                        break;
                    default:
                        throw new Exception("The card the card does not have a valid number in global payment systems");
                }
            }
        }

        public static bool LuhnAlg(Card card)
        {
            var str = string.Empty;
            for (int i = card.Number.Length - 2; i >= 0; i -= 2)
            {
                str += card.Number[i];
            }

            var numbers = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                numbers[i] = Convert.ToInt32(str[i].ToString()) * 2;
                numbers[i] = numbers[i] % 10 + numbers[i] % 100 / 10 + numbers[i] / 100;
            }

            int result = 0;
            for (int i = card.Number.Length - 1; i >= 0; i -= 2)
            {
                result += Convert.ToInt32(card.Number[i].ToString());
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            card.CheckSum = result;
            return result % 10 == 0 ? true : false;
        }
    }
}