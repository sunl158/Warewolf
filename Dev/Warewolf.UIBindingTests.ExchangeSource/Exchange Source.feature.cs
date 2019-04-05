// ------------------------------------------------------------------------------
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
namespace Warewolf.UIBindingTests.ExchangeSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ExchangeSourceFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Exchange Source.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Exchange Source", "\tIn order to avoid silly mistakes\r\n\tAs a math idiot\r\n\tI want to be told the sum o" +
                    "f two numbers", ProgrammingLanguage.CSharp, new string[] {
                        "ExchangeSource"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Exchange Source")))
            {
                global::Warewolf.UIBindingTests.ExchangeSource.ExchangeSourceFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating new exchange source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Exchange Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ExchangeSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ExchangeSource")]
        public virtual void CreatingNewExchangeSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating new exchange source", new string[] {
                        "ExchangeSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given("I open a new exchange source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.Then("\"New Exchange Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
 testRunner.And("Title is \"New Exchange Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.When("I Type Auto Discover as \"https://outlook.office365.com/EWS/Exchange.asmx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 18
 testRunner.When("I Type User Name as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.When("I Type Password as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.When("I Type TimeOut as \"1000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.When("I Type To Email as \"test@gmsil.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Testing new exchange source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Exchange Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ExchangeSource")]
        public virtual void TestingNewExchangeSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Testing new exchange source", new string[] {
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 28
this.ScenarioSetup(scenarioInfo);
#line 29
testRunner.Given("I open a new exchange source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.Then("\"New Exchange Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 31
 testRunner.And("Title is \"New Exchange Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.When("I Type Auto Discover as \"https://outlook.office365.com/EWS/Exchange.asmx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
 testRunner.When("I Type User Name as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
 testRunner.When("I Type Password as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.When("I Type TimeOut as \"1000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
 testRunner.When("I Type To Email as \"test@gmsil.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("I click on the Test Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Fail Send Shows correct error message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Exchange Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ExchangeSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("ExchangeSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DeploymentItem("Warewolf Studio.exe")]
        public virtual void FailSendShowsCorrectErrorMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Fail Send Shows correct error message", new string[] {
                        "ExchangeSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 45
this.ScenarioSetup(scenarioInfo);
#line 46
 testRunner.Given("I open a new exchange source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 47
 testRunner.Then("\"New Exchange Source\" tab is Opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("Title is \"New Exchange Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.When("I Type Auto Discover as \"https://outlook.office365.com/EWS/Exchange.asmx\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
 testRunner.When("I Type User Name as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
 testRunner.When("I Type Password as \"TestUser\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.When("I Type TimeOut as \"1000\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 53
 testRunner.When("I Type To Email as \"test@gmsil.com\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
 testRunner.And("Send is \"Unsuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.Then("Send is \"The request failed. The remote server returned an error: (401) Unauthori" +
                    "zed.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
