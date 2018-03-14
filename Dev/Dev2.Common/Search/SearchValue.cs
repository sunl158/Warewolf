﻿using Dev2.Common.Interfaces.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dev2.Common.Search
{
    public class SearchValue : ISearchValue
    {
        public SearchValue()
        {
            SearchInput = string.Empty;
            SearchOptions = new SearchOptions();
        }
        public string SearchInput { get; set; }
        public ISearchOptions SearchOptions { get; set; }

        public List<ISearchResult> GetSearchResults(List<ISearcher> searchers)
        {
            var searchResults = new List<ISearchResult>();  
            foreach(var searcher in searchers)
            {
                searchResults.AddRange(searcher.GetSearchResults(this));
            }
            return searchResults;
        }
    }

    public class SearchResult : ISearchResult
    {
        public SearchResult()
        {
        }

        public SearchResult(Guid resourceId, string name, string path, SearchItemType type, string match)
        {
            ResourceId = resourceId;
            Name = name;
            Path = path;
            Type = type;
            Match = match;
        }

        public Guid ResourceId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public SearchItemType Type { get; set; }
        public string Match { get; set; }
    }

    public class SearchOptions : ISearchOptions
    {
        bool _isAllSelected;
        bool _isWorkflowNameSelected;
        bool _isToolTitleSelected;
        bool _isScalarNameSelected;
        bool _isObjectNameSelected;
        bool _isRecSetNameSelected;
        bool _isInputVariableSelected;
        bool _isOutputVariableSelected;
        bool _isTestNameSelected;
        bool _isMatchCaseSelected;
        bool _isMatchWholeWordSelected;

        public SearchOptions()
        {
            IsAllSelected = true;
            UpdateAllStates(true);
        }

        public bool IsAllSelected
        {
            get => _isAllSelected;
            set
            {
                _isAllSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsWorkflowNameSelected
        {
            get => _isWorkflowNameSelected;
            set
            {
                _isWorkflowNameSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsTestNameSelected
        {
            get => _isTestNameSelected;
            set
            {
                _isTestNameSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsScalarNameSelected
        {
            get => _isScalarNameSelected;
            set
            {
                _isScalarNameSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsObjectNameSelected
        {
            get => _isObjectNameSelected;
            set
            {
                _isObjectNameSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsRecSetNameSelected
        {
            get => _isRecSetNameSelected;
            set
            {
                _isRecSetNameSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsToolTitleSelected
        {
            get => _isToolTitleSelected;
            set
            {
                _isToolTitleSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsInputVariableSelected
        {
            get => _isInputVariableSelected;
            set
            {
                _isInputVariableSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsOutputVariableSelected
        {
            get => _isOutputVariableSelected;
            set
            {
                _isOutputVariableSelected = value;
                OnPropertyChanged();
            }
        }

        public void UpdateAllStates(bool value)
        {
            IsWorkflowNameSelected = value;
            IsToolTitleSelected = value;
            IsScalarNameSelected = value;
            IsObjectNameSelected = value;
            IsRecSetNameSelected = value;
            IsInputVariableSelected = value;
            IsOutputVariableSelected = value;
            IsTestNameSelected = value;
        }

        public bool IsMatchCaseSelected
        {
            get => _isMatchCaseSelected;
            set
            {
                _isMatchCaseSelected = value;
                OnPropertyChanged();
            }
        }
        public bool IsMatchWholeWordSelected
        {
            get => _isMatchWholeWordSelected;
            set
            {
                _isMatchWholeWordSelected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
