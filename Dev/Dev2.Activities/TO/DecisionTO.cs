#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
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
using System.Collections.Generic;
using System.Linq;
using Dev2.Common.Interfaces.Infrastructure.Providers.Validation;
using Dev2.Common.Interfaces.Interfaces;
using Dev2.Data.Decisions.Operations;
using Dev2.Data.SystemTemplates.Models;
using Dev2.DataList;
using Dev2.DataList.Contract;
using Dev2.Providers.Validation.Rules;
using Dev2.Runtime.Configuration.ViewModels.Base;
using Dev2.Util;
using Dev2.Utilities;
using Dev2.Validation;
using Dev2.Common;

namespace Dev2.TO
{
    public class DecisionTO : ValidatedObject, IDev2TOFn
    {
        public Action<DecisionTO> UpdateDisplayAction { get; set; }
        int _indexNum;
        string _searchType;
        bool _isSearchCriteriaEnabled;
        bool _isSearchTypeFocused;
        string _matchValue;
        string _searchCriteria;
        string _from;
        string _to;
        bool _isSearchCriteriaVisible;
        bool _isFromFocused;
        bool _isToFocused;
        bool _isSinglematchCriteriaVisible;
        bool _isBetweenCriteriaVisible;
        public static readonly IList<IFindRecsetOptions> Whereoptions = FindRecsetOptions.FindAllDecision();
        bool _isLast;
        readonly bool _isInitializing;
        public RelayCommand DeleteCommand { get; set; }

        public DecisionTO()
            : this("Match", "Match On", "Equal", 0)
        {
        }

        public DecisionTO(string matchValue, string searchCriteria, string searchType, int indexNum)
            : this(matchValue, searchCriteria, searchType, indexNum, false, "", "", null, null)
        {
        }

        public DecisionTO(string matchValue, string searchCriteria, string searchType, int indexNum, bool inserted)
            : this(matchValue, searchCriteria, searchType, indexNum, inserted, "", "", null, null)
        {
        }

        public DecisionTO(string matchValue, string searchCriteria, string searchType, int indexNum, bool inserted, string from, string to, Action<DecisionTO> updateDisplayAction, Action<DecisionTO> delectAction)
        {
            UpdateDisplayAction = updateDisplayAction ?? (a => { });
            Inserted = inserted;
            _isInitializing = true;
            From = "";
            To = "";
            MatchValue = matchValue;
            SearchCriteria = searchCriteria;
            SearchType = searchType;
            IndexNumber = indexNum;
            IsSearchCriteriaEnabled = true;

            From = @from;
            To = to;
            IsSearchTypeFocused = false;
            DeleteAction = delectAction;
            DeleteCommand = new RelayCommand(a =>
            {
                DeleteAction?.Invoke(this);
            }, CanDelete);
            _isInitializing = false;
        }

        public Action<DecisionTO> DeleteAction { get; set; }

        public DecisionTO(Dev2Decision a, int ind)
            : this(a, ind, null, null)
        {
        }

        public DecisionTO(Dev2Decision a, int ind, Action<DecisionTO> updateDisplayAction, Action<DecisionTO> deleteAction)
        {
            UpdateDisplayAction = updateDisplayAction ?? (x => { });
            _isInitializing = true;
            Inserted = false;
            MatchValue = a.Col1;
            SearchCriteria = a.Col2;
            SearchType = DecisionDisplayHelper.GetDisplayValue(a.EvaluationFn);
            IndexNumber = ind;
            IsSearchCriteriaEnabled = true;
            IsSearchCriteriaVisible = true;
            From = a.Col2;
            To = a.Col3;
            IsSearchTypeFocused = false;
            DeleteAction = deleteAction;
            IsLast = false;
            DeleteCommand = new RelayCommand(x =>
            {
                DeleteAction?.Invoke(this);
            }, CanDelete);
            _isInitializing = false;
        }

        public bool CanDelete(object obj) => !IsLast;

        public bool IsLast
        {
            get => _isLast;
            set
            {
                _isLast = value;

                DeleteCommand?.RaiseCanExecuteChanged();
            }
        }

        [FindMissing]
        public string From
        {
            get => _from;
            set
            {
                if (_from == value)
                {
                    return;
                }
                _from = value;
                OnPropertyChanged();
                RaiseCanAddRemoveChanged();
                UpdateDisplay();
            }
        }

        public bool IsFromFocused { get => _isFromFocused; set => OnPropertyChanged(ref _isFromFocused, value); }

        [FindMissing]
        public string To
        {
            get => _to;
            set
            {
                if (_to == value)
                {
                    return;
                }
                _to = value;
                OnPropertyChanged();
                RaiseCanAddRemoveChanged();
                UpdateDisplay();
            }
        }

        public bool IsToFocused { get => _isToFocused; set => OnPropertyChanged(ref _isToFocused, value); }

        [FindMissing]
        public string SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                if (_searchCriteria == value)
                {
                    return;
                }
                _searchCriteria = value;
                OnPropertyChanged();
                RaiseCanAddRemoveChanged();
                UpdateDisplay();
            }
        }

        void UpdateDisplay()
        {
            if (!_isInitializing)
            {
                UpdateDisplayAction?.Invoke(this);
            }
        }

        [FindMissing]
        public string MatchValue
        {
            get => _matchValue;
            set
            {
                if (_matchValue == value)
                {
                    return;
                }
                _matchValue = value;

                OnPropertyChanged();
                RaiseCanAddRemoveChanged();
                UpdateDisplay();
            }
        }

        public string SearchType
        {
            get => _searchType;
            set
            {
                if (value != null)
                {
                    _searchType = FindRecordsDisplayUtil.ConvertForDisplay(value);
                    if (!string.IsNullOrEmpty(_searchType))
                    {
                        IsSearchCriteriaEnabled = true;
                    }
                    UpdateMatchVisibility(this, _searchType, Whereoptions);
                    if (_searchType == value)
                    {
                        return;
                    }
                    OnPropertyChanged();
                    RaiseCanAddRemoveChanged();
                    UpdateDisplay();
                }
            }
        }

        public bool IsSearchTypeFocused { get => _isSearchTypeFocused; set => OnPropertyChanged(ref _isSearchTypeFocused, value); }

        void RaiseCanAddRemoveChanged()
        {
            OnPropertyChanged("CanRemove");
            OnPropertyChanged("CanAdd");
        }

        public bool IsSearchCriteriaEnabled
        {
            get => _isSearchCriteriaEnabled;
            set
            {
                _isSearchCriteriaEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsSearchCriteriaVisible
        {
            get => _isSearchCriteriaVisible;
            set
            {
                _isSearchCriteriaVisible = value;
                OnPropertyChanged(ref _isSearchCriteriaVisible, value);
            }
        }

        public int IndexNumber
        {
            get => _indexNum;
            set
            {
                _indexNum = value;
                OnPropertyChanged();
            }
        }

        public bool CanRemove()
        {
            if (string.IsNullOrEmpty(MatchValue) && string.IsNullOrEmpty(SearchCriteria) && string.IsNullOrEmpty(SearchType))
            {
                return true;
            }
            return false;
        }

        public bool CanAdd() => !string.IsNullOrEmpty(MatchValue) || !string.IsNullOrEmpty(SearchCriteria);

        public void ClearRow()
        {
            MatchValue = "";
            SearchCriteria = string.Empty;
            SearchType = "";
        }

        public bool Inserted { get; set; }

        public bool IsEmpty() => string.IsNullOrEmpty(SearchType) && string.IsNullOrEmpty(SearchCriteria);

#pragma warning disable S1541 // Methods and properties should not be too complex
        public override IRuleSet GetRuleSet(string propertyName, string datalist)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            var ruleSet = new RuleSet();
            if (IsEmpty())
            {
                return ruleSet;
            }
            switch (propertyName)
            {
                case "SearchType":
                    if (SearchType == "Starts With" || SearchType == "Ends With" || SearchType == "Doesn't Start With" || SearchType == "Doesn't End With")
                    {
                        ruleSet.Add(new IsStringEmptyRule(() => SearchType));
                        ruleSet.Add(new IsValidExpressionRule(() => SearchType, datalist, "1", new VariableUtils()));
                    }
                    break;
                case "From":
                    if (SearchType == "Is Between" || SearchType == "Is Not Between")
                    {
                        ruleSet.Add(new IsStringEmptyRule(() => From));
                        ruleSet.Add(new IsValidExpressionRule(() => From, datalist, "1", new VariableUtils()));
                    }
                    break;
                case "To":
                    if (SearchType == "Is Between" || SearchType == "Is Not Between")
                    {
                        ruleSet.Add(new IsStringEmptyRule(() => To));
                        ruleSet.Add(new IsValidExpressionRule(() => To, datalist, "1", new VariableUtils()));
                    }
                    break;
                case "SearchCriteria":
                    if (string.IsNullOrEmpty(SearchCriteria))
                    {
                        ruleSet.Add(new IsStringEmptyRule(() => SearchCriteria));
                    }

                    ruleSet.Add(new IsValidExpressionRule(() => SearchCriteria, datalist, "1", new VariableUtils()));
                    break;
                default:
                    Dev2Logger.Info("No Rule Set for the Decision TO Property Name: " + propertyName, GlobalConstants.WarewolfInfo);
                    break;
            }

            return ruleSet;
        }

        public bool IsSinglematchCriteriaVisible
        {
            get => _isSinglematchCriteriaVisible;
            set
            {
                _isSinglematchCriteriaVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsBetweenCriteriaVisible
        {
            get => _isBetweenCriteriaVisible;
            set
            {
                _isBetweenCriteriaVisible = value;
                OnPropertyChanged();
            }
        }


        public static void UpdateMatchVisibility(DecisionTO to, string value, IList<IFindRecsetOptions> whereOptions)
        {

            var opt = whereOptions.FirstOrDefault(a => value.ToLower().StartsWith(a.HandlesType().ToLower()));
            if (opt != null)
            {
                switch (opt.ArgumentCount)
                {
                    case 1:
                        to.IsSearchCriteriaVisible = false;
                        to.IsBetweenCriteriaVisible = false;
                        to.IsSinglematchCriteriaVisible = false;
                        break;
                    case 2:
                        to.IsSearchCriteriaVisible = true;
                        to.IsBetweenCriteriaVisible = false;
                        to.IsSinglematchCriteriaVisible = true;
                        break;
                    case 3:
                        to.IsSearchCriteriaVisible = true;
                        to.IsBetweenCriteriaVisible = true;
                        to.IsSinglematchCriteriaVisible = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }


}