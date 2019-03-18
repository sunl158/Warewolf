#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
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
using System.Collections.ObjectModel;
using System.Linq;
using Dev2.Network;
using Dev2.Studio.Core.InterfaceImplementors;
using Dev2.Studio.Core.Models;
using Dev2.Studio.Interfaces;


namespace Dev2.ConnectionHelpers
{
    public class ConnectControlSingleton : IConnectControlSingleton
    {
        readonly IEnvironmentModelProvider _serverProvider;
        static IConnectControlSingleton _instance;
        readonly IServerRepository _serverRepository;
        public const string NewServerText = "New Remote Server...";
        public event EventHandler<ConnectionStatusChangedEventArg> ConnectedStatusChanged;
        public event EventHandler<ConnectedServerChangedEvent> ConnectedServerChanged;
        public event EventHandler<ConnectedServerChangedEvent> AfterReload;
        public static IConnectControlSingleton Instance => _instance ?? (_instance = new ConnectControlSingleton(ServerProvider.Instance, CustomContainer.Get<IServerRepository>()));

        public ConnectControlSingleton(IEnvironmentModelProvider serverProvider, IServerRepository serverRepository)
        {
            VerifyArgument.IsNotNull("serverProvider", serverProvider);
            VerifyArgument.IsNotNull("environmentRepository", serverRepository);
            _serverProvider = serverProvider;
            _serverRepository = serverRepository;
            Servers = new ObservableCollection<IConnectControlEnvironment>();
            LoadServers();
        }

        public ObservableCollection<IConnectControlEnvironment> Servers { get; set; }

        public void Remove(Guid environmentId)
        {
            var index = Servers.IndexOf(Servers.FirstOrDefault(s => s.Server.EnvironmentID == environmentId));

            if (index != -1)
            {
                var selectedServer = Servers[index];
                if (selectedServer.IsConnected)
                {
                    Disconnect(selectedServer.Server);
                }


                if (ConnectedServerChanged != null)
                {
                    var localhost = Servers.FirstOrDefault(s => s.Server.IsLocalHost);
                    var localhostId = localhost?.Server.EnvironmentID ?? Guid.Empty;
                    ConnectedServerChanged(this, new ConnectedServerChangedEvent(localhostId));
                }
            }
        }


        public void EditConnection(int selectedIndex, Action<int> openWizard)
        {
            if (selectedIndex != -1 && selectedIndex <= Servers.Count)
            {
                var selectedServer = Servers[selectedIndex];
                var environmentModel = selectedServer.Server;
                if (environmentModel?.Connection != null)
                {
                    var serverUri = environmentModel.Connection.AppServerUri;
                    var auth = environmentModel.Connection.AuthenticationType;
                    openWizard?.Invoke(selectedIndex);
                    var updatedServer = _serverRepository.All().FirstOrDefault(e => e.EnvironmentID == environmentModel.EnvironmentID);
                    if (updatedServer != null && (!serverUri.Equals(updatedServer.Connection.AppServerUri) || auth != updatedServer.Connection.AuthenticationType))
                    {
                        ConnectedStatusChanged?.Invoke(this, new ConnectionStatusChangedEventArg(ConnectionEnumerations.ConnectedState.Busy, environmentModel.EnvironmentID, false));

                        selectedServer.Server = updatedServer;
                    }
                }
            }
        }

        public void Refresh(Guid environmentId)
        {
            var selectedEnvironment = Servers.FirstOrDefault(s => s.Server.EnvironmentID == environmentId);
            if (selectedEnvironment != null)
            {
                var index = Servers.IndexOf(selectedEnvironment);
                if (index != -1)
                {
                    Connect(selectedEnvironment);
                }
            }
        }

        public void ToggleConnection(int selectedIndex)
        {
            if (selectedIndex != -1 && selectedIndex <= Servers.Count)
            {
                var selectedServer = Servers[selectedIndex];
                if (selectedServer != null)
                {
                    var environment = selectedServer.Server;
                    if (selectedServer.IsConnected)
                    {
                        Disconnect(environment);
                    }
                    else
                    {
                        Connect(selectedServer);
                    }
                }
            }
        }

        public void ToggleConnection(Guid environmentId)
        {
            var connectControlEnvironment = Servers.FirstOrDefault(s => s.Server.EnvironmentID == environmentId);
            var index = Servers.IndexOf(connectControlEnvironment);

            if (index != -1)
            {
                ToggleConnection(index);
            }
        }

        public void SetConnectionState(Guid environmentId, ConnectionEnumerations.ConnectedState connectedState)
        {
            ConnectedStatusChanged?.Invoke(this, new ConnectionStatusChangedEventArg(connectedState, environmentId, false));
        }

        void Disconnect(IServer environment)
        {
            ConnectedStatusChanged?.Invoke(this, new ConnectionStatusChangedEventArg(ConnectionEnumerations.ConnectedState.Busy, environment.EnvironmentID, false));
            ConnectedStatusChanged?.Invoke(this, new ConnectionStatusChangedEventArg(ConnectionEnumerations.ConnectedState.Disconnected, environment.EnvironmentID, true));
        }

        void Connect(IConnectControlEnvironment selectedServer)
        {
            var environmentId = selectedServer.Server.EnvironmentID;
            ConnectedStatusChanged?.Invoke(this, new ConnectionStatusChangedEventArg(ConnectionEnumerations.ConnectedState.Busy, environmentId, false));
        }

        ConnectControlEnvironment CreateNewRemoteServerEnvironment() => new ConnectControlEnvironment
        {
            Server = new Server(Guid.NewGuid(), new ServerProxy(new Uri("http://localhost:3142"))) { Name = NewServerText }
        };

        public void ReloadServer()
        {
            Servers.Clear();
            Servers.Add(CreateNewRemoteServerEnvironment());

            var servers = _serverProvider.ReloadServers();
            foreach (var server in servers)
            {
                Servers.Add(new ConnectControlEnvironment
                {
                    Server = server,
                    IsConnected = server.IsConnected,
                    AllowEdit = !server.IsLocalHost
                });
            }
            AfterReload?.Invoke(this, new ConnectedServerChangedEvent(Guid.Empty));
        }
        void LoadServers()
        {
            Servers.Clear();
            Servers.Add(CreateNewRemoteServerEnvironment());
            var servers = _serverProvider.Load();
            foreach (var server in servers)
            {
                Servers.Add(new ConnectControlEnvironment
                {
                    Server = server,
                    IsConnected = server.IsConnected,
                    AllowEdit = !server.IsLocalHost
                });
            }
        }
    }
}
