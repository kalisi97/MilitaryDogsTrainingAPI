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
    public class TaskEngagementRepository:GenericRepository<TaskEngagement>,ITaskEngagementRepository
    {
        private readonly ApplicationDbContext context;

        public TaskEngagementRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }

        public override IQueryable<TaskEngagement> GetAll(Expression<Func<TaskEngagement, bool>> filter)
        {
            return context.TaskEngagements.AsNoTracking().Include(t => t.Dog).ThenInclude(t => t.TrainingCourse).Include(t => t.Task).Where(filter);
        }

        public override IEnumerable<TaskEngagement> GetAll()
        {
            return context.TaskEngagements.AsNoTracking().Include(t => t.Dog).ThenInclude(t => t.TrainingCourse).Include(t=>t.Task);

        }

        public override TaskEngagement GetById(params int[] id)
        {
            int dogId = id.ElementAt(0);
            int taskId = id.ElementAt(1);
            return context.TaskEngagements.Include(t => t.Task).Include(t => t.Dog).ThenInclude(t => t.TrainingCourse).ThenInclude(t => t.Instructors).SingleOrDefault(
                d =>  d.DogId == dogId && d.TaskId == taskId);
        }
    }
}
