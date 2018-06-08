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
namespace Warewolf.Tools.Specs.Toolbox.Database.Oracle
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class OracleServerConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "OracleServerConnector.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "OracleServerConnector", "\tIn order to manage my database services\r\n\tAs a Warewolf User\r\n\tI want to be show" +
                    "n the database service setup", ProgrammingLanguage.CSharp, new string[] {
                        "Database"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "OracleServerConnector")))
            {
                global::Warewolf.Tools.Specs.Toolbox.Database.Oracle.OracleServerConnectorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Running Oracle Tool Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("CreatingOracleToolInstance")]
        public virtual void RunningOracleToolTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Running Oracle Tool Test", new string[] {
                        "CreatingOracleToolInstance"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given("I open New Workflow containing an Oracle Connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
 testRunner.And("I drag a Oracle Server database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Oracle Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.And("Oracle Action is Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.And("Oracle Inputs are Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("Oracle Outputs are Disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I Selected GreenPoint as Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 17
 testRunner.When("I select HR.TESTPROC9 as the Oracle action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.Then("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1.AddRow(new string[] {
                        "EID",
                        "[[EID]]",
                        "false"});
#line 19
 testRunner.And("Oracle Inputs appear as", ((string)(null)), table1, "And ");
#line 22
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.When("I click Oracle Validate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "EID"});
            table2.AddRow(new string[] {
                        "100"});
#line 24
 testRunner.Then("Test Oracle Inputs appear as", ((string)(null)), table2, "Then ");
#line 27
 testRunner.When("I click Oracle Tests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
 testRunner.When("I click Oracle OK", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table3.AddRow(new string[] {
                        "Column1",
                        "[[HR_TESTPROC9().Column1]]"});
#line 29
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table3, "Then ");
#line 32
 testRunner.Then("Oracle Recordset Name equals \"HR_TESTPROC9\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Saved workflow with Oracle tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void OpeningSavedWorkflowWithOracleTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Saved workflow with Oracle tool", ((string[])(null)));
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("I open workflow with Oracle connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.And("Oracle Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("Oracle Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("Oracle Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table4.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 40
 testRunner.Then("Oracle Inputs appear as", ((string)(null)), table4, "Then ");
#line 43
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table5.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table5.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 44
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table5, "Then ");
#line 48
 testRunner.And("Oracle Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change Source on Oracle Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ChangeSourceOnOracleTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change Source on Oracle Tool", ((string[])(null)));
#line 50
this.ScenarioSetup(scenarioInfo);
#line 51
 testRunner.Given("I open workflow with Oracle connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.And("Oracle Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("Oracle Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Oracle Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table6.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 56
 testRunner.Then("Oracle Inputs appear as", ((string)(null)), table6, "Then ");
#line 59
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table7.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table7.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 60
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table7, "Then ");
#line 64
 testRunner.And("Oracle Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.When("Oracle Source is changed from to GreenPoint", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.Then("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing Actions on Oracle Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ChangingOracleActions")]
        public virtual void ChangingActionsOnOracleTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing Actions on Oracle Tool", new string[] {
                        "ChangingOracleActions"});
#line 71
this.ScenarioSetup(scenarioInfo);
#line 72
 testRunner.Given("I open workflow with Oracle connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 73
 testRunner.And("Oracle Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("Oracle Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("Oracle Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table8.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 77
 testRunner.Then("Oracle Inputs appear as", ((string)(null)), table8, "Then ");
#line 80
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table9.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table9.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 81
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table9, "Then ");
#line 85
 testRunner.And("Oracle Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
 testRunner.When("Oracle Action is changed from to dbo.ImportOrder", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table10.AddRow(new string[] {
                        "ProductId",
                        "[[ProductId]]",
                        "false"});
#line 88
 testRunner.Then("Oracle Inputs appear as", ((string)(null)), table10, "Then ");
#line 91
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change Recordset Name on Oracle Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ChangeRecordsetNameOnOracleTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change Recordset Name on Oracle Tool", ((string[])(null)));
#line 93
this.ScenarioSetup(scenarioInfo);
#line 94
 testRunner.Given("I open workflow with Oracle connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 95
 testRunner.And("Oracle Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("Oracle Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("Oracle Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table11.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 99
 testRunner.Then("Oracle Inputs appear as", ((string)(null)), table11, "Then ");
#line 102
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table12.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table12.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 103
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table12, "Then ");
#line 107
 testRunner.And("Oracle Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
 testRunner.When("Oracle Recordset Name is changed to \"Pr_Cities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table13.AddRow(new string[] {
                        "CountryID",
                        "[[Pr_Cities().CountryID]]"});
            table13.AddRow(new string[] {
                        "Description",
                        "[[Pr_Cities().Description]]"});
#line 109
 testRunner.Then("Oracle Outputs appear as", ((string)(null)), table13, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Execute Oracle Server With Timeout")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "OracleServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Database")]
        public virtual void ExecuteOracleServerWithTimeout()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Execute Oracle Server With Timeout", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 115
    testRunner.Given("I have workflow \"OracleWorkflowForTimeout\" with \"OracleActivity\" Oracle database " +
                    "connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 116
    testRunner.And("Oracle Server Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
    testRunner.And("I Select \"NewOracleSource\" as Oracle Source for \"OracleActivity\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
    testRunner.And("I Select \"HR.GET_COUNTRIES\" as Oracle Server Action for \"OracleActivity\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
    testRunner.And("Oracle Server Inputs Are Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
 testRunner.And("Validate Oracle Server is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
    testRunner.And("I click Oracle Generate Outputs", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
    testRunner.And("I click Test for Oracle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table14.AddRow(new string[] {
                        "COUNTRY_ID",
                        "[[HR_GET_COUNTRIES().COUNTRY_ID]]"});
            table14.AddRow(new string[] {
                        "COUNTRY_NAME",
                        "[[HR_GET_COUNTRIES().COUNTRY_NAME]]"});
            table14.AddRow(new string[] {
                        "REGION_ID",
                        "[[HR_GET_COUNTRIES().REGION_ID]]"});
#line 123
    testRunner.Then("Oracle Server Outputs appear as", ((string)(null)), table14, "Then ");
#line 128
 testRunner.And("Oracle Server Recordset Name equals \"HR_GET_COUNTRIES\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
 testRunner.When("Oracle Workflow \"OracleWorkflowForTimeout\" containing dbTool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
    testRunner.And("the workflow \"OracleWorkflowForTimeout\" execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
