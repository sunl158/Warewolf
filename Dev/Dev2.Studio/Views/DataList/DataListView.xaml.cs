/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dev2.Common.Interfaces;
using Dev2.Studio.Interfaces.DataList;
using Dev2.Studio.ViewModels.WorkSurface;
using Microsoft.Practices.Prism.Mvvm;
using Dev2.Instrumentation;

namespace Dev2.Studio.Views.DataList
{
    /// <summary>
    /// Interaction logic for DataListView.xaml
    /// </summary>
    public partial class DataListView : IView,ICheckControlEnabledView
    {

        public DataListView()
        {
            InitializeComponent();
            KeyboardNavigation.SetTabNavigation(ScalarExplorer, KeyboardNavigationMode.Cycle);
        }

        #region Events

        private void NametxtTextChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is IDataListViewModel vm)
            {
                TextBox txtbox = sender as TextBox;
                if (txtbox?.DataContext is IDataListItemModel itemThatChanged)
                {
                    itemThatChanged.IsExpanded = true;
                }
                vm.AddBlankRow(null);
            }
        }

        private void Inputcbx_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null || !checkBox.IsEnabled)
            {
                return;
            }
            WriteToResourceModel();
        }

        private void Outputcbx_OnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null || !checkBox.IsEnabled)
            {
                return;
            }
            WriteToResourceModel();
        }

        private void NametxtFocusLost(object sender, RoutedEventArgs e)
        {
            DoDataListValidation(sender);
        }

        void DoDataListValidation(object sender)
        {
            if (DataContext is IDataListViewModel vm)
            {
                if (sender is TextBox txtbox)
                {
                    IDataListItemModel itemThatChanged = txtbox.DataContext as IDataListItemModel;
                    vm.RemoveBlankRows(itemThatChanged);
                    vm.ValidateNames(itemThatChanged);

                    // code to log errors to revulytics
                    if (vm.HasErrors && vm.DataListErrorMessage.Length != 0)
                    {
                        var applicationTracker = CustomContainer.Get<IApplicationTracker>();
                        if (applicationTracker != null)
                        {
                            applicationTracker.TrackCustomEvent(Warewolf.Studio.Resources.Languages.TrackEventVariables.EventCategory, Warewolf.Studio.Resources.Languages.TrackEventVariables.RedBracketsSyntax, vm.DataListErrorMessage);
                        }
                    }

                }
            }
        }

        private void UserControlLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            WriteToResourceModel();
        }

        #endregion Events

        #region Private Methods

        private void WriteToResourceModel()
        {
            if (DataContext is IDataListViewModel vm && !vm.IsSorting)
            {
                vm.WriteToResourceModel();
            }
        }

        #endregion Private Methods

        private void UIElement_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var vm = DataContext as IDataListViewModel;
            var model = vm?.Parent as WorkSurfaceContextViewModel;
            model?.FindMissing();
        }

        #region Implementation of ICheckControlEnabledView

        public bool GetControlEnabled(string controlName)
        {
            switch (controlName)
            {
                case "Delete Variables":
                    return DeleteButton.Command.CanExecute(null);
                case "Sort Variables":
                    return SortButton.Command.CanExecute(null);
                case "Variables":
                    return ScalarExplorer.IsEnabled;
                default:
                    break;
            }

            return false;
        }

        #endregion
    }
}
