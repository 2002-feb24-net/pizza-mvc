using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restaurant.DataAccess.Model;
using Restaurant.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbRestaurantContext _context;

        protected readonly ILogger<TEntity> _logger;

        public Repository(DbRestaurantContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
       }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id, params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _context.Set<TEntity>().Include.Find(id); //return single object of class
            IEnumerable<TEntity> query = null;
                    

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
