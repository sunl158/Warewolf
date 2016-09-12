using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Dev2.Common.Interfaces;

namespace Dev2.Studio.Core.Interfaces
{
    public interface IServiceTestViewModel : IDisposable,INotifyPropertyChanged, IUpdatesHelp
    {
        IServiceTestModel SelectedServiceTest { get; set; }
        IServiceTestCommandHandler ServiceTestCommandHandler { get; set; }
        string RunAllTestsUrl { get; set; }
        string TestPassingResult { get; set; }
        ObservableCollection<IServiceTestModel> Tests  { get; set; }

        
        ICommand DuplicateTestCommand { get; set; }
        ICommand DeleteTestCommand { get; set; }
        ICommand RunAllTestsInBrowserCommand { get; set; }
        ICommand RunAllTestsCommand { get; set; }
        ICommand RunSelectedTestInBrowserCommand { get; set; }
        ICommand RunSelectedTestCommand { get; set; }
        ICommand StopTestCommand { get; set; }
        ICommand CreateTestCommand { get; set; }
        string DisplayName { get; set; }
        bool CanSave { get; set; }
        bool IsDirty { get; }
        string ErrorMessage { get; set; }

        void Save();
    }
}