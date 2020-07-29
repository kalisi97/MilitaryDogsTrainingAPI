using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.BusinessLogicLayer.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Delete(Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Task> GetAll(Expression<Func<Entities.Task, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entities.Task GetBy(Expression<Func<Entities.Task, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Entities.Task GetById(params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Entities.Task> SearchFor(Expression<Func<Entities.Task, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
