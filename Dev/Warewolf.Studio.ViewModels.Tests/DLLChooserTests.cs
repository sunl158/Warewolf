﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2022 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.Generic;
using Dev2.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Warewolf.Studio.ViewModels.Tests
{
    [TestClass]
    public class DLLChooserTests
    {
        #region Fields

        Mock<IDllListingModel> _modelMock;
        Mock<IManagePluginSourceModel> _updateManagerMock;
        List<string> _changedProperties;
        DLLChooser _target;

        #endregion Fields

        #region Test initialize

        [TestInitialize]
        public void TestInitialize()
        {
            _modelMock = new Mock<IDllListingModel>();
            _updateManagerMock = new Mock<IManagePluginSourceModel>();

            _modelMock.Setup(model => model.Name).Returns("dllName");
            _modelMock.Setup(model => model.FullName).Returns("dllFullName");

            _changedProperties = new List<string>();
            _target = new DLLChooser(_updateManagerMock.Object);
            _target.PropertyChanged += (sender, args) => { _changedProperties.Add(args.PropertyName); };
        }

        #endregion Test initialize

        #region Test commands

        [TestMethod]
        [Timeout(350)]
        public void TestCancelDllChooserCommandCanExecute()
        {
            //act
            var result = _target.CancelCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Timeout(250)]
        public void DllChooser_TestCancelCommandExecute()
        {
            //act
            _target.CancelCommand.Execute(null);

            //assert
            Assert.IsNull(_target.SelectedDll);
        }

        [TestMethod]
        [Timeout(100)]
        public void TestSelectCommandCanExecute()
        {
            //act
            var result = _target.SelectCommand.CanExecute(null);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Timeout(1000)]
        public void TestSaveCommandExecute()
        {
            //act
            _target.SelectedDll = _modelMock.Object;
            _target.SelectCommand.Execute(null);

            //assert
            Assert.AreEqual(_modelMock.Object, _target.SelectedDll);
        }

        #endregion Test commands

        #region Test properties

        [TestMethod]
        [Timeout(250)]
        public void TestSelectedDll()
        {
            //act
            _target.SelectedDll = _modelMock.Object;

            //assert
            Assert.AreEqual(_modelMock.Object, _target.SelectedDll);
        }

        [TestMethod]
        [Timeout(100)]
        public void TestIsLoading()
        {
            //act
            _target.IsLoading = true;

            //assert
            Assert.IsTrue(_target.IsLoading);
        }

        [TestMethod]
        [Timeout(250)]
        public void TestDLLSearchTerm()
        {
            //act
            var expectedValue = "textFilter";
            _target.SearchTerm = expectedValue;

            //assert
            Assert.AreEqual(expectedValue, _target.SearchTerm);
        }

        #endregion Test properties
    }
}
