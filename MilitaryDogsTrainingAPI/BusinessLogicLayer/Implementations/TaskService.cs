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
            unitOfWork.TaskRepository.Delete(entity);
            unitOfWork.Save();
        }

        public IQueryable<Entities.Task> GetAll(Expression<Func<Entities.Task, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entities.Task> GetAll()
        {
            return unitOfWork.TaskRepository.GetAll();
        }

        public Entities.Task GetBy(Expression<Func<Entities.Task, bool>> filter)
        {
            return unitOfWork.TaskRepository.GetBy(filter);
        }

        public Entities.Task GetById(params int[] id)
        {
            return unitOfWork.TaskRepository.GetById(id);
        }

        public void Insert(Entities.Task entity)
        {
            unitOfWork.TaskRepository.Insert(entity);
            unitOfWork.Save();
        }

        public IQueryable<Entities.Task> SearchFor(Expression<Func<Entities.Task, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Entities.Task entity)
        {
            unitOfWork.TaskRepository.Update(entity);
            unitOfWork.Save();
        }
    }
}
