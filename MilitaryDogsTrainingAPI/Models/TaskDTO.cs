using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class TaskDTO:TaskForManipulationDTO
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy.}")]
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public ICollection<TaskEngagementDTO> TaskEngagementDTOs { get; set; }
    }
}
