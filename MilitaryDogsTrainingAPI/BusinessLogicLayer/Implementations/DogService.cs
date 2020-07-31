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
            unitOfWork.DogRepository.Delete(entity);
            unitOfWork.Save();
        }

        public IQueryable<Dog> GetAll(Expression<Func<Dog, bool>> filter)
        {
            return unitOfWork.DogRepository.GetAll(filter);
        }

        public IEnumerable<Dog> GetAll()
        {
            return unitOfWork.DogRepository.GetAll();
        }

        public Dog GetBy(Expression<Func<Dog, bool>> filter)
        {
            return unitOfWork.DogRepository.GetBy(filter);
        }

        public Dog GetById(params int[] id)
        {
            return unitOfWork.DogRepository.GetById(id);
        }

        public void Insert(Dog entity)
        {
            unitOfWork.DogRepository.Insert(entity);
            unitOfWork.Save();
        }

        public IQueryable<Dog> SearchFor(Expression<Func<Dog, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(Dog entity)
        {
            unitOfWork.DogRepository.Update(entity);
            unitOfWork.Save();
        }
    }
}
