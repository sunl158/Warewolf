#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
﻿/*
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
using System.Linq;
using System.Text;
using Dev2.Common;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Dev2.Workspaces;
using Newtonsoft.Json;
using ServiceStack.Common.Extensions;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class GetDependanciesOnList : DefaultEsbManagementEndpoint
    {
        #region Implementation of DefaultEsbManagementEndpoint
        
        public override StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {

            try
            {

         
            var dependancyNames = new List<string>();

                var dependsOnMe = false;
                var resourceIdsString = string.Empty;
                var dependsOnMeString = string.Empty;
                values.TryGetValue("ResourceIds", out StringBuilder tmp);
                if (tmp != null)
            {
                resourceIdsString = tmp.ToString();
            }
            values.TryGetValue("GetDependsOnMe", out tmp);
            if(tmp != null)
            {
                dependsOnMeString = tmp.ToString();
            }

            var resourceIds = JsonConvert.DeserializeObject<List<string>>(resourceIdsString).Select(Guid.Parse);
                Dev2Logger.Info("Get Dependencies On List. " + resourceIdsString, GlobalConstants.WarewolfInfo);
                if (!string.IsNullOrEmpty(dependsOnMeString) && !bool.TryParse(dependsOnMeString, out dependsOnMe))
                {
                    dependsOnMe = false;
                }

                if (dependsOnMe)
            {
                //TODO : other way
            }
            else
            {
                foreach (var resourceId in resourceIds)
                {

                    dependancyNames.AddRange(FetchRecursiveDependancies(resourceId, theWorkspace.ID));

                }
            }

            var serializer = new Dev2JsonSerializer();
                return serializer.SerializeToBuilder(dependancyNames);
            }
            catch (Exception e)
            {
                Dev2Logger.Error(e, GlobalConstants.WarewolfError);
                throw;
            }
        }

        #endregion

        #region Private Methods

        IEnumerable<string> FetchRecursiveDependancies(Guid resourceId, Guid workspaceId)
        {
            var results = new List<string>();
            var resource = ResourceCatalog.Instance.GetResource(workspaceId, resourceId);

            var dependencies = resource?.Dependencies;

            if (dependencies != null)
            {

                dependencies.ForEach(c =>

                    { results.Add(c.ResourceID != Guid.Empty ? c.ResourceID.ToString() : c.ResourceName); });
                dependencies.ToList().ForEach(c =>
                    { results.AddRange(c.ResourceID != Guid.Empty ? FetchRecursiveDependancies(c.ResourceID, workspaceId) : FetchRecursiveDependancies(workspaceId, c.ResourceName)); });
            }
            return results;
        }

        IEnumerable<string> FetchRecursiveDependancies(Guid workspaceId, string resourceName)
        {
            var resource = ResourceCatalog.Instance.GetResource(workspaceId, resourceName);
            if (resource != null)
            {
                return FetchRecursiveDependancies(resource.ResourceID, workspaceId);
            }
            return new List<string>();
        }

        #endregion

        public override DynamicService CreateServiceEntry() => EsbManagementServiceEntry.CreateESBManagementServiceEntry(HandlesType(), "<DataList><ResourceNames ColumnIODirection=\"Input\"/><GetDependsOnMe ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>");

        public override string HandlesType() => "GetDependanciesOnListService";
    }
}
