﻿using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.Core;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class TestExchangeServiceSource : IEsbManagementEndpoint
    {
        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            ExecuteMessage msg = new ExecuteMessage();
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();

            try
            {
                Dev2Logger.Info("Save Resource Service");
                StringBuilder resourceDefinition;

                values.TryGetValue("ExchangeSource", out resourceDefinition);

                var src = serializer.Deserialize<ExchangeSourceDefinition>(resourceDefinition);

                var con = new ExchangeSource()
                {
                    AutoDiscoverUrl = src.AutoDiscoverUrl,
                    UserName = src.UserName,
                    Password = src.Password,
                    Timeout = src.Timeout,
                };

                var testMessage = new ExchangeTestMessage()
                {
                    To = src.EmailTo,
                    CC = string.Empty,
                    BCC = string.Empty,
                    Subject = "Exchange Email Test",
                    Body = "Test Exchange email service source",
                };

                con.Send(con, testMessage);
            }
            catch (Exception err)
            {
                msg.HasError = true;
                msg.Message = new StringBuilder(err.Message);
                Dev2Logger.Error(err);
            }

            return serializer.SerializeToBuilder(msg);
        }

        public DynamicService CreateServiceEntry()
        {
            DynamicService newDs = new DynamicService { Name = HandlesType(), DataListSpecification = new StringBuilder("<DataList><Roles ColumnIODirection=\"Input\"/><EmailServiceSource ColumnIODirection=\"Input\"/><WorkspaceID ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>") };
            ServiceAction sa = new ServiceAction { Name = HandlesType(), ActionType = enActionType.InvokeManagementDynamicService, SourceMethod = HandlesType() };
            newDs.Actions.Add(sa);

            return newDs;
        }

        public string HandlesType()
        {
            return "TestExchangeServiceSource";
        }
    }
}
