using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
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
    }
}
