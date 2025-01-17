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
using Dev2.Common;
using Dev2.Common.Interfaces.Enums;
using Dev2.Common.Interfaces.Scripting;
using Warewolf.Resource.Errors;

namespace Dev2.Development.Languages.Scripting
{
    public class ScriptingEngineRepo : SpookyAction<IScriptingContext,enScriptType>
    {
        public IScriptingContext CreateEngine(enScriptType scriptType, IStringScriptSources sources)
        {
            switch(scriptType)
            {
                case enScriptType.JavaScript :
                    return  new JavaScriptContext(sources);
                case enScriptType.Python:
                    return new Dev2PythonContext(sources);
                case enScriptType.Ruby:
                    return new RubyContext(sources);
                default : throw new Exception(ErrorResource.InvalidScriptingContext);
            }
        }
    }
}
