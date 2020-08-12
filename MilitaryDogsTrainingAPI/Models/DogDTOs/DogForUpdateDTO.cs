using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class DogForUpdateDTO:DogForCreationDTO
    {
        public int Id { get; set; }
    }
}
