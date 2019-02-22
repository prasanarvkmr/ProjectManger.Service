using ProjectManager.Model;
using ProjectManager.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjectManager.Repository.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectManagerEntities entities = new ProjectManagerEntities();
        public DbContext _context;
        public Dictionary<Type, object> _repos;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            if(_repos == null)
            {
                _repos = new Dictionary<Type, object>();
            }

            if(_repos.Keys.Contains(typeof(T)))
            {
                return _repos[typeof(T)] as IRepository<T>;
            }

            var repos = new Repository<T>(_context);
            _repos.Add(typeof(T), repos);
            return repos;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
