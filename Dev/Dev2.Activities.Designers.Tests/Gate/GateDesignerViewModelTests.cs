﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Activities.Designers2.Gate;
using Dev2.Studio.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Warewolf.Options;

namespace Dev2.Activities.Designers.Tests.Gate
{
    [TestClass]
    public class GateDesignerViewModelTests
    {
        [TestInitialize]
        public void SetupForTest()
        {
            var optionBool = new OptionBool();
            var optionsList = new List<IOption> { optionBool };

            var mockServer = new Mock<IServer>();

            var mockResourceRepository = new Mock<IResourceRepository>();
            mockResourceRepository.Setup(resourceRepository => resourceRepository.FindOptionsBy(mockServer.Object, "")).Returns(optionsList);

            mockServer.Setup(server => server.ResourceRepository).Returns(mockResourceRepository.Object);

            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(shellViewModel => shellViewModel.ActiveServer).Returns(mockServer.Object);

            CustomContainer.Register(mockShellViewModel.Object);
        }

        private Mock<ModelProperty> CreateModelProperty(string name, object value)
        {
            var prop = new Mock<ModelProperty>();
            prop.Setup(p => p.Name).Returns(name);
            prop.Setup(p => p.ComputedValue).Returns(value);
            return prop;
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_Constructor()
        {
            //------------Setup for test--------------------------
            var gateFailureProperty = CreateModelProperty("GateFailure", null);
            var gateOptionsProperty = CreateModelProperty("GateOptions", null).Object;
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty).Object;

            var mockProperties = new Mock<ModelPropertyCollection>();
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty);
            mockProperties.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockProperties.Object);
            var expectedGateFailure = "StopOnError: Stop execution on error";
            //------------Execute Test----------------------------
            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object);
            //------------Assert Results-------------------------
            Assert.IsTrue(gateDesignerViewModel.HasLargeView);
            Assert.AreEqual(expectedGateFailure, gateDesignerViewModel.SelectedGateFailure);
            Assert.IsTrue(gateDesignerViewModel.Enabled);
            Assert.IsTrue(gateDesignerViewModel.ShowLarge);
            Assert.AreEqual(Visibility.Visible, gateDesignerViewModel.ThumbVisibility);
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_GateFailureOptions_Retry()
        {
            //------------Setup for test--------------------------
            var gateFailureProperty = CreateModelProperty("GateFailure", null);
            var gateOptionsProperty = CreateModelProperty("GateOptions", null).Object;
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty).Object;

            var mockProperties = new Mock<ModelPropertyCollection>();
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty);
            mockProperties.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockProperties.Object);
            CustomContainer.Register(mockModelItem.Object);
            //------------Execute Test---------------------------
            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object)
            {
                SelectedGateFailure = "Retry: Retry execution on error"
            };
            //------------Assert Results-------------------------
            Assert.AreEqual("Retry: Retry execution on error", gateDesignerViewModel.SelectedGateFailure);
            Assert.IsTrue(gateDesignerViewModel.Enabled);
            gateFailureProperty.Verify(prop => prop.SetValue("StopOnError"), Times.Exactly(1));
            gateFailureProperty.Verify(prop => prop.SetValue("Retry"), Times.Exactly(1));
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_GateFailureOptions_StopOnError()
        {
            //------------Setup for test--------------------------
            var gateFailureProperty = CreateModelProperty("GateFailure", "Retry");
            var gateOptionsProperty = CreateModelProperty("GateOptions", null).Object;
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty).Object;

            var mockProperties = new Mock<ModelPropertyCollection>();
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty);
            mockProperties.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockProperties.Object);
            CustomContainer.Register(mockModelItem.Object);
            //------------Execute Test---------------------------
            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object)
            {
                SelectedGateFailure = "StopOnError: Stop execution on error"
            };
            //------------Assert Results-------------------------
            Assert.AreEqual("StopOnError: Stop execution on error", gateDesignerViewModel.SelectedGateFailure);
            Assert.IsTrue(gateDesignerViewModel.Enabled);
            gateFailureProperty.Verify(prop => prop.SetValue("Retry"), Times.Exactly(1));
            gateFailureProperty.Verify(prop => prop.SetValue("StopOnError"), Times.Exactly(1));
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_GateFailureOptions_List()
        {
            //------------Setup for test--------------------------
            var gateFailureProperty = CreateModelProperty("GateFailure", null);
            var gateOptionsProperty = CreateModelProperty("GateOptions", null).Object;
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty).Object;

            var mockProperties = new Mock<ModelPropertyCollection>();
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockProperties.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty);
            mockProperties.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockProperties.Object);
            //------------Execute Test---------------------------
            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object);
            var gateFailureOptions = gateDesignerViewModel.GateFailureOptions.ToList();
            //------------Assert Results-------------------------
            Assert.AreEqual(2, gateFailureOptions.Count);
            Assert.AreEqual("Retry: Retry execution on error", gateFailureOptions[0]);
            Assert.AreEqual("StopOnError: Stop execution on error", gateFailureOptions[1]);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_GatesView()
        {
            var expected = string.Empty;
            var uniqueId = Guid.NewGuid().ToString();
            var activityName = "testActivity";
            var gates = new List<(string uniqueId, string activityName)>
            {
                (uniqueId, activityName)
            };

            var mockWorkflowDesignerViewModel = new Mock<IWorkflowDesignerViewModel>();
            mockWorkflowDesignerViewModel.Setup(workflowDesigner => workflowDesigner.GetGates(uniqueId)).Returns(gates);

            var mockModelProperty = new Mock<ModelProperty>();
            mockModelProperty.Setup(p => p.SetValue(expected)).Verifiable();
            var properties = new Dictionary<string, Mock<ModelProperty>>
            {
                { uniqueId, mockModelProperty }
            };

            var gateFailureProperty = CreateModelProperty("GateFailure", null);
            var gateOptionsProperty = CreateModelProperty("GateOptions", null).Object;
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty).Object;

            var mockPropertyCollection = new Mock<ModelPropertyCollection>();
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", uniqueId, true).Returns(mockModelProperty.Object);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockPropertyCollection.Object);

            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object);

            Assert.AreEqual(0, gateDesignerViewModel.Gates.Count);
            Assert.AreEqual(0, gateDesignerViewModel.GatesView.Count);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(GateDesignerViewModel))]
        public void GateDesignerViewModel_Gates_SelectedGate()
        {
            var expected = string.Empty;
            var uniqueId = Guid.NewGuid().ToString();
            var activityName = "testActivity";
            var gates = new List<(string uniqueId, string activityName)>
            {
                (uniqueId, activityName)
            };

            var mockModelProperty = new Mock<ModelProperty>();
            mockModelProperty.Setup(p => p.SetValue(expected)).Verifiable();
            var properties = new Dictionary<string, Mock<ModelProperty>>
            {
                { uniqueId, mockModelProperty }
            };

            var gateFailureProperty = CreateModelProperty("GateFailure", null);
            var gateOptionsProperty = CreateModelProperty("GateOptions", null);
            var retryEntryPointIdProperty = CreateModelProperty("RetryEntryPointId", Guid.Empty);

            var mockPropertyCollection = new Mock<ModelPropertyCollection>();
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", uniqueId, true).Returns(mockModelProperty.Object);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "GateFailure", true).Returns(gateFailureProperty.Object);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "GateOptions", true).Returns(gateOptionsProperty.Object);
            mockPropertyCollection.Protected().Setup<ModelProperty>("Find", "RetryEntryPointId", true).Returns(retryEntryPointIdProperty.Object);

            var mockModelItem = new Mock<ModelItem>();
            mockModelItem.Setup(modelItem => modelItem.Properties).Returns(mockPropertyCollection.Object);

            var gateDesignerViewModel = new GateDesignerViewModel(mockModelItem.Object);

            Assert.AreEqual(0, gateDesignerViewModel.Gates.Count);
            Assert.AreEqual(0, gateDesignerViewModel.GatesView.Count);

            gateDesignerViewModel.Gates = gates;

            Assert.AreEqual(1, gateDesignerViewModel.Gates.Count);
            Assert.AreEqual(1, gateDesignerViewModel.GatesView.Count);

            Assert.AreEqual(uniqueId, gateDesignerViewModel.Gates[0].uniqueId);
            Assert.AreEqual(activityName, gateDesignerViewModel.Gates[0].activityName);
            
            Assert.AreEqual(activityName, gateDesignerViewModel.GatesView[0]);

            gateDesignerViewModel.SelectedGate = gateDesignerViewModel.GatesView[0];

            Assert.AreEqual(activityName, gateDesignerViewModel.SelectedGate);

            retryEntryPointIdProperty.Verify(prop => prop.SetValue(Guid.Parse(uniqueId)), Times.Exactly(1));
        }
    }
}
