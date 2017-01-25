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

set /a LoopCounter=0
:RetryClean
IF NOT EXIST "%PROGRAMDATA%\Warewolf\Resources" IF NOT EXIST "%PROGRAMDATA%\Warewolf\Tests" IF NOT EXIST "%PROGRAMDATA%\Warewolf\Workspaces" IF NOT EXIST "%PROGRAMDATA%\Warewolf\Server Settings" GOTO StopRetrying

IF NOT "%1"=="dotcover" (
	REM ** Soft Kill **
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.exe" /fi "STATUS eq RUNNING") else (taskkill /im "Warewolf Studio.exe" /fi "STATUS eq RUNNING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.exe" /fi "STATUS eq UNKNOWN") else (taskkill /im "Warewolf Studio.exe" /fi "STATUS eq UNKNOWN")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.exe" /fi "STATUS eq NOT RESPONDING") else (taskkill /im "Warewolf Studio.exe" /fi "STATUS eq NOT RESPONDING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq RUNNING") else (taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq RUNNING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq UNKNOWN")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq NOT RESPONDING") else (taskkill /im "Warewolf Studio.vshost.exe" /fi "STATUS eq NOT RESPONDING")
	waitfor StudioShutdown /t 60 2>NUL
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.exe" /fi "STATUS eq RUNNING") else (taskkill /im "Warewolf Server.exe" /fi "STATUS eq RUNNING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN") else (taskkill /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.exe" /fi "STATUS eq NOT RESPONDING") else (taskkill /im "Warewolf Server.exe" /fi "STATUS eq NOT RESPONDING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING") else (taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /im "Warewolf Server.vshost.exe" /fi "STATUS eq NOT RESPONDING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING") else (taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN") else (taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN")
	IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq NOT RESPONDING") else (taskkill /im WarewolfCOMIPC.exe /fi "STATUS eq NOT RESPONDING")
	waitfor ServerShutdown /t 180 2>NUL
)
	
REM ** Forced TaskKill **
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING") else (taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq RUNNING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING") else (taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq RUNNING")

IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN") else (taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq UNKNOWN")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN") else (taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq UNKNOWN")

IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq NOT RESPONDING") else (taskkill /f /im "Warewolf Server.exe" /fi "STATUS eq NOT RESPONDING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq NOT RESPONDING") else (taskkill /f /im "Warewolf Server.vshost.exe" /fi "STATUS eq NOT RESPONDING")
IF EXIST %windir%\nircmd.exe (nircmd elevate taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq NOT RESPONDING") else (taskkill /f /im WarewolfCOMIPC.exe /fi "STATUS eq NOT RESPONDING")

REM ** Delete the Warewolf ProgramData folder
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Resources") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Resources")
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Tests") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Tests")
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Workspaces") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Workspaces")
IF EXIST %windir%\nircmd.exe (nircmd elevate cmd /c rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings\") else (rd /S /Q "%PROGRAMDATA%\Warewolf\Server Settings")
@echo off
IF EXIST "%PROGRAMDATA%\Warewolf\Resources" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Resources
IF EXIST "%PROGRAMDATA%\Warewolf\Tests" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Tests
IF EXIST "%PROGRAMDATA%\Warewolf\Workspaces" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Workspaces
IF EXIST "%PROGRAMDATA%\Warewolf\Server Settings" echo ERROR CANNOT DELETE %PROGRAMDATA%\Warewolf\Server Settings
@echo on

set /a LoopCounter=LoopCounter+1
IF %LoopCounter% EQU 30 exit 1
rem wait for 5 seconds before trying again
@echo %AgentName% is attempting number %LoopCounter% out of 30: Waiting 5 more seconds for "%PROGRAMDATA%\Warewolf" folder cleanup...
waitfor ServerWorkspaceClean /t 5 2>NUL
set errorlevel=0
goto RetryClean

:StopRetrying
IF NOT "%1"=="" exit 0