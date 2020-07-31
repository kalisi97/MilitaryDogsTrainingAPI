using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public override void Insert(Entities.Task entity)
        {
                context.Add(entity);
                foreach(TaskEngagement taskEngagement in entity.TaskEngagements)
                {
                    context.TaskEngagements.Add(taskEngagement);
                }
        }

        public override Entities.Task GetBy(Expression<Func<Entities.Task, bool>> filter)
        {
            return context.Tasks.AsNoTracking().Include(t => t.TaskEngagements).ThenInclude(t => t.Dog).Where(filter).FirstOrDefault();
        }

        public override Entities.Task GetById(params int[] id)
        {
            return context.Tasks.AsNoTracking().Include(t => t.TaskEngagements).ThenInclude(t => t.Dog).SingleOrDefault(t=>t.TaskId == id.ElementAt(0));

        }

        public override IEnumerable<Entities.Task> GetAll()
        {
            return context.Tasks.AsNoTracking().Include(t => t.TaskEngagements).ThenInclude(t => t.Dog);

        }
    }
}
