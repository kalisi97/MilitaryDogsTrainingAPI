using MilitaryDogsTrainingAPI.Models;
using MilitaryDogsTrainingAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClient.ViewModels
{
    public class CreateTaskViewModel
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(20, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You should fill out a location.")]
        [MaxLength(20, ErrorMessage = "The location shouldn't have more than 50 characters.")]
        public string Location { get; set; }
        [Required(ErrorMessage = "You should choose dogs for the task engagements.")]
        public ICollection<DogDTO> Dogs { get; set; }

        [TheDateOfTheTaskValidation(ErrorMessage = "The date must refer to a date in the future.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required(ErrorMessage = "You should fill out the date of the task.")]
        public DateTime Date { get; set; }
    }
}
