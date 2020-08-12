using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClient.ViewModels
{
    public class UpdateDogViewModel
    {
        public int DogId { get; set; }

       
        [MaxLength(20, ErrorMessage = "The name shouldn't have more than 20 characters.")]
        public string Name { get; set; }


        [MaxLength(20, ErrorMessage = "The chip number shouldn't have more than 20 characters.")]
        public string ChipNumber { get; set; }

    
        [MaxLength(20, ErrorMessage = "The breed shouldn't have more than 20 characters.")]
        public string Breed { get; set; }


        public double Age { get; set; }

        public string Gender { get; set; }

        public string TrainingCourse { get; set; }
    }
}
