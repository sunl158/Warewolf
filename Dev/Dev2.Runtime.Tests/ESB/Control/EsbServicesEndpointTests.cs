﻿using System;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.Monitoring;
using Dev2.Communication;
using Dev2.Data.ServiceModel;
using Dev2.Data.TO;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Interfaces;
using Dev2.PerformanceCounters.Counters;
using Dev2.Runtime.ESB.Control;
using Dev2.Runtime.ESB.Execution;
using Dev2.Runtime.Interfaces;
using Dev2.Workspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Warewolf.Resource.Errors;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;



namespace Dev2.Tests.Runtime.ESB.Control
{
    [TestClass]
    [TestCategory("Runtime ESB")]
    public class EsbServicesEndpointTests
    {
        [ClassInitialize]
        public static void Init(TestContext context)
        {
            var pCounter = new Mock<IWarewolfPerformanceCounterLocater>();
            pCounter.Setup(locater => locater.GetCounter(It.IsAny<Guid>(), It.IsAny<WarewolfPerfCounterType>())).Returns(new EmptyCounter());
            pCounter.Setup(locater => locater.GetCounter(It.IsAny<WarewolfPerfCounterType>())).Returns(new EmptyCounter());
            pCounter.Setup(locater => locater.GetCounter(It.IsAny<string>())).Returns(new EmptyCounter());
            CustomContainer.Register(pCounter.Object);
            CustomContainer.Register<IActivityParser>(new Dev2.Activities.ActivityParser());
        }

        [TestMethod]
        [Owner("Rory McGuire")]
        public void EsbServicesEndpoint_ExecuteWorkflow_GivenHelloWorldWorkflow_RunWorkflowAsyncFalse_ExpectSuccess()
        {
            var esbServicesEndpoint = new EsbServicesEndpoint();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(o => o.Identity).Returns(WindowsIdentity.GetCurrent());

            var dataObject = new DsfDataObject("", Guid.NewGuid())
            {
                ResourceID = Guid.Parse("acb75027-ddeb-47d7-814e-a54c37247ec1"),
                ExecutingUser = mockPrincipal.Object,
                IsDebug = true,
                RunWorkflowAsync = false,
            };
            dataObject.Environment.Assign("[[Name]]", "somename", 0);

            var request = new EsbExecuteRequest();
            var workspaceId = Guid.NewGuid();
            var errors = new ErrorResultTO();

            var result = esbServicesEndpoint.ExecuteRequest(dataObject, request, workspaceId, out errors);

            var expectedJson = "{\"Environment\":{\"scalars\":{\"Message\":\"Hello somename.\",\"Name\":\"somename\"},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[\"\"],\"AllErrors\":[]}";
            Assert.AreEqual("Hello somename.", dataObject.Environment.EvalAsListOfStrings("[[Message]]", 0)[0]);
            Assert.AreEqual(expectedJson, dataObject.Environment.ToJson());
        }
        

        [TestMethod]
        [Owner("Rory McGuire")]
        public void EsbServicesEndpoint_ExecuteWorkflow_GivenHelloWorldWorkflow_RunWorkflowAsync_ExpectSuccess()
        {
            var esbServicesEndpoint = new EsbServicesEndpoint();

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(o => o.Identity).Returns(WindowsIdentity.GetCurrent());

            var dataObject = new DsfDataObject("", Guid.NewGuid())
            {
                ResourceID = Guid.Parse("2311e5fb-3eaa-4986-b946-5a687f33fd51"),
                ExecutingUser = mockPrincipal.Object,
                IsDebug = true,
                RunWorkflowAsync = true,
            };
            dataObject.Environment.Assign("[[Name]]", "somename", 0);

            var request = new EsbExecuteRequest();
            var workspaceId = Guid.NewGuid();
            var errors = new ErrorResultTO();

            var result = esbServicesEndpoint.ExecuteRequest(dataObject, request, workspaceId, out errors);

            var expectedJson = "{\"Environment\":{\"scalars\":{\"Name\":\"somename\",\"output\":\"this is nested\"},\"record_sets\":{},\"json_objects\":{}},\"Errors\":[\"\"],\"AllErrors\":[]}";
            Assert.AreEqual("this is nested", dataObject.Environment.EvalAsListOfStrings("[[output]]", 0)[0]);
            Assert.AreEqual(expectedJson, dataObject.Environment.ToJson());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void EsbServicesEndpoint_CreateNewEnvironmentFromInputMappings_GivenInputsDefs_ShouldCreateNewEnvWithMappings()
        {
            //---------------Set up test pack-------------------
            var dataObj = new Mock<IDSFDataObject>();
            dataObj.SetupAllProperties();
            IExecutionEnvironment executionEnvironment = new ExecutionEnvironment();
            dataObj.Setup(o => o.Environment).Returns(executionEnvironment).Verifiable();
            dataObj.Setup(o => o.PushEnvironment(It.IsAny<IExecutionEnvironment>())).Verifiable();
            const string inputMappings = @"<Inputs><Input Name=""f1"" Source=""[[recset1(*).f1a]]"" Recordset=""recset1"" /><Input Name=""f2"" Source=""[[recset2(*).f2a]]"" Recordset=""recset2"" /></Inputs>";
            var esbServicesEndpoint = new EsbServicesEndpoint();
            //---------------Assert Precondition----------------
            //---------------Execute Test ----------------------
            esbServicesEndpoint.CreateNewEnvironmentFromInputMappings(dataObj.Object, inputMappings, 0);
            //---------------Test Result -----------------------
            dataObj.Verify(o => o.PushEnvironment(It.IsAny<IExecutionEnvironment>()), Times.Once);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void EsbServicesEndpoint_ExecuteSubRequest_GivenValidArgs_ShouldCheckIsRemoteWorkflow()
        {
            //---------------Set up test pack-------------------
            var dataObj = new Mock<IDSFDataObject>();
            var rCat = new Mock<IResourceCatalog>();
            var mock = new Mock<IResource>();
            rCat.Setup(catalog => catalog.GetResource(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mock.Object);
            var workRepo = new Mock<IWorkspaceRepository>();
            workRepo.Setup(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(new Workspace(Guid.NewGuid()));
            dataObj.SetupAllProperties();
            dataObj.Setup(o => o.Environment).Returns(new ExecutionEnvironment());
            dataObj.Setup(o => o.IsRemoteWorkflow());
            dataObj.Setup(o => o.ServiceName).Returns("SomeName");
            var esbServicesEndpoint = new EsbServicesEndpoint();
            //---------------Assert Precondition----------------
            Assert.IsNotNull(esbServicesEndpoint);
            //---------------Execute Test ----------------------
            esbServicesEndpoint.ExecuteSubRequest(dataObj.Object, Guid.NewGuid(), "", "", out ErrorResultTO err, 1, true);

            //---------------Test Result -----------------------
            dataObj.Verify(o => o.IsRemoteWorkflow(), Times.Once);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void EsbServicesEndpoint_ExecuteSubRequest_GivenExecuteWorkflowAsync_ShouldCheckIsRemoteWorkflow()
        {
            //---------------Set up test pack-------------------
            var dataObj = new Mock<IDSFDataObject>();
            var dataObjClon = new Mock<IDSFDataObject>();
            dataObjClon.Setup(o => o.ServiceName).Returns("Service Name");
            var rCat = new Mock<IResourceCatalog>();
            var mock = new Mock<IResource>();
            rCat.Setup(catalog => catalog.GetResource(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(mock.Object);
            var workRepo = new Mock<IWorkspaceRepository>();
            workRepo.Setup(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(new Workspace(Guid.NewGuid()));
            dataObj.SetupAllProperties();
            dataObj.Setup(o => o.Environment).Returns(new ExecutionEnvironment());
            dataObj.Setup(o => o.IsRemoteWorkflow());
            dataObj.Setup(o => o.RunWorkflowAsync).Returns(true);
            dataObj.Setup(o => o.Clone()).Returns(dataObjClon.Object);
            var mapManager = new Mock<IEnvironmentOutputMappingManager>();
            var esbServicesEndpoint = new EsbServicesEndpoint();
            //---------------Assert Precondition----------------
            Assert.IsNotNull(esbServicesEndpoint);
            //---------------Execute Test ----------------------

            esbServicesEndpoint.ExecuteSubRequest(dataObj.Object, Guid.NewGuid(), "", "", out ErrorResultTO err, 1, true);

            //---------------Test Result -----------------------
            dataObj.Verify(o => o.IsRemoteWorkflow(), Times.Once);
            var contains = err.FetchErrors().Contains(ErrorResource.ResourceNotFound);
            Assert.IsTrue(contains);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void EsbServicesEndpoint_ExecuteLogErrorRequest_GivenCorrectUri_ShouldNoThrowException()
        {
            //---------------Set up test pack-------------------
            var dataObj = new Mock<IDSFDataObject>();
            var rCat = new Mock<IResourceCatalog>();
            rCat.Setup(catalog => catalog.GetResource(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            var workRepo = new Mock<IWorkspaceRepository>();
            workRepo.Setup(repository => repository.Get(It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<bool>())).Returns(new Workspace(Guid.NewGuid()));
            dataObj.SetupAllProperties();
            dataObj.Setup(o => o.Environment).Returns(new ExecutionEnvironment());

            var mapManager = new Mock<IEnvironmentOutputMappingManager>();
            var esbServicesEndpoint = new EsbServicesEndpoint();
            //---------------Assert Precondition----------------
            Assert.IsNotNull(esbServicesEndpoint);
            //---------------Execute Test ----------------------
            try
            {
                esbServicesEndpoint.ExecuteLogErrorRequest(dataObj.Object, It.IsAny<Guid>(), "http://example.com/", out ErrorResultTO err, 1);
            }
            catch (Exception ex)
            {
                //---------------Test Result -----------------------
                Assert.Fail(ex.Message);
            }
        }


    }
}
