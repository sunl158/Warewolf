/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Activities.Specs.BaseTypes;
using System;
using System.Activities.Statements;
using Dev2.Interfaces;
using TechTalk.SpecFlow;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Tools.Specs.BaseTypes;

namespace Dev2.Activities.Specs.Toolbox.FileAndFolder.Create
{
    [Binding]
    public class CreateSteps : FileToolsBase
    {
        public CreateSteps(ScenarioContext scenarioContext)
            : base(scenarioContext)
        {
        }

        [When(@"the create file tool is executed")]
        public void WhenTheCreateFileToolIsExecuted()
        {
            BuildDataList();
            var result = ExecuteProcess(isDebug: true, throwException: false);
            scenarioContext.Add("result", result);
        }

        #region Overrides of RecordSetBases

        protected override void BuildDataList()
        {
            BuildShapeAndTestData();

            scenarioContext.TryGetValue(CommonSteps.DestinationPrivateKeyFile, out string privateKeyFile);
            var create = new DsfPathCreate
            {
                OutputPath = scenarioContext.Get<string>(CommonSteps.DestinationHolder),
                Username = scenarioContext.Get<string>(CommonSteps.DestinationUsernameHolder).ResolveDomain(),
                Password = scenarioContext.Get<string>(CommonSteps.DestinationPasswordHolder),
                Overwrite = scenarioContext.Get<bool>(CommonSteps.OverwriteHolder),
                Result = scenarioContext.Get<string>(CommonSteps.ResultVariableHolder),
                PrivateKeyFile = privateKeyFile
            };

            TestStartNode = new FlowStep
            {
                Action = create
            };

            scenarioContext.Add("activity", create);
        }

        #endregion
    }
}
