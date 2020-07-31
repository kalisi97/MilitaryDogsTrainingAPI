using AutoMapper;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Data.Profiles
{
    public class TaskProfile:Profile
    {
        //from source to destination
        public TaskProfile()
        {
            CreateMap<TaskForCreationDTO, Entities.Task>();
            CreateMap<TaskDTO, Entities.Task>().ForPath(t=>t.TaskEngagements,
                map=>map.MapFrom(t=>t.TaskEngagementDTOs));
            CreateMap<Entities.Task, TaskDTO>().ForPath(t => t.TaskEngagementDTOs,
              map => map.MapFrom(t => t.TaskEngagements));
            CreateMap<TaskForManipulationDTO, Entities.Task>();
            CreateMap<Entities.Task, TaskForManipulationDTO>();
        }
    }
}
