mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -NoExit -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Warewolf.Tools.Specs -ExcludeCategories FileMoveFromFTPS,NewReadFolder,CopyFileFromUNC,Zip,Resources,FileRenameFromUNC,CopyFileFromFTPS,Recordset,UnzipFromLocal,Email,Storage,CopyFileFromFTP,FileAndFolderMove,LoopConstructs,Scripting,FileRenameFromFTP,ReadFile,UnzipFromFTPS,FileMoveFromUNC,Database,ReadFolder,ZipFromSFTP,FileAndFolderRename,FileMoveFromLocal,SqlBulkInsert,ZipFromFTP,WriteFile,FileMoveFromFTP,ControlFlow,FileRenameFromSFTP,FileMoveFromSFTP,UnzipFromFTP,CopyFileFromSFTP,Utility,UnzipValidation,CopyFileFromLocal,ZipFromFTPS,FileAndFolderDelete,Data,UnzipFromSFTP,ZipFromLocal,DatabaseTimeout,FileAndFolderCopy,FileAndFolderCreate,FileRenameFromLocal,FileRenameFromFTPS