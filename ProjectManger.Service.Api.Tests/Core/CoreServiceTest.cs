using System;
using NUnit.Framework;
using Moq;
using ProjectManager.Repository.Core;
using ProjectManager.Service.Persistance;
using ProjectManager.Model;
using System.Collections.Generic;
using ProjectManager.Contract.Task;
using ProjectManager.Service.Mapping;
using AutoMapper;
using ProjectManager.Contract.Project;
using ProjectManager.Contract.User;

namespace ProjectManger.Service.Api.Tests.Core
{
    [TestFixture]
    public class CoreServiceTest
    {
        public CoreService Service { get; set; }

        public Mock<IUnitOfWork> UnitofWork { get; set; }

        public Mock<IRepository<Project>> ProjectRepo { get; set; }

        public  MappingProfile Mapping { get; set; }

        public static object thisLock = new object();
        // Centralize automapper initialize
        public static void Initialize()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (thisLock)
            {
                Mapper.Reset();
                Mapper.Initialize(cfg => { cfg.AddProfile<MappingProfile>(); });
            }
        }

        [SetUp]
        public void Setup()
        {
            UnitofWork = new Mock<IUnitOfWork>();
            Service = new CoreService(UnitofWork.Object);
            ProjectRepo = new Mock<IRepository<Project>>();
            Initialize();

            UnitofWork.Setup(x => x.Repository<Project>().Get(It.IsAny<Func<Project, bool>>())).Returns(new Project());
            UnitofWork.Setup(x => x.Repository<Project>().Get(It.IsAny<Func<Project, bool>>())).Returns(new Project());
        }

        [Test]
        public void GetAllDataTest()
        {
            UnitofWork.Setup(x => x.Repository<Project>().GetAllData()).Returns(new List<Project> { new Project { Id = 1 } });
            var result = Service.GetProject();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count == 1);
        }

        [Test]
        public void GetUser()
        {
            UnitofWork.Setup(x => x.Repository<User>().GetAllData()).Returns(new List<User> { new User { Id = 1 } });
            var result = Service.GetUsers();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count == 1);
        }

        [Test]
        public void GetTask()
        {
            UnitofWork.Setup(x => x.Repository<Task>().GetAllData()).Returns(new List<Task> { new Task { Id = 1 } });
            var result = Service.GetTasks();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Count == 1);
        }

        [Test]
        public void AddTask()
        {
            UnitofWork.Setup(x => x.Repository<Task>().Insert(It.IsAny<Task>()));
            var result = Service.AddTask(new TaskContract());
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddProject()
        {
            UnitofWork.Setup(x => x.Repository<Project>().Insert(It.IsAny<Project>()));
            UnitofWork.Setup(x => x.Repository<User>().Insert(It.IsAny<User>()));
            var result = Service.AddProject(new ProjectContract { Manager = new UserContract { } });
            Assert.IsNotNull(result);
        }

        [Test]
        public void AddUser()
        {
            UnitofWork.Setup(x => x.Repository<User>().Insert(It.IsAny<User>()));
            var result = Service.AddUser(new UserContract());
            Assert.IsNotNull(result);
        }
    }
}
