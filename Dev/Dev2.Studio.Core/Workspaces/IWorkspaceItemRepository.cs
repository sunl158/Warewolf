/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Collections.Generic;
using Dev2.Communication;
using Dev2.Studio.Interfaces;
using Dev2.Workspaces;


namespace Dev2.Studio.Core.Workspaces
{
    public interface IWorkspaceItemRepository
    {
        IList<IWorkspaceItem> WorkspaceItems { get; }
        void Write();
        void AddWorkspaceItem(IContextualResourceModel model);
        void Remove(IContextualResourceModel resourceModel);
        void UpdateWorkspaceItemIsWorkflowSaved(IContextualResourceModel resourceModel);
        void ClearWorkspaceItems(IContextualResourceModel resourceModel);
    }
}
