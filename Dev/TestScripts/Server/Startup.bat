REM ********************************************************************************************************************
REM * Hi-Jack the Auto Build Variables by QtAgent since this is injected after it has REM * setup
REM * Open the autogenerated qtREM * setup in the test run location of
REM * C:\Users\IntegrationTester\AppData\Local\VSEQT\QTAgent\...
REM * For example:
REM * set DeploymentDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set TestRunDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set TestRunResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set TotalAgents=5
REM * set AgentWeighting=100
REM * set AgentLoadDistributor=Microsoft.VisualStudio.TestTools.Execution.AgentLoadDistributor
REM * set AgentId=1
REM * set TestDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1
REM * set ResultsDirectory=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results
REM * set DataCollectionEnvironmentContext=Microsoft.VisualStudio.TestTools.Execution.DataCollectionEnvironmentContext
REM * set TestLogsDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\Results\RSAKLF~1
REM * set ControllerName=rsaklfsvrtfsbld:6901
REM * set TestDeploymentDir=C:\Users\INTEGR~1\AppData\Local\VSEQT\QTAgent\54371B~1\RSAKLF~1\DEPLOY~1
REM * set AgentName=RSAKLFTST7X64-3
REM ********************************************************************************************************************

REM ** Check for admin **
echo Administrative permissions required. Detecting permissions...
REM using the "net session" command to detect admin, it requires elevation in the most operating systems - Ashley
IF NOT EXIST %windir%\nircmd.exe (net session >nul 2>&1) else (nircmd elevate net session >nul 2>&1)
if %errorLevel% == 0 (
	echo Success: Administrative permissions confirmed.
) else (
	echo Failure: Current permissions inadequate.
	exit 1
)
	
REM ** Kill The Server **
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.exe" /T /F) else (taskkill /im "Warewolf Server.exe" /T /F)

REM  Wait 5 seconds ;)
ping -n 5 -w 1000 192.0.2.2 > nul

REM ** Delete the Warewolf ProgramData folder
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q %PROGRAMDATA%\Warewolf\Resources) else (rd /S /Q %PROGRAMDATA%\Warewolf\Resources)
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q %PROGRAMDATA%\Warewolf\Workspaces) else (rd /S /Q %PROGRAMDATA%\Warewolf\Workspaces)
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings\") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings\")
rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings\"
rd /S /Q "%PROGRAMDATA%\Warewolf\Resources"
rd /S /Q "%PROGRAMDATA%\Warewolf\Workspaces"

REM Init paths to Warewolf server under test
IF "%DeploymentDirectory%"=="" IF EXIST "%~dp0..\..\Dev2.Server\bin\Debug\Warewolf Server.exe" SET DeploymentDirectory=%~dp0..\..\Dev2.Server\bin\Debug
IF EXIST "%DeploymentDirectory%\Server\Warewolf Server.exe" SET DeploymentDirectory=%DeploymentDirectory%\Server
IF EXIST "%DeploymentDirectory%\ServerStarted" DEL "%DeploymentDirectory%\ServerStarted"

REM ** Start Warewolf server from deployed binaries **
IF EXIST %windir%\nircmd.exe (nircmd elevate "%DeploymentDirectory%\Warewolf Server.exe") else (START "%DeploymentDirectory%\Warewolf Server.exe" /D "%DeploymentDirectory%" "Warewolf Server.exe")
@echo Started "%DeploymentDirectory%\Warewolf Server.exe".

REM using the "ping" command as make-shift wait (or sleep) command, so now we wait for the server started file to appear - Ashley
:WaitForServerStart
set /a LoopCounter=0
:MainLoopBody
IF EXIST "%DeploymentDirectory%\ServerStarted" exit 0
set /a LoopCounter=LoopCounter+1
IF %LoopCounter% EQU 30 exit 1
rem wait for 5 seconds before trying again
@echo %AgentName% is attempting number %LoopCounter% out of 30: Waiting 5 more seconds for "%DeploymentDirectory%\ServerStarted" file to appear...
ping -n 5 -w 1000 192.0.2.2 > nul
goto MainLoopBody