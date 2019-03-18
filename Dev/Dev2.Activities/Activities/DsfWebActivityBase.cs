#pragma warning disable CC0091, S1226, S100, CC0044, CC0045, CC0021, S1449, S1541, S1067, S3235, CC0015, S107, S2292, S1450, S105, CC0074, S1135, S101, S3776, CS0168, S2339, CC0031, S3240, CC0020, CS0108, S1694, S1481, CC0008, AD0001, S2328, S2696, S1643, CS0659, CS0067, S104, CC0030, CA2202, S3376, S1185, CS0219, S3253, S1066, CC0075, S3459, S1871, S1125, CS0649, S2737, S1858, CC0082, CC0001, S3241, S2223, S1301, CC0013, S2955, S1944, CS4014, S3052, S2674, S2344, S1939, S1210, CC0033, CC0002, S3458, S3254, S3220, S2197, S1905, S1699, S1659, S1155, CS0105, CC0019, S3626, S3604, S3440, S3256, S2692, S2345, S1109, FS0058, CS1998, CS0661, CS0660, CS0162, CC0089, CC0032, CC0011, CA1001
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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Dev2.Activities.Debug;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Diagnostics;
using Dev2.Runtime.ServiceModel.Data;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Warewolf.Storage;
using Warewolf.Storage.Interfaces;
using Dev2.Comparer;
using System.Net;
using System.IO;
using Dev2.Interfaces;

namespace Dev2.Activities
{
    public abstract class DsfWebActivityBase : DsfActivity,IEquatable<DsfWebActivityBase>
    {
        readonly WebRequestMethod _method;
        const string UserAgent = "User-Agent";

        protected DsfWebActivityBase(WebRequestDataDto webRequestDataDto)
        {
            _method = webRequestDataDto.WebRequestMethod;
            Type = webRequestDataDto.Type;
            DisplayName = webRequestDataDto.DisplayName;
        }

        public IList<INameValue> Headers { get; set; }
        public string QueryString { get; set; }
        public IOutputDescription OutputDescription { get; set; }
        public IResponseManager ResponseManager { get; set; }
        public override List<DebugItem> GetDebugInputs(IExecutionEnvironment env, int update)
        {
            if (env == null)
            {
                return new List<DebugItem>();
            }
            base.GetDebugInputs(env, update);

            var head = Headers.Select(a => new NameValue(ExecutionEnvironment.WarewolfEvalResultToString(env.Eval(a.Name, update)), ExecutionEnvironment.WarewolfEvalResultToString(env.Eval(a.Value, update)))).Where(a => !(String.IsNullOrEmpty(a.Name) && String.IsNullOrEmpty(a.Value)));
            var query = ExecutionEnvironment.WarewolfEvalResultToString(env.Eval(QueryString, update));
            var url = ResourceCatalog.GetResource<WebSource>(Guid.Empty, SourceId);
            var headerString = string.Join(" ", head.Select(a => a.Name + " : " + a.Value));

            var debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "URL"), debugItem);
            AddDebugItem(new DebugEvalResult(url.Address, "", env, update), debugItem);
            _debugInputs.Add(debugItem);
            debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "Query String"), debugItem);
            AddDebugItem(new DebugEvalResult(query, "", env, update), debugItem);
            _debugInputs.Add(debugItem);
            debugItem = new DebugItem();
            AddDebugItem(new DebugItemStaticDataParams("", "Headers"), debugItem);
            AddDebugItem(new DebugEvalResult(headerString, "", env, update), debugItem);
            _debugInputs.Add(debugItem);

            return _debugInputs;
        }

        public virtual HttpClient CreateClient(IEnumerable<INameValue> head, string query, WebSource source)
        {
            var httpClient = new HttpClient();
            if (source.AuthenticationType == AuthenticationType.User)
            {
                var byteArray = Encoding.ASCII.GetBytes(String.Format("{0}:{1}", source.UserName, source.Password));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            }

            if (head != null)
            {
                var nameValues = head.Where(nameValue => !String.IsNullOrEmpty(nameValue.Name) && !String.IsNullOrEmpty(nameValue.Value));
                foreach (var nameValue in nameValues)
                {
                    httpClient.DefaultRequestHeaders.Add(nameValue.Name, nameValue.Value);
                }
            }

            httpClient.DefaultRequestHeaders.Add(UserAgent, GlobalConstants.UserAgentString);

            var address = source.Address;
            if (!string.IsNullOrEmpty(query))
            {
                address = address + query;
            }
            try
            {
                var baseAddress = new Uri(address);
                httpClient.BaseAddress = baseAddress;
            }
            catch (UriFormatException e)
            {
                Dev2Logger.Error(e.Message, e, GlobalConstants.WarewolfError);
                return httpClient;
            }

            return httpClient;
        }

        public override enFindMissingType GetFindMissingType() => enFindMissingType.DataGridActivity;

        protected virtual string PerformWebRequest(IEnumerable<INameValue> head, string query, WebSource source, string putData)
        {
            var headerValues = head as NameValue[] ?? head.ToArray();
            var httpClient = CreateClient(headerValues, query, source);
            if (httpClient != null)
            {
                try
                {
                    var address = BuildQuery(query, source);
                    string resultAsString;
                    switch (_method)
                    {
                        case WebRequestMethod.Get:
                            var taskOfString = httpClient.GetStringAsync(new Uri(address));
                            resultAsString = taskOfString.Result;
                            break;
                        case WebRequestMethod.Post:
                            var taskOfResponseMessage = httpClient.PostAsync(new Uri(address), new StringContent(putData));
                            resultAsString = taskOfResponseMessage.Result.Content.ReadAsStringAsync().Result;
                            break;
                        case WebRequestMethod.Delete:
                            taskOfResponseMessage = httpClient.DeleteAsync(new Uri(address));
                            resultAsString = taskOfResponseMessage.Result.Content.ReadAsStringAsync().Result;
                            break;
                        case WebRequestMethod.Put:
                            resultAsString = PerformPut(putData, headerValues, httpClient, address);
                            break;
                        default:
                            resultAsString = $"Invalid Request Method: {_method}";
                            break;
                    }                    
                    return resultAsString;
                }
                catch (WebException webEx)
                {
                    if (webEx.Response is HttpWebResponse httpResponse)
                    {
                        using (var responseStream = httpResponse.GetResponseStream())
                        {
                            var reader = new StreamReader(responseStream);
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        private static string PerformPut(string putData, INameValue[] headerValues, HttpClient httpClient, string address)
        {
            HttpContent httpContent = new StringContent(putData, Encoding.UTF8);
            var contentType = headerValues.FirstOrDefault(value => value.Name.ToLowerInvariant() == "Content-Type".ToLowerInvariant());
            if (contentType != null)
            {
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType.Value);
            }
            var httpRequest = new HttpRequestMessage(HttpMethod.Put, new Uri(address))
            {
                Content = httpContent
            };
            var taskOfResponseMessage = httpClient.SendAsync(httpRequest);
            return taskOfResponseMessage.Result.Content.ReadAsStringAsync().Result;
        }

        private static string BuildQuery(string query, WebSource source)
        {
            var address = source.Address;
            if (query != null)
            {
                address = address + query;
            }

            return address;
        }

        public bool Equals(DsfWebActivityBase other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            var headersEqual = CommonEqualityOps.CollectionEquals(Headers, other.Headers, new NameValueComparer());
            var equals = base.Equals(other);
            equals &= _method == other._method;
            equals &= headersEqual;
            equals &= string.Equals(QueryString, other.QueryString);
            equals &= Equals(OutputDescription, other.OutputDescription);
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

            return Equals((DsfWebActivityBase) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = base.GetHashCode();
                hashCode = (hashCode * 397) ^ (int) _method;
                hashCode = (hashCode * 397) ^ (Headers != null ? Headers.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (QueryString != null ? QueryString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (OutputDescription != null ? OutputDescription.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}