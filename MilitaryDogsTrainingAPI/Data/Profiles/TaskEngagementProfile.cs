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
            CreateMap<TaskEngagementDTO, TaskEngagement>().ForPath(t=>t.Dog.Name, map=>map.MapFrom(
                t=>t.Dog
                ));
            CreateMap<TaskEngagement, TaskEngagementDetailsDTO>().ForMember(t => t.TaskName, map => map.MapFrom(
                   t => t.Task.Name)).ForMember(t=>t.Dog, map=>map.MapFrom(t=>t.Dog.Name));
            CreateMap<TaskEngagementDetailsDTO, TaskEngagement>().ForPath(t => t.Task.Name, map => map.MapFrom(
                  t => t.TaskName)).ForPath(t=>t.Dog.Name, map=>map.MapFrom(t=>t.Dog));
        }
    }
}
