using MilitaryDogsTrainingAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    [TheDateOfBirthValidation(ErrorMessage = "The date mustn't refer to a date in the future.")]
    public class DogForCreationDTO
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(20, ErrorMessage = "The name shouldn't have more than 20 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a chip number.")]
        [MaxLength(20, ErrorMessage = "The chip number shouldn't have more than 20 characters.")]
        public string ChipNumber { get; set; }

        [Required(ErrorMessage = "You should fill out a breed.")]
        [MaxLength(20, ErrorMessage = "The breed shouldn't have more than 20 characters.")]
        public string Breed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required(ErrorMessage = "You should fill out a date of birth.")]
      
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "You should fill out a gender.")]
       
        public string Gender { get; set; }

        [Required(ErrorMessage = "You should fill out a training course.")]
        public string TrainingCourse { get; set; }
      
    }
}
