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
using Dev2.Activities.Designers2.Core;
using Dev2.Studio.Interfaces;



namespace Dev2.Activities.Designers2.ReadFolder
{
    public class ReadFolderDesignerViewModel : FileActivityDesignerViewModel
    {
        public ReadFolderDesignerViewModel(ModelItem modelItem)
            : base(modelItem, "Directory", string.Empty)
        {
            AddTitleBarLargeToggle();

            if (!IsFilesAndFoldersSelected && !IsFoldersSelected && !IsFilesSelected)
            {
                IsFilesSelected = true;
            }
            HelpText = Warewolf.Studio.Resources.Languages.HelpText.Tool_File_Read_Folder;
        }

        public override void Validate()
        {
            Errors = null;
            ValidateUserNameAndPassword();
            ValidateInputPath();
        }

        bool IsFilesAndFoldersSelected => GetProperty<bool>();
        bool IsFoldersSelected => GetProperty<bool>();
        bool IsFilesSelected { set => SetProperty(value); get => GetProperty<bool>(); }

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IShellViewModel>();
            mainViewModel?.HelpViewModel.UpdateHelpText(helpText);
        }
    }
}
