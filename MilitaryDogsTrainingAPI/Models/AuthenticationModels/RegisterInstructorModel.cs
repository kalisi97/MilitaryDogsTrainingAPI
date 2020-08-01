using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class RegisterInstructorModel:RegisterModel
    {
       
      
        [Required(ErrorMessage = "Full name is required")]
        public string FullName { get; set; }
       
        [Required(ErrorMessage = "Rank is required")]
        public string Rank { get; set; }

        [Required(ErrorMessage = "Training course is required")]
        public string TrainingCourse  { get; set; }
       
    }
}
