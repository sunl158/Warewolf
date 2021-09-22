mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Dev2.*.Tests,Warewolf.*.Tests,Warewolf.UIBindingTests.* -ExcludeProjects Dev2.Integration.Tests,Dev2.Studio.Core.Tests,Dev2.RunTime.Tests,Dev2.Infrastructure.Tests,Warewolf.UI.Tests,Warewolf.Logger.Tests,Warewolf.Studio.ViewModels.Tests,Warewolf.Web.UI.Tests,Warewolf.Storage.Tests,Warewolf.Auditing.Tests -ExcludeCategories CannotParallelize -Coverage