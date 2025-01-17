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
using Dev2.Common.Interfaces.Patterns;

namespace Dev2.Common.Interfaces.Core.Convertors.Base
{
    /// <summary>
    ///     The interface all conversion operations use
    /// </summary>
    public interface IBaseConverter : ISpookyLoadable<Enum>
    {
        /// <summary>
        ///     Confirms that the payload is of the selected from type
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        bool IsType(string payload);

        /// <summary>
        ///     Convert to the selected type
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        string ConvertToBase(byte[] payload);

        /// <summary>
        ///     Neutralize to a single common format
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        byte[] NeutralizeToCommon(string payload);
    }
}