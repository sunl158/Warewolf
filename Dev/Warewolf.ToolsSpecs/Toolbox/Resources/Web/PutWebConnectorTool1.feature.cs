﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class PutWebConnectorToolFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PutWebConnectorTool.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Put Web Connector Tool", "In order to create New Web Put Service Tool in Warewolf\r\nAs a Warewolf User\r\nI wa" +
                    "nt to Create or Edit Warewolf Web Put Request.", ProgrammingLanguage.CSharp, ((string[])(null)));
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
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Put Web Connector Tool")))
            {
                Warewolf.Tools.Specs.Toolbox.Resources.Web.PutWebConnectorToolFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Open new Web Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        public virtual void OpenNewWebTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Open new Web Tool", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("Put Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("I Select \"WebHeloo\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 15
 testRunner.And("Put Header appears as", ((string)(null)), table1, "And ");
#line 17
 testRunner.And("Put Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
 testRunner.And("Put Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("Put Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
#line 22
 testRunner.And("Put mapped outputs are", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Web Service with different methods")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        public virtual void CreateWebServiceWithDifferentMethods()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Web Service with different methods", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
 testRunner.And("Put Edit is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 31
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Header",
                        "Value"});
#line 32
 testRunner.And("Put Header appears as", ((string)(null)), table3, "And ");
#line 34
 testRunner.And("Put Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("Put Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("Put Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.When("I click Put Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
 testRunner.Then("the Put Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 41
 testRunner.And("Put Variables are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
 testRunner.When("Put Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
 testRunner.Then("the Put response is loaded", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 44
 testRunner.When("I click Put Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
 testRunner.Then("Put Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 46
 testRunner.And("Put mapped outputs are", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Adding parameters in request headers is updating variables")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        public virtual void AddingParametersInRequestHeadersIsUpdatingVariables()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Adding parameters in request headers is updating variables", ((string[])(null)));
#line 53
this.ScenarioSetup(scenarioInfo);
#line 54
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 55
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 59
 testRunner.And("Put Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("Put Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("I enter \"?extension=[[extension]]&prefix=[[prefix]]\" as Put Query String", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("Put Url as \"http://rsaklfsvrtfsbld/integrationTestSite/GetCountries.ashx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Value"});
            table5.AddRow(new string[] {
                        "[[a]]",
                        "T"});
#line 65
 testRunner.And("I add Put Header as", ((string)(null)), table5, "And ");
#line 68
 testRunner.When("I click Put Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 69
 testRunner.Then("the Put Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name"});
            table6.AddRow(new string[] {
                        "[[a]]"});
            table6.AddRow(new string[] {
                        "[[extension]]"});
            table6.AddRow(new string[] {
                        "[[prefix]]"});
#line 70
 testRunner.And("Put Input variables are", ((string)(null)), table6, "And ");
#line 75
 testRunner.And("Put Test is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("Put Paste is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.When("Put Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
 testRunner.And("I click Put Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.Then("Put Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 80
    testRunner.And("Put mapped outputs are", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing Web Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        public virtual void EditingWebService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing Web Service", ((string[])(null)));
#line 85
 this.ScenarioSetup(scenarioInfo);
#line 86
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
 testRunner.When("I Select \"Dev2CountriesWebService\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
 testRunner.And("Put Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.When("I click Put Edit", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("the \"Dev2CountriesWebService\" Put Source tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing Sources")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        public virtual void ChangingSources()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing Sources", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 96
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 97
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.When("I Select \"WebHeloo\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.And("Put Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
 testRunner.And("Put Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
 testRunner.And("I click Put Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
 testRunner.Then("the Put Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 107
 testRunner.When("Put Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("Put Response appears as \"{\"rec\" : [{\"a\":\"1\",\"b\":\"a\"}]}\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 109
 testRunner.When("I click Put Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 110
 testRunner.Then("Put Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 111
 testRunner.And("Put mapped outputs are", ((string)(null)), table8, "And ");
#line 115
 testRunner.When("I Select \"Google Address Lookup\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.And("Put Body is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
 testRunner.And("Put Query is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
 testRunner.And("Put Mappings is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Web Connector Tool returns text")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Put Web Connector Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute()]
        public virtual void WebConnectorToolReturnsText()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Web Connector Tool returns text", new string[] {
                        "ignore"});
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
 testRunner.Given("I open New Workflow", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 128
 testRunner.And("I drag Web Put Request Connector Tool onto the design surface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
    testRunner.And("Put New is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
 testRunner.And("Put Edit is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
 testRunner.When("I Select \"TestingReturnText\" as a Put web Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.Then("Put Header is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
 testRunner.And("Put Url is Visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 134
 testRunner.And("Put Generate Outputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
 testRunner.And("I click Put Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.Then("the Put Generate Outputs window is shown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.When("Put Test Inputs is Successful", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.And("I click Put Done", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
 testRunner.Then("Put Mapping is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias"});
            table9.AddRow(new string[] {
                        "Response",
                        "Response"});
#line 140
 testRunner.And("Put mapped outputs are", ((string)(null)), table9, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
