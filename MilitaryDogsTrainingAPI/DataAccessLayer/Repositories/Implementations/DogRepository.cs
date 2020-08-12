using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
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
        private readonly IPropertyMappingService propertyMappingService;
        public DogRepository(ApplicationDbContext _context, IPropertyMappingService propertyMappingService) : base(_context)
        {
           context = _context;
            this.propertyMappingService = propertyMappingService;
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
        public override void Insert(Dog entity)
        {
            try
            {
                base.Insert(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
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
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                /*
                if(parameters.OrderBy.ToLower()=="name")
                collection = collection.OrderBy(d => d.Name);
                if (parameters.OrderBy.ToLower() == "age")
                    collection = collection.OrderBy(d => d.DateOfBirth);
                if (parameters.OrderBy.ToLower() == "gender")
                    collection = collection.OrderBy(d => d.Gender);
                if (parameters.OrderBy.ToLower() == "breed")
                    collection = collection.OrderBy(d => d.Breed);
                    */


                var propertyMappingDictionary =
                       propertyMappingService.GetPropertyMapping<Models.DogDTO, Dog>();

                collection = collection.ApplySort(parameters.OrderBy,
                    propertyMappingDictionary);
            }

            return PagedList<Dog>.Create(collection,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}
