using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class DogForCreationDTO
    {
        public string Name { get; set; }
        public virtual string ChipNumber { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int TrainingCourseId { get; set; }
      
    }
}
