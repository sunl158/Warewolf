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
namespace Warewolf.AcceptanceTesting.SharepointSource
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class SharepointFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Sharepoint.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Sharepoint", "In order to connect with Sharepoint Online\r\nAs a Warewolf User\r\nI want to be able" +
                    " to interact with a sharepoint server", ProgrammingLanguage.CSharp, new string[] {
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
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Sharepoint")))
            {
                Warewolf.AcceptanceTesting.SharepointSource.SharepointFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating New Sharepoint Source")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Sharepoint")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointSource")]
        public virtual void CreatingNewSharepointSource()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating New Sharepoint Source", new string[] {
                        "SharepointSource"});
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 10
   testRunner.Then("\"New SharePoint Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 11
   testRunner.And("title is \"New SharePoint Service Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.And("I type Address as \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
   testRunner.Then("\"New SharePoint Service Source *\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
   testRunner.When("I save as \"Testing Sharepoint Resource Save\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
   testRunner.Then("the save dialog is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
   testRunner.Then("title is \"Testing Sharepoint Resource Save\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 24
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
                        "SharepointSource"});
#line 27
this.ScenarioSetup(scenarioInfo);
#line 28
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 29
   testRunner.And("I type Address as \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
   testRunner.And("I type Username as \"IntegrationTester\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
   testRunner.And("I type Password as \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
   testRunner.When("I save the source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 40
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
                        "SharepointSource"});
#line 43
this.ScenarioSetup(scenarioInfo);
#line 44
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
   testRunner.And("I type Address as \"sdfsdfd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
   testRunner.When("Test Connecton is \"UnSuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 50
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
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
                        "SharepointSource"});
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
   testRunner.And("I type Address as \"sdfsdfd\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
   testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
   testRunner.And("I type Password as \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
   testRunner.When("Test Connecton is \"UnSuccessful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
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
                        "SharepointSource"});
#line 67
this.ScenarioSetup(scenarioInfo);
#line 68
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 69
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
   testRunner.And("I type Address as \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
   testRunner.And("I type Username as \"test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
   testRunner.And("I type Password as \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
   testRunner.And("Validation message is Not thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
   testRunner.And("I Select Authentication Type as \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
   testRunner.When("Test Connecton is \"Successful\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 84
   testRunner.And("Validation message is Not thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 85
   testRunner.And("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
   testRunner.And("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
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
                        "SharepointSource"});
#line 92
this.ScenarioSetup(scenarioInfo);
#line 93
   testRunner.Given("I open \"Test\" Sharepoint source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 94
   testRunner.Then("\"Test\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
   testRunner.And("title is \"Test\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
   testRunner.And("Address is \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
   testRunner.And("Authentication Type is \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
   testRunner.When("I type Address as \"http://rsaklfsvrshareps\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
   testRunner.Then("\"Test *\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 108
   testRunner.When("Test Connecton is \"Successfull\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 109
   testRunner.Then("\"Save\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 110
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
                        "SharepointSource"});
#line 113
 this.ScenarioSetup(scenarioInfo);
#line 114
   testRunner.Given("I open \"Test\" Sharepoint source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 115
   testRunner.Then("\"Test\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 116
   testRunner.And("Address is \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 117
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
   testRunner.And("\"Test Connection\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 119
   testRunner.And("Authentication Type is \"Windows\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 120
   testRunner.And("Username field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 121
   testRunner.And("Password field is \"Collapsed\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 122
   testRunner.When("I Select Authentication Type as \"User\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 123
   testRunner.And("Username field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
   testRunner.And("Password field is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
   testRunner.And("Username field as \"IntegrationTester\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
   testRunner.And("Password field as \"I73573r0\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 127
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 128
   testRunner.When("Test Connecton is \"Successfull\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 129
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
                        "SharepointSource"});
#line 132
this.ScenarioSetup(scenarioInfo);
#line 133
   testRunner.Given("I open New Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 134
   testRunner.Then("\"New SharePoint Service Source\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 135
   testRunner.And("title is \"New SharePoint Service Source\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
   testRunner.And("I type Address as \"http://rsaklfsvrsharep\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
   testRunner.When("Test Connecton is \"Long Running\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
   testRunner.And("I Cancel the Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 139
   testRunner.Then("\"Cancel Test\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 140
   testRunner.And("Validation message is thrown", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 141
   testRunner.And("Validation message is \"Test Cancelled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
