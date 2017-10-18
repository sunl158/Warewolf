﻿@StudioStartupShutdown
Feature: StudioStartupShutdown
	As a Warewolf Studio user
	I have to wait for the Studio to shutdown fully
	
Scenario: Studio Startup And Shutdown
	Given I open "30" tabs
	And I start the timer
	When I close the Studio
	Then the timer duration is less than "5" seconds
	Given I open "30" new tabs
	And I start the timer
	When I start the Studio
	Then the timer duration is less than "5" seconds
