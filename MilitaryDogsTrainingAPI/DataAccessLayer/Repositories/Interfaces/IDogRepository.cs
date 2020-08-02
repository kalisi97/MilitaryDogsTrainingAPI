using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Helpers;
using MilitaryDogsTrainingAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces
{
    public interface IDogRepository:IGenericRepository<Dog>
    {
        PagedList<Dog> GetAll(EntityResourceParameters parameters);
    }
}
