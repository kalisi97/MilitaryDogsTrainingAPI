using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Helpers;
using MilitaryDogsTrainingAPI.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations
{
    public class DogRepository : GenericRepository<Dog>, IDogRepository
    {
        private readonly ApplicationDbContext context;

        public DogRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override IEnumerable<Dog> GetAll()
        {
            return context.Dogs.Include(d => d.TrainingCourse);
        }
        public override Dog GetBy(Expression<Func<Dog, bool>> filter)
        {
            return context.Dogs.Include(d => d.TrainingCourse).SingleOrDefault(filter);
        }
        public override Dog GetById(params int[] id)
        {
            return context.Dogs.AsNoTracking().Include(d => d.TrainingCourse).SingleOrDefault(d => d.DogId == id.ElementAt(0));
        }

        public override IQueryable<Dog> GetAll(Expression<Func<Dog, bool>> filter)
        {
            
            return context.Dogs.Include(d => d.TrainingCourse).Where(filter);
        }

        public PagedList<Dog> GetAll(EntityResourceParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            var collection = context.Dogs.Include(d => d.TrainingCourse) as IQueryable<Dog>;

            if (!string.IsNullOrWhiteSpace(parameters.SearchQuery))
            {
                collection = collection.Where(d => d.Name.ToLower().Contains(parameters.SearchQuery.ToLower())
                    || d.Breed.ToLower().Contains(parameters.SearchQuery.ToLower()));
            }
            if (!string.IsNullOrEmpty(parameters.Category))
            {
                collection = collection.Where(d => d.TrainingCourse.Name.ToLower()
                .Contains(parameters.Category));
            }

            return PagedList<Dog>.Create(collection,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
