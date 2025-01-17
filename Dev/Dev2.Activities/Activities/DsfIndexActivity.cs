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
using Dev2.Activities;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Common.State;
using Dev2.Data;
using Dev2.Data.Interfaces;
using Dev2.Data.Operations;
using Dev2.Data.TO;
using Dev2.Diagnostics;
using Dev2.Interfaces;
using Dev2.Util;
using Dev2.Validation;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;
using Warewolf.Core;
using Warewolf.Resource.Errors;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;


namespace Unlimited.Applications.BusinessDesignStudio.Activities

{
    [ToolDescriptorInfo("Data-FindIndex", "Find Index", ToolType.Native, "8999E59A-38A3-43BB-A98F-6090C5C9EA1E", "Dev2.Activities", "1.0.0.0", "Legacy", "Data", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_Data_Find_Index")]
    public class DsfIndexActivity : DsfActivityAbstract<string>, IEquatable<DsfIndexActivity>
    {

        #region Properties

        /// <summary>
        /// The property that holds the date time string the user enters into the "InField" box
        /// </summary>
        [Inputs("InField")]
        [FindMissing]
        public string InField { get; set; }

        /// <summary>
        /// The property that holds the input format string the user enters into the "Index" dropdownbox
        /// </summary>
        [Inputs("Index")]
        public string Index { get; set; }

        /// <summary>
        /// The property that holds the output format string the user enters into the "Characters" box
        /// </summary>
        [Inputs("Characters")]
        [FindMissing]
        public string Characters { get; set; }

        /// <summary>
        /// The property that holds the time modifier string the user selects in the "Direction" combobox
        /// </summary>
        [Inputs("Direction")]
        public string Direction { get; set; }

        /// <summary>
        /// The property that holds the result string the user enters into the "Result" box
        /// </summary>
        [Outputs("Result")]
        [FindMissing]
        public new string Result { get; set; }

        /// <summary>
        /// The property that holds the boolean for the match case checkbox 
        /// </summary>
        [Inputs("MatchCase")]
        public bool MatchCase { get; set; }

        /// <summary>
        /// The property that holds the start index that the user enters into the "StartIndex" textbox
        /// </summary>
        [Inputs("StartIndex")]
        [FindMissing]
        public string StartIndex { get; set; }


        #endregion Properties

        #region Ctor

        /// <summary>
        /// The consructor for the activity 
        /// </summary>
        public DsfIndexActivity()
            : base("Find Index")
        {
            InField = string.Empty;
            Index = "First Occurrence";
            Characters = string.Empty;
            Direction = "Left to Right";
            MatchCase = false;
            Result = string.Empty;
            StartIndex = "0";
        }

        #endregion Ctor

        public override List<string> GetOutputs() => new List<string> { Result };

        protected override void CacheMetadata(NativeActivityMetadata metadata) => base.CacheMetadata(metadata);

        protected override void OnExecute(NativeActivityContext context)
        {
            var dataObject = context.GetExtension<IDSFDataObject>();

            ExecuteTool(dataObject, 0);
        }

        protected override void ExecuteTool(IDSFDataObject dataObject, int update)
        {
            IDev2IndexFinder indexFinder = new Dev2IndexFinder();
            var allErrors = new ErrorResultTO();
            var errors = new ErrorResultTO();
            InitializeDebug(dataObject);

            try
            {
                TryExecute(dataObject, update, indexFinder, allErrors, errors);
            }
            catch (Exception e)
            {
                allErrors.AddError(e.Message);
            }
            finally
            {
                var hasErrors = allErrors.HasErrors();
                if (hasErrors)
                {
                    var errorString = allErrors.MakeDisplayReady();
                    dataObject.Environment.AddError(errorString);
                    DisplayAndWriteError(dataObject,DisplayName, allErrors);
                }

                if (dataObject.IsDebugMode())
                {
                    if (hasErrors)
                    {
                        AddDebugOutputItem(new DebugEvalResult(Result, "", dataObject.Environment, update));
                    }
                    DispatchDebugState(dataObject, StateType.Before, update);
                    DispatchDebugState(dataObject, StateType.After, update);
                }
            }
        }

        void TryExecute(IDSFDataObject dataObject, int update, IDev2IndexFinder indexFinder, ErrorResultTO allErrors, ErrorResultTO errors)
        {
            var outerIteratorCollection = new WarewolfListIterator();
            var innerIteratorCollection = new WarewolfListIterator();

            allErrors.MergeErrors(errors);

            if (dataObject.IsDebugMode())
            {
                AddDebugInputItem(new DebugEvalResult(InField, "In Field", dataObject.Environment, update));
                AddDebugInputItem(new DebugItemStaticDataParams(Index, "Index"));
                AddDebugInputItem(new DebugEvalResult(Characters, "Characters", dataObject.Environment, update));
                AddDebugInputItem(new DebugItemStaticDataParams(Direction, "Direction"));
            }

            var itrChar = new WarewolfIterator(dataObject.Environment.Eval(Characters, update));
            outerIteratorCollection.AddVariableToIterateOn(itrChar);

            var completeResultList = new List<string>();
            if (String.IsNullOrEmpty(InField))
            {
                allErrors.AddError(string.Format(ErrorResource.IsBlank, "'In Field'"));
            }
            else if (String.IsNullOrEmpty(Characters))
            {
                allErrors.AddError(string.Format(ErrorResource.IsBlank, "'Characters'"));
            }
            else
            {
                while (outerIteratorCollection.HasMoreData())
                {
                    allErrors.MergeErrors(errors);
                    errors.ClearErrors();
                    var itrInField = new WarewolfIterator(dataObject.Environment.Eval(InField, update));
                    innerIteratorCollection.AddVariableToIterateOn(itrInField);

                    var chars = outerIteratorCollection.FetchNextValue(itrChar);
                    while (innerIteratorCollection.HasMoreData())
                    {
                        CheckForErrors(dataObject, update, indexFinder, allErrors, errors, innerIteratorCollection, completeResultList, itrInField, chars);
                        completeResultList = new List<string>();
                    }
                }
                if (!allErrors.HasErrors() && dataObject.IsDebugMode())
                {
                    AddDebugOutputItem(new DebugEvalResult(Result, "", dataObject.Environment, update));
                }
            }
        }

        private void CheckForErrors(IDSFDataObject dataObject, int update, IDev2IndexFinder indexFinder, ErrorResultTO allErrors, ErrorResultTO errors, WarewolfListIterator innerIteratorCollection, List<string> completeResultList, WarewolfIterator itrInField, string chars)
        {
            if (!string.IsNullOrEmpty(InField) && !string.IsNullOrEmpty(Characters))
            {
                var val = innerIteratorCollection.FetchNextValue(itrInField);
                if (val != null)
                {
                    var returedData = indexFinder.FindIndex(val, Index, chars, Direction, MatchCase, StartIndex);
                    completeResultList.AddRange(returedData.Select(value => value.ToString(CultureInfo.InvariantCulture)).ToList());
                    var rule = new IsSingleValueRule(() => Result);
                    var single = rule.Check();
                    if (single != null)
                    {
                        allErrors.AddError(single.Message);
                    }
                    else
                    {
                        dataObject.Environment.Assign(Result, string.Join(",", completeResultList), update);
                        allErrors.MergeErrors(errors);
                    }
                }
            }
        }

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            foreach (DebugItem debugInput in _debugInputs)
            {
                debugInput.FlushStringBuilder();
            }
            return _debugInputs;
        }

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment env, int update)
        {
            foreach (IDebugItem debugOutput in _debugOutputs)
            {
                debugOutput.FlushStringBuilder();
            }
            return _debugOutputs;
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates)
        {
            if (updates != null)
            {
                foreach (Tuple<string, string> t in updates)
                {

                    if (t.Item1 == InField)
                    {
                        InField = t.Item2;
                    }

                    if (t.Item1 == Characters)
                    {
                        Characters = t.Item2;
                    }
                }
            }
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates)
        {
            var itemUpdate = updates?.FirstOrDefault(tuple => tuple.Item1 == Result);
            if (itemUpdate != null)
            {
                Result = itemUpdate.Item2;
            }
        }

        public override IList<DsfForEachItem> GetForEachInputs() => GetForEachItems(InField, Characters);

        public override IList<DsfForEachItem> GetForEachOutputs() => GetForEachItems(Result);

        public override IEnumerable<StateVariable> GetState()
        {
            return new[]
            {
                new StateVariable
                {
                    Name = "StartIndex",
                    Type = StateVariable.StateType.Input,
                    Value = StartIndex
                },
                new StateVariable
                {
                    Name ="MatchCase",
                    Type = StateVariable.StateType.Input,
                    Value = MatchCase.ToString()
                },
                new StateVariable
                {
                    Name ="Direction",
                    Type = StateVariable.StateType.Input,
                    Value = Direction
                },
                new StateVariable
                {
                    Name ="Characters",
                    Type = StateVariable.StateType.Input,
                    Value = Characters
                },
                new StateVariable
                {
                    Name ="Index",
                    Type = StateVariable.StateType.Input,
                    Value = Index
                },
                new StateVariable
                {
                    Name ="InField",
                    Type = StateVariable.StateType.Input,
                    Value = InField
                },
                new StateVariable
                {
                    Name = "Result",
                    Type = StateVariable.StateType.Output,
                    Value = Result
                },
            };
        }

        public bool Equals(DsfIndexActivity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return base.Equals(other) && string.Equals(InField, other.InField) && string.Equals(Index, other.Index) && string.Equals(Characters, other.Characters) && string.Equals(Direction, other.Direction) && string.Equals(Result, other.Result) && MatchCase == other.MatchCase && string.Equals(StartIndex, other.StartIndex);
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

            return Equals((DsfIndexActivity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (InField != null ? InField.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Index != null ? Index.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Characters != null ? Characters.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Direction != null ? Direction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Result != null ? Result.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MatchCase.GetHashCode();
                hashCode = (hashCode * 397) ^ (StartIndex != null ? StartIndex.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
