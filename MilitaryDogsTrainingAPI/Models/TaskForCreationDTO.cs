﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.Models
{
    public class TaskForCreationDTO:TaskForManipulationDTO
    {
      
        public ICollection<DogDTO> Dogs { get; set; }
    }
}
