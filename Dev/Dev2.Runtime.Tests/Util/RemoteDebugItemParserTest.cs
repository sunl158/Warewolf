/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Communication;
using Dev2.Diagnostics.Debug;
using Dev2.Runtime.ESB.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Dev2.Tests.Runtime.Util
{
    [TestClass]
    public class RemoteDebugItemParserTest
    {
        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("RemoteDebugItemParser_Parse")]
        
        public void RemoteDebugItemParser_Parse_WhenValidJsonList_ExpectItems()

        {
            //------------Setup for test--------------------------
            var items = new List<IDebugState>
            {
                new DebugState {ActivityType = ActivityType.Workflow, ClientID = Guid.Empty, DisplayName = "DebugState"}
            };

            var serializer = new Dev2JsonSerializer();
            var data = serializer.Serialize(items);

            //------------Execute Test---------------------------
            var result = RemoteDebugItemParser.ParseItems(data);

            //------------Assert Results-------------------------
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("DebugState", result[0].DisplayName);
            Assert.AreEqual(ActivityType.Workflow, result[0].ActivityType);
        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("RemoteDebugItemParser_Parse")]
        
        public void RemoteDebugItemParser_Parse_WhenValidJsonListUnderOldNamespace_ExpectItems()

        {
            //------------Setup for test--------------------------
            const string ParseData = @"[{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""e42141d2-f5b1-4e7e-9410-5034432dcd1c"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (3)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9192136+02:00"",""EndTime"":""2014-06-19T14:14:26.9192136+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[var]]"",""Operator"":""="",""Value"":""var"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]},{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""2"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[var]]"",""Operator"":""="",""Value"":""variable"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]},{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""3"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[Result]]"",""Operator"":""="",""Value"":""Assign: FAIL"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""e9edf6ab-6fab-4526-a91f-86b4d735c928"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (1)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00.0156250"",""DurationString"":""PT0.015625S"",""StartTime"":""2014-06-19T14:14:26.9192136+02:00"",""EndTime"":""2014-06-19T14:14:26.9348386+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[var]]"",""Operator"":""="",""Value"":""variablevariable"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""2b8ff32f-528e-4927-8222-4afc0b64cd86"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Decision"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Decision"",""ActivityType"":1,""Duration"":""00:00:00.0156250"",""DurationString"":""PT0.015625S"",""StartTime"":""2014-06-19T14:14:26.9348386+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":"""",""Variable"":null,""Operator"":"""",""Value"":""PASS"",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""b6a33592-5844-4853-90be-fb7ad0294686"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (3)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9504636+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(1).set]]"",""Operator"":""="",""Value"":""1"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]},{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""2"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(2).set]]"",""Operator"":""="",""Value"":""2"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]},{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""3"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(3).set]]"",""Operator"":""="",""Value"":""3"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""15685b03-a649-42c0-b1e3-04a111823586"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (1)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9504636+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(1).set]]"",""Operator"":""="",""Value"":""4"",""GroupName"":""[[rec(*).set]]"",""GroupIndex"":1,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(2).set]]"",""Operator"":""="",""Value"":""4"",""GroupName"":""[[rec(*).set]]"",""GroupIndex"":2,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[rec(3).set]]"",""Operator"":""="",""Value"":""4"",""GroupName"":""[[rec(*).set]]"",""GroupIndex"":3,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""3a07a8b4-46fe-4d6c-b042-7b4525599b9f"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (1)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9504636+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[var]]"",""Operator"":""="",""Value"":""12"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""d3d9c231-4e11-4fac-9df6-1b38daaf7b0a"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (1)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9504636+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[blank(1).recordset]]"",""Operator"":""="",""Value"":""1"",""GroupName"":"""",""GroupIndex"":1,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""3e923e80-4c95-4def-854b-a375667f448d"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Decision"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Decision"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9504636+02:00"",""EndTime"":""2014-06-19T14:14:26.9504636+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":"""",""Variable"":null,""Operator"":"""",""Value"":""PASS"",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""00e4e235-4acc-4d26-9d9c-a4c30a98e421"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":2,""DisplayName"":""Assign (1)"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""Assign"",""ActivityType"":1,""Duration"":""00:00:00"",""DurationString"":""PT0S"",""StartTime"":""2014-06-19T14:14:26.9660886+02:00"",""EndTime"":""2014-06-19T14:14:26.9660886+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":2,""Label"":""1"",""Variable"":null,""Operator"":"""",""Value"":"""",""GroupName"":null,""GroupIndex"":0,""MoreLink"":null},{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[Result]]"",""Operator"":""="",""Value"":""Assign: PASS"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":""f03ccc5c-34d8-4f0e-8cae-4f952ea41818"",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""},{""$type"":""Dev2.Diagnostics.DebugState, Dev2.Diagnostics"",""ID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""ParentID"":""00000000-0000-0000-0000-000000000000"",""ServerID"":""51a58300-7e9d-4927-a57b-e5d700b11b55"",""EnvironmentID"":""00000000-0000-0000-0000-000000000000"",""ClientID"":""00000000-0000-0000-0000-000000000000"",""StateType"":64,""DisplayName"":""Assign"",""HasError"":false,""ErrorMessage"":"""",""Version"":"""",""Name"":""WfApplicationUtils"",""ActivityType"":0,""Duration"":""00:00:00.0468750"",""DurationString"":""PT0.046875S"",""StartTime"":""2014-06-19T14:14:26.9192136+02:00"",""EndTime"":""2014-06-19T14:14:26.9660886+02:00"",""Inputs"":[],""Outputs"":[{""$type"":""Dev2.Diagnostics.DebugItem, Dev2.Diagnostics"",""ResultsList"":[{""$type"":""Dev2.Diagnostics.DebugItemResult, Dev2.Diagnostics"",""Type"":1,""Label"":"""",""Variable"":""[[Result]]"",""Operator"":""="",""Value"":""Assign: PASS"",""GroupName"":"""",""GroupIndex"":0,""MoreLink"":null}]}],""Server"":"""",""WorkspaceID"":""00000000-0000-0000-0000-000000000000"",""OriginalInstanceID"":""f78eddd6-ba23-4a27-ab40-219338e82c64"",""OriginatingResourceID"":""6361dbc7-9830-4465-984e-0767c049ba72"",""IsSimulation"":false,""Message"":null,""NumberOfSteps"":0,""Origin"":"""",""ExecutionOrigin"":0,""ExecutionOriginDescription"":null,""ExecutingUser"":null,""SessionID"":""00000000-0000-0000-0000-000000000000""}]";

            //------------Execute Test---------------------------
            var result = RemoteDebugItemParser.ParseItems(ParseData);

            //------------Assert Results-------------------------

            // Check count - It will throw exception on parse error
            // This actually good enough, check first and last just for completeness sake
            Assert.AreEqual(10, result.Count);
            // Check first and last item
            Assert.AreEqual("Assign (3)", result[0].DisplayName);
            Assert.AreEqual(ActivityType.Step, result[0].ActivityType);
            Assert.AreEqual("Assign", result[9].DisplayName);
            Assert.AreEqual(ActivityType.Workflow, result[9].ActivityType);
        }

        [TestMethod]
        [Owner("Travis Frisinger")]
        [TestCategory("RemoteDebugItemParser_Parse")]
        
        public void RemoteDebugItemParser_Parse_WhenNullJsonList_ExpectNull()

        {
            //------------Setup for test--------------------------
            var data = JsonConvert.SerializeObject(null);

            //------------Execute Test---------------------------
            var result = RemoteDebugItemParser.ParseItems(data);

            //------------Assert Results-------------------------
            Assert.IsNull(result);
        }
    }
}
