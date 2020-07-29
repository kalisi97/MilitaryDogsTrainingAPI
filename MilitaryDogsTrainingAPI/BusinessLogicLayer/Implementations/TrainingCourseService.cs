using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.DataAccessLayer.UnitOfWork;
using MilitaryDogsTrainingAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.BusinessLogicLayer.Implementations
{
    public class TrainingCourseService:ITrainingCourseService
    {
        private readonly IUnitOfWork unitOfWork;

        public TrainingCourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(TrainingCourse entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TrainingCourse> GetAll(Expression<Func<TrainingCourse, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TrainingCourse> GetAll()
        {
            return unitOfWork.TrainingCourseRepository.GetAll();
        }

        public TrainingCourse GetBy(Expression<Func<TrainingCourse, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public TrainingCourse GetById(params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TrainingCourse entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TrainingCourse> SearchFor(Expression<Func<TrainingCourse, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TrainingCourse entity)
        {
            throw new NotImplementedException();
        }
    }
}
