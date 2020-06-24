﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common;
using Dev2.Common.Interfaces.Logging;
using Newtonsoft.Json;
using System;
using Warewolf.Interfaces.Auditing;
using Dev2.Data.Interfaces.Enums;

namespace Warewolf.Auditing
{
    public interface IStateAuditLogger : IDisposable
    {
        IStateListener NewStateListener(IExecutionContext dataObject);
    }

    public class StateAuditLogger : IStateAuditLogger, IWarewolfLogWriter
    {
        private IWebSocketWrapper _ws;
        private readonly IWebSocketPool _webSocketFactory;

        public IStateListener NewStateListener(IExecutionContext dataObject) => new StateListener(this, dataObject);

        public StateAuditLogger(IWebSocketPool webSocketFactory)
        {
            _webSocketFactory = webSocketFactory;
            _ws = webSocketFactory.Acquire(Config.Auditing.Endpoint);
            _ws.Connect();
        }

        public void LogAuditState(Object logEntry)
        {
            if (logEntry is Audit auditLog && IsValidLogLevel(auditLog.LogLevel.ToString()))
            {
                if (!_ws.IsOpen())
                {
                    _ws = _webSocketFactory.Acquire(Config.Auditing.Endpoint);
                    _ws.Connect();
                }


                var auditCommand = new AuditCommand
                {
                    Audit = auditLog,
                    Type = "LogEntry"
                };
                string json = JsonConvert.SerializeObject(auditCommand);
                _ws.SendMessage(json);
            }
        }

        private static bool IsValidLogLevel(string auditLogLogLevel)
        {
            Enum.TryParse(Config.Server.ExecutionLogLevel, out LogLevel executionLogLevel);
            switch (executionLogLevel)
            {
                case LogLevel.OFF:
                    return false;
                case LogLevel.TRACE:
                    return true;
                case LogLevel.FATAL:
                case LogLevel.ERROR:
                    return auditLogLogLevel.ToUpper() == LogLevel.ERROR.ToString();
                case LogLevel.WARN:
                    switch (auditLogLogLevel.ToUpper())
                    {
                        case "FATAL":
                        case "WARN":
                        case "ERROR":
                            return true;
                        default:
                            return false;
                    }
                case LogLevel.INFO:
                    switch (auditLogLogLevel.ToUpper())
                    {
                        case "FATAL":
                        case "WARN":
                        case "ERROR":
                        case "INFO":
                            return true;
                        default:
                            return false;
                    }
                case LogLevel.DEBUG:
                    switch (auditLogLogLevel.ToUpper())
                    {
                        case "FATAL":
                        case "WARN":
                        case "ERROR":
                        case "INFO":
                        case "DEBUG":
                            return true;
                        default:
                            return false;
                    }
                default:
                    return false;
            }
        }

        private bool _isDisposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (_ws != null)
                    {
                        _webSocketFactory.Release(_ws);
                        _ws = null;
                    }
                }

                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}