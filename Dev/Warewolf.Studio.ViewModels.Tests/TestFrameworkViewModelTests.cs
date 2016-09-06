﻿using System;
using System.Collections.Generic;
using Dev2.Studio.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
// ReSharper disable ObjectCreationAsStatement

// ReSharper disable InconsistentNaming

namespace Warewolf.Studio.ViewModels.Tests
{
    [TestClass]
    public class TestFrameworkViewModelTests
    {
        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestFrameworkViewModel_Constructor_NullResourceModel_ShouldThrowException()
        {
            //------------Setup for test--------------------------


            //------------Execute Test---------------------------
            new TestFrameworkViewModel(null);
            //------------Assert Results-------------------------
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_Constructor")]
        public void TestFrameworkViewModel_Constructor_NotNullResourceModel_ShouldSetResourceModel()
        {
            //------------Setup for test--------------------------


            //------------Execute Test---------------------------
            var testVM = new TestFrameworkViewModel(new Mock<IResourceModel>().Object);
            //------------Assert Results-------------------------
            Assert.IsNotNull(testVM);
            Assert.IsNotNull(testVM.ResourceModel);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveRenameCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.RenameCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.RenameCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveSaveCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.SaveCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.SaveCommand.CanExecute(null));
        }


        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveEnableTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.EnableTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.EnableTestCommand.CanExecute(null));
        }


        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveDisableTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.DisableTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.DisableTestCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveDeleteTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.DeleteTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.DeleteTestCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveDuplicateTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.DuplicateTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.DuplicateTestCommand.CanExecute(null));
        }


        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveStopTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.StopTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.StopTestCommand.CanExecute(null));
        }


        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveCreateTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.CreateTestCommand);
            //---------------Test Result -----------------------
            Assert.IsTrue(vm.TestFrameworkCommandHandler.CreateTestCommand.CanExecute(null));
        }
        private IResourceModel CreateResourceModel()
        {
            var moqModel = new Mock<IResourceModel>();
            return moqModel.Object;
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveModel()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.CreateTestCommand);
            //---------------Test Result -----------------------
            Assert.IsTrue(vm.TestFrameworkCommandHandler.CreateTestCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveRunAllTestsCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.RunAllTestsCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.RunAllTestsCommand.CanExecute(null));
        }


        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveRunSelectedTestCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.RunSelectedTestCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.RunSelectedTestCommand.CanExecute(null));
        }



        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveRunAllTestsInBrowserCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.RunAllTestsInBrowserCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.RunAllTestsInBrowserCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void OnCreation_GivenIsNew_ShouldHaveRunSelectedTestInBrowserCommand()
        {
            //---------------Set up test pack-------------------
            var vm = new TestFrameworkViewModel(CreateResourceModel());
            //---------------Assert Precondition----------------
            Assert.IsNotNull(vm);
            //---------------Execute Test ----------------------
            Assert.IsNotNull(vm.TestFrameworkCommandHandler.RunSelectedTestInBrowserCommand);
            //---------------Test Result -----------------------
            Assert.IsFalse(vm.TestFrameworkCommandHandler.RunSelectedTestInBrowserCommand.CanExecute(null));
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_CreateTestCommand")]
        public void TestFrameworkViewModel_CreateTestCommand_Execute_ShouldAddANewTest()
        {
            //------------Setup for test--------------------------
            var testFrameworkViewModel = new TestFrameworkViewModel(CreateResourceModel());
            //------------Assert Preconditions-------------------
            Assert.IsNull(testFrameworkViewModel.Tests);
            //------------Execute Test---------------------------
            testFrameworkViewModel.CreateTestCommand.Execute(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, testFrameworkViewModel.Tests.Count);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_CreateTestCommand")]
        public void TestFrameworkViewModel_CreateTestCommand_Execute_ShouldAddANewTestWithDefaultName()
        {
            //------------Setup for test--------------------------
            var testFrameworkViewModel = new TestFrameworkViewModel(CreateResourceModel());
            //------------Assert Preconditions-------------------
            Assert.IsNull(testFrameworkViewModel.Tests);
            //------------Execute Test---------------------------
            testFrameworkViewModel.CreateTestCommand.Execute(null);
            //------------Assert Results-------------------------
            var test = testFrameworkViewModel.Tests[0];
            Assert.IsNotNull(test);
            Assert.AreEqual("Test 1", test.Name);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_CreateTestCommand")]
        public void TestFrameworkViewModel_CreateTestCommand_Executed_ShouldSetSelectedTestToNewlyCreatedTest()
        {
            //------------Setup for test--------------------------
            var testFrameworkViewModel = new TestFrameworkViewModel(CreateResourceModel());
            var testModel = new TestModel { Name = "Test 2" };
            testFrameworkViewModel.Tests = new List<TestModel> { testModel };
            testFrameworkViewModel.SelectedTest = testModel;
            //------------Assert Preconditions-------------------
            Assert.IsNotNull(testFrameworkViewModel.Tests);
            Assert.IsNotNull(testFrameworkViewModel.SelectedTest);
            Assert.AreEqual(1, testFrameworkViewModel.Tests.Count);
            Assert.AreEqual(testModel, testFrameworkViewModel.SelectedTest);
            //------------Execute Test---------------------------
            testFrameworkViewModel.CreateTestCommand.Execute(null);
            //------------Assert Results-------------------------
            Assert.AreEqual(2, testFrameworkViewModel.Tests.Count);
            Assert.AreNotEqual(testModel, testFrameworkViewModel.SelectedTest);
            Assert.AreEqual(testFrameworkViewModel.Tests[1], testFrameworkViewModel.SelectedTest);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_Tests")]
        public void TestFrameworkViewModel_Tests_SetProperty_ShouldFireOnPropertyChanged()
        {
            //------------Setup for test--------------------------
            var testFrameworkViewModel = new TestFrameworkViewModel(CreateResourceModel());
            var _wasCalled = false;
            testFrameworkViewModel.PropertyChanged += (sender, args) =>
              {
                  if (args.PropertyName == "Tests")
                  {
                      _wasCalled = true;
                  }
              };
            //------------Execute Test---------------------------
            testFrameworkViewModel.Tests = new List<TestModel>();
            //------------Assert Results-------------------------
            Assert.IsTrue(_wasCalled);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("TestFrameworkViewModel_Tests")]
        public void TestFrameworkViewModel_SelectedTest_SetProperty_ShouldFireOnPropertyChanged()
        {
            //------------Setup for test--------------------------
            var testFrameworkViewModel = new TestFrameworkViewModel(CreateResourceModel());
            var _wasCalled = false;
            testFrameworkViewModel.PropertyChanged += (sender, args) =>
              {
                  if (args.PropertyName == "SelectedTest")
                  {
                      _wasCalled = true;
                  }
              };
            //------------Execute Test---------------------------
            testFrameworkViewModel.SelectedTest = new TestModel();
            //------------Assert Results-------------------------
            Assert.IsTrue(_wasCalled);
        }
    }
}
