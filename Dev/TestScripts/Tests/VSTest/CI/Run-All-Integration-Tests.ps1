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
		        $TestList += "," + $TestName.Test.SubString($TestName.Test.LastIndexOf(".") + 1)
	        }
	    } else {        
            if ($playlistContent.Playlist.Add.Test -ne $NULL) {
                $TestList = " /Tests:" + $playlistContent.Playlist.Add.Test.SubString($playlistContent.Playlist.Add.Test.LastIndexOf(".") + 1)
            } else {
	            Write-Host Error parsing Playlist.Add from playlist file at $_.FullName
	            Continue
            }
        }
    }
}
if ($TestList.StartsWith(",")) {
	$TestList = $TestList -replace "^.", " /Tests:"
}

# Create test settings.
$TestSettingsFile = "$PSScriptRoot\IntegrationTests.testsettings"
[system.io.file]::WriteAllText($TestSettingsFile,  @"
<?xml version=`"1.0`" encoding="UTF-8"?>
<TestSettings
  id=`"
"@ + [guid]::NewGuid() + @"
`"
  name=`"IntegrationTests`"
  enableDefaultDataCollectors=`"false`"
  xmlns=`"http://microsoft.com/schemas/VisualStudio/TeamTest/2010`">
  <Description>Run all integration tests.</Description>
  <Deployment enabled=`"false`" />
  <Execution>
    <Timeouts testTimeout=`"180000`" />
  </Execution>
</TestSettings>
"@)

# Create assemblies list.
if (Test-Path "$PSScriptRoot\Dev2.IntegrationTests\bin\debug\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\Dev2.IntegrationTests\bin\debug"
}
if (Test-Path "$PSScriptRoot\..\Dev2.IntegrationTests\bin\debug\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\Dev2.IntegrationTests\bin\debug"
}
if (Test-Path "$PSScriptRoot\..\..\Dev2.IntegrationTests\bin\debug\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\Dev2.IntegrationTests\bin\debug"
}
if (Test-Path "$PSScriptRoot\..\..\..\Dev2.IntegrationTests\bin\debug\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\..\Dev2.IntegrationTests\bin\debug"
}
if (Test-Path "$PSScriptRoot\..\..\..\..\Dev2.IntegrationTests\bin\debug\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\..\..\Dev2.IntegrationTests\bin\debug"
}
if (Test-Path "$PSScriptRoot\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot"
}
if (Test-Path "$PSScriptRoot\..\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\.."
}
if (Test-Path "$PSScriptRoot\..\..\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\.."
}
if (Test-Path "$PSScriptRoot\..\..\..\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\.."
}
if (Test-Path "$PSScriptRoot\..\..\..\..\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\..\.."
}
if (Test-Path "$PSScriptRoot\..\..\..\..\..\Dev2.IntegrationTests.dll") {
	$TestAssembliesPath = "$PSScriptRoot\..\..\..\..\.."
}
$TestAssembliesList = ''
foreach ($file in Get-ChildItem $TestAssembliesPath -Include Dev2.IntegrationTests.dll -Recurse | Where-Object {-not $_.FullName.Contains("\obj\")} | Sort-Object -Property Name -Unique ) {
    $TestAssembliesList = $TestAssembliesList + " `"" + $file.FullName + "`""
}

# Create full VSTest argument string.
$FullArgsList = $TestAssembliesList + " /logger:trx /Settings:`"" + $TestSettingsFile + "`"" + $TestList

# Display full command including full argument string.
Write-Host `"$env:vs140comntools..\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.console.exe`"$FullArgsList

# Write full command including full argument string.
Out-File -LiteralPath $PSScriptRoot\RunTests.bat -Encoding default -InputObject `"$env:vs140comntools..\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.console.exe`"$FullArgsList