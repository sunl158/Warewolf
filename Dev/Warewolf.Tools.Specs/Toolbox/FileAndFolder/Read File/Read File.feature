﻿@ReadFile
Feature: Read File
	In order to be able to Read File
	as a Warewolf user
	I want a tool that reads the contents of a file at a given location


Scenario Outline: Read File at location
	Given I have a source path "<source>" with value "<sourceLocation>"
	And source credentials as "<username>" and "<password>"
	And use private public key for source is "<sourcePrivateKeyFile>"
	And result as "<resultVar>"
	When the read file tool is executed
	Then the result variable "<resultVar>" will be "<result>"
	And the execution has "<AN>" error
	And the debug inputs as
         | Input Path                  | Username   | Password | Private Key File       |
         | <source> = <sourceLocation> | <username> | String   | <sourcePrivateKeyFile> |
	And the debug output as
		|                        |
		| <resultVar> = <result> |
	Examples: 
	| NO | Name       | source   | sourceLocation                                                                                      | username      | password     | resultVar  | result | errorOccured | sourcePrivateKeyFile |
	| 1  | Local      | [[path]] | c:\filetoread.txt                                                                                   | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 2  | UNC        | [[path]] | \\\\SVRDEV.premier.local\FileSystemShareTestingSite\ReadFileSharedTestingSite\filetoread.txt        | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 3  | UNC Secure | [[path]] | \\\\SVRDEV.premier.local\FileSystemShareTestingSite\ReadFileSharedTestingSite\Secure\filetoread.txt | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 4  | FTP        | [[path]] | ftp://DEVOPSPDC.premier.local:1001/FORREADFILETESTING/filetoread.txt                                | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 5  | FTPS       | [[path]] | ftp://DEVOPSPDC.premier.local:1002/FORTESTING/filetodele.txt                                        | Administrator | Dev2@dmin123 | [[result]] | Guid   | NO           |                      |
	| 6  | SFTP       | [[path]] | sftp://SVRDEV.premier.local/filetoread.txt                                                          | dev2          | Q/ulw&]      | [[result]] | Guid   | NO           |                      |
	| 7  | SFTP PK    | [[path]] | sftp://SVRDEV.premier.local/filetoread1.txt                                                         | dev2          | Q/ulw&]      | [[result]] | Guid   | NO           | C:\\Temp\\key.opk    |

Scenario Outline: Read File at locationNull
	Given I have a source path "<source>" with value "<sourceLocation>"
	And source credentials as "<username>" and "<password>"
	And use private public key for source is "<sourcePrivateKeyFile>"
	And result as "<resultVar>"
	When the read file tool is executed
	Then the execution has "<errorOccured>" error
	Examples: 
	| NO | Name       | source   | sourceLocation                                                                                      | username      | password     | resultVar  | result | errorOccured | sourcePrivateKeyFile |
	| 1  | Local      | [[path]] | NULL                                                                                                | ""            | ""           | [[result]] | Error  | AN           |                      |
	| 2  | UNC        | [[path]] | \\\\SVRDEV.premier.local\FileSystemShareTestingSite\ReadFileSharedTestingSite\filetoread.txt        | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 3  | UNC Secure | [[path]] | \\\\SVRDEV.premier.local\FileSystemShareTestingSite\ReadFileSharedTestingSite\Secure\filetoread.txt | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 4  | FTP        | [[path]] | ftp://DEVOPSPDC.premier.local:1001/FORREADFILETESTING/filetoread.txt                                   | ""            | ""           | [[result]] | Guid   | NO           |                      |
	| 5  | FTPS       | [[path]] | ftps://SVRPDC.premier.local:1002/FORREADFILETESTING/filetodele.txt                                  | Administrator | Dev2@dmin123 | [[result]] | Guid   | NO           |                      |
	| 6  | SFTP       | [[path]] | sftp://SVRDEV.premier.local/filetoread.txt                                                          | dev2          | Q/ulw&]      | [[result]] | Guid   | NO           |                      |
	| 7  | SFTP PK    | [[path]] | sftp://SVRDEV.premier.local/filetoread1.txt                                                         | dev2          | Q/ulw&]      | [[result]] | Guid   | NO           | C:\\Temp\\key.opk    |

	
Scenario Outline: Read File validation
    Given I have a variable "[[a]]" with a value "<Val1>"
	Given I have a variable "[[b]]" with a value "<Val2>"
	Given I have a variable "[[rec(1).a]]" with a value "<Val1>"
	Given I have a variable "[[rec(2).a]]" with a value "<Val2>"
	Given I have a variable "[[index]]" with a value "1"
	Given I have a source path "<File or Folder>" with value "<sourceLocation>" 
	And source credentials as "<username>" and "<password>"
	And result as "<resultVar>"
	Then validation is "<ValidationResult>"
	And validation message is "<DesignValidation>"
    When the read file tool is executed
	Then the result variable "<resultVar>" will be "<result>"
	And the execution has "<errorOccured>" error
	#And execution error message will be "<DesignValidation>"
	And the debug inputs as
         | Input Path                          | Username   | Password |
         | <File or Folder> = <sourceLocation> | <username> | String   |
	And the debug output as
		|                        |
		| <resultVar> = <result> |
	Examples: 
		| No | Name        | File or Folder               | Val1              | Val2            | sourceLocation    | username              | password | resultVar              | result | errorOccured | ValidationResult | DesignValidation                                                                                                                                                                                                          | OutputError                                                                                                                                                                                                                    |
		| 1  | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 2  | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 3  | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 4  | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 5  | Local Files | [[a]][[b]].txt               | C:\file           | toread.txt      | C:\filetoread.txt | ""                    | ""       | [[result]]             | String | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 6  | Local Files | [[rec(1).a]]                 | C:\filetoread.txt |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 7  | Local Files | [[a]][[b]]                   | C:\file           | toread.txt      | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 8  | Local Files | [[a]]\[[b]]                  | C:                | filetoread.txt  | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 9  | Local Files | [[a]]:[[b]]                  | C                 | \filetoread.txt | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 10 | Local Files | C:[[a]][[b]].txt             | fileto            | read            | C:\filetoread.txt | ""                    | ""       | [[result]]             | String | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 11 | Local Files | [[rec(1).a]][[rec(2).a]]     | C:\file           | toread.txt      | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 12 | Local Files | [[rec(1).a]]\[[rec(2).a]]    | C:                | filetoread.txt  | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 13 | Local Files | [[rec(1).a]][[rec(2).a]].txt | C:\file           | toread          | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 14 | Local Files | [[rec(1).a]]:[[rec(2).a]]    | C                 | \filetoread.txt | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 15 | Local Files | [[rec(1).a]][[rec(2).a]].txt | C:\file           | toread          | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 16 | Local Files | [[a]]:\[[b]]                 | C                 | copyfile0.txt   |                   | ""                    | ""       | [[result]]             | String | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 17 | Local Files | [[rec(1).a]]                 | C:\filetoread.txt |                 | C:\filetoread.txt | ""                    | ""       | [[result]]             | Guid   | NO           | False            | ""                                                                                                                                                                                                                        | ""                                                                                                                                                                                                                             |
		| 18 | Local Files | [[a&]]                       |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | File Name - Variable name [[a&]] contains invalid character(s)                                                                                                                                                            | 1.Directory - Variable name [[a&]] contains invalid character(s)                                                                                                                                                               |
		| 19 | Local Files | [[rec(**).a]]                |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | File Name - Recordset index (**) contains invalid character(s)                                                                                                                                                            | 1.Directory - Recordset index (**) contains invalid character(s)                                                                                                                                                               |
		| 20 | Local Files | c(*()                        |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | Please supply a valid File or Folder                                                                                                                                                                                      | 1.Please supply a valid File or Folder                                                                                                                                                                                         |
		| 21 | Local Files | C:\\\\\gvh                   |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | False            | ""                                                                                                                                                                                                                        | 1.Directory not found [ C:\\\\\gvh ]                                                                                                                                                                                           |
		| 22 | Local Files | [[rec([[inde$x]]).a]]        |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | File Name - Variable name [[index$x]] contains invalid character(s)                                                                                                                                                       | 1.Directory - Variable name [[index$x]] contains invalid character(s)                                                                                                                                                          |
		| 23 | Local Files | [[sourcePath]]               |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | False            | ""                                                                                                                                                                                                                        | 1.No Value assigned for [[a]]                                                                                                                                                                                                  |
		| 24 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[$#]]                | String   | [[result]]             | ""     | AN           | True             | Username - Variable name [[$#]] contains invalid character(s)                                                                                                                                                             | 1.Username - Variable name [[$#]] contains invalid character(s)                                                                                                                                                                |
		| 25 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[a]]\[[b]]           | String   | [[result]]             | ""     | AN           | False            | ""                                                                                                                                                                                                                        | 1.No Value assigned for [[a]] 2.1.No Value assigned for [[b]]                                                                                                                                                                  |
		| 26 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[rec([[index]]).a]]  | String   | [[result]]             | ""     | AN           | False            | ""                                                                                                                                                                                                                        | 1.No Value assigned for [[index]]                                                                                                                                                                                              |
		| 27 | Local Files | [[sourcePath]].txt           |                   |                 | C:\filetoread.txt | [[rec([[index&]]).a]] | String   | [[result]]             | ""     | AN           | True             | Username - Recordset name [[indexx&]] contains invalid character(s)                                                                                                                                                       | Username - Recordset name [[indexx&]] contains invalid character(s)                                                                                                                                                            |
		| 28 | Local Files | [[sourcePath]].txt           |                   |                 | C:\filetoread.txt | [[a]]*]]              | String   | [[result]]             | ""     | AN           | True             | Username - Invalid expression: opening and closing brackets don't match                                                                                                                                                   | 1.Username - Invalid expression: opening and closing brackets don"t match                                                                                                                                                      |
		| 29 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[a]]                 | ""       | [[result]][[a]]        | ""     | NO           | True             | The result field only allows a single result                                                                                                                                                                              | 1.The result field only allows a single result                                                                                                                                                                                 |
		| 30 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[a]]*]]              | ""       | [[a]]*]]               | ""     | AN           | True             | Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                     | 1.Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                        |
		| 31 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[var@]]               | ""     | AN           | True             | Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                             | 1.Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                |
		| 32 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | [[var]]00]]           | ""       | [[var]]00]]            | ""     | AN           | True             | Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                     | 1.Result - Invalid expression: opening and closing brackets don't match                                                                                                                                                        |
		| 33 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[var@]]               | ""     | AN           | True             | Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                             | 1.Result - Variable name [[var@]] contains invalid character(s)                                                                                                                                                                |
		| 34 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[var[[a]]]]           | ""     | AN           | True             | Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                      | 1.Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                         |
		| 35 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[var.a]]              | ""     | AN           | True             | Result - Variable name [[var.a]]contains invalid character(s)                                                                                                                                                             | 1.Result - Variable name [[var.a]] contains invalid character(s)                                                                                                                                                               |
		| 36 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[#var]]               | ""     | AN           | True             | Result - Variable name [[@var]] contains invalid character(s)                                                                                                                                                             | 1.Result - Variable name [[@var]] contains invalid character(s)                                                                                                                                                                |
		| 37 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[var 1]]              | ""     | AN           | True             | Result - Variable name [[var 1]] contains invalid character(s)                                                                                                                                                            | 1.Result - Variable name [[var 1]] contains invalid character(s)                                                                                                                                                               |
		| 38 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[rec(1).[[rec().1]]]] | ""     | AN           | True             | Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                      | 1.Result - Invalid Region [[var[[a]]]]                                                                                                                                                                                         |
		| 39 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[rec(@).a]]           | ""     | AN           | True             | Result - Recordset index [[@]] contains invalid character(s)                                                                                                                                                              | 1.Result - Recordset index [[@]] contains invalid character(s)                                                                                                                                                                 |
		| 40 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[rec"()".a]]          | ""     | AN           | True             | Result - Recordset name [[rec"()"]] contains invalid character(s)                                                                                                                                                         | 1.Result - Recordset name [[rec"()"]] contains invalid character(s)                                                                                                                                                            |
		| 41 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | ""                    | ""       | [[rec([[[[b]]]]).a]]   | ""     | AN           | True             | Result - Invalid Region [[rec([[[[b]]]]).a]]                                                                                                                                                                              | 1.Result - Invalid Region [[rec([[[[b]]]]).a]]                                                                                                                                                                                 |
		| 42 | Local Files | [[a]                         |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | File Name - Invalid expression: opening and closing brackets don"t match                                                                                                                                                  | 1.Directory - Invalid expression: opening and closing brackets don't match                                                                                                                                                     |
		| 43 | Local Files | [[rec]                       |                   |                 |                   | ""                    | ""       | [[result]]             | ""     | AN           | True             | File Name - [[rec]] does not exist in your variable list                                                                                                                                                                  | 1.Directory - [[rec]] does not exist in your variable list                                                                                                                                                                     |
		| 44 | Local Files | [[sourcePath]]               |                   |                 | C:\filetoread.txt | Test                  | ""       | [[result]]             | ""     | AN           | True             | Password cannot be empty or only white space                                                                                                                                                                              | 1.Password cannot be empty or only white space                                                                                                                                                                                 |
		| 45 | Local Files | A                            |                   |                 | ""                | Test                  | ""       | [[result]]             | ""     | AN           | True             | Please supply valid File Name                                                                                                                                                                                             | 1.Please supply valid File Name                                                                                                                                                                                                |
		| 46 | Local Files | [[var@]]                     |                   |                 |                   | [[var@]]              | ""       | [[var@]]               | ""     | AN           | True             | Username - Variable name [[$#]] contains invalid character(s)   Result - Variable name [[var@]] contains invalid character(s)                                                                                             | 1.Username - Variable name [[$#]] contains invalid character(s)  2.Result - Variable name [[var@]] contains invalid character(s)                                                                                               |
		| 47 | Local Files | C#$%#$]]                     |                   |                 |                   | C#$%#$]]              | ""       | C#$%#$]]               | ""     | AN           | True             | File Name - Invalid expression: opening and closing brackets don't match  Username - Invalid expression: opening and closing brackets don"t match   Result - Invalid expression: opening and closing brackets don"t match | 1.File Name - Invalid expression: opening and closing brackets don"t match 2.Username - Invalid expression: opening and closing brackets don't match   3.Result - Invalid expression: opening and closing brackets don't match |

Scenario Outline: Read File at location using incorrect directory
	Given I have a source path "<source>" with value "<sourceLocation>"
	And source credentials as "<username>" and "<password>"
	And result as "<resultVar>"
	When the read file tool is executed
	Then the result variable "<resultVar>" will be "<result>"
	And the execution has "<errorOccured>" error
	And the debug inputs as
         | Input Path                  | Username   | Password |
         | <source> = <sourceLocation> | <username> | String   |
	And the debug output as
		|                        |
		| <resultVar> = <result> |
	Examples: 
	| NO | Name       | source       | sourceLocation | username                     | password | resultVar  | result | errorOccured |
	| 1  | Local      | [[var]]      |                | ""                           | ""       | [[result]] |        | AN           |
	| 2  | UNC        | [[variable]] | ""             | ""                           | ""       | [[result]] |        | AN           |
	| 3  | UNC Secure | 45454        | 45454          | "" | "" | [[result]] |        | AN           |





















