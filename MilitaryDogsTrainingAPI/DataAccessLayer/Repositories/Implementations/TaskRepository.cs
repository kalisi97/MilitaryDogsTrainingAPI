using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations
{
    public class TaskRepository:GenericRepository<Entities.Task>, ITaskRepository
    {
        private readonly ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
    }
}
