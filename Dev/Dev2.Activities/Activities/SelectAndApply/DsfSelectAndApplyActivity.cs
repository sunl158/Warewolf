#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
﻿using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Diagnostics;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using Dev2.Common.Interfaces;
using Dev2.Comparer;
using Dev2.Data.TO;
using Dev2.Diagnostics.Debug;
using Dev2.Interfaces;
using Dev2.Util;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Core;
using Warewolf.Resource.Errors;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;
using Dev2.Common.State;

namespace Dev2.Activities.SelectAndApply
{
    [ToolDescriptorInfo("SelectApply", "Select and apply", ToolType.Native, "8999E59A-38A3-43BB-A98F-6090D8C8FA3E", "Dev2.Activities", "1.0.0.0", "Legacy", "Loop Constructs", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_LoopConstruct_Select_and_Apply")]
    public class DsfSelectAndApplyActivity : DsfActivityAbstract<bool>, IEquatable<DsfSelectAndApplyActivity>
    {
        class NullDataSource : Exception
        {

        }
        public DsfSelectAndApplyActivity()
        {
            DisplayName = "Select and apply";
            ApplyActivityFunc = new ActivityFunc<string, bool>
            {
                DisplayName = "Data Action",
                Argument = new DelegateInArgument<string>($"explicitData_{DateTime.Now:yyyyMMddhhmmss}")
            };
        }

        public override IEnumerable<IDev2Activity> GetChildrenNodes()
        {
            var act = ApplyActivityFunc.Handler as IDev2ActivityIOMapping;
            if (act == null)
            {
                return new List<IDev2Activity>();
            }
            var nextNodes = new List<IDev2Activity> { act };
            return nextNodes;
        }

        public override List<string> GetOutputs() => new List<string>();

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.AddDelegate(ApplyActivityFunc);

            base.CacheMetadata(metadata);
        }

        [FindMissing]
        public string DataSource { get; set; }
        [FindMissing]
        public string Alias { get; set; }
        public ActivityFunc<string, bool> ApplyActivityFunc { get; set; }

        string _previousParentId;
        Guid _originalUniqueID;
        string _childUniqueID;

        /// <summary>
        /// When overridden runs the activity's execution logic
        /// </summary>
        /// <param name="context">The context to be used.</param>
        protected override void OnExecute(NativeActivityContext context)
        {
        }

        public override void UpdateDebugParentID(IDSFDataObject dataObject)
        {
            WorkSurfaceMappingId = Guid.Parse(UniqueID);
            var isNestedForEach = dataObject.ForEachNestingLevel > 0;
            if (!isNestedForEach || _originalUniqueID == Guid.Empty)
            {
                _originalUniqueID = WorkSurfaceMappingId;
            }
            UniqueID = isNestedForEach ? Guid.NewGuid().ToString() : UniqueID;
        }

        public override IEnumerable<StateVariable> GetState()
        {
            return new[] {
                new StateVariable
                {
                    Name = "DataSource",
                    Type = StateVariable.StateType.Input,
                    Value = DataSource
                },
                new StateVariable
                {
                    Name = "Alias",
                    Type = StateVariable.StateType.InputOutput,
                    Value = Alias
                }
            };
        }

        protected override void OnBeforeExecute(NativeActivityContext context)
        {
            var dataObject = context.GetExtension<IDSFDataObject>();
            _previousParentId = dataObject.ParentInstanceID;
        }

        public override void UpdateForEachInputs(IList<Tuple<string, string>> updates)
        {
            throw new NotImplementedException();
        }

        public override void UpdateForEachOutputs(IList<Tuple<string, string>> updates)
        {
            throw new NotImplementedException();
        }

        public override IList<DsfForEachItem> GetForEachInputs() => GetForEachItems(Alias);

        public override IList<DsfForEachItem> GetForEachOutputs() => GetForEachItems(Alias.Replace("*", ""));

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            foreach (IDebugItem debugInput in _debugInputs)
            {
                debugInput.FlushStringBuilder();
            }
            return _debugInputs;
        }

        public override List<DebugItem> GetDebugOutputs(IExecutionEnvironment env, int update) => _debugOutputs;

#pragma warning disable S1541 // Methods and properties should not be too complex
#pragma warning disable S3776 // Cognitive Complexity of methods should not be too high
        protected override void ExecuteTool(IDSFDataObject dataObject, int update)
#pragma warning restore S3776 // Cognitive Complexity of methods should not be too high
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var allErrors = new ErrorResultTO();
            InitializeDebug(dataObject);

            if (string.IsNullOrEmpty(DataSource))
            {
                allErrors.AddError(ErrorResource.DataSourceEmpty);
            }
            if (string.IsNullOrEmpty(Alias))
            {
                allErrors.AddError(string.Format(ErrorResource.CanNotBeEmpty, "Alias"));
            }
            if (allErrors.HasErrors())
            {
                DisplayAndWriteError("DsfSelectAndApplyActivity", allErrors);
                foreach (var fetchError in allErrors.FetchErrors())
                {
                    dataObject.Environment.AddError(fetchError);
                }
            }
            var startTime = DateTime.Now;
            _previousParentId = dataObject.ParentInstanceID;
            _debugInputs = new List<DebugItem>();
            _debugOutputs = new List<DebugItem>();

            dataObject.ForEachNestingLevel++;

            var expressions = new List<string>();
            try
            {
                string ds;
                try
                {
                    ds = dataObject.Environment.ToStar(DataSource);
                    expressions = dataObject.Environment.GetIndexes(ds);
                    if (expressions.Count == 0)
                    {
                        expressions.Add(ds);
                    }
                }
                catch (NullReferenceException)
                {
                    //Do nothing exception aleady added to errors
                    throw new NullDataSource();
                }

                if (dataObject.IsDebugMode())
                {
                    AddDebugInputItem(new DebugItemStaticDataParams(Alias, "As", DataSource));
                }

                var scopedEnvironment = new ScopedEnvironment(dataObject.Environment, ds, Alias);

                //Push the new environment
                dataObject.PushEnvironment(scopedEnvironment);
                dataObject.ForEachNestingLevel++;
                if (dataObject.IsDebugMode())
                {
                    DispatchDebugState(dataObject, StateType.Before, update);
                }
                dataObject.ParentInstanceID = UniqueID;
                dataObject.IsDebugNested = true;
                if (dataObject.IsDebugMode())
                {
                    DispatchDebugState(dataObject, StateType.After, update);
                }

                foreach (var exp in expressions)
                {
                    //Assign the warewolfAtom to Alias using new environment
                    scopedEnvironment.SetDataSource(exp);

                    if (ApplyActivityFunc.Handler is IDev2Activity exeAct)
                    {
                        _childUniqueID = exeAct.UniqueID;
                        exeAct.Execute(dataObject, 0);
                    }
                }
            }
            catch (NullDataSource e)
            {
                Dev2Logger.Error("DSFSelectAndApply", e, GlobalConstants.WarewolfError);
            }
            catch (Exception e)
            {
                Dev2Logger.Error("DSFSelectAndApply", e, GlobalConstants.WarewolfError);
                allErrors.AddError(e.Message);
            }
            finally
            {
                if (dataObject.IsServiceTestExecution)
                {
                    if (dataObject.IsDebugMode())
                    {
                        GetTestOurputResultForDebug(dataObject);
                    }
                    else
                    {
                        GetTestOutputForBrowserExecution(dataObject);
                    }
                }

                dataObject.PopEnvironment();
                dataObject.ForEachNestingLevel--;
                if (allErrors.HasErrors())
                {
                    DisplayAndWriteError("DsfSelectAndApplyActivity", allErrors);
                    foreach (var fetchError in allErrors.FetchErrors())
                    {
                        dataObject.Environment.AddError(fetchError);
                    }
                }
                if (dataObject.IsDebugMode())
                {
                    foreach (var expression in expressions)
                    {
                        AddExpresionEvalOutputItem(dataObject, update, expression);
                    }

                    DispatchDebugState(dataObject, StateType.End, update, startTime, DateTime.Now);
                }
                OnCompleted(dataObject);
            }
        }

        void AddExpresionEvalOutputItem(IDSFDataObject dataObject, int update, string expression)
        {
            var data = dataObject.Environment.Eval(expression, update);
            if (data.IsWarewolfAtomListresult)
            {
                var lst = data as CommonFunctions.WarewolfEvalResult.WarewolfAtomListresult;
                AddDebugOutputItem(new DebugItemWarewolfAtomListResult(lst, "", "", expression, "", "", "="));
            }
            else
            {
                if (data.IsWarewolfAtomResult && (data is CommonFunctions.WarewolfEvalResult.WarewolfAtomResult atom))
                {
                    AddDebugOutputItem(new DebugItemWarewolfAtomResult(atom.Item.ToString(), expression, ""));
                }
            }
        }

        void GetTestOutputForBrowserExecution(IDSFDataObject dataObject)
        {
            var serviceTestStep = dataObject.ServiceTest?.TestSteps?.FirstOrDefault(step => step.UniqueId == Guid.Parse(UniqueID));
            if (serviceTestStep != null)
            {
                var testRunResult = new TestRunResult();
                GetFinalTestRunResult(serviceTestStep, testRunResult, dataObject);
                serviceTestStep.Result = testRunResult;
            }
        }

        void GetTestOurputResultForDebug(IDSFDataObject dataObject)
        {
            var serviceTestStep = dataObject.ServiceTest?.TestSteps?.Flatten(step => step.Children)?.FirstOrDefault(step => step.UniqueId == _originalUniqueID);
            var serviceTestSteps = serviceTestStep?.Children;
            UpdateDebugStateWithAssertions(dataObject, serviceTestSteps?.ToList());
            if (serviceTestStep != null)
            {
                var testRunResult = new TestRunResult();
                GetFinalTestRunResult(serviceTestStep, testRunResult, dataObject);
                serviceTestStep.Result = testRunResult;

                var debugItems = TestDebugMessageRepo.Instance.GetDebugItems(dataObject.ResourceID, dataObject.TestName);
                debugItems = debugItems.Where(state => state.WorkSurfaceMappingId == serviceTestStep.UniqueId).ToList();
                var debugStates = debugItems.LastOrDefault();

                var debugItemStaticDataParams = new DebugItemServiceTestStaticDataParams(serviceTestStep.Result.Message, serviceTestStep.Result.RunTestResult == RunResult.TestFailed);
                var itemToAdd = new DebugItem();
                itemToAdd.AddRange(debugItemStaticDataParams.GetDebugItemResult());
                debugStates?.AssertResultList?.Add(itemToAdd);
            }
        }

        void GetFinalTestRunResult(IServiceTestStep serviceTestStep, TestRunResult testRunResult, IDSFDataObject dataObject)
        {
            RegularActivityAssertion(dataObject, serviceTestStep);
            var nonPassingSteps = serviceTestStep.Children?.Where(step => step.Result?.RunTestResult != RunResult.TestPassed).ToList();
            if (nonPassingSteps != null && nonPassingSteps.Count == 0)
            {
                testRunResult.Message = Warewolf.Resource.Messages.Messages.Test_PassedResult;
                testRunResult.RunTestResult = RunResult.TestPassed;
            }
            else
            {
                if (nonPassingSteps != null)
                {
                    var failMessage = string.Join(Environment.NewLine, nonPassingSteps.Select(step => step.Result.Message));
                    testRunResult.Message = failMessage;
                }
                testRunResult.RunTestResult = RunResult.TestFailed;
            }
        }

        void OnCompleted(IDSFDataObject dataObject)
        {
            dataObject.IsDebugNested = false;
            dataObject.ParentInstanceID = _previousParentId;
            dataObject.ForEachNestingLevel--;
            UniqueID = _originalUniqueID.ToString();
        }

        public override enFindMissingType GetFindMissingType() => enFindMissingType.ForEach;

        void UpdateDebugStateWithAssertions(IDSFDataObject dataObject, List<IServiceTestStep> serviceTestTestSteps)
        {
            ServiceTestHelper.UpdateDebugStateWithAssertions(dataObject, serviceTestTestSteps, _childUniqueID);
        }

        public bool Equals(DsfSelectAndApplyActivity other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var activityFuncComparer = new ActivityFuncComparer();
            return base.Equals(other)
                && string.Equals(_previousParentId, other._previousParentId)
                && Equals(_originalUniqueID, other._originalUniqueID)
                && string.Equals(_childUniqueID, other._childUniqueID)
                && string.Equals(DataSource, other.DataSource)
                && string.Equals(Alias, other.Alias)
                && activityFuncComparer.Equals(ApplyActivityFunc, other.ApplyActivityFunc);
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

            return Equals((DsfSelectAndApplyActivity)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (_previousParentId != null ? _previousParentId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _originalUniqueID.GetHashCode();
                hashCode = (hashCode * 397) ^ (_childUniqueID != null ? _childUniqueID.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (DataSource != null ? DataSource.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Alias != null ? Alias.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (ApplyActivityFunc != null ? ApplyActivityFunc.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}