/*
*  Warewolf - The Easy Service Bus
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data;
using Dev2.Runtime.ServiceModel.Data;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Warewolf.Security.Encryption;

namespace Dev2.Data.ServiceModel
{
    // ReSharper disable InconsistentNaming
    public class RabbitMQSource : Resource, IRabbitMQSource
    // ReSharper restore InconsistentNaming
    {
        private const int DefaultPort = 5672;
        private const string DefaultVirtualHost = "/";

        #region Properties

        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }

        #endregion Properties

        #region CTOR

        public RabbitMQSource()
        {
            ResourceID = Guid.Empty;
            ResourceType = ResourceType.RabbitMQSource;
            Port = DefaultPort;
            VirtualHost = DefaultVirtualHost;
        }

        public RabbitMQSource(XElement xml)
            : base(xml)
        {
            ResourceType = ResourceType.RabbitMQSource;
            Port = DefaultPort;

            var properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Host", string.Empty },
                { "Port", string.Empty },
                { "UserName", string.Empty },
                { "Password", string.Empty },
                { "VirtualHost", string.Empty },
            };

            var conString = xml.AttributeSafe("ConnectionString");
            var connectionString = conString.CanBeDecrypted() ? DpapiWrapper.Decrypt(conString) : conString;
            ParseProperties(connectionString, properties);

            Host = properties["Host"];
            UserName = properties["UserName"];
            Password = properties["Password"];

            int port;
            Port = Int32.TryParse(properties["Port"], out port) ? port : DefaultPort;
            VirtualHost = !string.IsNullOrWhiteSpace(properties["VirtualHost"]) ? properties["VirtualHost"] : DefaultVirtualHost;
        }

        #endregion CTOR

        #region ToXml

        public override XElement ToXml()
        {
            var result = base.ToXml();
            var connectionString = string.Join(";",
                string.Format("Host={0}", Host),
                string.Format("Port={0}", Port),
                string.Format("UserName={0}", UserName),
                string.Format("Password={0}", Password),
                string.Format("VirtualHost={0}", VirtualHost)
                );

            result.Add(
                new XAttribute("ConnectionString", DpapiWrapper.Encrypt(connectionString)),
                new XAttribute("Type", ResourceType),
                new XElement("TypeOf", ResourceType)
                );

            return result;
        }

        #endregion ToXml
    }
}