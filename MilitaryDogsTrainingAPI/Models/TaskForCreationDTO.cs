using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class TaskForCreationDTO:TaskForManipulationDTO
    {
        public DateTime Date { get; set; }
        public ICollection<DogDTO> Dogs { get; set; }
    }
}
