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
using System.Threading.Tasks;
using Dev2.Studio.ViewModels.Diagnostics;


namespace Dev2.Studio.Diagnostics
{
    public abstract class AppExceptionPopupControllerAbstract : IAppExceptionPopupController
    {
        public async void ShowPopup(Exception ex, ErrorSeverity severity)
        {
            var exceptionViewModel = CreateExceptionViewModel(ex, severity);
            var result = await exceptionViewModel;
            result.Show();
        }

        protected abstract Task<IExceptionViewModel> CreateExceptionViewModel(Exception exception, ErrorSeverity severity);
    }
}
