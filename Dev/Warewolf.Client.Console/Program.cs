﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using Dev2.Common;
using Dev2.Common.Interfaces.Data;
using Dev2.SignalR.Wrappers;
using Dev2.SignalR.Wrappers.New;
using Warewolf.Client;
using Warewolf.Data;
using Warewolf.Esb;

namespace Warewolf.ClientConsole
{
    class Program
    {
        public static int Main(string[] args)
        {
            var result = CommandLine.Parser.Default.ParseArguments<Args>(args);
            return result.MapResult(
                options => new Implementation(options).Run(),
                _ => 1);
        }
    }
    internal class Implementation
    {
        private readonly Args _options;
        private readonly ManualResetEvent _canExit = new ManualResetEvent(false);
        
        public Implementation(Args options)
        {
            this._options = options;
        } 
        public int Run()
        {
            try
            {
                var context = new Context(_options);
                var esb = context.EsbProxy;

                var t = esb.Watch<ChangeNotification>();
                t.OnChange += changeNotification =>
                {
                    Console.WriteLine("woot");
                };
                context.EsbProxy.Connection.Closed += () =>
                {
                    Console.WriteLine("connection closed");
                    _canExit.Set();
                };
                var connectedTask = context.EnsureConnected();
                connectedTask.Wait();
                var joinRequest = context.NewClusterJoinRequest("my key");
                var joinResponse = context.EsbProxy.ExecReq3<ChangeNotification>(joinRequest, 3);
                joinResponse.Wait();
                var response = joinResponse.Result;

                _canExit.WaitOne(-1);
            }
            catch (Exception e)
            {
                WriteExceptionToConsole(e);
            }

            return 0;
        }

        private void WriteExceptionToConsole(Exception t1Exception)
        {
            if (t1Exception is null)
            {
                return;
            }
            WriteExceptionToConsole(t1Exception.InnerException);
            Console.WriteLine(t1Exception.Message);
        }
    }

    internal class Context
    {
        private IConnectedHubProxy _hubProxy;
        private HubConnectionWrapper _hubConnection;

        public Context(Args args)
        {
            ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;

            _hubConnection = new HubConnectionWrapper(args.ServerEndpoint.ToString()) { Credentials = System.Net.CredentialCache.DefaultNetworkCredentials};
        }
        static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslpolicyerrors) => true;


        public IConnectedHubProxy EsbProxy
        {
            get => _hubProxy ?? (_hubProxy = new ConnectedHubProxy { Connection = _hubConnection, Proxy = _hubConnection.CreateHubProxy("esb") });
            set => _hubProxy = value;
        }

        public ICatalogRequest NewResourceRequest<T>(Guid serverWorkspaceId, Guid resourceId)
        {
            if (_hubConnection.State == ConnectionStateWrapped.Disconnected)
            {
                _hubConnection.Start();
            }
            return new ResourceRequest<T>(serverWorkspaceId, resourceId);
        }

        public ICatalogSubscribeRequest NewWatcher<T>(Guid serverWorkspaceId)
        {
            return new EventRequest<T>(serverWorkspaceId);
        }

        public Task EnsureConnected()
        {
            return _hubConnection.EnsureConnected(-1);
        }

        public ICatalogRequest NewClusterJoinRequest(string myKey)
        {
            return new ClusterJoinRequest(myKey);
        }
    }
}
