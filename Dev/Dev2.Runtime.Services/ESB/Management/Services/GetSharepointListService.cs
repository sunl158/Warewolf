using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Dev2.Common;
using Dev2.Common.Common;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Communication;
using Dev2.Data.ServiceModel;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class GetSharepointListService : IEsbManagementEndpoint
    {
        #region Implementation of ISpookyLoadable<string>

        public string HandlesType()
        {
            return "GetSharepointListService";
        }

        #endregion

        #region Implementation of IEsbManagementEndpoint

        /// <summary>
        /// Executes the service
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="theWorkspace">The workspace.</param>
        /// <returns></returns>
        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();

            if(values == null)
            {
                throw new InvalidDataContractException("No parameter values provided.");
            }
            string serializedSource = null;
            StringBuilder tmp;
            values.TryGetValue("SharepointServer", out tmp);
            if(tmp != null)
            {
                serializedSource = tmp.ToString();
            }

            if(string.IsNullOrEmpty(serializedSource))
            {
                ExecuteMessage message = new ExecuteMessage();
                message.HasError = true;
                message.SetMessage("No sharepoint server set.");
                Dev2Logger.Debug("No sharepoint server set.");
                return serializer.SerializeToBuilder(message);
            }

            SharepointSource source;
            SharepointSource runtimeSource = null;
            try
            {
                source = serializer.Deserialize<SharepointSource>(serializedSource);

                if(source.ResourceID != Guid.Empty)
                {
                    runtimeSource = ResourceCatalog.Instance.GetResource<SharepointSource>(theWorkspace.ID, source.ResourceID);
                    if(runtimeSource == null)
                    {
                        var contents = ResourceCatalog.Instance.GetResourceContents(theWorkspace.ID, source.ResourceID);
                        runtimeSource = new SharepointSource(contents.ToXElement());
                    }
                }
            }
            catch(Exception e)
            {
                Dev2Logger.Error(e);
                var res = new DbTableList("Invalid JSON data for sharepoint server parameter. Exception: {0}", e.Message);
                return serializer.SerializeToBuilder(res);
            }
            if(runtimeSource == null)
            {
                var res = new DbTableList("Invalid sharepoint server source");
                Dev2Logger.Debug("Invalid sharepoint server source");
                return serializer.SerializeToBuilder(res);
            }
            if(string.IsNullOrEmpty(runtimeSource.Server))
            {
                var res = new DbTableList("Invalid sharepoint server sent {0}.", serializedSource);
                Dev2Logger.Debug(String.Format("Invalid sharepoint server sent {0}.", serializedSource));
                return serializer.SerializeToBuilder(res);
            }

            try
            {
                Dev2Logger.Info("Get Sharepoint Server Lists. " + source.Server);
                List<SharepointListTo> lists = runtimeSource.LoadLists();
                return serializer.SerializeToBuilder(lists);
            }
            catch(Exception ex)
            {
                var tables = new DbTableList(ex);
                return serializer.SerializeToBuilder(tables);
            }
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <returns></returns>
        public DynamicService CreateServiceEntry()
        {
            var ds = new DynamicService
            {
                Name = HandlesType(),
                DataListSpecification = new StringBuilder("<DataList><Database ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>")
            };

            var sa = new ServiceAction
            {
                Name = HandlesType(),
                ActionType = enActionType.InvokeManagementDynamicService,
                SourceMethod = HandlesType()
            };

            ds.Actions.Add(sa);

            return ds;
        }

        #endregion
    }
}