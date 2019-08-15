using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Warewolf.Options;

namespace Warewolf.Data.Tests
{
    [TestClass]
    public class ConvertorTests
    {
        [TestMethod]
        public void OptionConvertor_GivenSimpleClass_ExpectListOfIOptions()
        {
            var result = ConvertDataToOptionsList();

            Assert.AreEqual(3, result.Length);
        }


        [TestMethod]
        public void OptionConvertor_GivenSimpleClass_ExpectIntOption_Success()
        {
            var result = ConvertDataToOptionsList();

            Assert.AreEqual("i", result[0].Name);
            Assert.AreEqual(12, ((OptionInt) result[0]).Value);
        }

        [TestMethod]
        public void OptionConvertor_GivenSimpleClass_ExpectStringOption_Success()
        {
            var result = ConvertDataToOptionsList();

            Assert.AreEqual("s", result[1].Name);
            Assert.AreEqual("hello", ((OptionAutocomplete)result[1]).Value);
            var expected = new TestData.OptionsForS().Options;
            var suggestions = ((OptionAutocomplete)result[1]).Suggestions;
            Assert.IsTrue(expected.SequenceEqual(suggestions));
        }

        [TestMethod]
        public void OptionConvertor_GivenSimpleClass_ExpectBoolOption_Success()
        {
            var result = ConvertDataToOptionsList();

            Assert.AreEqual("b", result[2].Name);
            Assert.AreEqual(true, ((OptionBool)result[2]).Value);
        }

        private static IOption[] ConvertDataToOptionsList()
        {
            var cls = new TestData
            {
                i = 12,
                s = "hello",
                b = true
            };

            return OptionConvertor.Convert(cls);
        }

        public class TestData
        {
            public int i { get; set; }
            [DataProvider(typeof(OptionsForS))]
            public string s { get; set; }
            public bool b { get; set; }

            public class OptionsForS : IOptionDataList
            {
                public string[] Options => new string[] { "sopt1", "sopt2", "sopt3", "sopt4" };
            }
        }
    }
}
