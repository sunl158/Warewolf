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
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Dev2;
using Dev2.Activities;
using Dev2.Activities.Debug;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.TO;
using Dev2.Diagnostics;
using Dev2.Interfaces;
using Dev2.TO;
using Dev2.Util;
using Dev2.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;
using Warewolf.Core;
using Warewolf.Storage.Interfaces;
using Dev2.Comparer;
using Dev2.Common.State;
using Dev2.Utilities;

namespace Unlimited.Applications.BusinessDesignStudio.Activities
{
    [ToolDescriptorInfo("Scripting-CreateJSON", "Create JSON", ToolType.Native, "8999E59A-38A3-43BB-A98F-6090C5C9EA1E", "Dev2.Activities", "1.0.0.0", "Legacy", "Utility", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_Utility_Create_JSON")]
    public class DsfCreateJsonActivity : DsfActivityAbstract<string>, IEquatable<DsfCreateJsonActivity>
    {
        /// <summary>
        ///     Gets or sets the Warewolf source scalars, lists or record sets, and the destination JSON names of the resulting
        ///     serealisation.
        /// </summary>
        [Inputs("JsonMappings")]
        [FindMissing]
        public List<JsonMappingTo> JsonMappings { get; set; }

        /// <summary>
        ///     Gets or sets the JSON string.
        /// </summary>
        [Outputs("JsonString")]
        [FindMissing]
        public string JsonString { get; set; }

        public DsfCreateJsonActivity()
            : base("Create JSON")
        {
            JsonMappings = new List<JsonMappingTo>();
            DisplayName = "Create JSON";
        }

        public override List<string> GetOutputs() => new List<string> { JsonString };

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
        }

        protected override void OnExecute(NativeActivityContext context)
        {
            var dataObject = context.GetExtension<IDSFDataObject>();
            ExecuteTool(dataObject, 0);
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        protected override void ExecuteTool(IDSFDataObject dataObject, int update)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var allErrors = new ErrorResultTO();
            var errors = new ErrorResultTO();
            allErrors.MergeErrors(errors);
            InitializeDebug(dataObject);
            JsonMappings = JsonMappings.Where(validMapping).ToList();
            // Process if no errors
            try
            {
                if (JsonMappings == null)
                {
                    dataObject.Environment.AddError("Json Mappings supplied to activity is null.");
                }

                if (!dataObject.Environment.Errors.Any() && !JsonMappings.Any())
                {
                    dataObject.Environment.AddError("No JSON Mappings supplied to activity.");
                }

                if (!dataObject.Environment.Errors.Any())
                {
                    JsonMappings.ToList().ForEach(m =>
                    {
                        var validationResult = new IsValidJsonCreateMappingInputRule(() => m).Check();
                        if (validationResult != null)
                        {
                            dataObject.Environment.AddError(validationResult.Message);
                        }
                    });
                }

                if (dataObject.IsDebugMode())
                {
                    var j = 0;

                    foreach (JsonMappingTo a in JsonMappings.Where(to => !String.IsNullOrEmpty(to.SourceName)))
                    {
                        var debugItem = new DebugItem();
                        AddDebugItem(new DebugItemStaticDataParams(string.Empty, (++j).ToString(CultureInfo.InvariantCulture)), debugItem);
                        AddDebugItem(new DebugEvalResult(a.SourceName, string.Empty, dataObject.Environment, update), debugItem);
                        _debugInputs.Add(debugItem);
                    }
                }
                if (!dataObject.Environment.Errors.Any())
                {
                    var json = new JObject();

                    var jsonMappingList = JsonMappings.ToList();
                    var results = jsonMappingList.Where(to => !String.IsNullOrEmpty(to.SourceName)).Select(jsonMapping =>
                        new JsonMappingCompoundTo(dataObject.Environment, jsonMapping
                            )).ToList();
                    results.ForEach(x =>
                    {
                        ParseResultsJSON(x, json);
                    });

                    dataObject.Environment.Assign(JsonString, json.ToString(Formatting.None), update);

                    if (dataObject.IsDebugMode())
                    {
                        AddDebugOutputItem(new DebugEvalResult(JsonString, string.Empty, dataObject.Environment, update));
                    }
                }
            }
            catch (Exception e)
            {
                JsonMappings.ToList().ForEach(x =>
                {
                    AddDebugInputItem(new DebugItemStaticDataParams("", x.SourceName, "SourceName", "="));
                    AddDebugInputItem(new DebugItemStaticDataParams("", x.DestinationName, "DestinationName"));
                });

                allErrors.AddError(e.Message);
                dataObject.Environment.Assign(JsonString, string.Empty, update);
                AddDebugOutputItem(new DebugItemStaticDataParams(string.Empty, JsonString, "", "="));
            }
            finally
            {
                HandleErrors(dataObject, update, allErrors);
            }
        }

        void HandleErrors(IDSFDataObject dataObject, int update, ErrorResultTO allErrors)
        {
            var hasErrors = allErrors.HasErrors();
            if (!hasErrors && dataObject.Environment.Errors.Any())
            {
                DisplayAndWriteError(dataObject, DisplayName, allErrors);
            }

            if (hasErrors)
            {
                var errorString = allErrors.MakeDataListReady();
                dataObject.Environment.AddError(errorString);
                DisplayAndWriteError(dataObject, DisplayName, allErrors);
            }

            if (dataObject.IsDebugMode())
            {
                DispatchDebugState(dataObject, StateType.Before, update);
                DispatchDebugState(dataObject, StateType.After, update);
            }
        }

        private static void ParseResultsJSON(JsonMappingCompoundTo x, JObject json)
        {
            if (!x.IsCompound)
            {
                json.Add(new JProperty(x.DestinationName, x.EvaluatedResultIndexed(0)));
            }
            else
            {
                if (!x.EvalResult.IsWarewolfRecordSetResult)
                {
                    json.Add(new JProperty(x.DestinationName, x.ComplexEvaluatedResultIndexed(0)));
                }
                else
                {
                    if (x.EvalResult.IsWarewolfRecordSetResult)
                    {
                        json.Add(x.ComplexEvaluatedResultIndexed(0));
                    }
                }
            }
        }

        bool validMapping(JsonMappingTo a) => !(String.IsNullOrEmpty(a.DestinationName) && string.IsNullOrEmpty(a.SourceName));

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update) => _debugInputs;

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment env, int update)
        {
            foreach (IDebugItem debugOutput in _debugOutputs)
            {
                debugOutput.FlushStringBuilder();
            }
            return _debugOutputs;
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates) => throw new NotImplementedException();

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates) => throw new NotImplementedException();

        public override IList<DsfForEachItem> GetForEachInputs() => throw new NotImplementedException();

        public override IList<DsfForEachItem> GetForEachOutputs() => throw new NotImplementedException();

        public override enFindMissingType GetFindMissingType() => enFindMissingType.MixedActivity;

        public bool Equals(DsfCreateJsonActivity other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var jsonMappingsAreEqual = Dev2.Common.CommonEqualityOps.CollectionEquals(JsonMappings, other.JsonMappings, new JsonMappingToComparer());
            return base.Equals(other)
                && jsonMappingsAreEqual
                && string.Equals(JsonString, other.JsonString);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
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

            return Equals((DsfCreateJsonActivity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (JsonMappings != null ? JsonMappings.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (JsonString != null ? JsonString.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override IEnumerable<StateVariable> GetState()
        {
            return new[]
            {
                new StateVariable
                {
                    Name="JsonMappings",
                    Type = StateVariable.StateType.Input,
                    Value = ActivityHelper.GetSerializedStateValueFromCollection(JsonMappings)
                },
                new StateVariable
                {
                    Name="JsonString",
                    Type = StateVariable.StateType.Output,
                    Value = JsonString
                }
            };
        }
    }
}
