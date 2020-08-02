using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Helpers;
using MilitaryDogsTrainingAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces
{
    public interface IDogService:IService<Dog>
    {
        PagedList<Dog> GetAll(EntityResourceParameters parameters);
    }
}
