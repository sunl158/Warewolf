#pragma warning disable
/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Data.Interfaces;
using Dev2.Data.Interfaces.Enums;

namespace Dev2.DataList.Contract
{
    public static class IntellisenseFactory
    {

        public static IIntellisenseResult CreateErrorResult(int start, int end, IDataListVerifyPart opt, string msg, enIntellisenseErrorCode code, bool isClosed) => new IntellisenseResult(start, end, opt, msg, enIntellisenseResultType.Error, code, isClosed);

        public static IIntellisenseResult CreateSelectableResult(int start, int end, IDataListVerifyPart opt, string msg) => new IntellisenseResult(start, end, opt, msg, enIntellisenseResultType.Selectable, enIntellisenseErrorCode.None, true);

        public static IIntellisenseResult CreateDateTimeResult(IDataListVerifyPart opt) => new IntellisenseResult(0, 0, opt, "", enIntellisenseResultType.Selectable, enIntellisenseErrorCode.None, true);

        public static IDataListVerifyPart CreateDateTimePart(string displayValue, string description) => new DateTimeVerifyPart(displayValue, description);

        public static IDataListVerifyPart CreateDataListValidationRecordsetPart(string recordset, string field) => new DataListVerifyPart(recordset, field);

        public static IDataListVerifyPart CreateJsonPart(string displayValue) => new DataListVerifyPart(displayValue) { IsJson = true };

        public static IDataListVerifyPart CreateDataListValidationRecordsetPart(string recordset, string field, bool useRawPartsForDisplayValue) => new DataListVerifyPart(recordset, field, useRawPartsForDisplayValue);

        public static IDataListVerifyPart CreateDataListValidationRecordsetPart(string recordset, string field, string desc) => new DataListVerifyPart(recordset, field, desc);

        public static IDataListVerifyPart CreateDataListValidationRecordsetPart(string recordset, string field, string desc, string index) => new DataListVerifyPart(recordset, field, desc, index);

        public static IDataListVerifyPart CreateDataListValidationScalarPart(string scalar) => new DataListVerifyPart(null, scalar);

        public static IDataListVerifyPart CreateDataListValidationScalarPart(string scalar, string desc) => new DataListVerifyPart(null, scalar, desc);
    }
}
