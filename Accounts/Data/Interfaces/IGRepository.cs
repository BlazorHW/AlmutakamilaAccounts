﻿using System.Linq.Expressions;

namespace Accounts.Data.Interfaces
{
    public interface IGRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool Tracking = false);
        Task<T> GetByIdAsync(Object id);// go db missions as async "t"
        void Insert(T entity);
        void Update(T entity);
        void Delete(Object entity);
        void RemoveRange(ICollection<T> entities);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool Tracking = true); // هي لينك 
       
    }
}
