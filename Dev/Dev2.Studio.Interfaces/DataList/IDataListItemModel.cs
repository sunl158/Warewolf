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
using Dev2.Data.Interfaces.Enums;

namespace Dev2.Studio.Interfaces.DataList
{
    public delegate void DataListItemDeletedEventHandler(IDataListItemModel dataListItemModel);

    public interface IDataListItemModel : IEquatable<IDataListItemModel>
    {
        string DisplayName { get; set; }
        string Description { get; set; }
        bool Input { get; set; }
        bool Output { get; set; }
        bool IsVisible { get; set; }
        bool IsExpanded { get; set; }
        bool IsUsed { get; set; }
        bool AllowNotes { get; set; }
        bool IsComplexObject { get; set; }
        bool IsSelected { get; set; }
        bool HasError { get; set; }
        string ErrorMessage { get; set; }
        bool IsEditable { get; set; }
        enDev2ColumnArgumentDirection ColumnIODirection { get; set; }
        bool IsBlank { get; }
        void SetError(string errorMessage);
        void RemoveError();
        string Name { get; set; }
        event DataListItemDeletedEventHandler OnDeleted;
    }
}