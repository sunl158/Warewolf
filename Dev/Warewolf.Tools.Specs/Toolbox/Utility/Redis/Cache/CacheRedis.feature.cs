﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.2.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.Tools.Specs.Toolbox.Utility.Redis.Cache
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RedisCacheFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "CacheRedis.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "RedisCache", "\tIn order to avoid rerunning the work-flow every time we need generated data\r\n\tAs" +
                    " a user\r\n\tI want to be to cached data while the Time To Live has not elapsed ", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "RedisCache")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Utility.Redis.Cache.RedisCacheFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("No data in cache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RedisCache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RedisCache")]
        public virtual void NoDataInCache()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No data in cache", new string[] {
                        "RedisCache"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("valid Redis source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.And("I have a key \"MyData\" with GUID and ttl of \"3000\" milliseconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("No data in the cache", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2769 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2769.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
#line 11
 testRunner.And("an assign \"dataToStore\" as", ((string)(null)), table2769, "And ");
#line 14
 testRunner.When("I execute the Redis Cache tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2770 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Data"});
            table2770.AddRow(new string[] {
                        "MyData",
                        "\"[[Var1]],Test1\""});
#line 15
 testRunner.Then("the cache will contain", ((string)(null)), table2770, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2771 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2771.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
#line 18
 testRunner.And("output variables have the following values", ((string)(null)), table2771, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Data exists for given TTL not hit")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RedisCache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RedisCache")]
        public virtual void DataExistsForGivenTTLNotHit()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Data exists for given TTL not hit", new string[] {
                        "RedisCache"});
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("valid Redis source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.And("I have a key \"MyData\" with GUID and ttl of \"20000\" milliseconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2772 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Data"});
            table2772.AddRow(new string[] {
                        "MyData",
                        "\"[[Var1]],Data in cache\""});
#line 26
 testRunner.And("data exists (TTL not hit) for key \"MyData\" with GUID as", ((string)(null)), table2772, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2773 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2773.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
#line 29
 testRunner.And("an assign \"dataToStore\" as", ((string)(null)), table2773, "And ");
#line 32
 testRunner.When("I execute the Redis Cache tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.Then("the assign \"dataToStore\" is not executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2774 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2774.AddRow(new string[] {
                        "[[Var1]]",
                        "\"[[Var1]],Data in cache\""});
#line 34
 testRunner.And("output variables have the following values", ((string)(null)), table2774, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Data Not Exist For Given Key (TTL exceeded) Spec")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RedisCache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RedisCache")]
        public virtual void DataNotExistForGivenKeyTTLExceededSpec()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Data Not Exist For Given Key (TTL exceeded) Spec", new string[] {
                        "RedisCache"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
 testRunner.Given("valid Redis source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.And("I have a key \"MyData\" with GUID and ttl of \"3000\" milliseconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2775 = new TechTalk.SpecFlow.Table(new string[] {
                        "",
                        ""});
#line 42
 testRunner.And("data does not exist (TTL exceeded) for key \"MyData\" as", ((string)(null)), table2775, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2776 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2776.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
#line 44
 testRunner.And("an assign \"dataToStore\" as", ((string)(null)), table2776, "And ");
#line 47
 testRunner.When("I execute the Redis Cache tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("the assign \"dataToStore\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2777 = new TechTalk.SpecFlow.Table(new string[] {
                        "Key",
                        "Data"});
            table2777.AddRow(new string[] {
                        "MyData",
                        "\"[[Var1]],Test1\""});
#line 49
 testRunner.Then("the cache will contain", ((string)(null)), table2777, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2778 = new TechTalk.SpecFlow.Table(new string[] {
                        "var",
                        "value"});
            table2778.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
#line 52
 testRunner.And("output variables have the following values", ((string)(null)), table2778, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Input Variable Keys Are Less Then Cached Data Variable Keys")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RedisCache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RedisCache")]
        public virtual void InputVariableKeysAreLessThenCachedDataVariableKeys()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Input Variable Keys Are Less Then Cached Data Variable Keys", new string[] {
                        "RedisCache"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
 testRunner.Given("valid Redis source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
 testRunner.And("I have \"key1\" of \"MyData\" with GUID and \"ttl1\" of \"15\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("I have \"key2\" of \"MyData\" with GUID and \"ttl2\" of \"3\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2779 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2779.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
            table2779.AddRow(new string[] {
                        "[[Var2]]",
                        "\"Test2\""});
#line 61
 testRunner.And("an assign \"dataToStore1\" into \"DsfMultiAssignActivity1\" with", ((string)(null)), table2779, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2780 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2780.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test21\""});
#line 65
 testRunner.And("an assign \"dataToStore2\" into \"DsfMultiAssignActivity2\" with", ((string)(null)), table2780, "And ");
#line 68
 testRunner.Then("the assigned \"key1\", \"ttl1\" and innerActivity \"DsfMultiAssignActivity1\" is execut" +
                    "ed by \"RedisActivity1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2781 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2781.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
            table2781.AddRow(new string[] {
                        "[[Var2]]",
                        "\"Test2\""});
#line 69
 testRunner.And("the Redis Cache under \"key1\" with GUID will contain", ((string)(null)), table2781, "And ");
#line 73
 testRunner.Then("the assigned \"key2\", \"ttl2\" and innerActivity \"DsfMultiAssignActivity2\" is execut" +
                    "ed by \"RedisActivity2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2782 = new TechTalk.SpecFlow.Table(new string[] {
                        "label",
                        "variable",
                        "operator",
                        "value"});
            table2782.AddRow(new string[] {
                        "Redis key { MyData } found",
                        "null",
                        "",
                        ""});
            table2782.AddRow(new string[] {
                        "null",
                        "[[Var1]]",
                        "=",
                        "\"Test21\""});
            table2782.AddRow(new string[] {
                        "null",
                        "[[Var2]]",
                        "=",
                        "\"Test22\""});
            table2782.AddRow(new string[] {
                        "null",
                        "[[Var3]]",
                        "=",
                        "\"Test23\""});
            table2782.AddRow(new string[] {
                        "null",
                        "[[Var4]]",
                        "=",
                        "\"Test24\""});
#line 74
 testRunner.Then("\"RedisActivity2\" output variables have the following values", ((string)(null)), table2782, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Input Variable Keys Are Greater Then Cached Data Variable Keys")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RedisCache")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("RedisCache")]
        public virtual void InputVariableKeysAreGreaterThenCachedDataVariableKeys()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Input Variable Keys Are Greater Then Cached Data Variable Keys", new string[] {
                        "RedisCache"});
#line 83
this.ScenarioSetup(scenarioInfo);
#line 84
 testRunner.Given("valid Redis source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 85
 testRunner.And("I have \"key1\" of \"MyData\" with GUID and \"ttl1\" of \"15\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("I have \"key2\" of \"MyData\" with GUID and \"ttl2\" of \"3\" seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2783 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2783.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
            table2783.AddRow(new string[] {
                        "[[Var2]]",
                        "\"Test2\""});
#line 87
 testRunner.And("an assign \"dataToStore1\" into \"DsfMultiAssignActivity1\" with", ((string)(null)), table2783, "And ");
#line hidden
            TechTalk.SpecFlow.Table table2784 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2784.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test21\""});
            table2784.AddRow(new string[] {
                        "[[Var2]]",
                        "\"Test22\""});
            table2784.AddRow(new string[] {
                        "[[Var3]]",
                        "\"Test23\""});
            table2784.AddRow(new string[] {
                        "[[Var4]]",
                        "\"Test24\""});
            table2784.AddRow(new string[] {
                        "[[bank(1).name]]",
                        "\"FNB\""});
            table2784.AddRow(new string[] {
                        "[[bank(1).id]]",
                        "\"100\""});
            table2784.AddRow(new string[] {
                        "[[bank(2).name]]",
                        "\"discovery\""});
            table2784.AddRow(new string[] {
                        "[[bank(2).id]]",
                        "\"200\""});
#line 91
 testRunner.And("an assign \"dataToStore2\" into \"DsfMultiAssignActivity2\" with", ((string)(null)), table2784, "And ");
#line 101
 testRunner.Then("the assigned \"key1\", \"ttl1\" and innerActivity \"DsfMultiAssignActivity1\" is execut" +
                    "ed by \"RedisActivity1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2785 = new TechTalk.SpecFlow.Table(new string[] {
                        "name",
                        "value"});
            table2785.AddRow(new string[] {
                        "[[Var1]]",
                        "\"Test1\""});
            table2785.AddRow(new string[] {
                        "[[Var2]]",
                        "\"Test2\""});
#line 102
 testRunner.And("the Redis Cache under \"key1\" with GUID will contain", ((string)(null)), table2785, "And ");
#line 106
 testRunner.Then("the assigned \"key2\", \"ttl2\" and innerActivity \"DsfMultiAssignActivity2\" is execut" +
                    "ed by \"RedisActivity2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2786 = new TechTalk.SpecFlow.Table(new string[] {
                        "label",
                        "variable",
                        "operator",
                        "value"});
            table2786.AddRow(new string[] {
                        "Redis key { MyData } found",
                        "null",
                        "",
                        ""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[Var1]]",
                        "=",
                        "\"Test21\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[Var2]]",
                        "=",
                        "\"Test22\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[Var3]]",
                        "=",
                        "\"Test23\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[Var4]]",
                        "=",
                        "\"Test24\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[bank(1).name]]",
                        "=",
                        "\"FNB\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[bank(1).id]]",
                        "=",
                        "\"100\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[bank(2).name]]",
                        "=",
                        "\"discovery\""});
            table2786.AddRow(new string[] {
                        "null",
                        "[[bank(2).id]]",
                        "=",
                        "\"200\""});
#line 107
 testRunner.Then("\"RedisActivity2\" output variables have the following values", ((string)(null)), table2786, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
