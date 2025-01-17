﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Warewolf.Auditing;
using Warewolf.Execution;
using Warewolf.Interfaces.Auditing;
using Warewolf.Streams;
using Warewolf.Triggers;

namespace Warewolf.Common.NetStandard20
{
    public class ExecutionLogger : NetworkLogger, IExecutionLogPublisher
    {
        public interface IExecutionLoggerFactory
        {
            IExecutionLogPublisher New(ISerializer jsonSerializer, IWebSocketPool webSocketPool);
        }

        public class ExecutionLoggerFactory : IExecutionLoggerFactory
        {
            public IExecutionLogPublisher New(ISerializer serializer, IWebSocketPool webSocketPool)
            {
                return new ExecutionLogger(serializer, webSocketPool);
            }
        }

        public ExecutionLogger(ISerializer serializer, IWebSocketPool webSocketPool)
            : base(serializer, webSocketPool)
        {
        }

        public void StartExecution(string message, params object[] args) => Info(message, args);

        public void ExecutionFailed(IExecutionHistory executionHistory)
        {
            LogExecutionCompleted(executionHistory);
        }

        public void ExecutionSucceeded(IExecutionHistory executionHistory)
        {
            LogExecutionCompleted(executionHistory);
        }

        private void LogExecutionCompleted(IExecutionHistory executionHistory)
        {
            var command = new AuditCommand
            {
                Type = executionHistory.AuditType,
                ExecutionHistory = executionHistory as ExecutionHistory
            };
            Publish(Serializer.Serialize(command));
        }


        public void LogResumedExecution(IAudit values)
        {
            var command = new AuditCommand
            {
                Type =  values.AuditType,
                Audit = values as Audit
            };
            Publish(Serializer.Serialize(command));
        }
    }
}