﻿@followerServer
Feature: WarewolfLoggingFollower
	In order to centralize all execution workflow logs
    As a warewolf user
    I want to be able to store logs to a leader server

 Scenario: No leader server discovered on log
          Given a valid follower server resource
          And log service have received logs
          When the follower server tries to log and connection to leader not live
          Then the logs should be logged locally
          And local log file should contain
          |  one   |  two    | three  |
          | value 1| value 2 | value 3| 
