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
        protected DbContext _context = new DbRestaurantContext();
/*        protected readonly ILogger<Repository> _logger;
*/
        public Repository()
        {
            _context = new DbRestaurantContext();
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
       }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeName) // only include one navigational property
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeName}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond) //  include two navigational properties
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, string includeNameFirst, string includeNameSecond, string includeNameThird) //  include three navigational properties
        {
            return _context.Set<TEntity>().Where(predicate).Include($"{includeNameFirst}").Include($"{includeNameSecond}").Include($"{includeNameThird}");
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id); //return single object of class
        }

        


        /* public IEnumerable<TEntity> Include(TEntity predicate)
         {
             return _context.Set<TEntity>().Include("predicate");
         }*/

        /* public object Include(Func<object, object> p)
         {
             return _context.Set<TEntity>().Include(p => p.);
         }*/

        /*public IQueryable<T> Include<T>(params Expression<Func<T, object>>[] includes)
    where T : class
        {
            if (includes != null)
            {
                _context = includes.Aggregate(_context,
                          (current, include) => current.Include(include));
            }

            return _context;
        }*/


        /* public IEnumerable<TEntity> Include(Expression<Func<TEntity>> predicate1, Expression<Func<TEntity>> predicate2)
         {
             return _context.Set<TEntity>().Include(predicate1).Include(predicate2);
         }*/





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

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Find(predicate);
            if (entity == null)
            {
                return false;
            }
            else
                return true;    // there is something
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
