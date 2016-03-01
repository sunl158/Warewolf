﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dev2.Activities;
using Dev2.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Tests.Activities.ActivityTests
{
    [TestClass]
    public class WebRequestDataDtoTests
    {
        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void CreateRequestDataDto_GivenMethodGet_ShouldReturnDtoWithMethodGet()
        {
            //---------------Set up test pack-------------------
            var webRequestDataDto = WebRequestDataDto.CreateRequestDataDto(WebRequestMethod.Get, "A", string.Empty);
            //---------------Assert Precondition----------------
            Assert.IsNotNull(webRequestDataDto);
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.AreEqual(webRequestDataDto.WebRequestMethod, WebRequestMethod.Get);
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void CreateRequestDataDto_GivenTypeA_ShouldReturnDtoWithTypeA()
        {
            //---------------Set up test pack-------------------
            var webRequestDataDto = WebRequestDataDto.CreateRequestDataDto(WebRequestMethod.Get, "A", string.Empty);
            //---------------Assert Precondition----------------
            Assert.AreEqual(webRequestDataDto.WebRequestMethod, WebRequestMethod.Get);
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.AreEqual(webRequestDataDto.Type.Expression.ToString(), "A".ToString());
        }

        [TestMethod]
        [Owner("Nkosinathi Sangweni")]
        public void CreateRequestDataDto_GivenDisplayNameB_ShouldReturnDtoWithDisplayNameB()
        {
            //---------------Set up test pack-------------------
            var displayName = "DisplayNameB";
            var webRequestDataDto = WebRequestDataDto.CreateRequestDataDto(WebRequestMethod.Get, "A", displayName);
            //---------------Assert Precondition----------------
            Assert.AreEqual(webRequestDataDto.Type.Expression.ToString(), "A".ToString());
            //---------------Execute Test ----------------------
            //---------------Test Result -----------------------
            Assert.AreEqual(webRequestDataDto.DisplayName, displayName);
        }
    }
}
