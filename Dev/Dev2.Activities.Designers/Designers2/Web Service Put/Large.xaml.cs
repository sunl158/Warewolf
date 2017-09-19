﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.ComponentModel;
using System.Windows;
using Dev2.Activities.Designers2.Core.Controls;

namespace Dev2.Activities.Designers2.Web_Service_Put
{
    // Interaction logic for Large.xaml
    public partial class Large
    {
        public Large()
        {
            InitializeComponent();
            SetInitialFocus();
        }

        #region Overrides of ActivityDesignerTemplate

        protected override IInputElement GetInitialFocusElement()
        {
            return MainGrid;
        }

        #endregion
        void RequestBody_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (DataContext is WebServicePutViewModel viewModel)
            {
                var dataContext = viewModel.InputArea;
                if (dataContext.IsEnabled)
                {
                    //MinHeight = dataContext.MinHeight + 25;
                    //MaxHeight += e.NewSize.Height;
                    //Height = MinHeight;
                }
            }
        }

        private void AutoCompleteBox_OnTextChanged(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("a");
        }
    }
}
