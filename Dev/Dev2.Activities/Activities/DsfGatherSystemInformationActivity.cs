#pragma warning disable
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
using System.Activities;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.ExtMethods;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Data.Interfaces.Enums;
using Dev2.Data.TO;
using Dev2.DataList.Contract;
using Dev2.Diagnostics;
using Dev2.Interfaces;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Resource.Errors;
using Warewolf.Storage.Interfaces;
using WarewolfParserInterop;
using Dev2.Comparer;
using Dev2.Common.State;
using Dev2.Utilities;

namespace Dev2.Activities
{
    public class DsfGatherSystemInformationActivity : DsfActivityAbstract<string>, ICollectionActivity
    {
        #region Fields

        IGetSystemInformation _getSystemInformation;
        IIdentity _currentIdentity;

        #endregion

        /// <summary>
        /// The property that holds all the conversions
        /// </summary>
        public IList<GatherSystemInformationTO> SystemInformationCollection { get; set; }

        public IGetSystemInformation GetSystemInformation
        {
            get
            {
                return _getSystemInformation ?? (_getSystemInformation = new GetSystemInformationHelper());
            }
            set
            {
                _getSystemInformation = value;
            }
        }


        public override List<string> GetOutputs() => SystemInformationCollection.Select(to => to.Result).ToList();

        #region Overrides of DsfNativeActivity<string>

        public DsfGatherSystemInformationActivity()
            : base("Gather System Information")
        {
            SystemInformationCollection = new List<GatherSystemInformationTO>();
        }

        public override IEnumerable<StateVariable> GetState()
        {
            return new[]
            {
                new StateVariable
                {
                    Name="SystemInformationCollection",
                    Type=StateVariable.StateType.InputOutput,
                    Value= ActivityHelper.GetSerializedStateValueFromCollection(SystemInformationCollection)
                }
            };
        }

        void CleanArgs()
        {
            var count = 0;
            while (count < SystemInformationCollection.Count)
            {
                if (string.IsNullOrWhiteSpace(SystemInformationCollection[count].Result))
                {
                    SystemInformationCollection.RemoveAt(count);
                }
                else
                {
                    count++;
                }
            }
        }
        /// <summary>
        /// When overridden runs the activity's execution logic
        /// </summary>
        /// <param name="context">The context to be used.</param>

        protected override void OnExecute(NativeActivityContext context)
            
        {
            var dataObject = context.GetExtension<IDSFDataObject>();
            ExecuteTool(dataObject, 0);
        }

        protected override void ExecuteTool(IDSFDataObject dataObject, int update)
        {
            var allErrors = new ErrorResultTO();

            if (dataObject.ExecutingUser != null)
            {
                _currentIdentity = dataObject.ExecutingUser.Identity;
            }
            InitializeDebug(dataObject);
            try
            {
                TryExecute(dataObject, update, allErrors);
            }
            catch (Exception e)
            {
                Dev2Logger.Error("DSFGatherSystemInformationTool", e, GlobalConstants.WarewolfError);
                allErrors.AddError(e.Message);
            }
            finally
            {
                HandleErrors(dataObject, update, allErrors);
            }
        }

        void HandleErrors(IDSFDataObject dataObject, int update, ErrorResultTO allErrors)
        {
            var hasErrors = allErrors.HasErrors();
            if (hasErrors)
            {
                foreach (var error in allErrors.FetchErrors())
                {
                    dataObject.Environment.AddError(error);
                }
                DisplayAndWriteError(dataObject,DisplayName, allErrors);
            }
            if (dataObject.IsDebugMode())
            {
                if (hasErrors)
                {
                    var innerCount = 1;
                    foreach (GatherSystemInformationTO item in SystemInformationCollection)
                    {
                        var itemToAdd = new DebugItem();
                        AddDebugItem(new DebugItemStaticDataParams("", innerCount.ToString(CultureInfo.InvariantCulture)), itemToAdd);
                        AddDebugItem(new DebugEvalResult(item.Result, "", dataObject.Environment, update), itemToAdd);
                        _debugOutputs.Add(itemToAdd);
                        innerCount++;
                    }
                }

                DispatchDebugState(dataObject, StateType.Before, update);
                DispatchDebugState(dataObject, StateType.After, update);
            }
        }

        void TryExecute(IDSFDataObject dataObject, int update, ErrorResultTO allErrors)
        {
            var indexCounter = 0;
            CleanArgs();

            foreach (GatherSystemInformationTO item in SystemInformationCollection)
            {
                try
                {
                    if (dataObject.IsDebugMode())
                    {
                        var inputToAdd = new DebugItem();
                        AddDebugItem(new DebugItemStaticDataParams("", (++indexCounter).ToString(CultureInfo.InvariantCulture)), inputToAdd);
                        AddDebugItem(new DebugItemStaticDataParams("", dataObject.Environment.EvalToExpression(item.Result, update), "", "="), inputToAdd);
                        AddDebugItem(new DebugItemStaticDataParams(item.EnTypeOfSystemInformation.GetDescription(), ""), inputToAdd);
                        _debugInputs.Add(inputToAdd);
                    }

                    var hasErrors = allErrors.HasErrors();
                    if (!hasErrors)
                    {
                        ExecuteForTO(dataObject, update, allErrors, item);
                    }
                }
                catch (Exception err)
                {
                    dataObject.Environment.Assign(item.Result, null, update);
                    allErrors.AddError(err.Message);
                }
            }
            dataObject.Environment.CommitAssign();
            if (dataObject.IsDebugMode() && !allErrors.HasErrors())
            {
                var innerCount = 1;
                foreach (GatherSystemInformationTO item in SystemInformationCollection)
                {
                    var itemToAdd = new DebugItem();
                    AddDebugItem(new DebugItemStaticDataParams("", "", innerCount.ToString(CultureInfo.InvariantCulture)), itemToAdd);
                    AddDebugItem(new DebugEvalResult(item.Result, "", dataObject.Environment, update), itemToAdd);
                    _debugOutputs.Add(itemToAdd);
                    innerCount++;
                }
            }
        }

        void ExecuteForTO(IDSFDataObject dataObject, int update, ErrorResultTO allErrors, GatherSystemInformationTO item)
        {
            var val = GetCorrectSystemInformation(item.EnTypeOfSystemInformation);
            var expression = item.Result;

            var regions = DataListCleaningUtils.SplitIntoRegions(expression);
            if (regions.Count > 1)
            {
                allErrors.AddError(ErrorResource.MultipleVariablesInResultField);
            }
            else
            {
                foreach (var region in regions)
                {
                    dataObject.Environment.AssignWithFrame(new AssignValue(region, val), update);
                }
            }
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        public string GetCorrectSystemInformation(enTypeOfSystemInformationToGather enTypeOfSystemInformation)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            switch(enTypeOfSystemInformation)
            {
                case enTypeOfSystemInformationToGather.ComputerName:
                    return GetSystemInformation.GetComputerName();
                case enTypeOfSystemInformationToGather.OperatingSystem:
                    return GetSystemInformation.GetOperatingSystemInformation();
                case enTypeOfSystemInformationToGather.OperatingSystemVersion:
                    return GetSystemInformation.GetOperatingSystemVersionInformation();
                case enTypeOfSystemInformationToGather.ServicePack:
                    return GetSystemInformation.GetServicePackInformation();
                case enTypeOfSystemInformationToGather.OSBitValue:
                    return GetSystemInformation.GetOSBitValueInformation();
                case enTypeOfSystemInformationToGather.FullDateTime:
                    return GetSystemInformation.GetFullDateTimeInformation();
                case enTypeOfSystemInformationToGather.DateTimeFormat:
                    return GetSystemInformation.GetDateTimeFormatInformation();
                case enTypeOfSystemInformationToGather.DiskAvailable:
                    return GetSystemInformation.GetDiskSpaceAvailableInformation();
                case enTypeOfSystemInformationToGather.DiskTotal:
                    return GetSystemInformation.GetDiskSpaceTotalInformation();
                case enTypeOfSystemInformationToGather.VirtualMemoryAvailable:
                    return GetSystemInformation.GetVirtualMemoryAvailableInformation();
                case enTypeOfSystemInformationToGather.VirtualMemoryTotal:
                    return GetSystemInformation.GetVirtualMemoryTotalInformation();
                case enTypeOfSystemInformationToGather.PhysicalMemoryAvailable:
                    return GetSystemInformation.GetPhysicalMemoryAvailableInformation();
                case enTypeOfSystemInformationToGather.PhysicalMemoryTotal:
                    return GetSystemInformation.GetPhysicalMemoryTotalInformation();
                case enTypeOfSystemInformationToGather.CPUAvailable:
                    return GetSystemInformation.GetCPUAvailableInformation();
                case enTypeOfSystemInformationToGather.CPUTotal:
                    return GetSystemInformation.GetCPUTotalInformation();
                case enTypeOfSystemInformationToGather.Language:
                    return GetSystemInformation.GetLanguageInformation();
                case enTypeOfSystemInformationToGather.Region:
                    return GetSystemInformation.GetRegionInformation();
                case enTypeOfSystemInformationToGather.UserRoles:
                    return GetSystemInformation.GetUserRolesInformation(_currentIdentity);
                case enTypeOfSystemInformationToGather.UserName:
                    return GetSystemInformation.GetUserNameInformation();
                case enTypeOfSystemInformationToGather.Domain:
                    return GetSystemInformation.GetDomainInformation();
                case enTypeOfSystemInformationToGather.NumberOfServerNICS:
                    return GetSystemInformation.GetNumberOfNICS();
                case enTypeOfSystemInformationToGather.MacAddress:
                    return GetSystemInformation.GetMACAdresses();
                case enTypeOfSystemInformationToGather.GateWayAddress:
                    return GetSystemInformation.GetDefaultGateway();
                case enTypeOfSystemInformationToGather.DNSAddress:
                    return GetSystemInformation.GetDNSServer();
                case enTypeOfSystemInformationToGather.IPv4Address:
                    return GetSystemInformation.GetIPv4Adresses();
                case enTypeOfSystemInformationToGather.IPv6Address:
                    return GetSystemInformation.GetIPv6Adresses();
                case enTypeOfSystemInformationToGather.WarewolfMemory:
                    return GetSystemInformation.GetWarewolfServerMemory();
                case enTypeOfSystemInformationToGather.WarewolfCPU:
                    return GetSystemInformation.GetWarewolfCPU();
                case enTypeOfSystemInformationToGather.WarewolfServerVersion:
                    return GetSystemInformation.GetWareWolfVersion();
                default:
                    throw new ArgumentOutOfRangeException("enTypeOfSystemInformation");
            }
        }

        public override IList<DsfForEachItem> GetForEachInputs()
        {
            var enumerable = SystemInformationCollection.Select(to => to.Result);
            return GetForEachItems(enumerable.ToArray());
        }

        public override IList<DsfForEachItem> GetForEachOutputs()
        {
            var enumerable = SystemInformationCollection.Select(to => to.Result);
            return GetForEachItems(enumerable.ToArray());
        }

        public override enFindMissingType GetFindMissingType() => enFindMissingType.DataGridActivity;

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates)
        {
            if(updates != null)
            {
                foreach(Tuple<string, string> t in updates)
                {
                    // locate all updates for this tuple
                    var t1 = t;
                    var items = SystemInformationCollection.Where(c => !string.IsNullOrEmpty(c.Result) && c.Result.Equals(t1.Item1));

                    // issues updates
                    foreach(var a in items)
                    {
                        a.Result = t.Item2;
                    }
                }
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates)
        {
            if(updates != null)
            {
                foreach(Tuple<string, string> t in updates)
                {
                    // locate all updates for this tuple
                    var t1 = t;
                    var items = SystemInformationCollection.Where(c => !string.IsNullOrEmpty(c.Result) && c.Result.Equals(t1.Item1));

                    // issues updates
                    foreach(var a in items)
                    {
                        a.Result = t.Item2;
                    }
                }
            }
        }

        #region Overrides of DsfNativeActivity<string>

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update) => _debugInputs;

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment env, int update)
        {
            foreach(IDebugItem debugOutput in _debugOutputs)
            {
                debugOutput.FlushStringBuilder();
            }
            return _debugOutputs;
        }

        #endregion

        #region Private Methods

        void InsertToCollection(IEnumerable<string> listToAdd, ModelItem modelItem)
        {
            var modelProperty = modelItem.Properties["SystemInformationCollection"];
            if (modelProperty != null)
            {
                var mic = modelProperty.Collection;

                if (mic != null)
                {
                    var listOfValidRows = SystemInformationCollection.Where(c => !c.CanRemove()).ToList();
                    if (listOfValidRows.Count > 0)
                    {
                        var gatherSystemInformationTo = SystemInformationCollection.Last(c => !c.CanRemove());
                        var startIndex = SystemInformationCollection.IndexOf(gatherSystemInformationTo) + 1;
                        startIndex = InsertAllItems(listToAdd, mic, startIndex);
                        CleanUpCollection(mic, modelItem, startIndex);
                    }
                    else
                    {
                        AddToCollection(listToAdd, modelItem);
                    }
                }
            }
        }

        private int InsertAllItems(IEnumerable<string> listToAdd, ModelItemCollection mic, int startIndex)
        {
            foreach (string s in listToAdd)
            {
                mic.Insert(startIndex, new GatherSystemInformationTO(SystemInformationCollection[startIndex - 1].EnTypeOfSystemInformation, s, startIndex + 1));
                startIndex++;
            }

            return startIndex;
        }

        void AddToCollection(IEnumerable<string> listToAdd, ModelItem modelItem)
        {
            var modelProperty = modelItem.Properties["SystemInformationCollection"];
            if (modelProperty != null)
            {
                var mic = modelProperty.Collection;

                if (mic != null)
                {
                    var startIndex = 0;
                    const enTypeOfSystemInformationToGather EnTypeOfSystemInformation = enTypeOfSystemInformationToGather.FullDateTime;
                    mic.Clear();
                    foreach (string s in listToAdd)
                    {
                        mic.Add(new GatherSystemInformationTO(EnTypeOfSystemInformation, s, startIndex + 1));
                        startIndex++;
                    }
                    CleanUpCollection(mic, modelItem, startIndex);
                }
            }
        }

        void CleanUpCollection(ModelItemCollection mic, ModelItem modelItem, int startIndex)
        {
            if (startIndex < mic.Count)
            {
                mic.RemoveAt(startIndex);
            }
            mic.Add(new GatherSystemInformationTO(enTypeOfSystemInformationToGather.FullDateTime, string.Empty, startIndex + 1));
            var modelProperty = modelItem.Properties["DisplayName"];
            if (modelProperty != null)
            {
                modelProperty.SetValue(CreateDisplayName(modelItem, startIndex + 1));
            }
        }

        string CreateDisplayName(ModelItem modelItem, int count)
        {
            var modelProperty = modelItem.Properties["DisplayName"];
            if (modelProperty != null)
            {
                var currentName = modelProperty.ComputedValue as string;
                if (currentName != null && currentName.Contains("(") && currentName.Contains(")"))
                {
                    currentName = currentName.Remove(currentName.Contains(" (") ? currentName.IndexOf(" (", StringComparison.Ordinal) : currentName.IndexOf("(", StringComparison.Ordinal));
                }
                currentName = currentName + " (" + (count - 1) + ")";
                return currentName;
            }

            return string.Empty;
        }

        #endregion

        #endregion

        #region Implementation of ICollectionActivity

        public int GetCollectionCount() => SystemInformationCollection.Count(caseConvertTo => !caseConvertTo.CanRemove());

        public void AddListToCollection(IList<string> listToAdd, bool overwrite, ModelItem modelItem)
        {
            if(!overwrite)
            {
                InsertToCollection(listToAdd, modelItem);
            }
            else
            {
                AddToCollection(listToAdd, modelItem);
            }
        }

        #endregion

        public bool Equals(DsfGatherSystemInformationActivity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other)
                && CommonEqualityOps.CollectionEquals(SystemInformationCollection, other.SystemInformationCollection, new GatherSystemInformationTOComparer());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((DsfGatherSystemInformationActivity) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (SystemInformationCollection != null ? SystemInformationCollection.GetHashCode() : 0);
                return hashCode;
            }
        }
    }


}
