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

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        T GetById(int id);

        T Get(Func<T, bool> criteria);

        IQueryable<T> QueryData(Expression<Func<T, bool>> criteria = null);
    }
}
