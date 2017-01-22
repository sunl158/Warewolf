﻿# Read playlists and args.
$TestList = ""
if ($Args.Count -gt 0) {
    $TestList = $Args.ForEach({ "," + $_ })
} else {
    Get-ChildItem "$PSScriptRoot" -Filter *.playlist | `
    Foreach-Object{
	    [xml]$playlistContent = Get-Content $_.FullName
	    if ($playlistContent.Playlist.Add.count -gt 0) {
	        foreach( $TestName in $playlistContent.Playlist.Add) {
		        $TestList += " /test:" + $TestName.Test.SubString($TestName.Test.LastIndexOf(".") + 1)
	        }
	    } else {        
            if ($playlistContent.Playlist.Add.Test -ne $null) {
                $TestList = " /test:" + $playlistContent.Playlist.Add.Test.SubString($playlistContent.Playlist.Add.Test.LastIndexOf(".") + 1)
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
if (Test-Path "$PSScriptRoot\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\..\..\Warewolf.UISpecs\bin\Debug\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\..\..\Warewolf.UISpecs.dll"
}
elseif (Test-Path "$PSScriptRoot\..\..\..\..\..\Warewolf.UISpecs.dll") {
	$TestAssemblyPath = "$PSScriptRoot\..\..\..\..\..\Warewolf.UISpecs.dll"
}
if ($TestAssemblyPath -ne ""){
	Write-Host Cannot find Warewolf.UISpecs.dll at $PSScriptRoot\Warewolf.UISpecs\bin\Debug or $PSScriptRoot
	exit 1
}
if (!(Test-Path $PSScriptRoot\TestResults)) {
	New-Item -ItemType Directory $PSScriptRoot\TestResults
}

if ($TestList -eq "") {
	# Create full MSTest argument string.
	$FullArgsList = " /testcontainer:`"" + $TestAssemblyPath + "`" /resultsfile:`"" + $PSScriptRoot + "\TestResults\PluginConnectorUISpecs.trx`" /testsettings:`"" + $TestSettingsFile + "`"" + " /category:`"PluginConnector`""
} else {
	# Create full MSTest argument string.
	$FullArgsList = " /testcontainer:`"" + $TestAssemblyPath + "`" /resultsfile:`"" + $PSScriptRoot + "\TestResults\PluginConnectorUISpecs.trx`" /testsettings:`"" + $TestSettingsFile + "`"" + $TestList
}

# Write full command including full argument string.
Out-File -LiteralPath $PSScriptRoot\RunTests.bat -Append -Encoding default -InputObject `"$env:vs140comntools..\IDE\MSTest.exe`"$FullArgsList