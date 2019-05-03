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
namespace Warewolf.UIBindingTests.SharepointSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.2.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SharepointFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "Sharepoint.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sharepoint", "\tIn order to connect with Sharepoint Online\r\n\tAs a Warewolf User\r\n\tI want to be a" +
                    "ble to interact with a sharepoint server", ProgrammingLanguage.CSharp, new string[] {
                        "SharepointSource"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "Sharepoint")))
            {
                global::Warewolf.UIBindingTests.SharepointSource.SharepointFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New Sharepoint Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void CreatingNewSharepointSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New Sharepoint Source", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
   testRunner.Then("\"New SharePoint Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 16
   testRunner.And("title is \"New SharePoint Service Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
   testRunner.And("I type Address as \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
   testRunner.Then("\"New SharePoint Service Source *\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 19
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
   testRunner.When("I save as \"Testing Sharepoint Resource Save\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
   testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 28
   testRunner.Then("title is \"Testing Sharepoint Resource Save\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
   testRunner.And("\"Testing Sharepoint Resource Save\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New Sharepoint Source under auth type as user")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void CreatingNewSharepointSourceUnderAuthTypeAsUser()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New Sharepoint Source under auth type as user", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 37
this.ScenarioSetup(scenarioInfo);
#line 38
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 39
   testRunner.And("I type Address as \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 40
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 42
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 43
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
   testRunner.And("I type Username as \"IntegrationTester\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.And("I type Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
   testRunner.When("I save the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
   testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Incorrect address anonymous auth type not allowing save")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void IncorrectAddressAnonymousAuthTypeNotAllowingSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect address anonymous auth type not allowing save", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 58
this.ScenarioSetup(scenarioInfo);
#line 59
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 60
   testRunner.And("I type Address as \"sdfsdfd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
   testRunner.When("Test Connecton is \"UnSuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Incorrect address Shows correct error message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void IncorrectAddressShowsCorrectErrorMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect address Shows correct error message", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 74
this.ScenarioSetup(scenarioInfo);
#line 75
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 76
   testRunner.And("I type Address as \"sdfsdfd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
   testRunner.When("Test Connecton is \"UnSuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 81
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
   testRunner.And("the error message is \"Unable to contact Server : Test Failed: Value does not fall" +
                    " within the expected range.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Incorrect address user auth type is not allowing to save")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void IncorrectAddressUserAuthTypeIsNotAllowingToSave()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Incorrect address user auth type is not allowing to save", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 91
this.ScenarioSetup(scenarioInfo);
#line 92
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 93
   testRunner.And("I type Address as \"sdfsdfd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
   testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
   testRunner.And("I type Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
   testRunner.When("Test Connecton is \"UnSuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Testing Auth type as Anonymous and swaping it resets the test connection")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void TestingAuthTypeAsAnonymousAndSwapingItResetsTheTestConnection()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Testing Auth type as Anonymous and swaping it resets the test connection", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
   testRunner.And("I type Address as \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 113
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 114
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 116
   testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
   testRunner.And("I type Password", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
   testRunner.And("Validation message is Not thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
   testRunner.And("Validation message is Not thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 129
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 130
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 131
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved Sharepoint Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void EditingSavedSharepointSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved Sharepoint Source", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 139
this.ScenarioSetup(scenarioInfo);
#line 140
   testRunner.Given("I open \"Test\" Sharepoint source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 141
   testRunner.Then("\"Test\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
   testRunner.And("title is \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 143
   testRunner.And("Address is \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 144
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 145
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 146
   testRunner.And("Authentication Type is \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 147
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 148
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 150
   testRunner.When("I type Address as \"http://rsaklfsvrdevs\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 151
   testRunner.Then("\"Test *\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 152
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 153
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 154
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
   testRunner.When("Test Connecton is \"Successfull\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 156
   testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 157
   testRunner.When("I save the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing saved Sharepoint Source auth type")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void EditingSavedSharepointSourceAuthType()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing saved Sharepoint Source auth type", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 165
 this.ScenarioSetup(scenarioInfo);
#line 166
   testRunner.Given("I open \"Test\" Sharepoint source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 167
   testRunner.Then("\"Test\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 168
   testRunner.And("Address is \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 169
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 170
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
   testRunner.And("Authentication Type is \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 173
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 174
   testRunner.When("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 175
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 176
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 177
   testRunner.And("Username field as \"IntegrationTester\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 178
   testRunner.And("Password field as \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 179
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 180
   testRunner.When("Test Connecton is \"Successfull\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 181
   testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Cancel Test")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void CancelTest()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Cancel Test", new string[] {
                        "SharepointSource",
                        "MSTest:DeploymentItem:InfragisticsWPF4.Controls.Interactions.XamDialogWindow.v15." +
                            "1.dll",
                        "MSTest:DeploymentItem:Warewolf_Studio.exe",
                        "MSTest:DeploymentItem:Newtonsoft.Json.dll",
                        "MSTest:DeploymentItem:Microsoft.Practices.Prism.SharedInterfaces.dll",
                        "MSTest:DeploymentItem:System.Windows.Interactivity.dll"});
#line 189
this.ScenarioSetup(scenarioInfo);
#line 190
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 191
   testRunner.Then("\"New SharePoint Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 192
   testRunner.And("title is \"New SharePoint Service Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 193
   testRunner.And("I type Address as \"http://rsaklfsvrdev\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 194
   testRunner.When("Test Connecton is \"Long Running\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 195
   testRunner.And("I Cancel the Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 196
   testRunner.Then("\"Cancel Test\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 197
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 198
   testRunner.And("Validation message is \"Test Cancelled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

