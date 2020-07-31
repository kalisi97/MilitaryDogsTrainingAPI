using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Helpers
{
    public static class CalculateCurrentAge
    {
        public static int Age(DateTime date)
        {
            //10.08.2018 -> sad ima jednu i po godinu, modifikovati metodu u zavisnosti od zahteva
          DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - date.Year;

            if (currentDate < date.AddYears(age))
            {
                age--;
            }
            return age;
        }
    }
}
