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

namespace Dev2.Data.Tests.DecisionsTests
{
    /// <summary>
    /// Summary description for NotEndsWithTests
    /// </summary>
    [TestClass]
    public class NotEndsWithTests
    {
        [TestMethod]
        [Owner("Massimo Guerrera")]
        [TestCategory("NotEndsWith_Invoke")]
        public void NotEndsWith_Invoke_DoesEndWith_ReturnsFalse()
        {
            //------------Setup for test--------------------------
            var notStartsWith = new NotEndsWith();
            var cols = new string[2];
            cols[0] = "TestData";
            cols[1] = "Data";

            //------------Execute Test---------------------------

            var result = notStartsWith.Invoke(cols);

            //------------Assert Results-------------------------
            Assert.IsFalse(result);
        }

        [TestMethod]
        [Owner("Massimo Guerrera")]
        [TestCategory("NotEndsWith_Invoke")]
        public void NotEndsWith_Invoke_DoesntEndWith_ReturnsTrue()
        {
            //------------Setup for test--------------------------
            var notStartsWith = new NotEndsWith();
            var cols = new string[2];
            cols[0] = "TestData";
            cols[1] = "No";

            //------------Execute Test---------------------------

            var result = notStartsWith.Invoke(cols);

            //------------Assert Results-------------------------
            Assert.IsTrue(result);
        }

        [TestMethod]
        [Owner("Sanele Mthmembu")]
        [TestCategory("NotEndsWith_HandlesType")]
        public void NotEndsWith_HandlesType_ReturnsNotEndsWithType()
        {
            var expected = enDecisionType.NotEndsWith;
            //------------Setup for test--------------------------
            var notEndsWith = new NotEndsWith();
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            Assert.AreEqual(expected, notEndsWith.HandlesType());
        }
    }
}
