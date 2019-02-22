using AutoMapper;
using ProjectManager.Contract.Project;
using ProjectManager.Repository.Core;
using ProjectManager.Service.Core;
using ProjectManager.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Service.Persistance
{
    public class CoreService : ICoreService
    {
        private readonly IUnitOfWork _unitWork;

        public CoreService(IUnitOfWork UnitWork)
        {
            _unitWork = UnitWork;                       
        }

        public List<ProjectContract> GetProject()
        {
            var repo = _unitWork.Repository<ProjectManager.Model.Project>();
            var data = repo.GetAllData();            
            return Mapper.Map<List<ProjectContract>>(data);
        }
    }
}
