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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Dev2.Common.Interfaces.DB;

namespace Dev2.Common.Interfaces
{
    public class PluginAction : IPluginAction, INotifyPropertyChanged, IEquatable<PluginAction>
    {
        public string FullName { get; set; }
        public string Method { get; set; }
        public IList<IServiceInput> Inputs { get; set; }
        public Type ReturnType { get; set; }
        public IList<INameValue> Variables { get; set; }
        public string Dev2ReturnType { get; set; }
        
        public string MethodResult { get; set; }
        public string OutputVariable { get; set; }
        public bool IsObject { get; set; }
        public bool IsVoid { get; set; }
        public string ErrorMessage { get; set; }
        public bool HasError { get; set; }
        public bool IsProperty { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(PluginAction other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (GetHashCode() == other.GetHashCode())
            {
                return true;
            }

            return string.Equals(Method, other.Method);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
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
            return Equals((PluginAction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Inputs?.GetHashCode() ?? 0) * 397) ^ (Method?.GetHashCode() ?? 0);
            }
        }

        public string GetIdentifier() => FullName + Method;

        public static bool operator ==(PluginAction left, PluginAction right) => Equals(left, right);

        public static bool operator !=(PluginAction left, PluginAction right) => !Equals(left, right);

        public override string ToString() => Method;

        public Guid ID { get; set; }
    }
}