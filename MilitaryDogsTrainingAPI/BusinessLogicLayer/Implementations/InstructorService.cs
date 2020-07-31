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
    public class InstructorService:IInstructorService
    {
        private readonly IUnitOfWork unitOfWork;

        public InstructorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Instructor> GetAll(Expression<Func<Instructor, bool>> filter)
        {
            return unitOfWork.InstructorRepository.GetAll(filter);
        }

        public IEnumerable<Instructor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Instructor GetBy(Expression<Func<Instructor, bool>> filter)
        {
            return unitOfWork.InstructorRepository.GetBy(filter);
        }

        public Instructor GetById(params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Instructor entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Instructor> SearchFor(Expression<Func<Instructor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Instructor entity)
        {
            throw new NotImplementedException();
        }
    }
}
