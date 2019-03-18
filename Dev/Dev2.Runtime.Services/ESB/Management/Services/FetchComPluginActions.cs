#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.DB;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.Runtime.Hosting;
using Dev2.Runtime.ServiceModel;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;
using Warewolf.Core;
using Task = System.Threading.Tasks.Task;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class FetchComPluginActions : DefaultEsbManagementEndpoint
    {
        public override StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            var serializer = new Dev2JsonSerializer();
            try
            {
                var pluginSource = serializer.Deserialize<ComPluginSourceDefinition>(values["source"]);
                var ns = serializer.Deserialize<INamespaceItem>(values["namespace"]);

                var services = new ComPluginServices();
                var src = ResourceCatalog.Instance.GetResource<ComPluginSource>(GlobalConstants.ServerWorkspaceID, pluginSource.Id);
                var svc = new ComPluginService();
                if (ns != null)
                {
                    svc.Namespace = ns.FullName;
                    svc.Source = src;
                }
                else
                {
                    svc.Source = src;
                }


                var serviceMethodList = new ServiceMethodList();
                var task = Task.Run(() =>
                {
                    return serviceMethodList = services.Methods(svc, Guid.Empty, Guid.Empty);
                });
                try
                {
                    var timeoutAfter = task.TimeoutAfter(TimeSpan.FromSeconds(3));
                    serviceMethodList = timeoutAfter.Result;
                }
                catch (Exception e)
                {
                    Dev2Logger.Error(e, GlobalConstants.WarewolfError);
                }


                var methods = serviceMethodList.Select(a => new PluginAction
                {
                    FullName = ns?.FullName,
                    Inputs = a.Parameters.Select(x =>
                    new ServiceInput(x.Name, x.DefaultValue ?? "")
                    {
                        Name = BuildServiceInputName(x.Name, x.TypeName)
                        ,
                        EmptyIsNull = x.EmptyToNull
                        ,
                        RequiredField = x.IsRequired
                        ,
                        TypeName = x.TypeName
                    } as IServiceInput).ToList(),
                    Method = a.Name,
                    Variables = a.Parameters.Select(x => new NameValue { Name = x.Name + " (" + x.TypeName + ")", Value = "" } as INameValue).ToList(),
                } as IPluginAction).ToList();
                return serializer.SerializeToBuilder(new ExecuteMessage
                {
                    HasError = false,
                    Message = serializer.SerializeToBuilder(methods)
                });
            }
            catch (Exception e)
            {

                return serializer.SerializeToBuilder(new ExecuteMessage()
                {
                    HasError = true,
                    Message = new StringBuilder(e.Message)
                });
            }
        }

        string BuildServiceInputName(string name, string typeName)
        {
            try
            {
                var cleanTypeName = Type.GetType(typeName);

                return $"{name} ({cleanTypeName.Name})";
            }
            catch (Exception)
            {
                try
                {
                    var cleanTypeName = typeName.Contains("&") ? typeName.Split('&').First() : typeName.Split(',').First();
                    var newName = $"{name} ({cleanTypeName})";
                    return newName;
                }
                catch (Exception)
                {
                    return name;
                }
            }
        }

        public ResourceCatalog Resources => ResourceCatalog.Instance;

        public override DynamicService CreateServiceEntry() => EsbManagementServiceEntry.CreateESBManagementServiceEntry(HandlesType(), "<DataList><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>");

        public override string HandlesType() => "FetchComPluginActions";
    }
}