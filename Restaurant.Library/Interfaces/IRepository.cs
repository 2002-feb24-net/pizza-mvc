using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Restaurant.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class // generic
    {
        //finding objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        //adding objects
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        //removing objects
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
