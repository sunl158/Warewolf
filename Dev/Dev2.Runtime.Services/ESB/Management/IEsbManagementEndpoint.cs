#pragma warning disable
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
using System.Text;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.Interfaces.Patterns;
using Dev2.DynamicServices;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management
{
    /**
     * Base interface for internal services that are primarily called from the Warewolf Studio via SignalR
     * See EsbHub (HubName("esb")) for the SignalR Hub.
     */
    public interface IEsbManagementEndpoint : ISpookyLoadable<string>
    {
        StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace);        
        DynamicService CreateServiceEntry();
        Guid GetResourceID(Dictionary<string, StringBuilder> requestArgs);
        AuthorizationContext GetAuthorizationContextForService();
    }
}
