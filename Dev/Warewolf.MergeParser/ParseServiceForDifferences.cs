﻿using System.Activities.Presentation.Model;
using System.Activities.Statements;
using System.Activities.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Dev2.Studio.Core.Activities.Utils;
using System.Activities.Presentation;
using Dev2;
using Dev2.Activities;
using Dev2.Studio.Interfaces;
using Dev2.Common;
using Unlimited.Applications.BusinessDesignStudio.Activities;

namespace Warewolf.MergeParser
{
    public class ParseServiceForDifferences : IParseServiceForDifferences
    {
        public ParseServiceForDifferences()
        {
            CurrentDifferences = new List<ModelItem>();
            Differences = new List<ModelItem>();
        }
        public List<ModelItem> CurrentDifferences { get; private set; }
        public List<ModelItem> Differences { get; private set; }

        private ModelItem GetCurrentModelItemUniqueId(IEnumerable<ModelItem> items, string uniqueId)
        {
            foreach (var modelItem in items)
            {
                if (modelItem.ItemType == typeof(FlowDecision))
                {
                    var act = modelItem.GetCurrentValue<FlowDecision>();
                    var dec = act.Condition as DsfFlowDecisionActivity;
                    if (dec != null && dec.UniqueID.Equals(uniqueId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return modelItem;
                    }
                }
                else if (modelItem.ItemType == typeof(FlowSwitch<string>))
                {
                    var condition = modelItem.GetProperty("Expression");
                    var activity = (DsfFlowNodeActivity<string>)condition;
                    if (activity != null && activity.UniqueID.Equals(uniqueId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return modelItem;
                    }
                }
                else
                {
                    if (modelItem.GetCurrentValue<FlowStep>().Action is IDev2Activity currentValue &&
                        currentValue.UniqueID.Equals(uniqueId, StringComparison.InvariantCultureIgnoreCase))
                    {
                        return modelItem;
                    }
                }
            }

            return default;
        }

        private List<IDev2Activity> DiscoverActivities(List<ModelItem> modelItems)
        {
            var discoverActivities = new List<IDev2Activity>();
            foreach (var modelItem in modelItems)
            {
                if (modelItem.ItemType == typeof(FlowDecision))
                {
                    var dev2Activity = modelItem.GetProperty<IDev2Activity>("Condition");
                    discoverActivities.Add(dev2Activity);
                }
                else if (modelItem.ItemType == typeof(FlowSwitch<string>))
                {
                    var condition = modelItem.GetProperty("Expression");
                    var activity = (DsfFlowNodeActivity<string>)condition;
                    discoverActivities.Add(activity);
                }
                else
                {
                    var currentValue = modelItem.GetProperty<IDev2Activity>("Action");
                    discoverActivities.Add(currentValue);
                }

            }
            return discoverActivities;
        }

        public List<(Guid uniqueId, ModelItem current, ModelItem difference, bool conflict)> GetDifferences(IContextualResourceModel current, IContextualResourceModel difference)
        {
            var conflictList = new List<(Guid uniqueId, ModelItem current, ModelItem difference, bool conflict)>();
            CurrentDifferences = GetNodes(current);
            Differences = GetNodes(difference);
            var currenctDifferences = DiscoverActivities(CurrentDifferences);
            var allDifferencesActivities = DiscoverActivities(Differences);
            var mergeHeadActivities = CurrentDifferences.Select(item => GetActivity(currenctDifferences, item)).ToList();
            var headActivities = Differences.Select(modelItem => GetActivity(allDifferencesActivities, modelItem)).ToList();
            List<IDev2Activity> equalItems = new List<IDev2Activity>();
            foreach (var mergeHeadActivity in mergeHeadActivities)
            {
                var singleOrDefault = headActivities.SingleOrDefault(activity => activity.Equals(mergeHeadActivity));
                if (singleOrDefault != null)
                    equalItems.Add(singleOrDefault);
            }

            List<IDev2Activity> nodesDifferentInMergeHead = mergeHeadActivities.Except(headActivities, new Dev2ActivityComparer()).ToList();
            List<IDev2Activity> toRemove = new List<IDev2Activity>();
            foreach (var differentInMergeHead in nodesDifferentInMergeHead)
            {
                if (equalItems.Contains(differentInMergeHead, new Dev2UniqueActivityComparer()))
                {
                    toRemove.Add(differentInMergeHead);
                }
            }

            nodesDifferentInMergeHead.RemoveAll(activity => toRemove.Exists(dev2Activity => dev2Activity.Equals(activity)));

            var nodesDifferentInHead = headActivities.Except(mergeHeadActivities, new Dev2ActivityComparer()).ToList();
            List<IDev2Activity> toRemove1 = new List<IDev2Activity>();
            foreach (var differentInMergeHead in nodesDifferentInHead)
            {
                if (equalItems.Contains(differentInMergeHead))
                {
                    toRemove1.Add(differentInMergeHead);
                }
            }
            nodesDifferentInHead.RemoveAll(activity => toRemove1.Exists(dev2Activity => dev2Activity.Equals(activity)));

            var allDifferences = nodesDifferentInMergeHead.Union(nodesDifferentInHead, new Dev2ActivityComparer());

            foreach (var item in equalItems)
            {
                if (item is null)
                {
                    continue;
                }
                var currentModelItemUniqueId = GetCurrentModelItemUniqueId(CurrentDifferences, item.UniqueID);
                var equalItem = (Guid.Parse(item.UniqueID), currentModelItemUniqueId, currentModelItemUniqueId, false);
                conflictList.Add(equalItem);
            }

            var differenceGroups = allDifferences.GroupBy(activity => activity.UniqueID);
            foreach (var item in differenceGroups)
            {
                var currentModelItemUniqueId = GetCurrentModelItemUniqueId(CurrentDifferences, item.Key);
                var differences = GetCurrentModelItemUniqueId(Differences, item.Key);
                var diffItem = (Guid.Parse(item.Key), currentModelItemUniqueId, differences, true);
                conflictList.Add(diffItem);
            }
            return conflictList;
        }

        private IDev2Activity GetActivity(List<IDev2Activity> currentDifferences, ModelItem modelItem)
        {
            var activityParser = CustomContainer.Get<IActivityParser>() ?? new ActivityParser();
            return activityParser?.Parse(currentDifferences, modelItem);
        }

        private List<ModelItem> GetNodes(IContextualResourceModel resourceModel)
        {
            var wd = new WorkflowDesigner();
            var xaml = resourceModel.WorkflowXaml;

            var workspace = GlobalConstants.ServerWorkspaceID;
            var msg = resourceModel.Environment.ResourceRepository.FetchResourceDefinition(resourceModel.Environment, workspace, resourceModel.ID, false);
            if (msg != null)
            {
                xaml = msg.Message;
            }

            if (xaml == null || xaml.Length == 0)
            {
                throw new Exception($"Could not find resource definition for {resourceModel.ResourceName}");
            }
            wd.Text = xaml.ToString();
            wd.Load();

            var modelService = wd.Context.Services.GetService<ModelService>();
            var nodeList = modelService.Find(modelService.Root, typeof(FlowNode)).ToList();
            // ReSharper disable once RedundantAssignment assuming this is for disposing
            wd = null;
            return nodeList;
        }
    }
}
