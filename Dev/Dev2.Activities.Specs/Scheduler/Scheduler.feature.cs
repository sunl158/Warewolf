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
namespace Dev2.Activities.Specs.Scheduler
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SchedulerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Scheduler.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Scheduler", "\tIn order to schedule workflows\r\n\tAs a Warewolf user\r\n\tI want to setup schedules", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Scheduler")))
            {
                Dev2.Activities.Specs.Scheduler.SchedulerFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Schedule with history")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void ScheduleWithHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Schedule with history", new string[] {
                        "Scheduler"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
      testRunner.Given("I have a schedule \"ScheduleWithHistory\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
   testRunner.And("\"ScheduleWithHistory\" executes an Workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
   testRunner.And("the task status \"Status\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.And("\"ScheduleWithHistory\" has a username of \"LocalSchedulerAdmin\" and a Password of \"" +
                    "987Sched#@!\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Interval",
                        "StartDate",
                        "StartTime",
                        "Recurs",
                        "RecursInterval",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table1.AddRow(new string[] {
                        "On a schedule",
                        "Daily",
                        "2014/01/01",
                        "15:40:44",
                        "1",
                        "day",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 13
   testRunner.And("\"ScheduleWithHistory\" has a Schedule of", ((string)(null)), table1, "And ");
#line 16
   testRunner.When("the \"ScheduleWithHistory\" is executed \"1\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
   testRunner.Then("the Schedule task has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 18
   testRunner.Then("the schedule status is \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
   testRunner.And("\"ScheduleWithHistory\" has \"2\" row of history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table2.AddRow(new string[] {
                        "1",
                        "[[Message]] = String"});
#line 20
   testRunner.And("the history debug output for \"ScheduleWithHistory\" for row \"1\" is", ((string)(null)), table2, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating task with schedule statud disabled")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void CreatingTaskWithScheduleStatudDisabled()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating task with schedule statud disabled", new string[] {
                        "Scheduler"});
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
      testRunner.Given("I have a schedule \"Diceroll00\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
   testRunner.And("\"Diceroll00\" executes an Workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
   testRunner.And("the task status \"Status\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
   testRunner.And("\"Diceroll00\" has a username of \"IntegrationTester\" and a Password of \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Interval",
                        "StartDate",
                        "StartTime",
                        "Recurs",
                        "RecursInterval",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table3.AddRow(new string[] {
                        "On a schedule",
                        "\"Daily\"",
                        "2014/01/01",
                        "15:40:44",
                        "1",
                        "day",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 31
   testRunner.And("\"Diceroll00\" has a Schedule of", ((string)(null)), table3, "And ");
#line 34
   testRunner.When("the \"Diceroll00\" is executed \"1\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
   testRunner.Then("the Schedule task has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
   testRunner.Then("the schedule status is \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Setting schedule task \"At log on\"")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void SettingScheduleTaskAtLogOn()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Setting schedule task \"At log on\"", new string[] {
                        "Scheduler"});
#line 39
this.ScenarioSetup(scenarioInfo);
#line 40
      testRunner.Given("I have a schedule \"Diceroll1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
   testRunner.And("\"Diceroll1\" executes an Workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
   testRunner.And("the task status \"Status\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.And("\"Diceroll1\" has a username of \"LocalSchedulerAdmin\" and a Password of \"987Sched#@" +
                    "!\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table4.AddRow(new string[] {
                        "At log on",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 45
   testRunner.And("\"Diceroll1\" has a Schedule of", ((string)(null)), table4, "And ");
#line 48
   testRunner.Then("the Schedule task has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
   testRunner.When("the \"Diceroll1\" is executed \"1\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
   testRunner.Then("the schedule status is \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 51
   testRunner.And("\"Diceroll1\" has \"2\" row of history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table5.AddRow(new string[] {
                        "1",
                        "[[Message]] = String"});
#line 52
   testRunner.And("the history debug output for \"ScheduleWithHistory\" for row \"1\" is", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Schedule the task with Incorrect username or password")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void ScheduleTheTaskWithIncorrectUsernameOrPassword()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Schedule the task with Incorrect username or password", new string[] {
                        "Scheduler"});
#line 57
this.ScenarioSetup(scenarioInfo);
#line 58
      testRunner.Given("I have a schedule \"Diceroll1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 59
   testRunner.And("\"Diceroll1\" executes an Workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
   testRunner.And("the task status \"Status\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
   testRunner.And("\"Diceroll1\" has a username of \"bobthebuilder\" and a Password of \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table6.AddRow(new string[] {
                        "At log on",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 63
   testRunner.And("\"Diceroll1\" has a Schedule of", ((string)(null)), table6, "And ");
#line 66
   testRunner.Then("the Schedule task has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Schedule with LocalUser")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void ScheduleWithLocalUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Schedule with LocalUser", new string[] {
                        "Scheduler"});
#line 69
this.ScenarioSetup(scenarioInfo);
#line 70
      testRunner.Given("I have a schedule \"LocalUserSchedule\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 71
   testRunner.And("\"LocalUserSchedule\" executes an Workflow \"Hello World\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
   testRunner.And("the task status \"Status\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
   testRunner.And("\"LocalUserSchedule\" has a username of \"LocalSchedulerAdmin\" and a Password of \"98" +
                    "7Sched#@!\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Interval",
                        "StartDate",
                        "StartTime",
                        "Recurs",
                        "RecursInterval",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table7.AddRow(new string[] {
                        "On a schedule",
                        "Daily",
                        "2014/01/01",
                        "15:40:44",
                        "1",
                        "day",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 75
   testRunner.And("\"LocalUserSchedule\" has a Schedule of", ((string)(null)), table7, "And ");
#line 78
   testRunner.When("the \"LocalUserSchedule\" is executed \"1\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
   testRunner.Then("the Schedule task has \"No\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
   testRunner.Then("the schedule status is \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
   testRunner.And("\"LocalUserSchedule\" has \"2\" row of history", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "#",
                        ""});
            table8.AddRow(new string[] {
                        "1",
                        "[[Message]] = String"});
#line 82
   testRunner.And("the history debug output for \"LocalUserSchedule\" for row \"1\" is", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Schedule with ErrorInDebug")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Scheduler")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Scheduler")]
        public virtual void ScheduleWithErrorInDebug()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Schedule with ErrorInDebug", new string[] {
                        "Scheduler"});
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
      testRunner.Given("I have a schedule \"ScheduleWithError\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
   testRunner.And("\"ScheduleWithError\" executes an Workflow \"moocowimpi\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
   testRunner.And("task history \"Number of history records to load\" is \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 91
   testRunner.And("the task status \"Status\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
   testRunner.And("\"ScheduleWithError\" has a username of \"dev2\\IntegrationTester\" and a Password of " +
                    "\"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "ScheduleType",
                        "Interval",
                        "StartDate",
                        "StartTime",
                        "Recurs",
                        "RecursInterval",
                        "Delay",
                        "DelayInterval",
                        "Repeat",
                        "RepeatInterval",
                        "ExpireDate",
                        "ExpireTime"});
            table9.AddRow(new string[] {
                        "On a schedule",
                        "Daily",
                        "2014/01/01",
                        "15:40:44",
                        "1",
                        "day",
                        "1",
                        "hour",
                        "1",
                        "hour",
                        "2014/01/02",
                        "15:40:15"});
#line 93
   testRunner.And("\"ScheduleWithError\" has a Schedule of", ((string)(null)), table9, "And ");
#line 96
   testRunner.When("the \"ScheduleWithError\" is executed \"1\" times", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 97
   testRunner.Then("the Schedule task has \"An\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 98
   testRunner.Then("the schedule status is \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
