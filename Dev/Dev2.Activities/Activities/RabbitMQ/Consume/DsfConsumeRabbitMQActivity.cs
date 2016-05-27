﻿/*
*  Warewolf - The Easy Service Bus
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.ServiceModel;
using Dev2.Diagnostics;
using Dev2.Util;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;
using Warewolf.Core;
using Warewolf.Storage;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

// ReSharper disable VirtualMemberCallInContructor
// ReSharper disable InconsistentNaming
namespace Dev2.Activities.RabbitMQ.Consume
{
    [ToolDescriptorInfo("RabbitMq", "RabbitMQ Consume", ToolType.Native, "406ea660-64cf-4c82-b6f0-42d48172a799", "Dev2.Acitivities", "1.0.0.0", "Legacy", "Utility", "/Warewolf.Studio.Themes.Luna;component/Images.xaml")]
    public class DsfConsumeRabbitMQActivity : DsfBaseActivity
    {
        public string _response;
        public ushort _prefetch;
        public const int _timeOut = 5000;

        #region Ctor

        public DsfConsumeRabbitMQActivity()
        {
            DisplayName = "RabbitMQ Consume";
        }

        #endregion Ctor

        public Guid RabbitMQSourceResourceId { get; set; }

        [Inputs("Queue Name")]
        [FindMissing]
        public string QueueName { get; set; }

        [FindMissing]
        public string Response { get; set; }

        [FindMissing]
        public string Prefetch { get; set; }

        [FindMissing]
        public bool Acknowledge { get; set; }

        [FindMissing]
        public bool ReQueue { get; set; }

        public QueueingBasicConsumer Consumer { get; set; }

        [NonSerialized]
        private ConnectionFactory _connectionFactory;

        internal ConnectionFactory ConnectionFactory
        {
            get
            {
                return _connectionFactory ?? (_connectionFactory = new ConnectionFactory());
            }
            set
            {
                _connectionFactory = value;
            }
        }

        internal IConnection Connection { get; set; }

        internal IModel Channel { get; set; }

        internal RabbitMQSource RabbitMQSource { get; set; }

        #region Overrides of DsfBaseActivity

        public override string DisplayName { get; set; }

        protected override string PerformExecution(Dictionary<string, string> evaluatedValues)
        {
            try
            {
                RabbitMQSource = ResourceCatalog.GetResource<RabbitMQSource>(GlobalConstants.ServerWorkspaceID, RabbitMQSourceResourceId);
                if (RabbitMQSource == null || RabbitMQSource.ResourceType != "RabbitMQSource")
                {
                    return "Failure: Source has been deleted.";
                }

                string queueName;
                if (!evaluatedValues.TryGetValue("QueueName", out queueName))
                {
                    return "Failure: Queue Name is required.";
                }
                ConnectionFactory.HostName = RabbitMQSource.HostName;
                ConnectionFactory.Port = RabbitMQSource.Port;
                ConnectionFactory.UserName = RabbitMQSource.UserName;
                ConnectionFactory.Password = RabbitMQSource.Password;
                ConnectionFactory.VirtualHost = RabbitMQSource.VirtualHost;

                using (Connection = ConnectionFactory.CreateConnection())
                {
                    using (Channel = Connection.CreateModel())
                    {
                        _prefetch = string.IsNullOrEmpty(Prefetch) ? (ushort)1 : ushort.Parse(Prefetch);
                        Channel.BasicQos(0, _prefetch, Acknowledge);
                        if (ReQueue)
                        {
                            BasicGetResult response;
                            try
                            {
                                response = Channel.BasicGet(queueName, false);
                            }
                            catch (Exception)
                            {
                                throw new Exception(string.Format("Queue '{0}' not found", queueName));
                            }

                            _response = response == null ? string.Format("The Queue is Empty, timeout: {0} seconds", TimeSpan.FromMilliseconds(_timeOut).Seconds) : Encoding.Default.GetString(response.Body);
                        }
                        else
                        {
                            Consumer = new QueueingBasicConsumer(Channel);
                            try
                            {
                                Channel.BasicConsume(queue: queueName,
                                noAck: false,
                                consumer: Consumer);
                            }
                            catch (Exception)
                            {
                                throw new Exception(string.Format("Queue '{0}' not found", queueName));
                            }

                            BasicDeliverEventArgs basicDeliverEventArgs;
                            Consumer.Queue.Dequeue(_timeOut, out basicDeliverEventArgs);
                            if (basicDeliverEventArgs == null)
                                _response = string.Format("The Queue is Empty, timeout: {0} seconds", TimeSpan.FromMilliseconds(_timeOut).Seconds);
                            else
                            {
                                var body = basicDeliverEventArgs.Body;
                                _response = Encoding.Default.GetString(body);
                                Channel.BasicAck(basicDeliverEventArgs.DeliveryTag, false);
                            }
                        }
                    }
                }                
                return "Success";
            }
            catch (Exception ex)
            {
                Dev2Logger.Error("ConsumeRabbitMQActivity", ex);
                throw new Exception(ex.GetAllMessages());
            }
        }

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            if (env == null)
            {
                return new List<DebugItem>();
            }
            DebugItem debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "Requeue"), debugItem);
            string value = ReQueue ? "True" : "False";
            AddDebugItem(new DebugEvalResult(value, "", env, update), debugItem);
            _debugInputs.Add(debugItem);

            if(!string.IsNullOrEmpty(Prefetch))
            {
                debugItem = new DebugItem();
                AddDebugItem(new DebugItemStaticDataParams("", "Prefetch"), debugItem);
                AddDebugItem(new DebugEvalResult(Prefetch, "", env, update), debugItem);
                _debugInputs.Add(debugItem);
            }            

            debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "QueueName"), debugItem);
            AddDebugItem(new DebugEvalResult(QueueName, "", env, update), debugItem);
            _debugInputs.Add(debugItem);

            return _debugInputs;
        }

        #region Overrides of DsfBaseActivity

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment dataList, int update)
        {
            base.GetDebugOutputs(dataList, update);

            if (dataList == null)
                return new List<DebugItem>();

            DebugItem debugItem = new DebugItem();
            AddDebugItem(new DebugEvalResult(Response, "", dataList, update), debugItem);
            _debugOutputs.Add(debugItem);

            return _debugOutputs;
        }

        #endregion Overrides of DsfBaseActivity

        protected override void AssignResult(IDSFDataObject dataObject, int update)
        {
            base.AssignResult(dataObject, update);

            if (!string.IsNullOrEmpty(Response))
            {
                dataObject.Environment.Assign(Response, _response, update);
            }
        }

        #endregion Overrides of DsfBaseActivity
    }
}