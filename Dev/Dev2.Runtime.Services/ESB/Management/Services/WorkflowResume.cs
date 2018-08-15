using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using Dev2.Common;
using Dev2.Communication;
using Dev2.Data.TO;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Warewolf.Storage;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class WorkflowResume : WorkflowManagementEndpointAbstract
    {
        public override string HandlesType() => nameof(WorkflowResume);

        protected override ExecuteMessage ExecuteImpl(Dev2JsonSerializer serializer, Guid resourceId, Dictionary<string, StringBuilder> values)
        {
            
            values.TryGetValue("environment", out StringBuilder environmentString);
            if (environmentString == null)
            {
                throw new InvalidDataContractException("no environment passed");
            }
            values.TryGetValue("startActivityId", out StringBuilder startActivityIdString);
            if (startActivityIdString == null)
            {
                startActivityIdString = new StringBuilder(resourceId.ToString());
            }
            if (!Guid.TryParse(startActivityIdString.ToString(), out Guid startActivityId))
            {
                throw new InvalidDataContractException("startActivityId is not a valid GUID.");
            }
            var decodedEnv = HttpUtility.UrlDecode(environmentString.ToString())
            var env = new ExecutionEnvironment().FromJson(decodedEnv);
            var dataObject = new DsfDataObject("", Guid.NewGuid())
            {
                ResourceID = resourceId,
                Environment = env
            };
            var dynamicService = ResourceCatalog.Instance.GetService(GlobalConstants.ServerWorkspaceID, resourceId, "");
            var sa = dynamicService.Actions.FirstOrDefault();
            if(sa is null)
            {
                return new ExecuteMessage { HasError = true, Message = new StringBuilder($"Error resuming. ServiceAction is null for Resource ID:{resourceId}") };
            }
            var container = CustomContainer.CreateInstance<IResumableExecutionContainer>(startActivityId,sa,dataObject);
            container.Execute(out ErrorResultTO errors, 0);
            if (errors.HasErrors())
            {
                return new ExecuteMessage { HasError = true, Message = new StringBuilder(errors.MakeDisplayReady()) };
            }
            return new ExecuteMessage { HasError = false, Message = new StringBuilder("Execution Completed.") };
        }
       
    }
}
