using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public class Customer : ICloneable
    {
        public double Arrears;
        public double AllKilowatt;

        public int? ApartmentNumber { get; set; }
        public string? Address { get; set; }
        public string? SurName { get; set; }
        public DateTime? TakingFirstMonth { get; set; }
        public double? FirstMonthIndicator { get; set; }
        public DateTime? TakingSecondMonth { get; set; }
        public double? SecondMonthIndicator { get; set; }
        public DateTime? TakingThirdMonth { get; set; }
        public double? ThirdMonthIndicator { get; set; }

        public Customer(int apartmentNumber, string address, string surName,
            DateTime takingFirstMonth, double firstMonthIndicator,
            DateTime takingSecondMonth, double secondMonthIndicator,
            DateTime takingThirdMonth, double thirdMonthIndicator)
        {
            ApartmentNumber = apartmentNumber;
            Address = address;
            SurName = surName;
            TakingFirstMonth = takingFirstMonth;
            FirstMonthIndicator = firstMonthIndicator;
            TakingSecondMonth = takingSecondMonth;
            SecondMonthIndicator = secondMonthIndicator;
            TakingThirdMonth = takingThirdMonth;
            ThirdMonthIndicator = thirdMonthIndicator;
            AllKilowatt = firstMonthIndicator + secondMonthIndicator + thirdMonthIndicator;
            Arrears = AllKilowatt * Accounting.UAH_PERE_KILOWATT;
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            return $"Surname: {SurName},\nAddress: {Address}," +
                $"\nTakingFirstMonth: {TakingFirstMonth:dd.mm.yyyy},\nFirstMonthIndicator: {FirstMonthIndicator}," +
                $"\nTakingSecondMonth: {TakingSecondMonth:dd.mm.yyyy},\nSecondMonthIndicator: {SecondMonthIndicator}" +
                $"\nTakingThirdMonth: {TakingThirdMonth:dd.mm.yyyy},\nThirdMonthIndicator: {ThirdMonthIndicator}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
