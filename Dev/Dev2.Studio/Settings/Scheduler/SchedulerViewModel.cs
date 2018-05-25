/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using CubicOrange.Windows.Forms.ActiveDirectory;
using Dev2.Activities.Designers2.Core;
using Dev2.Activities.Designers2.Core.Help;
using Dev2.Common;
using Dev2.Common.ExtMethods;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Data.TO;
using Dev2.Common.Interfaces.Diagnostics.Debug;
using Dev2.Common.Interfaces.Infrastructure;
using Dev2.Common.Interfaces.Scheduler.Interfaces;
using Dev2.Common.Interfaces.Studio.Controller;
using Dev2.Common.Interfaces.Threading;
using Dev2.Communication;
using Dev2.Data.TO;
using Dev2.Diagnostics;
using Dev2.Dialogs;
using Dev2.Messages;
using Dev2.Providers.Events;
using Dev2.Runtime.Configuration.ViewModels.Base;
using Dev2.Security;
using Dev2.Services.Events;
using Dev2.Studio.Controller;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.Core.Models;
using Dev2.Studio.Interfaces;
using Dev2.Studio.Interfaces.DataList;
using Dev2.Studio.ViewModels.Diagnostics;
using Dev2.Studio.ViewModels.WorkSurface;
using Dev2.Threading;
using Dev2.ViewModels.WorkSurface;
using Warewolf.Studio.Resources.Languages;
using Warewolf.Studio.ViewModels;

namespace Dev2.Settings.Scheduler
{
    public class SchedulerViewModel : BaseWorkSurfaceViewModel, IHelpSource, IStudioTab, ISchedulerViewModel
    {
        ICommand _saveCommand;
        ICommand _newCommand;
        ICommand _deleteCommand;
        ICommand _editTriggerCommand;
        ICommand _addWorkflowCommand;
        readonly Dev2JsonSerializer _ser = new Dev2JsonSerializer();
        IScheduledResource _selectedTask;
        readonly IPopupController _popupController;
        readonly IAsyncWorker _asyncWorker;
        IResourceHistory _selectedHistory;
        IList<IResourceHistory> _history;
        TabItem _activeItem;
        bool _isProgressBarVisible;
        bool _isHistoryTabVisible;
        string _helpText;
        bool _isLoading;
        string _connectionError;
        bool _hasConnectionError;
        IServer _currentEnvironment;
        IScheduledResourceModel _scheduledResourceModel;
        Func<IServer, IServer> _toEnvironmentModel;
        bool _errorShown;
        DebugOutputViewModel _debugOutputViewModel;
        string _displayName;

        public SchedulerViewModel()
            : this(EventPublishers.Aggregator, new DirectoryObjectPickerDialog(), new PopupController(), new AsyncWorker(), CustomContainer.Get<IShellViewModel>().ActiveServer, null)
        {
        }

        public SchedulerViewModel(Func<IServer, IServer> toEnvironmentModel)
            : this(EventPublishers.Aggregator, new DirectoryObjectPickerDialog(), new PopupController(), new AsyncWorker(), CustomContainer.Get<IShellViewModel>().ActiveServer, toEnvironmentModel)
        {
        }

        public SchedulerViewModel(IEventAggregator eventPublisher, DirectoryObjectPickerDialog directoryObjectPicker, IPopupController popupController, IAsyncWorker asyncWorker, IServer server, Func<IServer, IServer> toEnvironmentModel)
            : this(eventPublisher, directoryObjectPicker, popupController, asyncWorker, server, toEnvironmentModel, null)
        {
        }

        public SchedulerViewModel(IEventAggregator eventPublisher, DirectoryObjectPickerDialog directoryObjectPicker, IPopupController popupController, IAsyncWorker asyncWorker, IServer server, Func<IServer, IServer> toEnvironmentModel, Task<IResourcePickerDialog> getResourcePicker)
            : base(eventPublisher)
        {
            SchedulerTaskManager = new SchedulerTaskManager(this, getResourcePicker);

            VerifyArgument.IsNotNull("directoryObjectPicker", directoryObjectPicker);
            var directoryObjectPicker1 = directoryObjectPicker;

            VerifyArgument.IsNotNull("popupController", popupController);
            _popupController = popupController;

            VerifyArgument.IsNotNull("asyncWorker", asyncWorker);
            _asyncWorker = asyncWorker;
            _toEnvironmentModel = toEnvironmentModel ?? (a => a.ToEnvironmentModel());
            Errors = new ErrorResultTO();
            IsLoading = false;
            directoryObjectPicker1.AllowedObjectTypes = ObjectTypes.Users;
            directoryObjectPicker1.DefaultObjectTypes = ObjectTypes.Users;
            directoryObjectPicker1.AllowedLocations = Locations.All;
            directoryObjectPicker1.DefaultLocations = Locations.JoinedDomain;
            directoryObjectPicker1.MultiSelect = false;
            directoryObjectPicker1.TargetComputer = string.Empty;
            directoryObjectPicker1.ShowAdvancedView = false;

            InitializeHelp();
            var serverRepository = CustomContainer.Get<IServerRepository>();
            DebugOutputViewModel = new DebugOutputViewModel(new EventPublisher(), serverRepository, new DebugOutputFilterStrategy());

            Server = server;
            SetupServer(server);
            SetDisplayName(false);
        }

        public override string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                OnPropertyChanged("DisplayName");
            }
        }

        public override bool HasDebugOutput => true;

        public Func<IServer, IServer> ToEnvironmentModel
        {
            private get => _toEnvironmentModel ?? (a => a.ToEnvironmentModel());
            set
            {
                _toEnvironmentModel = value;
            }
        }

        public bool HasConnectionError
        {
            get => _hasConnectionError;
            set
            {
                _hasConnectionError = value;
                NotifyOfPropertyChange(() => HasConnectionError);
            }
        }

        public void SetConnectionError()
        {
            ConnectionError = Core.SchedulerConnectionError;
            HasConnectionError = true;
        }

        public void CreateNewTask()
        {
            SchedulerTaskManager.CreateNewTask();
        }

        public string ConnectionError
        {
            get => _connectionError;
            set
            {
                _connectionError = value;
                NotifyOfPropertyChange(() => ConnectionError);
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            private set
            {
                _isLoading = value;
                NotifyOfPropertyChange(() => IsLoading);
            }
        }

        public ActivityDesignerToggle HelpToggle { get; private set; }

        public IScheduleTrigger Trigger
        {
            get => SelectedTask.Trigger;
            set
            {
                if (SelectedTask != null)
                {
                    SelectedTask.Trigger = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => Trigger);
                }
            }
        }

        public SchedulerStatus Status
        {
            get => SelectedTask?.Status ?? SchedulerStatus.Enabled;
            set
            {
                if (SelectedTask != null)
                {
                    if (value == SelectedTask.Status)
                    {
                        return;
                    }
                    SelectedTask.Status = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => Status);
                }
            }
        }

        public string WorkflowName
        {
            get => SelectedTask != null ? SelectedTask.WorkflowName : string.Empty;
            set
            {
                if (SelectedTask != null && !SelectedTask.IsNewItem)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        ShowError(Core.SchedulerBlankWorkflowNameErrorMessage);
                    }
                    else
                    {
                        ClearError(Core.SchedulerBlankWorkflowNameErrorMessage);
                    }

                    if (value == SelectedTask.WorkflowName)
                    {
                        return;
                    }

                    SelectedTask.WorkflowName = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => WorkflowName);
                }
            }
        }

        public string Name
        {
            get => SelectedTask != null ? SelectedTask.Name : string.Empty;
            set
            {
                if (SelectedTask == null || SelectedTask.Name == value)
                {
                    return;
                }
                if (string.IsNullOrEmpty(value))
                {
                    ShowError(Core.SchedulerBlankNameErrorMessage);
                }
                else
                {
                    ClearError(Core.SchedulerBlankNameErrorMessage);
                }

                if (TaskList.Any(c => c.Name == value))
                {
                    foreach (var resource in TaskList.Where(a => a.Name == value))
                    {
                        resource.Errors.AddError(Core.SchedulerDuplicateNameErrorMessage);
                    }
                    ShowError(Core.SchedulerDuplicateNameErrorMessage);
                }
                else
                {
                    ClearError(Core.SchedulerDuplicateNameErrorMessage);
                }
                SelectedTask.Name = value;
                NotifyOfPropertyChange(() => IsDirty);
                NotifyOfPropertyChange(() => Name);
            }
        }

        public bool RunAsapIfScheduleMissed
        {
            get => SelectedTask != null && SelectedTask.RunAsapIfScheduleMissed;
            set
            {
                if (SelectedTask != null)
                {
                    if (value == SelectedTask.RunAsapIfScheduleMissed)
                    {
                        return;
                    }
                    SelectedTask.RunAsapIfScheduleMissed = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => RunAsapIfScheduleMissed);
                }
            }
        }

        public string NumberOfRecordsToKeep
        {
            get => SelectedTask?.NumberOfHistoryToKeep.ToString(CultureInfo.InvariantCulture) ?? string.Empty;
            set
            {
                if (SelectedTask != null)
                {
                    if (value == SelectedTask.NumberOfHistoryToKeep.ToString(CultureInfo.InvariantCulture))
                    {
                        return;
                    }
                    if (string.IsNullOrEmpty(value))
                    {
                        SelectedTask.NumberOfHistoryToKeep = 0;
                        NotifyOfPropertyChange(() => IsDirty);
                    }
                    else
                    {
                        if (value.IsWholeNumber(out int val))
                        {
                            SelectedTask.NumberOfHistoryToKeep = val;
                            NotifyOfPropertyChange(() => IsDirty);
                        }
                    }
                    NotifyOfPropertyChange(() => NumberOfRecordsToKeep);
                }
            }
        }

        public IList<IResourceHistory> History
        {
            get
            {
                if (ScheduledResourceModel != null && SelectedTask != null && _history == null && !SelectedTask.IsNewItem)
                {
                    _asyncWorker.Start(() =>
                    {
                        IsHistoryTabVisible = false;
                        IsProgressBarVisible = true;
                        _history = ScheduledResourceModel.CreateHistory(SelectedTask).ToList();
                    }
                   , () =>
                   {
                       IsHistoryTabVisible = true;
                       IsProgressBarVisible = false;
                       NotifyOfPropertyChange(() => History);
                   });
                }
                var history = _history;
                _history = null;
                return history ?? new List<IResourceHistory>();
            }
        }

        public IResourceHistory SelectedHistory
        {
            get => _selectedHistory;
            set
            {
                if (null == value)
                {
                    EventPublisher.Publish(new DebugOutputMessage(new List<IDebugState>()));
                    return;
                }
                _selectedHistory = value;
                DebugOutputViewModel.Clear();
                if (value.DebugOutput != null)
                {
                    foreach (var debugState in value.DebugOutput)
                    {
                        if (debugState != null)
                        {
                            debugState.StateType = StateType.Clear;
                            debugState.SessionID = DebugOutputViewModel.SessionID;
                            DebugOutputViewModel.Append(debugState);
                        }
                    }
                }
                NotifyOfPropertyChange(() => SelectedHistory);
            }
        }

        public ObservableCollection<IScheduledResource> TaskList => ScheduledResourceModel != null ? ScheduledResourceModel.ScheduledResources : new ObservableCollection<IScheduledResource>();

        public string TriggerText => SelectedTask?.Trigger.Trigger.Instance.ToString() ?? string.Empty;

        public IScheduledResource SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (value == null)
                {
                    _selectedTask = null;
                    NotifyOfPropertyChange(() => SelectedTask);
                    return;
                }
                if (Equals(_selectedTask, value) || value.IsNewItem)
                {
                    return;
                }
                _selectedTask = value;
                Item = _ser.Deserialize<IScheduledResource>(_ser.SerializeToBuilder(_selectedTask));
                NotifyOfPropertyChange(() => SelectedTask);
                if (_selectedTask != null)
                {
                    NotifyOfPropertyChange(() => Trigger);
                    NotifyOfPropertyChange(() => Status);
                    NotifyOfPropertyChange(() => WorkflowName);
                    NotifyOfPropertyChange(() => Name);
                    NotifyOfPropertyChange(() => RunAsapIfScheduleMissed);
                    NotifyOfPropertyChange(() => NumberOfRecordsToKeep);
                    NotifyOfPropertyChange(() => TriggerText);
                    NotifyOfPropertyChange(() => AccountName);
                    NotifyOfPropertyChange(() => Password);
                    NotifyOfPropertyChange(() => Errors);
                    NotifyOfPropertyChange(() => Error);
                    NotifyOfPropertyChange(() => SelectedHistory);
                    SelectedHistory = null;
                    NotifyOfPropertyChange(() => History);
                }
            }
        }
        public IScheduledResource Item { get; set; }

        public IScheduledResourceModel ScheduledResourceModel
        {
            get => _scheduledResourceModel;
            set
            {
                _scheduledResourceModel = value;
                NotifyOfPropertyChange(() => ScheduledResourceModel);
                NotifyOfPropertyChange(() => TaskList);
            }
        }

        public string AccountName
        {
            get => SelectedTask != null ? SelectedTask.UserName : string.Empty;
            set
            {
                if (SelectedTask != null)
                {
                    if (Equals(SelectedTask.UserName, value))
                    {
                        return;
                    }
                    ClearError(Core.SchedulerLoginErrorMessage);
                    SelectedTask.UserName = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => AccountName);
                }
            }
        }

        public string Password
        {
            get => SelectedTask != null ? SelectedTask.Password : string.Empty;
            set
            {
                if (SelectedTask != null)
                {
                    if (Equals(SelectedTask.Password, value))
                    {
                        return;
                    }
                    ClearError(Core.SchedulerLoginErrorMessage);
                    SelectedTask.Password = value;
                    NotifyOfPropertyChange(() => IsDirty);
                    NotifyOfPropertyChange(() => Password);
                }
            }
        }

        public IServer CurrentEnvironment
        {
            get => _currentEnvironment;
            set
            {
                _currentEnvironment = value;
                NotifyOfPropertyChange(() => CurrentEnvironment);
            }
        }

        public bool HasErrors => Errors.HasErrors();

        public IErrorResultTO Errors
        {
            get => _selectedTask != null ? _selectedTask.Errors : new ErrorResultTO();
            private set
            {
                if (_selectedTask != null)
                {
                    _selectedTask.Errors = value;
                }

                NotifyOfPropertyChange(() => Errors);
            }
        }

        public bool IsHistoryTabVisible
        {
            get => _isHistoryTabVisible;
            private set
            {
                _isHistoryTabVisible = value;
                NotifyOfPropertyChange(() => IsHistoryTabVisible);
            }
        }

        public bool IsProgressBarVisible
        {
            get => _isProgressBarVisible;
            set
            {
                _isProgressBarVisible = value;
                NotifyOfPropertyChange(() => IsProgressBarVisible);
            }
        }

        public string Error => HasErrors ? Errors.FetchErrors()[0] : string.Empty;

        public TabItem ActiveItem
        {
            private get => _activeItem;
            set
            {
                if (Equals(value, _activeItem))
                {
                    return;
                }
                _activeItem = value;
                if (IsHistoryTab)
                {
                    NotifyOfPropertyChange(() => History);
                }
            }
        }

        bool IsHistoryTab
        {
            get
            {
                if (ActiveItem != null)
                {
                    return (string)ActiveItem.Header == "History";
                }
                return false;
            }
        }

        public ICommand SaveCommand => _saveCommand ??
                       (_saveCommand = new DelegateCommand(param => SchedulerTaskManager.SaveTasks()));

        public ICommand NewCommand => _newCommand ??
                       (_newCommand = new DelegateCommand(param => CreateNewTask()));

        public ICommand DeleteCommand => _deleteCommand ??
                       (_deleteCommand = new DelegateCommand(DeleteTask));

        private void DeleteTask(object param)
        {
            var taskToBeDeleted = param as IScheduledResource;
            if (taskToBeDeleted == null)
            {
                return;
            }

            SelectedTask = taskToBeDeleted;
            SchedulerTaskManager.TryDeleteTask();
        }

        public ICommand EditTriggerCommand => _editTriggerCommand ??
                       (_editTriggerCommand = new DelegateCommand(param => SchedulerTaskManager.EditTrigger()));

        public ICommand AddWorkflowCommand => _addWorkflowCommand ??
                       (_addWorkflowCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SchedulerTaskManager.AddWorkflow, SchedulerTaskManager.CanSelectWorkflow));

        void InitializeHelp()
        {
            HelpToggle = CreateHelpToggle();
            HelpText = Warewolf.Studio.Resources.Languages.HelpText.SchedulerSettingsHelpTextSettingsView;
        }

        static ActivityDesignerToggle CreateHelpToggle()
        {
            var toggle = ActivityDesignerToggle.Create("ServiceHelp", "Close Help", "ServiceHelp", "Open Help", "HelpToggle");

            return toggle;
        }

        void SetupServer(IServer tmpEnv)
        {
            CurrentEnvironment = ToEnvironmentModel?.Invoke(tmpEnv);

            if (CurrentEnvironment?.AuthorizationService != null && CurrentEnvironment.IsConnected && tmpEnv.Permissions.Any(a => a.Administrator))
            {
                ClearConnectionError();
                CreateNewSchedulerTaskManagerSource();

                try
                {
                    ScheduledResourceModel = new ClientScheduledResourceModel(CurrentEnvironment, CreateNewTask);
                    IsLoading = true;

                    var cmd = AddWorkflowCommand as Microsoft.Practices.Prism.Commands.DelegateCommand;
                    cmd?.RaiseCanExecuteChanged();

                    foreach (var scheduledResource in ScheduledResourceModel.ScheduledResources.Where(a => !a.IsNewItem))
                    {
                        scheduledResource.NextRunDate = scheduledResource.Trigger.Trigger.StartBoundary;
                        scheduledResource.OldName = scheduledResource.Name;
                    }
                    NotifyOfPropertyChange(() => TaskList);
                    if (TaskList.Count > 0)
                    {
                        SelectedTask = TaskList[0];
                    }
                    IsLoading = false;
                }
                catch (Exception ex)
                {
                    if (!_errorShown)
                    {
                        Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                        _errorShown = true;
                    }
                }
            }
            else
            {
                ClearConnectionError();
                ClearViewModel();
            }
        }

        private void CreateNewSchedulerTaskManagerSource()
        {
            var serverRepository = CustomContainer.Get<IServerRepository>();
            var server = CurrentEnvironment ?? serverRepository.ActiveServer;

            if (server.Permissions == null)
            {
                server.Permissions = new List<IWindowsGroupPermission>();
                server.Permissions.AddRange(server.AuthorizationService.SecurityService.Permissions);
            }
            SchedulerTaskManager.Source = new EnvironmentViewModel(server, CustomContainer.Get<IShellViewModel>(), true);
        }

        public void ClearConnectionError()
        {
            ConnectionError = string.Empty;
            HasConnectionError = false;
        }

        void ClearViewModel()
        {
            Name = string.Empty;
            WorkflowName = string.Empty;
            Status = SchedulerStatus.Enabled;
            AccountName = string.Empty;
            Password = string.Empty;
            NumberOfRecordsToKeep = string.Empty;
            Trigger = null;
            ScheduledResourceModel?.ScheduledResources.Clear();
            NotifyOfPropertyChange(() => TaskList);
            NotifyOfPropertyChange(() => History);
            Errors.ClearErrors();
        }

        public void ClearError(string description)
        {
            Errors.RemoveError(description);
            NotifyOfPropertyChange(() => Error);
            NotifyOfPropertyChange(() => HasErrors);
        }

        public void ShowError(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                Errors.AddError(description, true);
                NotifyOfPropertyChange(() => Error);
                NotifyOfPropertyChange(() => HasErrors);
            }
        }

        public bool IsDirty
        {
            get
            {
                try
                {
                    if (SelectedTask == null)
                    {
                        SetDisplayName(false);
                        return false;
                    }
                    var dirty = !SelectedTask.Equals(Item);
                    SelectedTask.IsDirty = dirty;
                    SetDisplayName(dirty);
                    return dirty;
                }
                catch (Exception ex)
                {
                    if (!_errorShown)
                    {
                        _popupController.ShowCorruptTaskResult(ex.Message);
                        Dev2Logger.Error(ex, GlobalConstants.WarewolfError);
                        _errorShown = true;
                    }
                }
                return false;
            }
        }

        void SetDisplayName(bool dirty)
        {
            var baseName = "Scheduler";
            if (Server != null)
            {
                baseName = baseName + " - " + Server.DisplayName;
            }
            if (dirty)
            {
                if (!baseName.EndsWith(" *"))
                {
                    DisplayName = baseName + " *";
                }
            }
            else
            {
                DisplayName = baseName;
            }
        }

        public void CloseView()
        {
        }

        public virtual bool DoDeactivate(bool showMessage)
        {
            if (showMessage && SelectedTask != null && SelectedTask.IsDirty)
            {
                var showSchedulerCloseConfirmation = _popupController.ShowSchedulerCloseConfirmation();
                switch (showSchedulerCloseConfirmation)
                {
                    case MessageBoxResult.Cancel:
                    case MessageBoxResult.None:
                        return false;
                    case MessageBoxResult.No:
                        return true;
                    default:
                        break;
                }
                return SchedulerTaskManager.SaveTasks();
            }

            if (SelectedTask != null && !showMessage)
            {
                return SchedulerTaskManager.SaveTasks();
            }

            return true;
        }

        protected internal virtual void ShowSaveErrorDialog(string error)
        {
            _popupController.ShowSaveErrorDialog(error);
        }

        public string HelpText
        {
            get => _helpText;
            set
            {
                if (value == _helpText)
                {
                    return;
                }

                _helpText = value;
                NotifyOfPropertyChange(() => HelpText);
            }
        }

        public IServer Server { private get; set; }

        public string ResourceType => "Scheduler";
        internal SchedulerTaskManager SchedulerTaskManager { get; set; }
        public IPopupController PopupController => _popupController;

        public DebugOutputViewModel DebugOutputViewModel
        {
            get => _debugOutputViewModel;
            set
            {
                _debugOutputViewModel = value;
                NotifyOfPropertyChange(() => DebugOutputViewModel);
            }
        }

        bool ISchedulerViewModel.IsDirty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWorkSurfaceKey WorkSurfaceKey => throw new NotImplementedException();
        public IServer Environment => throw new NotImplementedException();
        public bool DeleteRequested { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDataListViewModel DataListViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IWorkSurfaceViewModel WorkSurfaceViewModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IContextualResourceModel ContextualResourceModel => throw new NotImplementedException();
        AuthorizeCommand IWorkSurfaceContextViewModel.SaveCommand => throw new NotImplementedException();
        public AuthorizeCommand RunCommand => throw new NotImplementedException();
        public AuthorizeCommand ViewInBrowserCommand => throw new NotImplementedException();
        public AuthorizeCommand DebugCommand => throw new NotImplementedException();
        public AuthorizeCommand QuickViewInBrowserCommand => throw new NotImplementedException();
        public AuthorizeCommand QuickDebugCommand => throw new NotImplementedException();
        public void UpdateScheduleWithResourceDetails(string resourcePath, Guid id, string resourceName) => SchedulerTaskManager.UpdateScheduleWithResourceDetails(resourcePath, id, resourceName);
        public void Handle(SaveResourceMessage message) => throw new NotImplementedException();
        public void Handle(UpdateWorksurfaceDisplayName message) => throw new NotImplementedException();
        public void SetDebugStatus(DebugStatus debugStatus) => throw new NotImplementedException();
        public void Debug(IContextualResourceModel resourceModel, bool isDebug) => throw new NotImplementedException();
        public void StopExecution() => throw new NotImplementedException();
        public void ViewInBrowser() => throw new NotImplementedException();
        public void QuickViewInBrowser() => throw new NotImplementedException();
        public void QuickDebug() => throw new NotImplementedException();
        public void BindToModel() => throw new NotImplementedException();
        public void ShowSaveDialog(IContextualResourceModel resourceModel, bool addToTabManager) => throw new NotImplementedException();
        public bool CanSave() => throw new NotImplementedException();
        public bool Save() => throw new NotImplementedException();
        public bool Save(bool isLocalSave, bool isStudioShutdown) => throw new NotImplementedException();
        public bool IsEnvironmentConnected() => throw new NotImplementedException();
        public void FindMissing() => throw new NotImplementedException();
        public void Debug() => throw new NotImplementedException();
    }

    public static class SchedulerServerExtensions
    {
        public static IServer ToEnvironmentModel(this IServer server)
        {
            if (server is Server resource)
            {
                return resource;
            }
            throw new Exception();
        }
    }
}
