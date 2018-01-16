﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.StudioTestFramework
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class StudioTestFrameworkWithDatabaseToolsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "StudioTestFrameworkWithDatabaseTools.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "StudioTestFrameworkWithDatabaseTools", "\tIn order to test workflows that contain database tools in warewolf \r\n\tAs a user\r" +
                    "\n\tI want to create, edit, delete and update tests in a test window", ProgrammingLanguage.CSharp, new string[] {
                        "StudioTestFrameworkWithDatabaseTools"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "StudioTestFrameworkWithDatabaseTools")))
            {
                global::Dev2.Activities.Specs.StudioTestFramework.StudioTestFrameworkWithDatabaseToolsFeature.FeatureSetup(null);
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
        
        public virtual void FeatureBackground()
        {
#line 8
#line 9
  testRunner.Given("test folder is cleaned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table966 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table966.AddRow(new string[] {
                        "[[a]]"});
#line 10
  testRunner.And("I have \"Workflow 1\" with inputs as", ((string)(null)), table966, "And ");
#line hidden
            TechTalk.SpecFlow.Table table967 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table967.AddRow(new string[] {
                        "[[outputValue]]"});
#line 13
  testRunner.And("\"Workflow 1\" has outputs as", ((string)(null)), table967, "And ");
#line hidden
            TechTalk.SpecFlow.Table table968 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table968.AddRow(new string[] {
                        "[[rec().a]]"});
            table968.AddRow(new string[] {
                        "[[rec().b]]"});
#line 16
  testRunner.Given("I have \"Workflow 2\" with inputs as", ((string)(null)), table968, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table969 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table969.AddRow(new string[] {
                        "[[returnVal]]"});
#line 20
  testRunner.And("\"Workflow 2\" has outputs as", ((string)(null)), table969, "And ");
#line hidden
            TechTalk.SpecFlow.Table table970 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table970.AddRow(new string[] {
                        "[[A]]"});
            table970.AddRow(new string[] {
                        "[[B]]"});
            table970.AddRow(new string[] {
                        "[[C]]"});
#line 23
  testRunner.Given("I have \"Workflow 3\" with inputs as", ((string)(null)), table970, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table971 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table971.AddRow(new string[] {
                        "[[message]]"});
#line 28
  testRunner.And("\"Workflow 3\" has outputs as", ((string)(null)), table971, "And ");
#line hidden
            TechTalk.SpecFlow.Table table972 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table972.AddRow(new string[] {
                        "[[input]]"});
#line 31
  testRunner.Given("I have \"WorkflowWithTests\" with inputs as", ((string)(null)), table972, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table973 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table973.AddRow(new string[] {
                        "[[outputValue]]"});
#line 34
  testRunner.And("\"WorkflowWithTests\" has outputs as", ((string)(null)), table973, "And ");
#line hidden
            TechTalk.SpecFlow.Table table974 = new TechTalk.SpecFlow.Table(new string[] {
                        "TestName",
                        "AuthenticationType",
                        "Error",
                        "TestFailing",
                        "TestPending",
                        "TestInvalid",
                        "TestPassed"});
            table974.AddRow(new string[] {
                        "Test1",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "false",
                        "true"});
            table974.AddRow(new string[] {
                        "Test2",
                        "Windows",
                        "false",
                        "true",
                        "false",
                        "false",
                        "false"});
            table974.AddRow(new string[] {
                        "Test3",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "true",
                        "false"});
            table974.AddRow(new string[] {
                        "Test4",
                        "Windows",
                        "false",
                        "false",
                        "true",
                        "false",
                        "false"});
#line 37
  testRunner.And("\"WorkflowWithTests\" Tests as", ((string)(null)), table974, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with MySql")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithMySql()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with MySql", ((string[])(null)));
#line 45
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 46
  testRunner.Given("I have a workflow \"MySqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table975 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input to Service",
                        "From Variable",
                        "Output from Service",
                        "To Variable"});
            table975.AddRow(new string[] {
                        "",
                        "",
                        "name",
                        "[[rec(*).name]]"});
            table975.AddRow(new string[] {
                        "",
                        "",
                        "email",
                        "[[rec(*).email]]"});
#line 47
   testRunner.And("\"MySqlTestWF\" contains a mysql database service \"MySqlEmail\" with mappings for te" +
                    "sting as", ((string)(null)), table975, "And ");
#line 51
  testRunner.And("I save workflow \"MySqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
  testRunner.Then("the test builder is open with \"MySqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 53
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
  testRunner.And("I Add \"MySqlEmail\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table976 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table976.AddRow(new string[] {
                        "[[MySqlEmail(1).name]]",
                        "=",
                        "Monk"});
            table976.AddRow(new string[] {
                        "[[MySqlEmail(1).email]]",
                        "=",
                        "dora@explorers.com"});
#line 57
  testRunner.And("I add StepOutputs as", ((string)(null)), table976, "And ");
#line 61
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 66
  testRunner.Then("workflow \"MySqlTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with Sql Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithSqlServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with Sql Server", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 69
  testRunner.Given("I have a workflow \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table977 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table977.AddRow(new string[] {
                        "Prefix",
                        "D"});
#line 70
   testRunner.And("\"SqlTestWF\" contains a sqlserver database service \"dbo.Pr_CitiesGetCountries\" wit" +
                    "h mappings for testing as", ((string)(null)), table977, "And ");
#line 73
  testRunner.And("I save workflow \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
  testRunner.Then("the test builder is open with \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
  testRunner.And("I Add \"dbo.Pr_CitiesGetCountries\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table978 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table978.AddRow(new string[] {
                        "[[dbo_Pr_CitiesGetCountries(2).CountryID]]",
                        "=",
                        "40"});
            table978.AddRow(new string[] {
                        "[[dbo_Pr_CitiesGetCountries(2).Description]]",
                        "=",
                        "Djibouti"});
#line 79
  testRunner.And("I add StepOutputs as", ((string)(null)), table978, "And ");
#line 83
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 86
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 87
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 88
  testRunner.Then("workflow \"SqlTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with Oracle")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithOracle()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with Oracle", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 91
  testRunner.Given("I have a workflow \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table979 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table979.AddRow(new string[] {
                        "P_DEPTNO",
                        "110"});
#line 92
   testRunner.And("\"oracleTestWF\" contains a oracle database service \"HR.GET_EMP_RS\" with mappings a" +
                    "s", ((string)(null)), table979, "And ");
#line 95
  testRunner.And("I save workflow \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
  testRunner.Then("the test builder is open with \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
  testRunner.And("I Add \"HR.GET_EMP_RS\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table980 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table980.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).EMPLOYEE_ID]]",
                        "=",
                        "205"});
            table980.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).FIRST_NAME]]",
                        "=",
                        "Shelley"});
            table980.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).LAST_NAME]]",
                        "=",
                        "Higgins"});
            table980.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).EMAIL]]",
                        "=",
                        "SHIGGINS"});
#line 101
  testRunner.And("I add StepOutputs as", ((string)(null)), table980, "And ");
#line 107
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 109
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 111
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 112
  testRunner.Then("workflow \"oracleTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with PostGre Sql")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithPostGreSql()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with PostGre Sql", ((string[])(null)));
#line 114
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 115
  testRunner.Given("I have a workflow \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table981 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table981.AddRow(new string[] {
                        "Prefix",
                        "K"});
#line 116
   testRunner.And("\"PostGreTestWF\" contains a postgre tool using \"get_countries\" with mappings for t" +
                    "esting as", ((string)(null)), table981, "And ");
#line 119
  testRunner.And("I save workflow \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
  testRunner.Then("the test builder is open with \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
  testRunner.And("I Add \"get_countries\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table982 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table982.AddRow(new string[] {
                        "[[get_countries(1).id]]",
                        "=",
                        "2"});
#line 125
  testRunner.And("I add StepOutputs as", ((string)(null)), table982, "And ");
#line 128
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 131
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 133
  testRunner.Then("workflow \"PostGreTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with Decision")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithDecision()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with Decision", ((string[])(null)));
#line 135
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 136
  testRunner.Given("I have a workflow \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table983 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table983.AddRow(new string[] {
                        "[[A]]",
                        "30"});
#line 137
  testRunner.And("\"DecisionTestWF\" contains an Assign \"TestAssign\" as", ((string)(null)), table983, "And ");
#line 140
  testRunner.And("a decision variable \"[[A]]\" value \"30\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
  testRunner.And("decide if \"[[A]]\" \"IsAlphanumeric\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 142
  testRunner.And("I save workflow \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
  testRunner.Then("the test builder is open with \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 144
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
  testRunner.And("I Add \"TestDecision\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table984 = new TechTalk.SpecFlow.Table(new string[] {
                        "Step Name",
                        "Output Variable",
                        "Output Value",
                        "Activity Type"});
            table984.AddRow(new string[] {
                        "If [[Name]] <> (Not Equal)",
                        "Flow Arm",
                        "True",
                        "Decision"});
#line 148
  testRunner.And("I add Assert steps as", ((string)(null)), table984, "And ");
#line 151
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 152
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 155
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 156
  testRunner.Then("workflow \"DecisionTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Test WF with SqlBulk Insert")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "StudioTestFrameworkWithDatabaseTools")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("StudioTestFrameworkWithDatabaseTools")]
        public virtual void TestWFWithSqlBulkInsert()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Test WF with SqlBulk Insert", ((string[])(null)));
#line 158
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 159
  testRunner.Given("I have a workflow \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table985 = new TechTalk.SpecFlow.Table(new string[] {
                        "Column",
                        "Mapping",
                        "IsNullable",
                        "DataTypeName",
                        "MaxLength",
                        "IsAutoIncrement"});
            table985.AddRow(new string[] {
                        "Name",
                        "Warewolf",
                        "false",
                        "varchar",
                        "50",
                        "false"});
            table985.AddRow(new string[] {
                        "Email",
                        "Warewolf@dev2.co.za",
                        "false",
                        "varchar",
                        "50",
                        "false"});
#line 160
   testRunner.And("\"SqlBulkTestWF\" contains an SQL Bulk Insert \"BulkInsert\" using database \"NewSqlBu" +
                    "lkInsertSource\" and table \"dbo.MailingList\" and KeepIdentity set \"true\" and Resu" +
                    "lt set \"[[result]]\" for testing as", ((string)(null)), table985, "And ");
#line 164
  testRunner.And("I save workflow \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
  testRunner.Then("the test builder is open with \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 166
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 167
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 168
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
  testRunner.And("I Add \"BulkInsert\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table986 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table986.AddRow(new string[] {
                        "[[result]]",
                        "=",
                        "Success"});
#line 170
 testRunner.And("I add StepOutputs as", ((string)(null)), table986, "And ");
#line 173
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 174
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 175
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 176
  testRunner.When("I delete \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 177
  testRunner.Then("The \"DeleteConfirmation\" popup is shown I click Ok", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 178
  testRunner.Then("workflow \"SqlBulkTestWF\" is deleted as cleanup", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
