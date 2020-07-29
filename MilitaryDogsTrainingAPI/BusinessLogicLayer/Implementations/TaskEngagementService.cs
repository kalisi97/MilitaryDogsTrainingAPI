using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.DataAccessLayer.UnitOfWork;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.BusinessLogicLayer.Implementations
{
    public class TaskEngagementService:ITaskEngagementService
    {
        private readonly IUnitOfWork unitOfWork;

        public TaskEngagementService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(TaskEngagement entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaskEngagement> GetAll(Expression<Func<TaskEngagement, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskEngagement> GetAll()
        {
            throw new NotImplementedException();
        }

        public TaskEngagement GetBy(Expression<Func<TaskEngagement, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TaskEngagement GetById(params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TaskEngagement entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TaskEngagement> SearchFor(Expression<Func<TaskEngagement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskEngagement entity)
        {
            throw new NotImplementedException();
        }
    }
}
