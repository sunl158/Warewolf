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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Dev2.Common.Interfaces.DB;
using Dev2.Common.Interfaces.Toolbox;
using Dev2.Data.TO;
using Dev2.Diagnostics;
using Dev2.Interfaces;
using Dev2.Services.Execution;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Core;
using Warewolf.Resource.Errors;
using Warewolf.Storage.Interfaces;



namespace Dev2.Activities
{
    [ToolDescriptorInfo("MicrosoftSQL", "SQL Server", ToolType.Native, "8999E59B-38A3-43BB-A98F-6090C5C9EA1E", "Dev2.Activities", "1.0.0.0", "Legacy", "Database", "/Warewolf.Studio.Themes.Luna;component/Images.xaml", "Tool_Database_SQL_Server")]
    public class DsfSqlServerDatabaseActivity : DsfActivity,IEquatable<DsfSqlServerDatabaseActivity>
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IServiceExecution ServiceExecution { get; protected set; }
        public string ProcedureName { get; set; }
        public int? CommandTimeout { get; set; }

        public string ExecuteActionString { get; set; }
        public DsfSqlServerDatabaseActivity()
        {
            Type = "SQL Server Database";
            DisplayName = "SQL Server Database";
        }

        protected override void ExecutionImpl(IEsbChannel esbChannel, IDSFDataObject dataObject, string inputs, string outputs, out ErrorResultTO tmpErrors, int update)
        {
            var execErrors = new ErrorResultTO();

            tmpErrors = new ErrorResultTO();
            tmpErrors.MergeErrors(execErrors);
            if (string.IsNullOrEmpty(ProcedureName))
            {
                tmpErrors.AddError(ErrorResource.NoActionsInSelectedDB);
                return;
            }
            if (ServiceExecution is DatabaseServiceExecution databaseServiceExecution)
            {
                if (databaseServiceExecution.SourceIsNull())
                {
                    databaseServiceExecution.GetSource(SourceId);
                }
                databaseServiceExecution.Inputs = Inputs.Select(a => new ServiceInput { EmptyIsNull = a.EmptyIsNull, Name = a.Name, RequiredField = a.RequiredField, Value = a.Value, TypeName = a.TypeName } as IServiceInput).ToList();
                databaseServiceExecution.Outputs = Outputs;
            }
            ServiceExecution.Execute(out execErrors, update);
            var fetchErrors = execErrors.FetchErrors();
            foreach (var error in fetchErrors)
            {
                dataObject.Environment.Errors.Add(error);
            }
            tmpErrors.MergeErrors(execErrors);
        }

        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            if (env == null)
            {
                return new List<DebugItem>();
            }
            base.GetDebugInputs(env, update);

            if (Inputs != null)
            {
                foreach (var serviceInput in Inputs)
                {
                    var debugItem = new DebugItem();
                    AddDebugItem(new DebugEvalResult(serviceInput.Value, serviceInput.Name, env, update), debugItem);
                    _debugInputs.Add(debugItem);
                }
            }
            return _debugInputs;
        }

        protected override void BeforeExecutionStart(IDSFDataObject dataObject, ErrorResultTO tmpErrors)
        {
            base.BeforeExecutionStart(dataObject, tmpErrors);
            var databaseServiceExecution = new DatabaseServiceExecution(dataObject)
            {
                ProcedureName = ProcedureName,
            };
            if (CommandTimeout != null)
            {
                databaseServiceExecution.CommandTimeout = CommandTimeout.Value;
            }
            if (!string.IsNullOrEmpty(ExecuteActionString))
            {
                databaseServiceExecution.ProcedureName = ExecuteActionString;
            }
            ServiceExecution = databaseServiceExecution;
            ServiceExecution.GetSource(SourceId);
            ServiceExecution.BeforeExecution(tmpErrors);
        }


        public override enFindMissingType GetFindMissingType() => enFindMissingType.DataGridActivity;

        public bool Equals(DsfSqlServerDatabaseActivity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var eq = base.Equals(other);
            eq &= string.Equals(SourceId.ToString(), other.SourceId.ToString());
            eq &= string.Equals(ProcedureName, other.ProcedureName);            
            eq &= CommandTimeout == other.CommandTimeout;
            eq &= string.Equals(ExecuteActionString, other.ExecuteActionString);
            return eq;
        }

        public override bool Equals(object obj)
        {
            if (obj is DsfSqlServerDatabaseActivity instance)
            {
                return Equals(instance);
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (SourceId.GetHashCode());
                if (ProcedureName != null)
                {
                    hashCode = (hashCode * 397) ^ (ProcedureName.GetHashCode());
                }
                if (CommandTimeout != null)
                {
                    hashCode = (hashCode * 397) ^ CommandTimeout.Value;
                }                
                if (ExecuteActionString != null)
                {
                    hashCode = (hashCode * 397) ^ (ExecuteActionString.GetHashCode());
                }
                return hashCode;
            }
        }
    }
}
