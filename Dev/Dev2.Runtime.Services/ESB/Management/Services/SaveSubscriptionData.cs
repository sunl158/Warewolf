/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2021 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces.Communication;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Communication;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.Subscription;
using Dev2.Workspaces;
using Warewolf.Licensing;

namespace Dev2.Runtime.ESB.Management.Services
{
    public class SaveSubscriptionData : DefaultEsbManagementEndpoint
    {
        private readonly IWarewolfLicense _warewolfLicense;
        private readonly IBuilderSerializer _serializer;
        private ISubscriptionProvider _subscriptionProvider;

        public SaveSubscriptionData()
            : this(new Dev2JsonSerializer(), new WarewolfLicense(), SubscriptionProvider.Instance)
        {
        }

        public SaveSubscriptionData(IBuilderSerializer serializer, IWarewolfLicense warewolfLicense, ISubscriptionProvider subscriptionProvider)
        {
            _warewolfLicense = warewolfLicense;
            _serializer = serializer;
            _subscriptionProvider = subscriptionProvider;
        }

        public override StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            var result = new ExecuteMessage { HasError = false };
            try
            {
                if(_subscriptionProvider == null)
                {
                    _subscriptionProvider = SubscriptionProvider.Instance;
                }
                Dev2Logger.Info("Save Subscription Data Service", GlobalConstants.WarewolfInfo);
                values.TryGetValue(Warewolf.Service.SaveSubscriptionData.SubscriptionData, out var data);

                var subscriptionData = _serializer.Deserialize<SubscriptionData>(data);
                subscriptionData.SubscriptionKey = _subscriptionProvider.SubscriptionKey;
                subscriptionData.SubscriptionSiteName = _subscriptionProvider.SubscriptionSiteName;

                var resultData = _warewolfLicense.CreatePlan(subscriptionData);
                if(resultData is null)
                {
                    result.HasError = true;
                    result.SetMessage("An error occured.");
                    return _serializer.SerializeToBuilder(result);
                }

                _subscriptionProvider.SaveSubscriptionData(resultData);

                result.SetMessage(GlobalConstants.Success);
                return _serializer.SerializeToBuilder(result);
            }
            catch(Exception e)
            {
                result.HasError = true;
                result.SetMessage(e.Message);
                return _serializer.SerializeToBuilder(result);
            }
        }

        public override DynamicService CreateServiceEntry()
        {
            var newDs = new DynamicService { Name = HandlesType() };
            var sa = new ServiceAction { Name = HandlesType(), ActionType = enActionType.InvokeManagementDynamicService, SourceMethod = HandlesType() };
            newDs.Actions.Add(sa);
            return newDs;
        }

        public override string HandlesType() => nameof(Warewolf.Service.SaveSubscriptionData);
    }
}