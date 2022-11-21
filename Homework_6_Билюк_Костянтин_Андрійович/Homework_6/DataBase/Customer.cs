using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6
{
    public class Customer : ICloneable
    {
        public const double UAH_PERE_KILOWATT = 1.44;
        [Key]
        public int Id { get; set; }
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
        public int? Quarter { get; set; }

        public Customer(int apartmentNumber, string address, string surName,
            DateTime? takingFirstMonth, double? firstMonthIndicator,
            DateTime? takingSecondMonth, double? secondMonthIndicator,
            DateTime? takingThirdMonth, double? thirdMonthIndicator, int? quarter)
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
            if (FirstMonthIndicator != null)
                AllKilowatt += FirstMonthIndicator.Value;
            if (SecondMonthIndicator != null)
                AllKilowatt += SecondMonthIndicator.Value;
            if (ThirdMonthIndicator != null)
                AllKilowatt += ThirdMonthIndicator.Value;
            Arrears = AllKilowatt * UAH_PERE_KILOWATT;
            Quarter = quarter;
        }

        public Customer()
        {

        }

        public override string ToString()
        {
            return $"{ApartmentNumber, -5} | {SurName, -15} " +
                        $"| {TakingFirstMonth, -20:dd.MM.yy} | {FirstMonthIndicator, -20}" +
                        $" | {TakingSecondMonth, -20:dd.MM.yy} | {SecondMonthIndicator, -20}" +
                        $" | {TakingThirdMonth, -20:dd.MM.yy} | {ThirdMonthIndicator, -20}";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Customer obj2)
            {
                return false;
            }
            return this.AllKilowatt == obj2.AllKilowatt && this.Arrears == obj2.Arrears && 
                this.SurName == obj2.SurName;
        }
    }
}
