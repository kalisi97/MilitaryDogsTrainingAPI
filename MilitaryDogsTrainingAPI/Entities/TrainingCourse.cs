using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Entities
{
    public class TrainingCourse
    {
        public int TrainingCourseId { get; set; }
        public string  Name { get; set; }
        public string Description  { get; set; }
        public int Duration  { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Dog> Dogs { get; set; }
    }
}
