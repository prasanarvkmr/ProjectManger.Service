using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NBench;
using ProjectManager.Service.Core;
using ProjectManger.Service.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectManger.Service.Api.Tests.Performance
{
    //[TestClass]
    public class PerformanceTest
    {
        private Counter _counter;

        public Mock<ICoreService> Service { get; set; }

        public ProjectManagerController Controller { get; set; }

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            _counter = context.GetCounter("TestCounter");
            Service = new Mock<ICoreService>();
            Controller = new ProjectManagerController(Service.Object)
            {
                Request = new HttpRequestMessage()
            };
            Controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestInitialize]
        public void Setup()
        {
            Service = new Mock<ICoreService>();
            Controller = new ProjectManagerController(Service.Object);
        }

        [TestMethod()]
        [PerfBenchmark(NumberOfIterations = 10, RunMode = RunMode.Throughput,
            RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 1000)]
        [CounterTotalAssertion("TestCounter", MustBe.GreaterThan, 1000)]
        [CounterMeasurement("TestCounter")]
        public void GetParentTasksTest()
        {            
            _counter.Increment();
            var result = Controller.GetParentTasks();
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        [PerfBenchmark(NumberOfIterations = 10, RunMode = RunMode.Throughput,
           RunTimeMilliseconds = 1000, TestMode = TestMode.Test)]
        [CounterThroughputAssertion("TestCounter", MustBe.GreaterThan, 500)]
        [CounterTotalAssertion("TestCounter", MustBe.GreaterThan, 500)]
        [CounterMeasurement("TestCounter")]
        public void GetTaskControllerTest()
        {            
            _counter.Increment();
            var result = Controller.GetUsers();
            Assert.IsNotNull(result);
        }


        [PerfCleanup]
        public void Cleanup()
        {
            // does nothing
        }
    }
}
