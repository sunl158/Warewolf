﻿if ([string]::IsNullOrEmpty($PSScriptRoot)) {
	$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent
}
$WorkingDir = (Get-Item $PSScriptRoot).FullName
# Read playlists and args.
$TestList = ""
if ($Args.Count -gt 0) {
    $TestList = $Args.ForEach({ "," + $_ })
} else {
    Get-ChildItem "$PSScriptRoot" -Filter *.playlist | `
    Foreach-Object{
	    [xml]$playlistContent = Get-Content $_.FullName
	    if ($playlistContent.Playlist.Add.count -gt 0) {
	        foreach( $TestName in $playlistContent.Playlist.Add) {
		        $TestList += "," + $TestName.Test.SubString($TestName.Test.LastIndexOf(".") + 1)
	        }
	    } else {        
            if ($playlistContent.Playlist.Add.Test -ne $null) {
                $TestList = " /Tests:" + $playlistContent.Playlist.Add.Test.SubString($playlistContent.Playlist.Add.Test.LastIndexOf(".") + 1)
            } else {
	            Write-Host Error parsing Playlist.Add from playlist file at $_.FullName
            }
        }
    }
}
if ($TestList.StartsWith(",")) {
	$TestList = $TestList -replace "^.", " /Tests:"
}

# Create test settings.
$TestSettingsFile = "$PSScriptRoot\PluginConnectorUISpecs.testsettings"
[system.io.file]::WriteAllText($TestSettingsFile,  @"
<?xml version=`"1.0`" encoding="UTF-8"?>
<TestSettings
  id=`"
"@ + [guid]::NewGuid() + @"
`"
  name=`"PluginConnectorUISpecs`"
  enableDefaultDataCollectors=`"false`"
  xmlns=`"http://microsoft.com/schemas/VisualStudio/TeamTest/2010`">
  <Description>Run Plugin Connector UI Specs.</Description>
  <Deployment enabled=`"false`" />
  <NamingScheme baseName=`"UI`" appendTimeStamp=`"false`" useDefault=`"false`" />
  <Execution>
    <Timeouts testTimeout=`"300000`" />
  </Execution>
</TestSettings>
"@)

# Find test assembly
$TestAssemblyPath = ""
if (Test-Path "$WorkingDir\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$WorkingDir\..\..\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$WorkingDir\..\..\..\..\..\Warewolf.UISpecs.dll"
}
if ($TestAssemblyPath -ne "") {
	Write-Host Cannot find Warewolf.UISpecs.dll at $WorkingDir\Warewolf.UISpecs\bin\Debug or $WorkingDir
	exit 1
}

# Create full VSTest argument string.
if ($TestList -eq "") {
	$FullArgsList = " `"" + $TestAssemblyPath + "`" /logger:trx /Settings:`"" + $TestSettingsFile + "`"" + " /TestCaseFilter:`"TestCategory=PluginConnector`""
} else {
	$FullArgsList = " `"" + $TestAssemblyPath + "`" /logger:trx /Settings:`"" + $TestSettingsFile + "`"" + $TestList
}

# Display full command including full argument string.
Write-Host $WorkingDir> `"$env:vs140comntools..\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.console.exe`"$FullArgsList

# Write full command including full argument string.
Out-File -LiteralPath $PSScriptRoot\RunTests.bat -Encoding default -InputObject `"$env:vs140comntools..\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.console.exe`"$FullArgsList