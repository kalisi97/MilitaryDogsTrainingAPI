using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationClient.Controllers
{
    public class TrainingCourseViewModel
    {
        
        public IEnumerable<TrainingCourseDTO> TrainingCourses { get; private set; }
         = new List<TrainingCourseDTO>();

        public TrainingCourseViewModel(IEnumerable<TrainingCourseDTO> entites)
        {
            TrainingCourses = entites;
        }
        
    }
}
