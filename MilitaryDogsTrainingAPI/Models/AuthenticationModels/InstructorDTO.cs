using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class InstructorDTO
    {
        [Required(ErrorMessage = "You should fill out a full name.")]
        [MaxLength(20, ErrorMessage = "The full name shouldn't have more than 50 characters.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "You should fill out a rank.")]
        public string Rank { get; set; }
        [Required(ErrorMessage = "You should fill out a phone number.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "You should fill out an email.")]
        public string Email  { get; set; }
    }
}
