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
                    d=>CalculateCurrentAge.Age(d.DateOfBirth))).ForMember(d=>d.dogId, map=>
                    map.MapFrom(d=>d.DogId));
            CreateMap<DogForCreationDTO, Dog>().ForPath(d => d.TrainingCourse.Name, map => map.MapFrom(
                  d => d.TrainingCourse
                  ));
            CreateMap<DogForUpdateDTO, Dog>().ForPath(d => d.TrainingCourse.Name, map => map.MapFrom(
                  d => d.TrainingCourse
                  )).ForPath(d => d.DogId, map =>
                        map.MapFrom(d => d.Id));
            CreateMap<DogDTO, Dog>();
        }
    }
}
