using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository.Core
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAllData();

        IEnumerable<T> GetBasedOnCriteria(Expression<Func<T, bool>> where = null);

        T Insert(T entity);

        T Update(T entity);

        bool Delete(int id);
    }
}
