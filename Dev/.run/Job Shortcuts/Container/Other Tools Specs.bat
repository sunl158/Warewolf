powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\..\..\..\Compile.ps1" -AcceptanceTesting
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -Projects Warewolf.Tools.Specs -ExcludeCategories FileAndFolderMove,CopyFileFromFTPS,FileMoveFromSFTP,ReadFolder,FileRenameFromFTPS,UnzipFromSFTP,Storage,CopyFileFromSFTP,CopyFileFromFTP,Recordset,FileRenameFromSFTP,Utility,SqlBulkInsert,Database,FileMoveFromLocal,FileAndFolderCopy,ZipFromFTP,UnzipFromLocal,ControlFlow,FileAndFolderCreate,NewReadFolder,FileRenameFromFTP,FileAndFolderDelete,LoopConstructs,FileAndFolderRename,DatabaseTimeout,ReadFile,ZipFromFTPS,UnzipFromFTP,WriteFile,UnzipValidation,FileRenameFromLocal,FileMoveFromFTP,Zip,Email,Data,FileMoveFromFTPS,CopyFileFromLocal,UnzipFromFTPS,Resources,ZipFromSFTP,Scripting,ZipFromLocal -RunInDocker