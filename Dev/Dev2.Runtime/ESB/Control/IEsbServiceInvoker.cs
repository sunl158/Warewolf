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
using Dev2.Data.TO;
using Dev2.Interfaces;
using Dev2.Runtime;


namespace Dev2.DynamicServices
{


    public interface IEsbServiceInvoker
    {

        /// <summary>
        /// Invokes the specified data object.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="errors">The errors.</param>
        /// <returns></returns>
        Guid Invoke(IDSFDataObject dataObject, out ErrorResultTO errors);

        /// <summary>
        /// Generates the invoke container.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="serviceId">The service unique identifier.</param>
        /// <param name="isLocal">if set to <c>true</c> [is local].</param>
        /// <param name="masterDataListId">The master data list unique identifier.</param>
        /// <returns></returns>
    
        IEsbExecutionContainer GenerateInvokeContainer(IDSFDataObject dataObject, Guid serviceId, bool isLocal, Guid masterDataListId);

        /// <summary>
        /// Generates the invoke container.
        /// </summary>
        /// <param name="dataObject">The data object.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="isLocalInvoke">if set to <c>true</c> [is local invoke].</param>
        /// <param name="masterDataListId">The master data list unique identifier.</param>
        /// <returns></returns>
        IEsbExecutionContainer GenerateInvokeContainer(IDSFDataObject dataObject, String serviceName, bool isLocalInvoke, Guid masterDataListId);

    }
}
