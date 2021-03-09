mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Warewolf.UI.Tests -ExcludeCategories Settings,'Hello World Mocking Tests','Merge Variable Conflicts','Deploy from Explorer','Shortcut Keys','Object Search','Source Wizards','Deploy Select Dependencies','Tabs and Panes','Deploy Hello World','Server Sources','Merge Foreach','Input Search','Scalar Search','Merge Decision Conflicts','Merge Sequence Conflicts','HTTP Tools','Web Sources','Recordset Search','Assign Tool','Email Tools','Plugin Sources','Database Sources','Dependency Graph','Deploy Filtering','File Tools','Debug Input',Variables,'Studio Shutdown','Dropbox Tools','DotNet Connector Mocking Tests',MSSql,Deploy,'Merge All Tools Conflicts','Merge Switch Conflicts','Scheduler Delete Task','Merge Assign Conflicts','Default Layout',Scheduler,'Test Name Search','Sharepoint Tools','Deploy from Remote','Merge Simple Tools Conflicts','Database Tools',Tools,'Save Dialog','Utility Tools','Scheduler Delete Is Disabled','DotNet Connector Tool','Workflow Testing','Output Search','Workflow Mocking Tests','Control Flow Tools',Search,'Recordset Tools','Title Search','Service Search','Data Tools','Resource Tools' -PreTestRunScript 'StartAs.ps1 -Cleanup -Anonymous -ResourcesPath UITests' -PostTestRunScript 'ReverseDeployLog.ps1' -InContainer