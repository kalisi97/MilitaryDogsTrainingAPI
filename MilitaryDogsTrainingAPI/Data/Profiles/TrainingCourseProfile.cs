using AutoMapper;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data.Profiles
{
    public class TrainingCourseProfile:Profile
    {
        public TrainingCourseProfile()
        {
            CreateMap<TrainingCourse, TrainingCourseDTO>();
        }
    }
}
