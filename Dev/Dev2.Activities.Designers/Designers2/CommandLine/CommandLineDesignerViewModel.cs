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
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using Dev2.Activities.Designers2.Core;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Providers.Errors;
using Dev2.Studio.Interfaces;
using Dev2.Validation;
using Warewolf.Resource.Errors;

namespace Dev2.Activities.Designers2.CommandLine
{
    public class CommandLineDesignerViewModel : ActivityDesignerViewModel
    {
        public CommandLineDesignerViewModel(ModelItem modelItem)
            : base(modelItem)
        {
            AddTitleBarLargeToggle();
            InitializeCommandPriorities();
            HelpText = Warewolf.Studio.Resources.Languages.HelpText.Tool_Scripting_CMD_Script;
        }

        public List<KeyValuePair<ProcessPriorityClass, string>> CommandPriorities { get; private set; }

        public bool IsCommandFileNameFocused { get => (bool)GetValue(IsCommandFileNameFocusedProperty); set { SetValue(IsCommandFileNameFocusedProperty, value); } }

        public static readonly DependencyProperty IsCommandFileNameFocusedProperty =
            DependencyProperty.Register("IsCommandFileNameFocused", typeof(bool), typeof(CommandLineDesignerViewModel), new PropertyMetadata(false));

        string CommandFileName => GetProperty<string>();

        public override void Validate()
        {
            Errors = null;
            var errors = new List<IActionableErrorInfo>();

            Action onError = () => IsCommandFileNameFocused = true;
            var util = new VariableUtils();
            util.AddError(errors, util.TryParseVariables(CommandFileName,out string commandValue, onError));

            if (string.IsNullOrWhiteSpace(commandValue))
            {
                errors.Add(new ActionableErrorInfo(onError) { ErrorType = ErrorType.Critical, Message = string.Format(ErrorResource.PropertyMusHaveAValue, "Command") });
            }

            // Always assign property otherwise binding does not update!
            Errors = errors;
        }

        void InitializeCommandPriorities()
        {
            CommandPriorities = new List<KeyValuePair<ProcessPriorityClass, string>>
            {
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.BelowNormal, "Below Normal"),
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.Normal, "Normal"),
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.AboveNormal, "Above Normal"),
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.Idle, "Idle"),
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.High, "High"),
                new KeyValuePair<ProcessPriorityClass, string>(ProcessPriorityClass.RealTime, "Real Time"),
            };
        }

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IShellViewModel>();
            mainViewModel?.HelpViewModel.UpdateHelpText(helpText);
        }
    }
}
