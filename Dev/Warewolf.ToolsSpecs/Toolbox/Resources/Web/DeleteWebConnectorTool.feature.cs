﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.ToolsSpecs.Toolbox.Resources.Web
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DeleteWebConnectorToolFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeleteWebConnectorTool.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delete Web Connector Tool", "\tIn order to create New Web Delete Service Tool in Warewolf\r\n\tAs a Warewolf User\r" +
                    "\n\tI want to Create or Edit Warewolf Web Delete Request.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Delete Web Connector Tool")))
            {
                Warewolf.ToolsSpecs.Toolbox.Resources.Web.DeleteWebConnectorToolFeature.FeatureSetup(null);
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
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Open new Deletge Web Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void OpenNewDeletgeWebTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open new Deletge Web Tool", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("Delete Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.When("I Select \"WebHeloo\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 13
 testRunner.And("Delete Header appears as", ((string)(null)), table1, "And ");
#line 15
 testRunner.And("Delete Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("Delete Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("Delete Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
#line 20
 testRunner.And("Delete mapped outputs are", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Delete Web Service with different methods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void CreateDeleteWebServiceWithDifferentMethods()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Delete Web Service with different methods", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Delete Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 29
 testRunner.And("Delete Header appears as", ((string)(null)), table3, "And ");
#line 31
 testRunner.And("Delete Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("Delete Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("Delete Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.When("I click Delete Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("the Delete Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 38
 testRunner.And("Delete Variables are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("Delete Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("the Delete response is loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.When("I click Delete Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
 testRunner.Then("Delete Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table4.AddRow(new string[] {
                        "CountryID",
                        "[[CountryID]]"});
            table4.AddRow(new string[] {
                        "Description",
                        "[[Description]]"});
#line 43
 testRunner.And("Delete mapped outputs are", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding parameters in Delete Post Web Connector Tool request headers is updating v" +
            "ariables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void AddingParametersInDeletePostWebConnectorToolRequestHeadersIsUpdatingVariables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding parameters in Delete Post Web Connector Tool request headers is updating v" +
                    "ariables", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 55
 testRunner.And("Delete Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("Delete Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("I enter \"?extension=[[extension]]&prefix=[[prefix]]\" as Delete Query String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Delete Url as \"http://rsaklfsvrtfsbld/integrationTestSite/GetCountries.ashx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Value"});
            table5.AddRow(new string[] {
                        "[[a]]",
                        "T"});
#line 61
 testRunner.And("I add Delete Header as", ((string)(null)), table5, "And ");
#line 64
 testRunner.When("I click Delete Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
 testRunner.Then("the Delete Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table6.AddRow(new string[] {
                        "[[a]]"});
            table6.AddRow(new string[] {
                        "[[extension]]"});
            table6.AddRow(new string[] {
                        "[[prefix]]"});
#line 66
 testRunner.And("Delete Input variables are", ((string)(null)), table6, "And ");
#line 71
 testRunner.And("Delete Test is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("Delete Paste is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When("Delete Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.And("I click Delete Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.Then("Delete Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table7.AddRow(new string[] {
                        "CountryID",
                        "[[CountryID]]"});
            table7.AddRow(new string[] {
                        "Description",
                        "[[Description]]"});
#line 76
    testRunner.And("Delete mapped outputs are", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing Delete Web Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void EditingDeleteWebService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing Delete Web Service", ((string[])(null)));
#line 81
 this.ScenarioSetup(scenarioInfo);
#line 82
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 84
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 85
 testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.And("Delete Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
 testRunner.When("I click Delete Edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
 testRunner.Then("the \"Dev2CountriesWebService\" Delete Source tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing Delete Web Connector Tool Sources")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void ChangingDeleteWebConnectorToolSources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing Delete Web Connector Tool Sources", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 91
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.When("I Select \"WebHeloo\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.And("Delete Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("Delete Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("I click Delete Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.Then("the Delete Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.When("Delete Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.Then("Delete Response appears as \"{\"rec\" : [{\"a\":\"1\",\"b\":\"a\"}]}\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.When("I click Delete Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("Delete Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table8.AddRow(new string[] {
                        "a",
                        "[[rec().a]]"});
            table8.AddRow(new string[] {
                        "b",
                        "[[rec().b]]"});
#line 105
 testRunner.And("Delete mapped outputs are", ((string)(null)), table8, "And ");
#line 109
 testRunner.When("I Select \"Google Address Lookup\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 111
 testRunner.And("Delete Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
 testRunner.And("Delete Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.And("Delete Mappings is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete Web Connector Tool returns text")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete Web Connector Tool")]
        public virtual void DeleteWebConnectorToolReturnsText()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete Web Connector Tool returns text", ((string[])(null)));
#line 119
this.ScenarioSetup(scenarioInfo);
#line 120
 testRunner.And("I drag Web Delete Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
    testRunner.And("Delete New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
 testRunner.And("Delete Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.When("I Select \"TestingReturnText\" as a Delete web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.Then("Delete Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.And("Delete Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("Delete Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
 testRunner.And("I click Delete Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
 testRunner.Then("the Delete Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
 testRunner.When("Delete Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
 testRunner.And("I click Delete Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.Then("Delete Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table9.AddRow(new string[] {
                        "Response",
                        "Response"});
#line 132
 testRunner.And("Delete mapped outputs are", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
