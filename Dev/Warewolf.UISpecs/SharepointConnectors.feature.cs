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
namespace Warewolf.UISpecs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class SharepointConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SharepointConnectors.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "SharepointConnector", "\tIn order to connect to sharepoint servers\r\n\tAs a Warewolf Studio user\r\n\tI want t" +
                    "o perform a composition of recorded actions", ProgrammingLanguage.CSharp, new string[] {
                        "SharepointConnector"});
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "SharepointConnector")))
            {
                Warewolf.UISpecs.SharepointConnectorFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Create Sharepoint Source From Tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "SharepointConnector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("SharepointConnector")]
        public virtual void CreateSharepointSourceFromTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Sharepoint Source From Tool", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("The Warewolf Studio is running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I Click New Workflow Ribbon Button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.And("I Drag Toolbox Sharepoint CopyFile Onto DesignSurface", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("I Click New Source Button From SharepointCopyFile Tool", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I Enter Sharepoint ServerSource ServerName", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.And("I Click User Button On Sharepoint Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 14
 testRunner.And("I Enter Sharepoint ServerSource User Credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("I Click Sharepoint Server Source TestConnection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
