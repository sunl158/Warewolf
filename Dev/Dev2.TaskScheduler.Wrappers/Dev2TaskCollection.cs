/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections;
using System.Collections.Generic;
using Dev2.Common.Interfaces.WindowsTaskScheduler.Wrappers;
using Microsoft.Win32.TaskScheduler;
using System;

namespace Dev2.TaskScheduler.Wrappers
{
    public class Dev2TaskCollection : ITaskCollection
    {
        readonly TaskCollection _instance;
        readonly ITaskServiceConvertorFactory _taskServiceConvertorFactory;

        public Dev2TaskCollection(ITaskServiceConvertorFactory taskServiceConvertorFactory, TaskCollection instance)
        {
            _taskServiceConvertorFactory = taskServiceConvertorFactory;
            _instance = instance;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Cleanup
        }

        public TaskCollection Instance => _instance;

        public IEnumerator<IDev2Task> GetEnumerator()
        {
            var e = _instance.GetEnumerator();
            while (e.MoveNext())
            {
                yield return _taskServiceConvertorFactory.CreateTask(e.Current);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
