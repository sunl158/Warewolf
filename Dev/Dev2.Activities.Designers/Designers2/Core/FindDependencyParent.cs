﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Windows;
using System.Windows.Media;

namespace Dev2.Activities.Designers2.Core
{
    public static class FindDependencyParent
    {
        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
           
            if(child == null)
            {
                return null;
            }
            //get parent item
            var parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null)
            {
                return null;
            }

            //check if the parent matches the type we're looking for
            if (parentObject is T parent)
            {
                return parent;
            }

            return FindParent<T>(parentObject);
        }
    }
}
