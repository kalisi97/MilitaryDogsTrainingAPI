using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class DogDTO
    {

        public int dogId { get; set; }
        public string Name { get; set; }
        public string ChipNumber { get; set; }
        public double Age { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public string TrainingCourse { get; set; }

       
    }
}
