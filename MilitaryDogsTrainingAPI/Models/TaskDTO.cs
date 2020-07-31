using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class TaskDTO:TaskForManipulationDTO
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public ICollection<TaskEngagementDTO> TaskEngagementDTOs { get; set; }
    }
}
