using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Service.Core;
using Moq;
using ProjectManager.Contract.Project;
using ProjectManger.Service.Api.Controllers;
using ProjectManager.Service.Persistance;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Contract.User;
using ProjectManager.Contract.Task;

namespace ProjectManger.Service.Api.Tests.Controllers
{
    [TestFixture]
    public class ProjectManagerControllerTest
    {
        public Mock<ICoreService> Service { get; set; }

        public ProjectManagerController Controller { get; set; }

        [SetUp]
        public void Setup()
        {
            Service = new Mock<ICoreService>();
            Controller = new ProjectManagerController(Service.Object);
            Controller.Request = new HttpRequestMessage();
            Controller.Request.SetConfiguration(new HttpConfiguration());

            Service.Setup(x => x.AddProject(It.IsAny<ProjectContract>())).Returns("Success");
            Service.Setup(x => x.AddTask(It.IsAny<TaskContract>())).Returns("Success");
            Service.Setup(x => x.AddUser(It.IsAny<UserContract>())).Returns("Success");

            Service.Setup(x => x.GetUsers()).Returns(new List<UserContract>());
            Service.Setup(x => x.GetProject()).Returns(new List<ProjectContract>());
            Service.Setup(x => x.GetTasks()).Returns(new List<TaskContract>());
        }

        [Test]
        public void AddProjectTest()
        {
            var result = this.Controller.AddProject(new ProjectContract());
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddUserTest()
        {
            var result = this.Controller.AddUser(new UserContract());
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddTasksTest()
        {
            var result = this.Controller.AddTasks(new TaskContract());
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetUserTest()
        {
            var result = this.Controller.GetUsers();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTaskTest()
        {
            var result = this.Controller.GetTasks();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetProjectTest()
        {
            var result = this.Controller.GetProjects();
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetProjectCriteriaTest()
        {
            Service.Setup(x => x.GetProject(It.IsAny<string>())).Returns(new List<ProjectContract>());
            var result = this.Controller.GetProjects("");
            Assert.IsNotNull(result);
        }

        [Test]
        public void RemoveUserTest()
        {
            Service.Setup(x => x.DeleteUser(It.IsAny<int>())).Returns(true);
            var result = this.Controller.RemoveUser(1);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GetTasksTest()
        {
            Service.Setup(x => x.GetTasks()).Returns(new List<TaskContract>());
            var result = this.Controller.GetTasks();
            Assert.IsNotNull(result);
        }

        //DeleteProject
        [Test]
        public void RemoveProjectTest()
        {
            Service.Setup(x => x.DeleteProject(It.IsAny<int>())).Returns(true);
            var result = this.Controller.DeleteProject(1);
            Assert.IsNotNull(result);
        }

        //GetParentTasks
        [Test]
        public void GetParentTasksTest()
        {
            Service.Setup(x => x.GetParentTasks()).Returns(new List<ParentTaskContract>());
            var result = this.Controller.GetParentTasks();
            Assert.IsNotNull(result);
        }

        //UpdateTasks
        [Test]
        public void UpdateTaskTests()
        {
            Service.Setup(x => x.AddTask(It.IsAny<TaskContract>()));
            var result = this.Controller.UpdateTasks(new TaskContract { Id = 1 });
            Assert.IsNotNull(result);
        }

        //GetProjectTasks
        [Test]
        public void GetProjectTasksTest()
        {
            Service.Setup(x => x.GetTasks(It.IsAny<int>())).Returns(new List<TaskContract>());
            var result = this.Controller.GetTasks(1);
            Assert.IsNotNull(result);
        }

        //GetTask
        [Test]
        public void GetTaskssTest()
        {
            Service.Setup(x => x.GetTask(It.IsAny<int>())).Returns(new TaskContract());
            var result = this.Controller.GetTask(1);
            Assert.IsNotNull(result);
        }

        //DeleteTask
        [Test]
        public void DeleteTaskTest()
        {
            Service.Setup(x => x.DeleteTask(It.IsAny<int>())).Returns(true);
            var result = this.Controller.DeleteTask(1);
            Assert.IsNotNull(result);
        }

        //GetUsers
        [Test]
        public void GetUsersTest()
        {
            Service.Setup(x => x.GetUsers()).Returns(new List<UserContract>());
            var result = this.Controller.GetUsers();
            Assert.IsNotNull(result);
        }
    }
}
