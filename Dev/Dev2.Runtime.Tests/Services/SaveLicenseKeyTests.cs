﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2021 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common.Common;
using Dev2.Communication;
using Dev2.Runtime.ESB.Management.Services;
using Dev2.Workspaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Warewolf.Licensing;

namespace Dev2.Tests.Runtime.Services
{
    [TestClass]
    public class SaveLicenseKeyTests
    {
        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_GetResourceID_ShouldReturnEmptyGuid()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            //------------Execute Test---------------------------
            var resId = saveLicenseKey.GetResourceID(new Dictionary<string, StringBuilder>());
            //------------Assert Results-------------------------
            Assert.AreEqual(Guid.Empty, resId);
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_HandlesType_ExpectName()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            Assert.AreEqual(nameof(SaveLicenseKey), saveLicenseKey.HandlesType());
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_CreateServiceEntry_ExpectActions()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            //------------Execute Test---------------------------
            var dynamicService = saveLicenseKey.CreateServiceEntry();
            //------------Assert Results-------------------------
            Assert.IsNotNull(dynamicService);
            Assert.IsNotNull(dynamicService.Actions);
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_Execute_NullValues_HasError_IsTrue_ReturnsUnRegisteredLicenseInfo()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            var serializer = new Dev2JsonSerializer();
            // LicenseSettings.ApiKey = "test_VMxitsiobdAyth62k0DiqpAUKocG6sV3";
            // LicenseSettings.SiteName = "warewolf-test";
            // LicenseSettings.SubscriptionId = "None";
            // LicenseSettings.PlanId = "NotActive";
            //------------Execute Test---------------------------
            var jsonResult = saveLicenseKey.Execute(null, null);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsTrue(result.HasError);
            var res = serializer.Deserialize<ISubscriptionData>(result.Message);
            Assert.AreEqual("Unknown",res.CustomerId);
            Assert.IsNotNull("NotActive",res.PlanId);
            Assert.IsFalse(res.IsLicensed);
            // Assert.AreEqual(LicenseSettings.PlanId,res.PlanId);
            // Assert.AreEqual(LicenseSettings.IsLicensed,res.IsLicensed);
            // Assert.AreEqual(LicenseSettings.CustomerId,res.CustomerId);
            // Assert.AreEqual(LicenseSettings.SubscriptionId,res.SubscriptionId);
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_Execute_Success_ReturnsLicenceInfo()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            var serializer = new Dev2JsonSerializer();
            var workspaceMock = new Mock<IWorkspace>();
            // LicenseSettings.CustomerId = "16BjmNSXISIQjctO";
            // LicenseSettings.SubscriptionId = "16BjmNSXISIQjctO";
            // LicenseSettings.PlanId = "developer";
            // LicenseSettings.ApiKey = "test_VMxitsiobdAyth62k0DiqpAUKocG6sV3";
            // LicenseSettings.SiteName = "warewolf-test";
            var data = new SubscriptionData
            {
                // CustomerId = LicenseSettings.CustomerId ,
                // PlanId =  LicenseSettings.PlanId,
                // SubscriptionId =  LicenseSettings.SubscriptionId
            };
            var licenseData = serializer.Serialize<ISubscriptionData>(data).ToStringBuilder();

            var values = new Dictionary<string, StringBuilder>
            {
                { "LicenseData", licenseData}
            };

            //------------Execute Test---------------------------
            var jsonResult = saveLicenseKey.Execute(values, workspaceMock.Object);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsFalse(result.HasError);
            var res = serializer.Deserialize<ISubscriptionData>(result.Message);
            Assert.AreEqual(data.CustomerId,res.CustomerId);
            Assert.AreEqual(data.SubscriptionId,res.SubscriptionId);
            Assert.AreEqual(data.PlanId,res.PlanId);
        }

        [TestMethod]
        [Owner("Candice Daniel")]
        [TestCategory(nameof(SaveLicenseKey))]
        public void SaveLicenseKey_Execute_HasError_MissingCustomerId_ReturnsUnRegisteredLicenseInfo()
        {
            //------------Setup for test--------------------------
            var saveLicenseKey = new SaveLicenseKey();
            var serializer = new Dev2JsonSerializer();
            var workspaceMock = new Mock<IWorkspace>();
            var data = new SubscriptionData
            {
                CustomerFirstName = "Customer ABC",
                PlanId = "Developer"
            };
            var licenseData = serializer.Serialize<ISubscriptionData>(data).ToStringBuilder();

            var values = new Dictionary<string, StringBuilder>
            {
                { "LicenseData", licenseData}
            };
            // LicenseSettings.ApiKey = "test_VMxitsiobdAyth62k0DiqpAUKocG6sV3";
            // LicenseSettings.SiteName = "warewolf-test";
            // LicenseSettings.SubscriptionId = "None";
            // LicenseSettings.PlanId = "UnRegistered";
            //------------Execute Test---------------------------
            var jsonResult = saveLicenseKey.Execute(values, workspaceMock.Object);
            var result = serializer.Deserialize<ExecuteMessage>(jsonResult);
            //------------Assert Results-------------------------
            Assert.IsTrue(result.HasError);
            var res = serializer.Deserialize<ISubscriptionData>(result.Message);
            Assert.AreEqual("Unknown",res.CustomerId);
            Assert.IsNotNull("UnRegistered",res.PlanId);
            Assert.IsFalse(res.IsLicensed);
            // Assert.AreEqual(LicenseSettings.PlanId,res.PlanId);
            // Assert.AreEqual(LicenseSettings.IsLicensed,res.IsLicensed);
            // Assert.AreEqual(LicenseSettings.CustomerId,res.CustomerId);
            // Assert.AreEqual(LicenseSettings.SubscriptionId,res.SubscriptionId);
        }
    }
}