/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Activities.Presentation.Model;
using Dev2.Activities.Designers2.DeleteRecordsNullHandler;

namespace Dev2.Activities.Designers.Tests.DeleteRecordsNullHandler
{
    public class TestDeleteRecordsNullHandlerDesignerViewModel : DeleteRecordsDesignerViewModel
    {
        public TestDeleteRecordsNullHandlerDesignerViewModel(ModelItem modelItem)
            : base(modelItem)
        {
        }

        public TestDeleteRecordsNullHandlerDesignerViewModel(ModelItem modelItem, string recordSetName)
            : base(modelItem)
        {
            RecordsetName = recordSetName;
        }

        public string RecordsetName { get { return GetProperty<string>(); } set { SetProperty(value); } }
    }
}
