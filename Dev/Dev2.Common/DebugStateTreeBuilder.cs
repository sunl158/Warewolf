﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Dev2.Common.Interfaces.Diagnostics.Debug;

namespace Dev2.Common
{
    public class DebugStateTreeBuilder
    {
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<IDebugState> BuildTree(IEnumerable<IDebugState> source)
        {


            //var groups = source.GroupBy(i => i.ParentID);

            //var roots = groups.First(g => g.Key == Guid.Empty).ToList();

            //if (roots.Any())
            //{
            //    var dict = groups.Where(g => g.Key != Guid.Empty).ToDictionary(g => g.Key.ToString(), g => g.ToList());
            //    for (var i = 0; i < roots.Count(); i++)
            //        AddChildren(roots[i], dict);
            //}
            //var debugStates = roots.GroupBy(state => state.Children).Select(states => states.First());

            return BuildTreeAndReturnRootNodes(source);
        }

        private static IEnumerable<IDebugState> BuildTreeAndReturnRootNodes(IEnumerable<IDebugState> flatItems)
        {
            var debugStates = flatItems.ToList();
            var byIdLookup = debugStates.ToLookup(i => i.ID);
            foreach (var item in debugStates)
            {
                if (item.ParentID != Guid.Empty)
                {

                    var a=byIdLookup.FirstOrDefault(grouping => grouping.Key.ID == item.ID && grouping.Key.ParentID == item.ParentID);
                  byIdLookup[]
                    var parent = a.ToList();
                    if (parent.Children == null)
                    {
                        parent.Children = new List<IDebugState>();
                    }
                    parent.Children.Add(item);
                }
            }
            var clone = debugStates.ToArray().Clone();
            var states = clone as IDebugState[];
            if (states != null)

                foreach (var debugState in states)
                {
                    var any = debugStates.Any(state => state.Children?.Any(p => p.ID == debugState.ID) ?? false);
                    if (any)
                    {
                        debugStates.Remove(debugState);
                    }
                }


            return debugStates;
        }

        private static void AddChildren(IDebugState node, IDictionary<string, List<IDebugState>> source)
        {
            //if (source.ContainsKey(node.ID.ToString()))
            //{
            //    node.Children = source[node.ID.ToString()];
            //    for (var i = 0; i < node.Children.Count; i++)
            //        AddChildren(node.Children[i], source);
            //}
            //else
            //{
            //    node.Children = new List<IDebugState>();
            //}
        }
    }
}
