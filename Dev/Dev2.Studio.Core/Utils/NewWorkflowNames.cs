#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;


namespace Dev2.Studio.Core.Utils
{
    /// <summary>
    /// Used for storing all the used workflow names and getting the next available name
    /// </summary>
    public class NewWorkflowNames
    {
        #region Fields

        static NewWorkflowNames _instance;
        readonly HashSet<string> _workflowNamesHashSet = new HashSet<string>();

        #endregion

        #region Ctor

        public NewWorkflowNames()
        {
            _workflowNamesHashSet = new HashSet<string>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Remove a name from WorkflowNamesHashSet so i can be reused
        /// </summary>
        /// <param name="nameToRemove"></param>
        public bool Remove(string nameToRemove)
        {
            var result = false;
            if (Contains(nameToRemove))
            {
                _workflowNamesHashSet.Remove(nameToRemove);
                result = true;
            }
            return result;
        }

        public bool RemoveAll(string nameToRemove)
        {
            _workflowNamesHashSet.Remove(nameToRemove);
            return true;
        }

        /// <summary>
        /// Gets the next available name to use for createing new workflow
        /// </summary>
        /// <returns>The next available workflow name</returns>
        public string GetNext()
        {
            var newWorkflowBaseName = StringResources.NewWorkflowBaseName;

            var counter = 1;
            var fullName = StringResources.NewWorkflowBaseName + " " + counter;

            while (Contains(fullName))
            {
                counter++;
                fullName = newWorkflowBaseName + " " + counter;
            }

            Add(fullName);

            return fullName;
        }

        /// <summary>
        /// Check if the HashSet contains the specified name
        /// </summary>
        /// <param name="nameToCheck"></param>
        /// <returns>Does the HashSet contain the string</returns>
        public bool Contains(string nameToCheck) => _workflowNamesHashSet.Contains(nameToCheck);

        /// <summary>
        /// Add a used name to the WorkflowNamesHashSet
        /// </summary>
        /// <param name="newWorkflowName"></param>
        public bool Add(string newWorkflowName)
        {
            // only add the one's that matter ;)
            if(newWorkflowName.IndexOf(StringResources.NewWorkflowBaseName, StringComparison.Ordinal) == 0)
            {
                _workflowNamesHashSet.Add(newWorkflowName);

                return true;
            }

            return false;
        }

        #endregion

        #region Properties

        public static NewWorkflowNames Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new NewWorkflowNames();
                }
                return _instance;
            }
        }

        #endregion
    }
}
