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
namespace Dev2.Activities.Specs.StudioTestFramework
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class StudioTestFrameworkWithDatabaseToolsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "StudioTestFrameworkWithDatabaseTools.feature"
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
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(TestContext);
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
            TechTalk.SpecFlow.Table table1075 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1075.AddRow(new string[] {
                        "[[a]]"});
#line 10
  testRunner.And("I have \"Workflow 1\" with inputs as", ((string)(null)), table1075, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1076 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1076.AddRow(new string[] {
                        "[[outputValue]]"});
#line 13
  testRunner.And("\"Workflow 1\" has outputs as", ((string)(null)), table1076, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1077 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1077.AddRow(new string[] {
                        "[[rec().a]]"});
            table1077.AddRow(new string[] {
                        "[[rec().b]]"});
#line 16
  testRunner.Given("I have \"Workflow 2\" with inputs as", ((string)(null)), table1077, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1078 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1078.AddRow(new string[] {
                        "[[returnVal]]"});
#line 20
  testRunner.And("\"Workflow 2\" has outputs as", ((string)(null)), table1078, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1079 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1079.AddRow(new string[] {
                        "[[A]]"});
            table1079.AddRow(new string[] {
                        "[[B]]"});
            table1079.AddRow(new string[] {
                        "[[C]]"});
#line 23
  testRunner.Given("I have \"Workflow 3\" with inputs as", ((string)(null)), table1079, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1080 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1080.AddRow(new string[] {
                        "[[message]]"});
#line 28
  testRunner.And("\"Workflow 3\" has outputs as", ((string)(null)), table1080, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1081 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Var Name"});
            table1081.AddRow(new string[] {
                        "[[input]]"});
#line 31
  testRunner.Given("I have \"WorkflowWithTests\" with inputs as", ((string)(null)), table1081, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1082 = new TechTalk.SpecFlow.Table(new string[] {
                        "Ouput Var Name"});
            table1082.AddRow(new string[] {
                        "[[outputValue]]"});
#line 34
  testRunner.And("\"WorkflowWithTests\" has outputs as", ((string)(null)), table1082, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1083 = new TechTalk.SpecFlow.Table(new string[] {
                        "TestName",
                        "AuthenticationType",
                        "Error",
                        "TestFailing",
                        "TestPending",
                        "TestInvalid",
                        "TestPassed"});
            table1083.AddRow(new string[] {
                        "Test1",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "false",
                        "true"});
            table1083.AddRow(new string[] {
                        "Test2",
                        "Windows",
                        "false",
                        "true",
                        "false",
                        "false",
                        "false"});
            table1083.AddRow(new string[] {
                        "Test3",
                        "Windows",
                        "false",
                        "false",
                        "false",
                        "true",
                        "false"});
            table1083.AddRow(new string[] {
                        "Test4",
                        "Windows",
                        "false",
                        "false",
                        "true",
                        "false",
                        "false"});
#line 37
  testRunner.And("\"WorkflowWithTests\" Tests as", ((string)(null)), table1083, "And ");
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
            TechTalk.SpecFlow.Table table1084 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input to Service",
                        "From Variable",
                        "Output from Service",
                        "To Variable"});
            table1084.AddRow(new string[] {
                        "",
                        "",
                        "name",
                        "[[rec(*).name]]"});
            table1084.AddRow(new string[] {
                        "",
                        "",
                        "email",
                        "[[rec(*).email]]"});
#line 47
   testRunner.And("\"MySqlTestWF\" contains a mysql database service \"MySqlEmail\" with mappings for te" +
                    "sting as", ((string)(null)), table1084, "And ");
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
            TechTalk.SpecFlow.Table table1085 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1085.AddRow(new string[] {
                        "[[MySqlEmail(1).name]]",
                        "=",
                        "Monk"});
            table1085.AddRow(new string[] {
                        "[[MySqlEmail(1).email]]",
                        "=",
                        "dora@explorers.com"});
#line 57
  testRunner.And("I add StepOutputs as", ((string)(null)), table1085, "And ");
#line 61
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 62
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 65
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 66
  testRunner.Given("I depend on a valid MSSQL server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 67
  testRunner.And("I have a workflow \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1086 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table1086.AddRow(new string[] {
                        "Prefix",
                        "D"});
#line 68
  testRunner.And("\"SqlTestWF\" contains a sqlserver database service \"dbo.Pr_CitiesGetCountries\" wit" +
                    "h mappings for testing as", ((string)(null)), table1086, "And ");
#line 71
  testRunner.And("I save workflow \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
  testRunner.Then("the test builder is open with \"SqlTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
  testRunner.And("I Add \"dbo.Pr_CitiesGetCountries\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1087 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1087.AddRow(new string[] {
                        "[[dbo_Pr_CitiesGetCountries(2).CountryID]]",
                        "=",
                        "40"});
            table1087.AddRow(new string[] {
                        "[[dbo_Pr_CitiesGetCountries(2).Description]]",
                        "=",
                        "Djibouti"});
#line 77
  testRunner.And("I add StepOutputs as", ((string)(null)), table1087, "And ");
#line 81
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 85
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 86
  testRunner.Given("I have a workflow \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1088 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table1088.AddRow(new string[] {
                        "P_DEPTNO",
                        "110"});
#line 87
   testRunner.And("\"oracleTestWF\" contains a oracle database service \"HR.GET_EMP_RS\" with mappings a" +
                    "s", ((string)(null)), table1088, "And ");
#line 90
  testRunner.And("I save workflow \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
  testRunner.Then("the test builder is open with \"oracleTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
  testRunner.And("I Add \"HR.GET_EMP_RS\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1089 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1089.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).EMPLOYEE_ID]]",
                        "=",
                        "205"});
            table1089.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).FIRST_NAME]]",
                        "=",
                        "Shelley"});
            table1089.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).LAST_NAME]]",
                        "=",
                        "Higgins"});
            table1089.AddRow(new string[] {
                        "[[HR_GET_EMP_RS(2).EMAIL]]",
                        "=",
                        "SHIGGINS"});
#line 96
  testRunner.And("I add StepOutputs as", ((string)(null)), table1089, "And ");
#line 102
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 103
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 106
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 107
  testRunner.Given("I depend on a valid PostgreSQL server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 108
  testRunner.And("I have a workflow \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1090 = new TechTalk.SpecFlow.Table(new string[] {
                        "ParameterName",
                        "ParameterValue"});
            table1090.AddRow(new string[] {
                        "Prefix",
                        "K"});
#line 109
  testRunner.And("\"PostGreTestWF\" contains a postgre tool using \"get_countries\" with mappings for t" +
                    "esting as", ((string)(null)), table1090, "And ");
#line 112
  testRunner.And("I save workflow \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
  testRunner.Then("the test builder is open with \"PostGreTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
  testRunner.And("I Add \"get_countries\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1091 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1091.AddRow(new string[] {
                        "[[get_countries(1).id]]",
                        "=",
                        "2"});
#line 118
  testRunner.And("I add StepOutputs as", ((string)(null)), table1091, "And ");
#line 121
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 125
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 126
  testRunner.Given("I have a workflow \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1092 = new TechTalk.SpecFlow.Table(new string[] {
                        "variable",
                        "value"});
            table1092.AddRow(new string[] {
                        "[[A]]",
                        "30"});
#line 127
  testRunner.And("\"DecisionTestWF\" contains an Assign \"TestAssign\" as", ((string)(null)), table1092, "And ");
#line 130
  testRunner.And("a decision variable \"[[A]]\" value \"30\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
  testRunner.And("decide if \"[[A]]\" \"IsAlphanumeric\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 132
  testRunner.And("I save workflow \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 133
  testRunner.Then("the test builder is open with \"DecisionTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 134
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 135
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
  testRunner.And("I Add \"TestDecision\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1093 = new TechTalk.SpecFlow.Table(new string[] {
                        "Step Name",
                        "Output Variable",
                        "Output Value",
                        "Activity Type"});
            table1093.AddRow(new string[] {
                        "If [[Name]] <> (Not Equal)",
                        "Flow Arm",
                        "True",
                        "Decision"});
#line 138
  testRunner.And("I add Assert steps as", ((string)(null)), table1093, "And ");
#line 141
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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
#line 145
this.ScenarioSetup(scenarioInfo);
#line 8
this.FeatureBackground();
#line 146
  testRunner.Given("I depend on a valid MSSQL server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 147
  testRunner.And("I have a workflow \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1094 = new TechTalk.SpecFlow.Table(new string[] {
                        "Column",
                        "Mapping",
                        "IsNullable",
                        "DataTypeName",
                        "MaxLength",
                        "IsAutoIncrement"});
            table1094.AddRow(new string[] {
                        "Name",
                        "Warewolf",
                        "false",
                        "varchar",
                        "50",
                        "false"});
            table1094.AddRow(new string[] {
                        "Email",
                        "Warewolf@dev2.co.za",
                        "false",
                        "varchar",
                        "50",
                        "false"});
#line 148
  testRunner.And("\"SqlBulkTestWF\" contains an SQL Bulk Insert \"BulkInsert\" using database \"NewSqlBu" +
                    "lkInsertSource\" and table \"dbo.MailingList\" and KeepIdentity set \"true\" and Resu" +
                    "lt set \"[[result]]\" for testing as", ((string)(null)), table1094, "And ");
#line 152
  testRunner.And("I save workflow \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
  testRunner.Then("the test builder is open with \"SqlBulkTestWF\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
  testRunner.And("I click New Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
  testRunner.And("a new test is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
  testRunner.And("test name starts with \"Test 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 157
  testRunner.And("I Add \"BulkInsert\" as TestStep", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1095 = new TechTalk.SpecFlow.Table(new string[] {
                        "Variable Name",
                        "Condition",
                        "Value"});
            table1095.AddRow(new string[] {
                        "[[result]]",
                        "=",
                        "Success"});
#line 158
  testRunner.And("I add StepOutputs as", ((string)(null)), table1095, "And ");
#line 161
  testRunner.When("I save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 162
  testRunner.And("I run the test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 163
  testRunner.Then("test result is Passed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
