﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Common.Interfaces.ToolBase;
using Dev2.Common.Interfaces.ToolBase.Database;
using Microsoft.Practices.Prism.Commands;
using Warewolf.Core;

namespace Dev2.Activities.Designers2.Core
{
    public class ManageDatabaseServiceInputViewModel : IManageDatabaseInputViewModel
    {
        IGenerateOutputArea _generateOutputArea;
        IGenerateInputArea _generateInputArea;
        double _minHeight;
        double _currentHeight;
        double _maxHeight;
        bool _isVisible;
        bool _pasteResponseAvailable;
        IDatabaseServiceViewModel _viewmodel;
        IDbServiceModel _serverModel;
        bool _isGenerateInputsEmptyRows;
        private bool _okSelected;
        private DataTable _testResults;
        private bool _testResultsAvailable;
        private bool _isTestResultsEmptyRows;
        private bool _isTesting;
        private IDatabaseService _model;
        private bool _pasteResponseVisible;
        private const double BaseHeight = 60;

        public ManageDatabaseServiceInputViewModel(IDatabaseServiceViewModel model, IDbServiceModel serviceModel)
        {
            PasteResponseAvailable = false;
            PasteResponseVisible = false;
            IsTesting = false;
            CloseCommand = new DelegateCommand(ExecuteClose);
            OkCommand = new DelegateCommand(ExecuteOk);
            TestCommand = new DelegateCommand(ExecuteTest);
            _generateOutputArea = new GenerateOutputsRegion();
            _generateOutputArea.HeightChanged += GenerateAreaHeightChanged;
            _generateInputArea = new GenerateInputsRegion();
            _generateInputArea.HeightChanged += GenerateAreaHeightChanged;
            Errors = new List<string>();
            _viewmodel = model;
            _serverModel = serviceModel;
        }

        private void SetInitialHeight()
        {
            var maxInputHeight = _generateInputArea.IsVisible ? _generateInputArea.MaxHeight : 0;
            var minInputHeight = _generateInputArea.IsVisible ? _generateInputArea.MinHeight : 0;
            var inputHeight = _generateInputArea.IsVisible ? _generateInputArea.CurrentHeight : 0;

            var maxOutputHeight = _generateOutputArea.IsVisible ? _generateOutputArea.MaxHeight : 0;
            var minOutputHeight = _generateOutputArea.IsVisible ? _generateOutputArea.MinHeight : 0;
            var outputHeight = _generateOutputArea.IsVisible ? _generateOutputArea.CurrentHeight : 0;

            IsGenerateInputsEmptyRows = false;
            if (_generateInputArea.Inputs == null || _generateInputArea.Inputs.Count < 1)
            {
                IsGenerateInputsEmptyRows = true;
                maxInputHeight = BaseHeight;
                minInputHeight = BaseHeight;
                inputHeight = BaseHeight;
            }

            MaxHeight = BaseHeight + maxInputHeight + maxOutputHeight;
            MinHeight = BaseHeight + minInputHeight + minOutputHeight;
            CurrentHeight = BaseHeight + inputHeight + outputHeight;
        }

        void GenerateAreaHeightChanged(object sender, IToolRegion args)
        {
            SetInitialHeight();
            OnHeightChanged(this);
        }

        void ResetOutputsView()
        {
            IsVisible = false;
            _viewmodel.GenerateOutputsVisible = false;
            InputArea.IsVisible = false;
            OutputArea.IsVisible = false;
            TestResults = new DataTable();
            TestResultsAvailable = false;

            _viewmodel.SetDisplayName("");
            _viewmodel.ErrorMessage(new Exception(), false);
        }

        public void ExecuteClose()
        {
            _viewmodel.OutputsRegion.Outputs.Clear();
            _viewmodel.OutputsRegion.IsVisible = _viewmodel.OutputsRegion.Outputs.Count > 0;
            if (TestResults != null)
            {
                TestResultsAvailable = TestResults != null;
                IsTesting = false;
            }
            ResetOutputsView();
            OnHeightChanged(this);
        }

        public void ExecuteOk()
        {
            try
            {
                _viewmodel.OutputsRegion.Outputs.Clear();
                if (OutputArea != null)
                {
                    foreach (var serviceOutputMapping in OutputArea.Outputs)
                    {
                        _viewmodel.OutputsRegion.Outputs.Add(serviceOutputMapping);
                    }
                }
                else
                {
                    throw new Exception("No Outputs detected");
                }

                _viewmodel.OutputsRegion.Description = Description;
                _viewmodel.OutputsRegion.IsVisible = _viewmodel.OutputsRegion.Outputs.Count > 0;
                ResetOutputsView();
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                IsTesting = false;
                _viewmodel.ErrorMessage(e, true);
            }

            OkSelected = true;
            OnHeightChanged(this);
        }

        public void ExecuteTest()
        {
            ViewErrors = new List<IActionableErrorInfo>();
            OutputArea.IsVisible = true;
            TestResults = null;
            IsTesting = true;

            try
            {
                TestResults = _serverModel.TestService(Model);
                if (TestResults != null)
                {
                    TestResultsAvailable = TestResults.Rows.Count != 0;
                    IsTestResultsEmptyRows = TestResults.Rows.Count < 1;
                    _generateOutputArea.IsVisible = true;

                    IsTesting = false;
                }
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
                IsTesting = false;
                _generateOutputArea.IsVisible = false;
                _generateOutputArea.Outputs = new List<IServiceOutputMapping>();
                _viewmodel.ErrorMessage(e, true);
            }
            OnHeightChanged(this);
        }

        public bool IsGenerateInputsEmptyRows
        {
            get
            {
                return _isGenerateInputsEmptyRows;
            }
            set
            {
                _isGenerateInputsEmptyRows = value;
                OnPropertyChanged();
            }
        }

        public List<IActionableErrorInfo> ViewErrors { get; set; }

        #region Implementation of IToolRegion

        public string ToolRegionName { get; set; }
        public double MinHeight
        {
            get
            {
                return _minHeight;
            }
            set
            {

                if (Math.Abs(_minHeight - value) > GlobalConstants.DesignHeightTolerance)
                {
                    _minHeight = value;
                    OnHeightChanged(this);
                    OnPropertyChanged();
                }
            }
        }
        public double CurrentHeight
        {
            get
            {
                return _currentHeight;
            }
            set
            {
                if (Math.Abs(_currentHeight - value) > GlobalConstants.DesignHeightTolerance)
                {
                    _currentHeight = value;
                    OnHeightChanged(this);
                    OnPropertyChanged();
                }
            }
        }
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
                OnHeightChanged(this);
                OnPropertyChanged();
            }
        }
        public double MaxHeight
        {
            get
            {
                return _maxHeight;
            }
            set
            {
                if (Math.Abs(_maxHeight - value) > GlobalConstants.DesignHeightTolerance)
                {
                    _maxHeight = value;
                    OnHeightChanged(this);
                    OnPropertyChanged();
                }
            }
        }
        public event HeightChanged HeightChanged;
        public IList<IToolRegion> Dependants { get; set; }
        public IList<string> Errors { get; private set; }

        public IToolRegion CloneRegion()
        {
            return this;
        }

        public void RestoreRegion(IToolRegion toRestore)
        {
        }

        #endregion

        #region Implementation of IManageServiceInputViewModel<IDatabaseService>

        public Action TestAction { get; set; }
        public ICommand TestCommand { get; private set; }
        public bool TestResultsAvailable
        {
            get
            {
                return _testResultsAvailable;
            }
            set
            {
                _testResultsAvailable = value;
                OnPropertyChanged();
            }
        }
        public bool IsTestResultsEmptyRows
        {
            get
            {
                return _isTestResultsEmptyRows;
            }
            set
            {
                _isTestResultsEmptyRows = value;
                OnPropertyChanged();
            }
        }
        public bool IsTesting
        {
            get
            {
                return _isTesting;
            }
            set
            {
                _isTesting = value;
                OnPropertyChanged();
            }
        }

        [ExcludeFromCodeCoverage]
        public ImageSource TestIconImageSource { get; set; }
        public ICommand CloseCommand { get; private set; }
        public ICommand OkCommand { get; private set; }
        public Action OkAction { get; set; }
        public Action CloseAction { get; set; }
        public IDatabaseService Model
        {
            get
            {
                return _model ?? new DatabaseService();
            }
            set
            {
                _model = value;
            }
        }
        public string TestHeader { get; set; }
        [ExcludeFromCodeCoverage]
        public void ShowView()
        {
        }
        [ExcludeFromCodeCoverage]
        public void CloseView()
        {
        }

        #endregion

        #region Implementation of IManageDatabaseInputViewModel

        public ICollection<IServiceInput> Inputs { get; set; }
        public DataTable TestResults
        {
            get
            {
                return _testResults;
            }
            set
            {
                _testResults = value;
                OnPropertyChanged();
            }
        }
        public bool OkSelected
        {
            get
            {
                return _okSelected;
            }
            set
            {
                _okSelected = value;
                OnPropertyChanged();
            }
        }
        public IGenerateOutputArea OutputArea
        {
            get
            {
                return _generateOutputArea;
            }
            [ExcludeFromCodeCoverage]
            set
            {
                
            }
        }
        public IOutputDescription Description { get; set; }
        public IGenerateInputArea InputArea
        {
            get
            {
                return _generateInputArea;
            }
            [ExcludeFromCodeCoverage]
            set
            {
                
            }
        }
        public bool PasteResponseVisible
        {
            get
            {
                return _pasteResponseVisible;
            }
            set
            {
                _pasteResponseVisible = value;
                OnPropertyChanged();
            }
        }

        public bool PasteResponseAvailable
        {
            get
            {
                return _pasteResponseAvailable;
            }
            set
            {
                _pasteResponseAvailable = value;
                OnPropertyChanged();
            }
        }

        public void SetInitialVisibility()
        {
            SetInitialHeight();
            IsVisible = true;
            InputArea.IsVisible = true;
            OutputArea.IsVisible = false;
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        protected void OnHeightChanged(IToolRegion args)
        {
            var handler = HeightChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
