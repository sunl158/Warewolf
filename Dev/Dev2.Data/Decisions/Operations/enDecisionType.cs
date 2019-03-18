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
using System.Linq;
using System.Reflection;
using Warewolf.Resource.Messages;


namespace Dev2.Data.Decisions.Operations
{
    public class DecisionTypeDisplayValue : Attribute
    {
        internal DecisionTypeDisplayValue(string displayValue)
        {
            DisplayValue = displayValue;
        }

        public string DisplayValue { get; set; }
    }    
    
    public static class DecisionDisplayHelper
    {
        public static string GetDisplayValue(enDecisionType typeOf)
        {

            MemberInfo mi = typeof(enDecisionType).GetField(Enum.GetName(typeof(enDecisionType), typeOf));

            var attr = (DecisionTypeDisplayValue)Attribute.GetCustomAttribute(mi, typeof(DecisionTypeDisplayValue));

            return attr.DisplayValue;
        }
        
        public static enDecisionType GetValue(string displayValue)
        {
            var values = Enum.GetValues(typeof(enDecisionType));
            return (from object value in values let mi = typeof(enDecisionType).GetField(Enum.GetName(typeof(enDecisionType), value)) let attr = (DecisionTypeDisplayValue)Attribute.GetCustomAttribute(mi, typeof(DecisionTypeDisplayValue)) where attr.DisplayValue.Equals(displayValue) select value as enDecisionType? ?? enDecisionType.Choose).FirstOrDefault();
        }

#pragma warning disable S1541 // Methods and properties should not be too complex
        public static string GetFailureMessage(enDecisionType decisionType)
#pragma warning restore S1541 // Methods and properties should not be too complex
        {
            switch (decisionType)
            {
                case enDecisionType.Choose: return Messages.Test_FailureMessage_Choose;
                case enDecisionType.IsError: return Messages.Test_FailureMessage_IsError;
                case enDecisionType.IsNotError: return Messages.Test_FailureMessage_IsNotError;
                case enDecisionType.IsNull: return Messages.Test_FailureMessage_IsNull;
                case enDecisionType.IsNotNull: return Messages.Test_FailureMessage_IsNotNull;
                case enDecisionType.IsNumeric: return Messages.Test_FailureMessage_IsNumeric;
                case enDecisionType.IsNotNumeric: return Messages.Test_FailureMessage_IsNotNumeric;
                case enDecisionType.IsText: return Messages.Test_FailureMessage_IsText;
                case enDecisionType.IsNotText: return Messages.Test_FailureMessage_IsNotText;
                case enDecisionType.IsAlphanumeric: return Messages.Test_FailureMessage_IsAlphanumeric;
                case enDecisionType.IsNotAlphanumeric: return Messages.Test_FailureMessage_IsNotAlphanumeric;
                case enDecisionType.IsXML: return Messages.Test_FailureMessage_IsXML;
                case enDecisionType.IsNotXML: return Messages.Test_FailureMessage_IsNotXML;
                case enDecisionType.IsDate: return Messages.Test_FailureMessage_IsDate;
                case enDecisionType.IsNotDate: return Messages.Test_FailureMessage_IsNotDate;
                case enDecisionType.IsEmail: return Messages.Test_FailureMessage_IsEmail;
                case enDecisionType.IsNotEmail: return Messages.Test_FailureMessage_IsNotEmail;
                case enDecisionType.IsRegEx: return Messages.Test_FailureMessage_IsRegEx;
                case enDecisionType.NotRegEx: return Messages.Test_FailureMessage_NotRegEx;
                case enDecisionType.IsEqual: return Messages.Test_FailureMessage_Equals;
                case enDecisionType.IsNotEqual: return Messages.Test_FailureMessage_IsNotEqual;
                case enDecisionType.IsLessThan: return Messages.Test_FailureMessage_IsLessThan;
                case enDecisionType.IsLessThanOrEqual: return Messages.Test_FailureMessage_IsLessThanOrEqual;
                case enDecisionType.IsGreaterThan: return Messages.Test_FailureMessage_IsGreaterThan;
                case enDecisionType.IsGreaterThanOrEqual: return Messages.Test_FailureMessage_IsGreaterThanOrEqual;
                case enDecisionType.IsContains: return Messages.Test_FailureMessage_IsContains;
                case enDecisionType.NotContain: return Messages.Test_FailureMessage_NotContain;
                case enDecisionType.IsEndsWith: return Messages.Test_FailureMessage_IsEndsWith;
                case enDecisionType.NotEndsWith: return Messages.Test_FailureMessage_NotEndsWith;
                case enDecisionType.IsStartsWith: return Messages.Test_FailureMessage_IsStartsWith;
                case enDecisionType.NotStartsWith: return Messages.Test_FailureMessage_NotStartsWith;
                case enDecisionType.IsBetween: return Messages.Test_FailureMessage_IsBetween;
                case enDecisionType.NotBetween: return Messages.Test_FailureMessage_NotBetween;
                case enDecisionType.IsBinary: return Messages.Test_FailureMessage_IsBinary;
                case enDecisionType.IsNotBinary: return Messages.Test_FailureMessage_IsNotBinary;
                case enDecisionType.IsHex: return Messages.Test_FailureMessage_IsHex;
                case enDecisionType.IsNotHex: return Messages.Test_FailureMessage_IsNotHex;
                case enDecisionType.IsBase64: return Messages.Test_FailureMessage_IsBase64;
                case enDecisionType.IsNotBase64: return Messages.Test_FailureMessage_IsNotBase64;
                default: return string.Empty;
            }
        }
    }
    
    public enum enDecisionType
    {
        [DecisionTypeDisplayValue("Not a Valid Decision Type")] Choose,
        [DecisionTypeDisplayValue("There is An Error")] IsError,
        [DecisionTypeDisplayValue("There is No Error")] IsNotError,
        [DecisionTypeDisplayValue("Is NULL")] IsNull,
        [DecisionTypeDisplayValue("Is Not NULL")] IsNotNull,
        [DecisionTypeDisplayValue("Is Numeric")] IsNumeric,
        [DecisionTypeDisplayValue("Not Numeric")] IsNotNumeric,
        [DecisionTypeDisplayValue("Is Text")] IsText,
        [DecisionTypeDisplayValue("Not Text")] IsNotText,
        [DecisionTypeDisplayValue("Is Alphanumeric")] IsAlphanumeric,
        [DecisionTypeDisplayValue("Not Alphanumeric")] IsNotAlphanumeric,
        [DecisionTypeDisplayValue("Is XML")] IsXML,
        [DecisionTypeDisplayValue("Not XML")] IsNotXML,
        [DecisionTypeDisplayValue("Is Date")] IsDate,
        [DecisionTypeDisplayValue("Not Date")] IsNotDate,
        [DecisionTypeDisplayValue("Is Email")] IsEmail,
        [DecisionTypeDisplayValue("Not Email")] IsNotEmail,
        [DecisionTypeDisplayValue("Is Regex")] IsRegEx,
        [DecisionTypeDisplayValue("Not Regex")] NotRegEx,
        [DecisionTypeDisplayValue("=")] IsEqual,
        [DecisionTypeDisplayValue("<> (Not Equal)")] IsNotEqual,
        [DecisionTypeDisplayValue("<")] IsLessThan,
        [DecisionTypeDisplayValue("<=")] IsLessThanOrEqual,
        [DecisionTypeDisplayValue(">")] IsGreaterThan,
        [DecisionTypeDisplayValue(">=")] IsGreaterThanOrEqual,
        [DecisionTypeDisplayValue("Contains")] IsContains,
        [DecisionTypeDisplayValue("Doesn't Contain")] NotContain,
        [DecisionTypeDisplayValue("Ends With")] IsEndsWith,
        [DecisionTypeDisplayValue("Doesn't End With")] NotEndsWith,
        [DecisionTypeDisplayValue("Starts With")] IsStartsWith,
        [DecisionTypeDisplayValue("Doesn't Start With")] NotStartsWith,
        [DecisionTypeDisplayValue("Is Between")] IsBetween,
        [DecisionTypeDisplayValue("Not Between")] NotBetween,
        [DecisionTypeDisplayValue("Is Binary")] IsBinary,
        [DecisionTypeDisplayValue("Not Binary")] IsNotBinary,
        [DecisionTypeDisplayValue("Is Hex")] IsHex,
        [DecisionTypeDisplayValue("Not Hex")] IsNotHex,
        [DecisionTypeDisplayValue("Is Base64")] IsBase64,
        [DecisionTypeDisplayValue("Not Base64")] IsNotBase64
    }
}
