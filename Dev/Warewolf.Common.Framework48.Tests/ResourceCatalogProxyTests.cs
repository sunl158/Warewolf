﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.ServiceModel;
using Dev2.Studio.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Text;
using Warewolf.Common;
using Warewolf.Esb;

namespace Warewolf.Tests
{
    [TestClass]
    public class ResourceCatalogProxyTests
    {
        [TestMethod]
        public void ResourceCatalogProxy_Construct()
        {
            var proxy = GetResourceCatalog();
            Assert.IsNotNull(proxy);
        }

        [TestMethod]
        public void ResourceCatalogProxy_GetResourceById_ReturnsResource()
        {
            var environmentConnection = GetConnection();
            var proxy = new ResourceCatalogProxy(environmentConnection);
            var resourceId = Guid.Parse("5d82c480-505e-48e9-9915-aca0293be30c");
            var resource = proxy.GetResourceById<RabbitMQSource>(Guid.Empty, resourceId);

            Assert.IsTrue(resource.IsSource);
            Assert.AreEqual("test", resource.UserName);
            Assert.AreEqual("test", resource.Password);
        }

        [TestMethod]
        public void ResourceCatalogProxy_GetResourceById_ReturnsResource2()
        {
            var environmentConnection = GetConnection();
            var resourceId = Guid.Parse("5d82c480-505e-48e9-9915-aca0293be30c");
            var req = environmentConnection.NewResourceRequest<RabbitMQSource>(Guid.Empty, resourceId);
            var resource = req.Result;

            Assert.IsTrue(resource.IsSource);
            Assert.AreEqual("test", resource.UserName);
            Assert.AreEqual("test", resource.Password);
        }

        private static ResourceCatalogProxy GetResourceCatalog()
        {
            var environmentConnection = GetConnection();
            var proxy = new ResourceCatalogProxy(environmentConnection);
            return proxy;
        }

        private static IEnvironmentConnection GetConnection()
        {
            var mockEnvironmentConnection = new Mock<IEnvironmentConnection>();

            mockEnvironmentConnection.Setup(o => o.IsConnected).Returns(true);
            var returnValue =
                new StringBuilder("{\"$id\": \"1\",\"$type\": \"Dev2.Data.ServiceModel.RabbitMQSource, Dev2.Data\",\"UserName\": \"test\",\"Password\": \"test\",\"ResourceID\": \"5d82c480-505e-48e9-9915-aca0293be30c\"}");
            mockEnvironmentConnection.Setup(o => o.ExecuteCommand(It.IsAny<StringBuilder>(), It.IsAny<Guid>(), It.IsAny<int>())).Returns(returnValue);
            mockEnvironmentConnection.Setup(o => o.ExecuteCommandAsync(It.IsAny<ICatalogRequest>(), It.IsAny<Guid>()))
                .ReturnsAsync(returnValue);

            var environmentConnection = mockEnvironmentConnection.Object;
            return environmentConnection;
        }
    }
}
