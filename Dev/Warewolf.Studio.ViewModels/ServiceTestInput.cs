using System;
using Dev2.Common.Interfaces;
using Microsoft.Practices.Prism.Mvvm;

namespace Warewolf.Studio.ViewModels
{
    public class ServiceTestInput : BindableBase, IServiceTestInput
    {
        private string _variable;
        private string _value;
        private bool _emptyIsNull;

        public ServiceTestInput(string variableName, string value)
        {
            if (variableName == null)
                throw new ArgumentNullException(nameof(variableName));
            EmptyIsNull = false;
            Variable = variableName;
            Value = value;
        }

        #region Implementation of IServiceTestInput

        public string Variable
        {
            get
            {
                return _variable;
            }
            set
            {
                _variable = value;
                OnPropertyChanged(() => Variable);
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (!string.IsNullOrEmpty(_value))
                {
                    AddNewAction?.Invoke();
                }
                OnPropertyChanged(() => Value);
            }
        }
        public bool EmptyIsNull
        {
            get
            {
                return _emptyIsNull;
            }
            set
            {
                _emptyIsNull = value;
                AddNewAction?.Invoke();
                OnPropertyChanged(() => EmptyIsNull);
            }
        }
        public Action AddNewAction { get; set; }

        #endregion

        #region Implementation of ICloneable

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        #endregion
    }
}