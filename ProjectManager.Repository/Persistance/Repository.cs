using ProjectManager.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository.Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllData()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetBasedOnCriteria(System.Linq.Expressions.Expression<Func<T, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        public T Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
