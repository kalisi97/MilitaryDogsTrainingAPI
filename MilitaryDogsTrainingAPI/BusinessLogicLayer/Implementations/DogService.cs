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
    public class DogService : IDogService
    {
        private readonly IUnitOfWork unitOfWork;

        public DogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Delete(Dog entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dog> GetAll(Expression<Func<Dog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dog> GetAll()
        {
            throw new NotImplementedException();
        }

        public Dog GetBy(Expression<Func<Dog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Dog GetById(params int[] id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Dog entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Dog> SearchFor(Expression<Func<Dog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Dog entity)
        {
            throw new NotImplementedException();
        }
    }
}
