/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.Decisions.Operations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Data.Tests.DecisionsTests.Operations
{
    /// <summary>
    /// Is Not Bse64 Decision
    /// </summary>
    [TestClass]
    public class IsNotBase64Tests
    {
        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(IsNotBase64))]
        public void IsNotBase64_Invoke_ItemsEqual_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBase64();
            var cols = new string[2];
            cols[0] = "aGVsbG8=";
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsFalse(result);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(IsNotBase64))]
        public void IsNotBase64_Invoke_NotEqualItems_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBase64();
            var cols = new string[2];
            cols[0] = "aGVsbG8ASS@";
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(IsNotBase64))]
        public void IsNotBase64_Invoke_EmptyColumns_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var endsWith = new IsNotBase64();
            var cols = new string[1];
            cols[0] = null;
            //------------Execute Test---------------------------
            var result = endsWith.Invoke(cols);
            //------------Assert Results-------------------------
            Assert.IsFalse(result);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(IsNotBase64))]
        public void IsNotBase64_HandlesType_ReturnsIsEndsWithType()
        {
            var expected = enDecisionType.IsNotBase64;
            //------------Setup for test--------------------------
            var isEndsWith = new IsNotBase64();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            Assert.AreEqual(expected, isEndsWith.HandlesType());
        }
    }
}
