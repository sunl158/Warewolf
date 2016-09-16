﻿using System;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dev2.Common.Interfaces;
using Dev2.Studio.Core.Interfaces;
using Dev2.UI;
using Microsoft.Practices.Prism.Mvvm;

namespace Warewolf.Studio.Views
{
    /// <summary>
    /// Interaction logic for ServiceTestView.xaml
    /// </summary>
    public partial class ServiceTestView : IView
    {
        public ServiceTestView()
        {
            InitializeComponent();
        }

        private void TxtValue_OnTextChanged(object sender, RoutedEventArgs e)
        {
            var textBox = sender as IntellisenseTextBox;
            if(textBox != null)
            {
                RefreshCommands(e);
            }
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            var textBox = sender as CheckBox;
            if (textBox != null)
            {
                RefreshCommands(e);
            }
        }

        private void RefreshCommands(RoutedEventArgs e)
        {
            var serviceTestViewModel = DataContext as IServiceTestViewModel;
            serviceTestViewModel?.RefreshCommands();
            e.Handled = true;
        }

        private void SelectedTestCheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            if (cb != null)
            {
                var item = cb.DataContext;
                TestsListbox.SelectedItem = item;
            }
        }

        private void SelectedTestRunTestButton_OnClick(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var item = btn.DataContext;
                TestsListbox.SelectedItem = item;
            }
        }
    }
}
