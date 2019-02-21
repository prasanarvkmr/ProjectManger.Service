using ProjectManager.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repository.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<T> Repository<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
