﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Logging;
using Dev2.Interfaces;
using Newtonsoft.Json;
using System;

namespace Warewolf.Auditing
{
    public interface IStateAuditLogger : IDisposable
    {
        IStateListener NewStateListener(IDSFDataObject dataObject);
    }

    public class StateAuditLogger : IStateAuditLogger, IWarewolfLogWriter
    {
        WebSocketWrapper _ws;
        public IStateListener NewStateListener(IDSFDataObject dataObject) => new StateListener(this, dataObject);
        
        public StateAuditLogger()
        {
            _ws = WebSocketWrapper.Create("ws://localhost:5000/ws");
            _ws.Connect();
        }

        public void LogAuditState(Object logEntry)
        {
            if (logEntry is Audit auditLog)
            {
                string json = JsonConvert.SerializeObject(auditLog);
                _ws.SendMessage(json);
            }
        }

        public void Dispose()
        {
        }
    }
}