﻿using Dev2.Common;
using Dev2.Common.Interfaces.Monitoring;
using Dev2.PerformanceCounters.Counters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Dev2.Infrastructure.Tests.PerformanceCounters
{
    [TestClass]
    public class WarewolfRequestsPerSecondPerformanceCounterTests
    {
        const string CounterName = "Request Per Second";

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_Construct()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            using (IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory))
            {

                Assert.IsTrue(counter.IsActive);
                Assert.AreEqual(WarewolfPerfCounterType.RequestsPerSecond, counter.PerfCounterType);
                Assert.AreEqual(GlobalConstants.Warewolf, counter.Category);
                Assert.AreEqual(CounterName, counter.Name);
            }
        }

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_CreationData_Valid()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory);

            var data = counter.CreationData();
            Assert.AreEqual(1, data.Count());

            var dataItem = counter.CreationData().First();
            Assert.AreEqual(CounterName, dataItem.CounterHelp);
            Assert.AreEqual(CounterName, dataItem.CounterName);
            Assert.AreEqual(PerformanceCounterType.RateOfCountsPerSecond32, dataItem.CounterType);
        }


        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_Reset_ClearsCounter()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var mockCounter = new Mock<IWarewolfPerformanceCounter>();
            mockPerformanceCounterFactory.Setup(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName)).Returns(mockCounter.Object).Verifiable();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory);
            counter.Setup();
            counter.Reset();

            mockPerformanceCounterFactory.Verify();
            mockCounter.VerifySet(o => o.RawValue = 0, Times.Once);
        }

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_Increment_CallsUnderlyingCounter()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var mockCounter = new Mock<IWarewolfPerformanceCounter>();
            mockPerformanceCounterFactory.Setup(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName)).Returns(mockCounter.Object).Verifiable();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory);
            counter.Setup();
            counter.Increment();

            mockPerformanceCounterFactory.Verify();
            mockCounter.Verify(o => o.Increment(), Times.Once);
        }

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_IncrementBy_CallsUnderlyingCounter()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var mockCounter = new Mock<IWarewolfPerformanceCounter>();
            mockPerformanceCounterFactory.Setup(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName)).Returns(mockCounter.Object).Verifiable();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory);
            counter.Setup();
            counter.IncrementBy(1234);

            mockPerformanceCounterFactory.Verify();
            mockCounter.Verify(o => o.IncrementBy(1234), Times.Once);
        }

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_Setup_CreatesCounter()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var mockCounter = new Mock<IWarewolfPerformanceCounter>();
            mockPerformanceCounterFactory.Setup(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName)).Returns(mockCounter.Object);
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory);
            counter.Setup();

            mockPerformanceCounterFactory.Verify(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName), Times.Once);
        }

        [TestMethod]
        public void WarewolfRequestsPerSecondPerformanceCounter_Decrement_CallsUnderlyingCounter()
        {
            var mockPerformanceCounterFactory = new Mock<IRealPerformanceCounterFactory>();
            var mockCounter = new Mock<IWarewolfPerformanceCounter>();
            mockCounter.SetupGet(o => o.RawValue).Returns(1);
            mockPerformanceCounterFactory.Setup(o => o.New(GlobalConstants.Warewolf, CounterName, GlobalConstants.GlobalCounterName)).Returns(mockCounter.Object).Verifiable();
            var performanceCounterFactory = mockPerformanceCounterFactory.Object;
            using (IPerformanceCounter counter = new WarewolfRequestsPerSecondPerformanceCounter(performanceCounterFactory))
            {
                counter.Setup();
                counter.Decrement();

                mockPerformanceCounterFactory.Verify();
                mockCounter.Verify(o => o.Decrement(), Times.Once);
            }
        }
    }
}
