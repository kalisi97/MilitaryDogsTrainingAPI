using AutoMapper;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data.Profiles
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {  
            CreateMap<Instructor, InstructorDTO>().ForMember(i=>i.Email, map => map.MapFrom(
                i=>i.Email
                ))
                .ForMember(i=>i.PhoneNumber, map=>map.MapFrom(i=>i.PhoneNumber));
        }
    }
}
