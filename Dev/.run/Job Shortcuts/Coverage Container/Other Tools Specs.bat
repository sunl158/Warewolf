mkdir "%~dp0..\..\..\..\bin\AcceptanceTesting"
cd /d "%~dp0..\..\..\..\bin\AcceptanceTesting"
powershell -NoProfile -NoLogo -ExecutionPolicy Bypass -File "%~dp0..\TestRun.ps1" -RetryRebuild -Projects Warewolf.Tools.Specs -ExcludeCategories Recordset,FileMoveFromFTP,ZipFromFTPS,UnzipFromLocal,UnzipFromFTPS,CopyFileFromFTP,SqlBulkInsert,FileAndFolderDelete,CopyFileFromSFTP,FileMoveFromFTPS,WriteFile,FileRenameFromLocal,Storage,FileRenameFromFTPS,ReadFolder,FileAndFolderCreate,ControlFlow,FileRenameFromFTP,FileMoveFromUNC,CopyFileFromFTPS,Scripting,Zip,ZipFromLocal,CopyFileFromUNC,FileAndFolderRename,UnzipFromFTP,FileAndFolderMove,FileMoveFromLocal,Resources,CopyFileFromLocal,DatabaseTimeout,Database,UnzipValidation,Email,ZipFromSFTP,FileRenameFromUNC,UnzipFromSFTP,FileAndFolderCopy,LoopConstructs,ZipFromFTP,NewReadFolder,FileMoveFromSFTP,Data,ReadFile,FileRenameFromSFTP,Utility -Coverage -InContainer