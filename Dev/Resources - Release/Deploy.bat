rmdir /S /Q "%programdata%\Warewolf\Resources"
rmdir /S /Q "%programdata%\Warewolf\Tests"
rmdir /S /Q "%programdata%\Warewolf\Workspaces"
rmdir /S /Q "%programdata%\Warewolf\Temp"
rmdir /S /Q "%programdata%\Warewolf\Audits"
rmdir /S /Q "%programdata%\Warewolf\VersionControl"
echo d | xcopy /-Y /E "%~dp0Resources" "%programdata%\Warewolf\Resources"
echo d | xcopy /-Y /E "%~dp0Tests" "%programdata%\Warewolf\Tests"
echo d | xcopy /-Y /E "%~dp0Audits" "%programdata%\Warewolf\Audits"
powershell -ExecutionPolicy Bypass -Command "Invoke-WebRequest http://localhost:3142/services/FetchExplorerItemsService.json?ReloadResourceCatalogue=true -UseBasicParsing -UseDefaultCredentials"