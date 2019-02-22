using ProjectManager.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ProjectManager.Repository.Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DbContext _context;
        internal IDbSet<T> _entity;

        public Repository(DbContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public void Delete(int id)
        {
            this.Delete(GetById(id));
        }

        public virtual void Delete(T entity)
        {
            if(entity != null)
            {
                if(_context.Entry(entity).State == EntityState.Detached)
                {
                    _entity.Attach(entity);
                }

                _entity.Remove(entity);
            }
        }

        public T Get(Func<T, bool> criteria)
        {
            return Enumerable.FirstOrDefault(_entity.Where(criteria));
        }

        public IEnumerable<T> GetAllData()
        {
            return Enumerable.ToList(_entity);
        }

        public IEnumerable<T> GetBasedOnCriteria(System.Linq.Expressions.Expression<Func<T, bool>> criteria = null)
        {
            return criteria == null ? GetAllData() : _entity.Where(criteria);
        }

        public T GetById(int id)
        {
            return _entity.Find(id);
        }

        public void Insert(T entity)
        {
            _entity.Add(entity);
        }

        public IQueryable<T> QueryData(Expression<Func<T, bool>> criteria = null)
        {
            return criteria == null ? Queryable.AsQueryable(_entity) : Queryable.AsQueryable(_entity.Where(criteria));
        }

        public void Update(T entity)
        {
            if (entity != null)
            {
                try
                {
                    _entity.Attach(entity);
                }
                catch (Exception)
                {

                    throw;
                }

                _context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
