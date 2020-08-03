using MilitaryDogsTrainingAPI.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    [CourseTitleMustBeDifferentFromDescription(ErrorMessage = "Name must be different from description.")]
    public class TrainingCourseDTO
    {
        [Required(ErrorMessage = "You should fill out a name.")]
        [MaxLength(100, ErrorMessage = "The name shouldn't have more than 100 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You should fill out a description.")]
        [MaxLength(100, ErrorMessage = "The description shouldn't have more than 100 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You should fill out a duration.")]
        [Range(1, 10)]
        public int Duration { get; set; }
      
    }
}
