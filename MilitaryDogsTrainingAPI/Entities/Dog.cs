using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Entities
{
    public class Dog
    {
        public int DogId  { get; set; }
        [Required]
        public string ChipNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        [Required]
        public DateTime  DateOfBirth { get; set; }
        [Required]
        public string Breed  { get; set; }
        [Required]
        public string Gender  { get; set; }
        public int TrainingCourseId { get; set; }
        public TrainingCourse TrainingCourse { get; set; }

        public ICollection<TaskEngagement> TaskEngagements { get; set; }
    }
}
