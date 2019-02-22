using ProjectManager.Contract.Project;
using ProjectManager.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProjectManger.Service.Api.Controllers
{
    public class ProjectManagerController : ApiController
    {
        public ICoreService _service;

        public ProjectManagerController(ICoreService service)
        {
            _service = service;
        }

        [Route("api/projects")]
        public List<ProjectContract> GetProjects()
        {
            var name = HttpContext.Current.User.Identity.Name;
            string currUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString();
            return _service.GetProject();
        }
    }
}
