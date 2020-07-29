using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.DataAccessLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(params int[] id);
        T GetBy(Expression<Func<T, bool>> filter);
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
    }
}
