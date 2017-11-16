/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;

namespace Dev2.Services.Security
{
    public class WindowsGroupPermissionEqualityComparer : IEqualityComparer<WindowsGroupPermission>
    {
        #region Implementation of IEqualityComparer<in WindowsGroupPermission>

        public bool Equals(WindowsGroupPermission x, WindowsGroupPermission y) => x.Permissions.Equals(y.Permissions) && x.ResourceID.Equals(y.ResourceID) && ((x.WindowsGroup == null) || x.WindowsGroup.Equals(y.WindowsGroup));

        public int GetHashCode(WindowsGroupPermission obj) => throw new NotImplementedException();

        #endregion
    }
}
