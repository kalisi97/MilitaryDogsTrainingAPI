using AutoMapper;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Helpers;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data.Profiles
{
    public class DogProfile:Profile
    {
        public DogProfile()
        {
            CreateMap<Dog, DogDTO>().ForMember(d=>d.TrainingCourse, map=>map.MapFrom(
                d=>d.TrainingCourse.Name)).ForMember(d=>d.Age, map=>map.MapFrom(
                    d=>CalculateCurrentAge.Age(d.DateOfBirth)));
            CreateMap<DogForCreationDTO, Dog>();
            CreateMap<DogForUpdateDTO, Dog>().ForMember(d=>d.TrainingCourseId, map=>map.MapFrom(
                d=>d.TrainingCourseId
                ));
            CreateMap<DogDTO, Dog>();
        }
    }
}
