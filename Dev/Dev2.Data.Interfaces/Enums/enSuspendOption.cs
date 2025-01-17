﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2020 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.ComponentModel;

namespace Dev2.Data.Interfaces.Enums
{
    public enum enSuspendOption
    {
        [Description("Suspend until:")]
        SuspendUntil,
        [Description("Suspend for Second(s):")]
        SuspendForSeconds,
        [Description("Suspend for Minute(s):")]
        SuspendForMinutes,
        [Description("Suspend for Hour(s):")]
        SuspendForHours,
        [Description("Suspend for Day(s):")]
        SuspendForDays,
        [Description("Suspend for Month(s):")]
        SuspendForMonths,
    }
}