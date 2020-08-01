using MilitaryDogsTrainingAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    [TheDateOfTheTaskValidation(ErrorMessage = "The date must refer to a date in the future.")]
    public class TaskForCreationDTO:TaskForManipulationDTO
    {
        [Required(ErrorMessage = "You should choose dogs for the task engagements.")]  
        public ICollection<DogDTO> Dogs { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required(ErrorMessage = "You should fill out the date of the task.")]    
        public DateTime Date  { get; set; }
    }
}
