using AutoMapper;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data.Profiles
{
    public class TaskEngagementProfile:Profile
    {
        public TaskEngagementProfile()
        {
            CreateMap<TaskEngagement, TaskEngagementDTO>().ForMember(t=>t.Dog, map=>map.MapFrom(
                t=>t.Dog.Name));
            CreateMap<TaskEngagementDTO, TaskEngagement>();
        }
    }
}
