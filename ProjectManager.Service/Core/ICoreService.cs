using ProjectManager.Contract.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Service.Core
{
    public interface ICoreService
    {
        List<ProjectContract> GetProject();
    }
}
