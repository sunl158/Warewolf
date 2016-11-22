Write-Host Getting script path.
$Invocation = (Get-Variable MyInvocation -Scope 0).Value
$SolutionDirectory = (get-item (Split-Path $Invocation.MyCommand.Path)).parent.FullName
Write-Host Got solution path as `"$SolutionDirectory`".

Write-Host Starting nuget package restore using nuget.exe at `"$SolutionDirectory\.nuget\nuget.exe`".
[System.Diagnostics.Process]::Start("""" + $SolutionDirectory + "\.nuget\nuget.exe""", "restore """ + $SolutionDirectory + "\Server.sln""")
Write-Host Nuget package restore finished.

Write-Host Starting compile using compiler at `"$env:vs120comntools..\IDE\devenv.com`".
[System.Diagnostics.Process]::Start("""" + $env:vs120comntools + "..\IDE\devenv.com""", """" + $SolutionDirectory + "\Server.sln"" /Build ""Debug""")
Write-Host Compile finished.

Write-Host Loading assembly at `"$SolutionDirectory\Dev2.Runtime.Services\bin\Debug\Dev2.Runtime.Services.dll`".
Add-Type -Path "$SolutionDirectory\Dev2.Runtime.Services\bin\Debug\Dev2.Runtime.Services.dll"
Write-Host Assembly loaded.

Write-Host Loading assembly at `"$SolutionDirectory\Dev2.Warewolf.Security\bin\Debug\Warewolf.Security.dll`".
Add-Type -Path "$SolutionDirectory\Dev2.Warewolf.Security\bin\Debug\Warewolf.Security.dll"
Write-Host Assembly loaded.

Write-Host Loading assembly at `"$SolutionDirectory\Dev2.Common\bin\Debug\Dev2.Common.dll`".
Add-Type -Path "$SolutionDirectory\Dev2.Common\bin\Debug\Dev2.Common.dll"
Write-Host Assembly loaded.

Write-Host Loading types.
$ResourceHandler = New-Object Dev2.Runtime.ESB.Management.Services.FetchResourceDefinition
Write-Host Types loaded.

Write-Host Recursing through resources.
get-childitem "$SolutionDirectory\Resources - Debug\Resources","$env:ProgramData\Warewolf\Resources","$SolutionDirectory\Dev2.Server\bin\Debug\Resources" -recurse | where {$_.extension -eq ".xml"} | % {

	Write-Host Resource found at $_.FullName.
	$sb = New-Object System.Text.StringBuilder
	[void]$sb.Append([string](Get-Content $_.FullName))
	Write-Host Resource read.
	
    Write-Host Creating Dev2 String Transforms
    $Dev2SourceStringTransform = New-Object Dev2.Common.Utils.StringTransform
    $Dev2SourceStringTransform.SearchRegex = New-Object System.Text.RegularExpressions.Regex "<Source ID=`"[a-fA-F0-9\-]+`" .*ConnectionString=`"([^`"]+)`" .*>"
    $Dev2SourceStringTransform.GroupNumbers = @(1)
    $Dev2SourceStringTransform.TransformFunction = [Warewolf.Security.Encryption.DpapiWrapper]::DecryptIfEncrypted
    $Dev2AbstractFileActivityStringTransform = New-Object Dev2.Common.Utils.StringTransform
    $Dev2AbstractFileActivityStringTransform.SearchRegex = New-Object System.Text.RegularExpressions.Regex "&lt;([a-zA-Z0-9]+:)?(DsfFileWrite|DsfFileRead|DsfFolderRead|DsfPathCopy|DsfPathCreate|DsfPathDelete|DsfPathMove|DsfPathRename|DsfZip|DsfUnzip) .*?Password=`"([^`"]+)`" .*?&gt;"
    $Dev2AbstractFileActivityStringTransform.GroupNumbers = @(1)
    $Dev2AbstractFileActivityStringTransform.TransformFunction = [Warewolf.Security.Encryption.DpapiWrapper]::DecryptIfEncrypted
    $Dev2AbstractMultipleFilesActivityStringTransform = New-Object Dev2.Common.Utils.StringTransform
    $Dev2AbstractMultipleFilesActivityStringTransform.SearchRegex = New-Object System.Text.RegularExpressions.Regex "&lt;([a-zA-Z0-9]+:)?(DsfPathCopy|DsfPathMove|DsfPathRename|DsfZip|DsfUnzip) .*?DestinationPassword=`"([^`"]+)`" .*?&gt;"
    $Dev2AbstractMultipleFilesActivityStringTransform.GroupNumbers = @(1)
    $Dev2AbstractMultipleFilesActivityStringTransform.TransformFunction = [Warewolf.Security.Encryption.DpapiWrapper]::DecryptIfEncrypted
    $Dev2ZipStringTransform = New-Object Dev2.Common.Utils.StringTransform
    $Dev2ZipStringTransform.SearchRegex = New-Object System.Text.RegularExpressions.Regex "&lt;([a-zA-Z0-9]+:)?(DsfZip|DsfUnzip) .*?ArchivePassword=`"([^`"]+)`" .*?&gt;"
    $Dev2ZipStringTransform.GroupNumbers = @(1)
    $Dev2ZipStringTransform.TransformFunction = [Warewolf.Security.Encryption.DpapiWrapper]::DecryptIfEncrypted

	Write-Host Decrypting resource.
    $replacements = New-Object 'system.collections.generic.dictionary[[string],[Dev2.Common.Utils.StringTransform]]'
    $replacements.Add("Source", $Dev2SourceStringTransform)
    $replacements.Add("DsfAbstractFileActivity", $Dev2AbstractFileActivityStringTransform)
    $replacements.Add("DsfAbstractMultipleFilesActivity", $Dev2AbstractMultipleFilesActivityStringTransform)
    $replacements.Add("Zip", $Dev2ZipStringTransform)
    $ReplacementValues = New-Object 'system.collections.generic.list[Dev2.Common.Utils.StringTransform]'
    $ReplacementValues.Add($Dev2SourceStringTransform)
    $ReplacementValues.Add($Dev2AbstractFileActivityStringTransform)
    $ReplacementValues.Add($Dev2AbstractMultipleFilesActivityStringTransform)
    $ReplacementValues.Add($Dev2ZipStringTransform)
    $xml = [Dev2.Common.Utils.StringTransform]::TransformAllMatches($sb.ToString(), $ReplacementValues)
    $sb.Append($xml)
	Write-Host Resource decrypted.

	Write-Host Writing decrypted resource.
	$sb.ToString() | Out-File -LiteralPath $_.FullName -Encoding utf8 -Force
	Write-Host Written back to $_.FullName.
}