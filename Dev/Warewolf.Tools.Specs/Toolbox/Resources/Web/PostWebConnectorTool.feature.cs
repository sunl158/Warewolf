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
namespace Warewolf.Tools.Specs.Toolbox.Resources.Web
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PostWebConnectorToolFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "PostWebConnectorTool.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Post Web Connector Tool", "\tIn order to create New Web Post Service Tool in Warewolf\r\n\tAs a Warewolf User\r\n\t" +
                    "I want to Create or Edit Warewolf Web Post Request.", ProgrammingLanguage.CSharp, new string[] {
                        "Resources"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Post Web Connector Tool")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Resources.Web.PostWebConnectorToolFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Open new Post Web Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void OpenNewPostWebTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open new Post Web Tool", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 10
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("Post Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I Select \"WebHeloo\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2437 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 15
 testRunner.And("Post Header appears as", ((string)(null)), table2437, "And ");
#line 17
 testRunner.And("Post Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("Post Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("Post Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2438 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
#line 22
 testRunner.And("Post mapped outputs are", ((string)(null)), table2438, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Web Service with different methods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void CreateWebServiceWithDifferentMethods()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Web Service with different methods", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.And("Post Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2439 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 31
 testRunner.And("Post Header appears as", ((string)(null)), table2439, "And ");
#line 33
 testRunner.And("Post Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("Post Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("Post Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("I click Post Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("Post the Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
 testRunner.And("Post Variables are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
 testRunner.When("Post Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("Post the response is loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 43
 testRunner.When("I click Post Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 44
 testRunner.Then("Post Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2440 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table2440.AddRow(new string[] {
                        "CountryID",
                        "[[CountryID]]"});
            table2440.AddRow(new string[] {
                        "Description",
                        "[[Description]]"});
#line 45
 testRunner.And("Post mapped outputs are", ((string)(null)), table2440, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding parameters in Post Post Web Connector Tool request headers is updating var" +
            "iables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void AddingParametersInPostPostWebConnectorToolRequestHeadersIsUpdatingVariables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding parameters in Post Post Web Connector Tool request headers is updating var" +
                    "iables", ((string[])(null)));
#line 52
this.ScenarioSetup(scenarioInfo);
#line 53
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 56
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 57
 testRunner.And("Post Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("Post Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("I enter \"?extension=[[extension]]&prefix=[[prefix]]\" as Post Query String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("Post Url as \"http://TFSBLD.premier.local/integrationTestSite/GetCountries.ashx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2441 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Value"});
            table2441.AddRow(new string[] {
                        "[[a]]",
                        "T"});
#line 63
 testRunner.And("I add Post Header as", ((string)(null)), table2441, "And ");
#line 66
 testRunner.When("I click Post Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 67
 testRunner.Then("Post the Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2442 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table2442.AddRow(new string[] {
                        "[[a]]"});
            table2442.AddRow(new string[] {
                        "[[extension]]"});
            table2442.AddRow(new string[] {
                        "[[prefix]]"});
#line 68
 testRunner.And("Post Input variables are", ((string)(null)), table2442, "And ");
#line 73
 testRunner.And("Post Test is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("Post Paste is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("Post Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.And("I click Post Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.Then("Post Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2443 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table2443.AddRow(new string[] {
                        "CountryID",
                        "[[CountryID]]"});
            table2443.AddRow(new string[] {
                        "Description",
                        "[[Description]]"});
#line 78
    testRunner.And("Post mapped outputs are", ((string)(null)), table2443, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing Post Web Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void EditingPostWebService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing Post Web Service", ((string[])(null)));
#line 83
 this.ScenarioSetup(scenarioInfo);
#line 84
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
 testRunner.And("Post Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("I click Post Edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("the \"Dev2CountriesWebService\" Post Source tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing Post Post Web Connector Tool Sources")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void ChangingPostPostWebConnectorToolSources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing Post Post Web Connector Tool Sources", ((string[])(null)));
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.When("I Select \"WebHeloo\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.And("Post Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("Post Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("I click Post Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.Then("Post the Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.When("Post Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("Post Response appears as \"{\"rec\" : [{\"a\":\"1\",\"b\":\"a\"}]}\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.When("I click Post Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("Post Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2444 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table2444.AddRow(new string[] {
                        "a",
                        "[[rec().a]]"});
            table2444.AddRow(new string[] {
                        "b",
                        "[[rec().b]]"});
#line 107
 testRunner.And("Post mapped outputs are", ((string)(null)), table2444, "And ");
#line 111
 testRunner.When("I Select \"Google Address Lookup\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.And("Post Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("Post Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
 testRunner.And("Post Mappings is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Post Web Connector Tool returns text")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Post Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Resources")]
        public virtual void PostWebConnectorToolReturnsText()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Post Web Connector Tool returns text", ((string[])(null)));
#line 121
this.ScenarioSetup(scenarioInfo);
#line 122
 testRunner.And("I drag Web Post Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
    testRunner.And("Post New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.When("I Select \"TestingReturnText\" as a Post web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 125
 testRunner.Then("Post Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 126
 testRunner.And("Post Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("Post Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.And("I click Post Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.Then("Post the Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 130
 testRunner.When("Post Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 131
 testRunner.And("I click Post Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
 testRunner.Then("Post Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2445 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table2445.AddRow(new string[] {
                        "a",
                        "[[rec().a]]"});
#line 133
 testRunner.And("Post mapped outputs are", ((string)(null)), table2445, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
