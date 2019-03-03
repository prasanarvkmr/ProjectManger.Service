using ProjectManager.Contract.Project;
using ProjectManager.Contract.Task;
using ProjectManager.Contract.User;
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
    [AllowAnonymous]
    public class ProjectManagerController : ApiController
    {
        public ICoreService _service;

        public ProjectManagerController(ICoreService service)
        {
            _service = service;
        }

        [Route("api/projects")]
        [HttpGet]
        public HttpResponseMessage GetProjects()
        {            
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetProject());
        }

        [Route("api/projects/{criteria}")]
        [HttpGet]
        public HttpResponseMessage GetProjects(string criteria)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetProject(criteria));
        }

        [Route("api/projects-id/{projectid}")]
        [HttpGet]
        public HttpResponseMessage GetTasks(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetProject(projectId));
        }

        [Route("api/projects")]
        [HttpPost]
        public HttpResponseMessage AddProject([FromBody]ProjectContract data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.AddProject(data));
        }

        [Route("api/projects/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteProject(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.DeleteProject(id));
        }

        [Route("api/tasks")]
        [HttpGet]
        public HttpResponseMessage GetTasks()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetTasks());            
        }

        [Route("api/parenttasks")]
        [HttpGet]
        public HttpResponseMessage GetParentTasks()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetParentTasks());
        }

        [Route("api/tasks")]
        [HttpPost]
        public HttpResponseMessage AddTasks([FromBody]TaskContract data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.AddTask(data));
        }

        [Route("api/tasks")]
        [HttpPut]
        public HttpResponseMessage UpdateTasks([FromBody]TaskContract data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.AddTask(data));
        }

        [Route("api/tasks/{projectid}")]
        [HttpGet]
        public HttpResponseMessage GetProjectTasks(int projectId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetTasks(projectId));
        }

        [Route("api/task/{id}")]
        [HttpGet]
        public HttpResponseMessage GetTask(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetTask(id));
        }

        [Route("api/delete-task/{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.DeleteTask(id));
        }

        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetUsers());            
        }

        [Route("api/users/{criteria}")]
        [HttpGet]
        public HttpResponseMessage GetUsers(string criteria)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.GetUsers(criteria));
        }

        [Route("api/users")]
        [HttpPost]
        public HttpResponseMessage AddUser([FromBody] UserContract data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.AddUser(data));
        }

        [Route("api/users")]
        [HttpPut]
        public HttpResponseMessage UpdateUser([FromBody] UserContract data)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.AddUser(data));
        }

        [Route("api/users/{id}")]
        [HttpDelete]
        public HttpResponseMessage RemoveUser(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _service.DeleteUser(id));
        }
    }
}
