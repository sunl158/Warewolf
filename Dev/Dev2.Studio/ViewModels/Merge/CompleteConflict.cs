﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dev2.Common.Interfaces;
using Microsoft.Practices.Prism.Mvvm;

namespace Dev2.ViewModels.Merge
{

    public class ArmConnectorConflict : IArmConnectorConflict
    {
        public IMergeArmConnectorConflict CurrentArmConnector { get; set; }
        public IMergeArmConnectorConflict DifferentArmConnector { get; set; }
        public bool HasConflict { get; set; }
        public bool IsChecked { get; set; }
        public Guid UniqueId { get; set; }
    }

    public class MergeArmConnectorConflict : BindableBase, IMergeArmConnectorConflict
    {
        public string ArmDescription { get; set; }
        public string SourceUniqueId { get; set; }
        public string DestinationUniqueId { get; set; }
        public string Key { get; set; }
        public bool HasConflict { get; set; }
        bool _isChecked;

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                _isChecked = value;
                OnPropertyChanged(() => IsChecked);
            }
        }

        public MergeArmConnectorConflict()
        {

        }
        public MergeArmConnectorConflict(string armDescription, string sourceUniqueId, string destinationUniqueId, string key)
        {
            ArmDescription = armDescription;
            SourceUniqueId = sourceUniqueId;
            DestinationUniqueId = destinationUniqueId;
            Key = key;
            HasConflict = false;
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        public bool Equals(IMergeArmConnectorConflict other)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            if (other == null)
            {
                return false;
            }
            var equals = true;
            equals &= other.SourceUniqueId == SourceUniqueId;
            equals &= other.DestinationUniqueId == DestinationUniqueId;
            equals &= other.Key == Key;
            return equals;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            return Equals((IMergeArmConnectorConflict)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = (397) ^ SourceUniqueId.GetHashCode();
            hashCode = (hashCode * 397) ^ (DestinationUniqueId != null ? DestinationUniqueId.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (Key != null ? Key.GetHashCode() : 0);
            return hashCode;
        }
    }

    public class ToolConflict : BindableBase, IToolConflict
    {
        bool _isMergeExpanded;
        bool _isMergeExpanderEnabled;
        bool _hasConflict;
        bool _hasNodeArmConflict;
        IEnumerator<IToolConflict> _conflictEnumerator;
        bool _isContainerTool;

        public ToolConflict()
        {
            Children = new LinkedList<IToolConflict>();
        }

        public IMergeToolModel CurrentViewModel { get; set; }
        public IMergeToolModel DiffViewModel { get; set; }
        public LinkedList<IToolConflict> Children { get; set; }
        public IToolConflict Parent { get; set; }
        public Guid UniqueId { get; set; }

        public bool IsChecked { get; set; }

        public bool HasConflict
        {
            get => _hasConflict;
            set
            {
                _hasConflict = value;
                OnPropertyChanged(() => HasConflict);
            }
        }

        public bool HasNodeArmConflict
        {
            get => _hasNodeArmConflict;
            set
            {
                _hasNodeArmConflict = value;
                OnPropertyChanged(() => HasNodeArmConflict);
            }
        }

        public bool IsMergeExpanderEnabled
        {
            get => _isMergeExpanderEnabled;
            set
            {
                _isMergeExpanderEnabled = value;
                OnPropertyChanged(() => IsMergeExpanderEnabled);
            }
        }

        public bool IsMergeExpanded
        {
            get => _isMergeExpanded;
            set
            {
                _isMergeExpanded = value;
                OnPropertyChanged(() => IsMergeExpanded);
            }
        }

        public bool IsContainerTool
        {
            get => _isContainerTool;
            set
            {
                _isContainerTool = value;
                OnPropertyChanged(() => IsContainerTool);
            }
        }

        public IToolConflict GetNextConflict()
        {
            if (_conflictEnumerator == null)
            {
                _conflictEnumerator = Children.GetEnumerator();
            }
            if (_conflictEnumerator.Current != null)
            {
                var current = _conflictEnumerator.Current;
                if (current.Children.Count > 0)
                {
                    var nextConflict = current.GetNextConflict();
                    if (nextConflict != null)
                    {
                        return nextConflict;
                    }
                }
            }
            if (_conflictEnumerator.MoveNext())
            {
                var current = _conflictEnumerator.Current;
                return current;
            }
            return null;
        }

        public LinkedListNode<IToolConflict> Find(IToolConflict itemToFind)
        {
            var linkedConflict = Children.Find(itemToFind);
            if (linkedConflict != null)
            {
                return linkedConflict;
            }
            foreach (var completeConflict in Children)
            {
                var childItem = completeConflict.Find(itemToFind);
                if (childItem != null)
                {
                    return childItem;
                }
            }
            return null;
        }

        public bool All(Func<IToolConflict, bool> check)
        {
            var current = Children.All(check);
            var childrenMatch = true;
            foreach (var completeConflict in Children)
            {
                childrenMatch &= completeConflict.All(check);
            }
            return current && childrenMatch;
        }

        public bool ValidateContainerTool(IMergeToolModel parentItem)
        {
            var mergeToolModel = parentItem as MergeToolModel;

            switch (mergeToolModel?.ActivityDesignerViewModel.GetType().Name)
            {
                case "SequenceDesignerViewModel":
                case "SelectAndApplyDesignerViewModel":
                case "ForeachDesignerViewModel":
                    return true;
                default:
                    return false;
            }
        }
    }
}
