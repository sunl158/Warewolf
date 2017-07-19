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
namespace Warewolf.ToolsSpecs.Toolbox.Resources.SqlServer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SqlServerConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SqlServerConnector.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SqlServerConnector", "\tIn order to manage my database services\r\n\tAs a Warewolf User\r\n\tI want to be show" +
                    "n the database service setup", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "SqlServerConnector")))
            {
                Warewolf.ToolsSpecs.Toolbox.Resources.SqlServer.SqlServerConnectorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Saved workflow with SQL Server tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void OpeningSavedWorkflowWithSQLServerTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Saved workflow with SQL Server tool", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
   testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1493 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1493.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 12
 testRunner.And("Inputs appear as", ((string)(null)), table1493, "And ");
#line 15
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1494 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1494.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table1494.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 16
 testRunner.Then("Outputs appear as", ((string)(null)), table1494, "Then ");
#line 20
 testRunner.And("Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change SQL Server Source on Existing tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void ChangeSQLServerSourceOnExistingTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change SQL Server Source on Existing tool", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 23
 testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.And("Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 25
 testRunner.And("Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1495 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1495.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 28
 testRunner.And("Inputs appear as", ((string)(null)), table1495, "And ");
#line 31
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1496 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1496.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table1496.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 32
 testRunner.Then("Outputs appear as", ((string)(null)), table1496, "Then ");
#line 36
 testRunner.And("Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("Source is changed from to \"GreenPoint\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("Action is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing SQL Server Actions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ChangingSqlServerFunctions")]
        public virtual void ChangingSQLServerActions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing SQL Server Actions", new string[] {
                        "ChangingSqlServerFunctions"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
 testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.And("Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1497 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1497.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 50
 testRunner.And("Inputs appear as", ((string)(null)), table1497, "And ");
#line 53
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1498 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1498.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table1498.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 54
 testRunner.Then("Outputs appear as", ((string)(null)), table1498, "Then ");
#line 58
 testRunner.And("Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.When("Action is changed from to \"dbo.ImportOrder\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 60
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1499 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1499.AddRow(new string[] {
                        "ProductId",
                        "[[ProductId]]",
                        "false"});
#line 61
 testRunner.And("Inputs appear as", ((string)(null)), table1499, "And ");
#line 64
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change SQL Server Recordset Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void ChangeSQLServerRecordsetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change SQL Server Recordset Name", ((string[])(null)));
#line 66
this.ScenarioSetup(scenarioInfo);
#line 67
 testRunner.Given("I open workflow with database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And("Source is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("Source is \"testingDBSrc\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("Inputs is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1500 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1500.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 73
 testRunner.And("Inputs appear as", ((string)(null)), table1500, "And ");
#line 76
 testRunner.And("Validate is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1501 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1501.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table1501.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 77
 testRunner.Then("Outputs appear as", ((string)(null)), table1501, "Then ");
#line 81
 testRunner.And("Recordset Name equals \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.When("Recordset Name is changed to \"Pr_Cities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1502 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1502.AddRow(new string[] {
                        "CountryID",
                        "[[Pr_Cities().CountryID]]"});
            table1502.AddRow(new string[] {
                        "Description",
                        "[[Pr_Cities().Description]]"});
#line 83
 testRunner.Then("Outputs appear as", ((string)(null)), table1502, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("No SQL Server Action to be loaded Error")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void NoSQLServerActionToBeLoadedError()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No SQL Server Action to be loaded Error", ((string[])(null)));
#line 88
this.ScenarioSetup(scenarioInfo);
#line 89
 testRunner.Given("I have a workflow \"NoStoredProceedureToLoad\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1503 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or [[Variable]]",
                        "Parameter",
                        "Empty is Null"});
#line 90
 testRunner.And("\"NoStoredProceedureToLoad\" contains \"Testing/SQL/NoSqlStoredProceedure\" from serv" +
                    "er \"localhost\" with mapping as", ((string)(null)), table1503, "And ");
#line 92
 testRunner.When("\"NoStoredProceedureToLoad\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("the sqlsERVER workflow execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1504 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1504.AddRow(new string[] {
                        "Error: The selected database does not contain actions to perform"});
#line 94
 testRunner.And("The sqlsERVER \"Testing/SQL/NoSqlStoredProceedure\" in Workflow \"NoStoredProceedure" +
                    "ToLoad\" debug outputs as", ((string)(null)), table1504, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Passing Null Input values to SQL Server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void PassingNullInputValuesToSQLServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Passing Null Input values to SQL Server", ((string[])(null)));
#line 98
this.ScenarioSetup(scenarioInfo);
#line 99
 testRunner.Given("I have a workflow \"PassingNullInputValue\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1505 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or [[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table1505.AddRow(new string[] {
                        "[[value]]",
                        "a",
                        "True"});
#line 100
 testRunner.And("\"PassingNullInputValue\" contains \"Acceptance Testing Resources/GreenPoint\" from s" +
                    "erver \"localhost\" with mapping as", ((string)(null)), table1505, "And ");
#line 103
 testRunner.When("\"PassingNullInputValue\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("the sqlsERVER workflow execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1506 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1506.AddRow(new string[] {
                        "Error: Scalar value { value } is NULL"});
#line 105
 testRunner.And("The sqlsERVER \"Acceptance Testing Resources/GreenPoint\" in Workflow \"PassingNullI" +
                    "nputValue\" debug outputs as", ((string)(null)), table1506, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Mapped To Recordsets incorrect")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void MappedToRecordsetsIncorrect()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Mapped To Recordsets incorrect", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("I have a workflow \"BadSqlParameterName\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1507 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or [[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table1507.AddRow(new string[] {
                        "",
                        "a",
                        "True"});
#line 111
 testRunner.And("\"BadSqlParameterName\" contains \"Acceptance Testing Resources/GreenPoint\" from ser" +
                    "ver \"localhost\" with mapping as", ((string)(null)), table1507, "And ");
#line hidden
            TechTalk.SpecFlow.Table table1508 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table1508.AddRow(new string[] {
                        "id",
                        "[[dbo_leon bob proc().id]]"});
            table1508.AddRow(new string[] {
                        "some column Name",
                        "[[dbo_leon bob proc().some column Name]]"});
#line 114
 testRunner.And("And \"BadSqlParameterName\" contains \"Acceptance Testing Resources/GreenPoint\" from" +
                    " server \"localhost\" with Mapping To as", ((string)(null)), table1508, "And ");
#line 118
 testRunner.When("\"BadSqlParameterName\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
 testRunner.Then("the sqlsERVER workflow execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1509 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1509.AddRow(new string[] {
                        "Error: Sql Error: parse error"});
#line 120
 testRunner.And("The sqlsERVER \"Acceptance Testing Resources/GreenPoint\" in Workflow \"BadSqlParame" +
                    "terName\" debug outputs as", ((string)(null)), table1509, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Parameter not found in the collection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void ParameterNotFoundInTheCollection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Parameter not found in the collection", ((string[])(null)));
#line 126
this.ScenarioSetup(scenarioInfo);
#line 127
 testRunner.Given("I have a workflow \"BadMySqlParameterName\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1510 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or [[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table1510.AddRow(new string[] {
                        "",
                        "`p_startswith`",
                        "false"});
#line 128
 testRunner.And("\"BadMySqlParameterName\" contains \"Testing/MySql/MySqlParameters\" from server \"loc" +
                    "alhost\" with mapping as", ((string)(null)), table1510, "And ");
#line 131
 testRunner.When("\"BadMySqlParameterName\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 132
 testRunner.Then("the sqlsERVER workflow execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1511 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1511.AddRow(new string[] {
                        "Parameter \"p_startswith\" not found in the collection"});
#line 133
 testRunner.And("The sqlsERVER \"Testing/MySql/MySqlParameters\" in Workflow \"BadMySqlParameterName\"" +
                    " debug outputs as", ((string)(null)), table1511, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Recordset has invalid character")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void RecordsetHasInvalidCharacter()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Recordset has invalid character", ((string[])(null)));
#line 138
this.ScenarioSetup(scenarioInfo);
#line 139
 testRunner.Given("I have a workflow \"MappingHasIncorrectCharacter\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1512 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input Data or [[Variable]]",
                        "Parameter",
                        "Empty is Null"});
            table1512.AddRow(new string[] {
                        "1",
                        "charValue",
                        "True"});
#line 140
 testRunner.And("\"MappingHasIncorrectCharacter\" contains \"Acceptance Testing Resources/GreenPoint\"" +
                    " from server \"localhost\" with mapping as", ((string)(null)), table1512, "And ");
#line 143
 testRunner.When("\"MappingHasIncorrectCharacter\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 144
 testRunner.Then("the sqlsERVER workflow execution has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1513 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table1513.AddRow(new string[] {
                        "[[dbo_ConvertTo,Int().result]] : Recordset name has invalid format"});
#line 145
 testRunner.And("The sqlsERVER \"Acceptance Testing Resources/GreenPoint\" in Workflow \"MappingHasIn" +
                    "correctCharacter\" debug outputs as", ((string)(null)), table1513, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("SqlServer backward Compatiblity")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SqlServerConnector")]
        public virtual void SqlServerBackwardCompatiblity()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("SqlServer backward Compatiblity", ((string[])(null)));
#line 150
this.ScenarioSetup(scenarioInfo);
#line 151
 testRunner.Given("I have a workflow \"DataMigration\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1514 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input to Service",
                        "From Variable",
                        "Output from Service",
                        "To Variable"});
            table1514.AddRow(new string[] {
                        "[[ProductId]]",
                        "productId",
                        "[[dbo_GetCountries().CountryID]]",
                        "dbo_GetCountries().CountryID"});
            table1514.AddRow(new string[] {
                        "",
                        "",
                        "[[dbo_GetCountries().Description]]",
                        "dbo_GetCountries().Description"});
#line 152
 testRunner.And("\"DataMigration\" contains \"DataCon\" from server \"localhost\" with mapping as", ((string)(null)), table1514, "And ");
#line 156
 testRunner.When("\"DataMigration\" is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
 testRunner.Then("the workflow execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
