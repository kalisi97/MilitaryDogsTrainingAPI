using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class DogForCreationDTO
    {
        public string Name { get; set; }
        public virtual string ChipNumber { get; set; }
        public string Breed { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int TrainingCourseId { get; set; }
      
    }
}
