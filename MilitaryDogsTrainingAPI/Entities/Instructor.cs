using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Entities
{
    public class Instructor:ApplicationUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Rank { get; set; }
        public int TrainingCourseId { get; set; }
        public TrainingCourse TrainingCourse { get; set; }
    }
}
