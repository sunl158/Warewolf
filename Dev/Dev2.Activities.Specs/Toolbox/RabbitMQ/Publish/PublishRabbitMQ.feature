﻿Feature: PublishRabbitMQ
	In order to publish a message to a queue
	As a Warewolf user
	I want a tool that performs this action

Scenario: Open new RabbitMQ Publish Tool
	Given I open New Workflow
	And I drag RabbitMQ Publish Tool onto the design surface
    And New is Enabled
	And Edit is Disabled
	And RabbitMQ Source is Enabled
	And Message is Enabled
	And Result is Enabled
	When I Click New
	Then the New RabbitMQ Publish Source window is opened
	
Scenario: Editing RabbitMQ Publish Tool Source
	Given I open New Workflow
	And I drag RabbitMQ Publish Tool onto the design surface
    And New is Enabled
	And Edit is Disabled
	And RabbitMQ Source is Enabled
	And Message is Enabled
	And Result is Enabled
	When I Select "Test (localhost)" as the source
	Then Edit is Enabled
	And I Click Edit
	Then the "Test (localhost)" RabbitMQ Publish Source window is opened

Scenario: Change RabbitMQ Publish Source
	Given I open New Workflow
	And I drag RabbitMQ Publish Tool onto the design surface
    And New is Enabled
	And Edit is Disabled
	And RabbitMQ Source is Enabled
	And Message is Enabled
	And Result is Enabled
	When I Select "Test (localhost)" as the source
	Then Edit is Enabled
	And I set Message equals "test123"
	And I set Queue Name equals "Testing Publish"
	When I change source from "Test (localhost)" to "BackupSource"
	And I set Message equals ""
	And I set Queue Name equals ""
