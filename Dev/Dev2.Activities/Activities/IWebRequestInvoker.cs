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

namespace Dev2.Activities
{
    public interface IWebRequestInvoker
    {

        string ExecuteRequest(string method, string url, List<Tuple<string, string>> headers);

        string ExecuteRequest(string method, string url, List<Tuple<string, string>> headers, int timeoutMilliseconds);
        string ExecuteRequest(string method, string url, string data);
        string ExecuteRequest(string method, string url, string data, List<Tuple<string, string>> headers);
        string ExecuteRequest(string method, string url, string data, List<Tuple<string, string>> headers, Action<string> asyncCallback);
        string ExecuteRequest(int timeoutMilliseconds, string method, string url, string data);
        string ExecuteRequest(int timeoutMilliseconds, string method, string url, string data, List<Tuple<string, string>> headers);
        string ExecuteRequest(int timeoutMilliseconds, string method, string url, string data, List<Tuple<string, string>> headers, Action<string> asyncCallback);
    }
}
