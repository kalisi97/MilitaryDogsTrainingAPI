using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{

    public class TaskForManipulationDTO
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(20, ErrorMessage = "The name shouldn't have more than 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should fill out a location.")]
        [MaxLength(20, ErrorMessage = "The location shouldn't have more than 50 characters.")]
        public string Location { get; set; }
    }
}
