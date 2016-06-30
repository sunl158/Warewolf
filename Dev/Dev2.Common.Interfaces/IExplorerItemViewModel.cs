﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Dev2.Common.Interfaces
{
    public interface IExplorerItemViewModel : IExplorerTreeItem
    {
        bool Checked { get; set; }
        bool IsRenaming{ get; set; }
        bool IsVisible { get; set; }
        bool CanExecute { get; set; }
        bool CanEdit { get; set; }
        bool CanView { get; set; }
        bool CanShowDependencies { get; set; }
        bool IsVersion { get; set; }

        string VersionNumber { get; set; }
        string VersionHeader { get; set; }
        string Inputs { get; set; }
        string Outputs { get; set; }
        string ExecuteToolTip { get; }
        string EditToolTip { get; }
        string ActivityName { get; }

        ICommand OpenCommand { get; set; }
        ICommand OpenVersionCommand { get; set; }
        ICommand DeleteVersionCommand { get; set; }
        ICommand ShowDependenciesCommand { get; set; }
        ICommand ItemSelectedCommand { get; set; }
        ICommand LostFocus { get; set; }

        IEnumerable<IExplorerItemViewModel> AsList();

        Task<bool> Move(IExplorerTreeItem destination);

        void AddSibling(IExplorerItemViewModel sibling);
        void CreateNewFolder();
        void Apply(Action<IExplorerItemViewModel> action);
        void Filter(string filter);
        void Filter(Func<IExplorerItemViewModel, bool> filter);
        void ShowErrorMessage(string errorMessage, string header);
    }

    public enum ExplorerEventContext
    {
        Selected
    }
}