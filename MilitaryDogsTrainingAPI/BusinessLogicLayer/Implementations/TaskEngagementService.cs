﻿using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
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
            unitOfWork.TaskEngagementRepository.Delete(entity);
            unitOfWork.Save();
        }

        public IQueryable<TaskEngagement> GetAll(Expression<Func<TaskEngagement, bool>> filter)
        {
            return unitOfWork.TaskEngagementRepository.GetAll(filter);
        }

        public IEnumerable<TaskEngagement> GetAll()
        {
            return unitOfWork.TaskEngagementRepository.GetAll();
        }

        public TaskEngagement GetBy(Expression<Func<TaskEngagement, bool>> filter)
        {
            return unitOfWork.TaskEngagementRepository.GetAll(filter).FirstOrDefault();
        }

        public TaskEngagement GetById(params int[] id)
        {
            return unitOfWork.TaskEngagementRepository.GetById(id);
        }

        public void Insert(TaskEngagement entity)
        {
            
        }

        public IQueryable<TaskEngagement> SearchFor(Expression<Func<TaskEngagement, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TaskEngagement entity)
        {
            unitOfWork.TaskEngagementRepository.Update(entity);
            unitOfWork.Save();
        }
    }
}
