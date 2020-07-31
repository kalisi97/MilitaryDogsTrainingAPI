using Microsoft.EntityFrameworkCore;
using MilitaryDogsTrainingAPI.Data;
using MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter);
        }

        public virtual T GetBy(Expression<Func<T, bool>> filter)
        {
            
            return context.Set<T>().FirstOrDefault(filter);
        }

        public virtual T GetById(params int[] id)
        {  
           return context.Set<T>().Find(id.ElementAt(0));
        }

        public virtual void Insert(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public virtual IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public virtual void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}
