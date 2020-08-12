using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Helpers
{
    public static class CalculateCurrentAge
    {
        public static double Age(DateTime date)
        {
            //10.08.2018 -> sad ima jednu i po godinu, modifikovati metodu u zavisnosti od zahteva
          DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - date.Year;
            int months = currentDate.Month;
            if (currentDate < date.AddYears(age))
            {
                age--;
            }

            if (currentDate.Day < date.Day) months--;
            var monthsCalculate = (double)months / 10;
            return (double)age+monthsCalculate;
        }
    }
}
