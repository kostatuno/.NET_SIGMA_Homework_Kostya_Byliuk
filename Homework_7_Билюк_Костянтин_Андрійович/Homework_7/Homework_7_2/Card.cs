using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7_2
{
    sealed class Card
    {
        private int _checkSum;
        private string _number;
        public int CheckSum
        {
            get { return _checkSum; }
            set
            {
                if (value < 0)
                    throw new Exception("CheckSum shouldn't be a negative one");
                _checkSum = value;
            }
        }
        public string Number 
        {
            get { return _number; }
            private set
            {
                if (value.Length == 13 || value.Length == 15 || value.Length == 16)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (!char.IsDigit(value[i]))
                            throw new Exception("Your numbers contain no correct symbols. Fix it");
                    }
                    _number = value;   
                }
                else throw new Exception("Length is not correct");
            } 
        }
        public CardType Type { get; set; }

        public Card(string numbers)
        {
            Number = numbers;
        }

        public Card()
        {
        }

        public override string ToString()
        {
            return $"{Type}: {Number}, CheckSum: {CheckSum}";
        }
    }
}
