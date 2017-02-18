﻿Feature: BrowserDebug
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Executing an empty workflow
		Given I have a workflow "BlankWorkflow"
		When workflow "BlankWorkflow" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/BlankWorkflow.debug?" in Browser
		Then The Debug in Browser content contains "The workflow must have at least one service or activity connected to the Start Node."

Scenario: Executing a workflow with no inputs and outputs
		Given I have a workflow "NoInputsWorkflow"
		When workflow "NoInputsWorkflow" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/NoInputsWorkflow.debug?" in Browser
		Then The Debug in Browser content contains has children with no Inputs and Ouputs

Scenario: Executing Assign workflow with valid inputs
		Given I have a workflow "ValidAssignedVariableWF"
		And "ValidAssignedVariableWF" contains an Assign "ValidAssignVariables" as
			| variable      | value    |
			| [[dateMonth]] | February |
			| [[dateYear]]  | 2017     |
		When workflow "ValidAssignedVariableWF" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/ValidAssignedVariableWF.debug?" in Browser
		Then The Debug in Browser content contains has "2" inputs and "2" outputs for "ValidAssignVariables"

Scenario: Executing Assign workflow with invalid variable
		Given I have a workflow "InvalidAssignedVariableWF"
		And "InvalidAssignedVariableWF" contains an Assign "InvalidAssignVariables" as
			| variable  | value    |
			| d@teMonth | February |
		When workflow "InvalidAssignedVariableWF" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/InvalidAssignedVariableWF.debug?" in Browser
		Then The Debug in Browser content contains has error messagge ""invalid variable assigned to d@teMonth""

Scenario: Executing Hello World workflow
		Given I have a workflow "Hello World"
		And I Debug "http://localhost:3142/secure/Hello%20World.debug?Name=Bob" in Browser
		Then The Debug in Browser content contains has "3" inputs and "1" outputs for "Decision"
		Then The Debug in Browser content contains has "1" inputs and "1" outputs for "Set the output variable (1)"

Scenario: Executing Hello World workflow with no Name Input
		Given I have a workflow "Hello World"
		And I Debug "http://localhost:3142/secure/Hello%20World.debug?Name=" in Browser
		Then The Debug in Browser content contains has "3" inputs and "1" outputs for "Decision"
		Then The Debug in Browser content contains has "1" inputs and "1" outputs for "Set the output variable (1)"

Scenario: Executing a Sequence workflow
		Given I have a workflow "SequenceVariableWF"
		And "SequenceVariableWF" contains a Sequence "SequenceFlow" as
		And "SequenceFlow" contains an Assign "AssignFlow" as
			| variable      | value    |
			| [[dateMonth]] | February |
			| [[dateDay]]	| Thursday |
		And "SequenceFlow" contains case convert "CaseConvertFlow" as
			| Variable  | Type  |
			| [[dateMonth]] | UPPER |
			| [[dateDay]]	| UPPER |
		And "SequenceFlow" contains Replace "ReplaceFlow" into "[[replaceResult]]" as	
			| In Fields | Find | Replace With |
			| [[dateDay]] | THURSDAY    | Friday      |
		When workflow "SequenceVariableWF" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/SequenceVariableWF.debug?" in Browser
		Then The Debug in Browser content contains order of "AssignFlow", "CaseConvertFlow" and "ReplaceFlow" in SequenceFlow

Scenario: Executing a Foreach workflow
		Given I have a workflow "ForEachAssigneWF"
		And "ForEachAssigneWF" contains a Foreach "ForEachTest" as "NumOfExecution" executions "4"
		And "ForEachTest" contains an Assign "MyAssign" as
	    | variable  | value |
	    | [[Year]]	| 2017  |
		When workflow "ForEachAssigneWF" is saved "1" time
		And I Debug "http://localhost:3142/secure/Acceptance%20Tests/ForEachAssigneWF.debug?" in Browser
		Then The Debug in Browser content contains the variable assigned executed "4" times
	  
#Scenario: Executing a Dotnet plugin workflow
#Scenario: Executing a Recordset sort workflow