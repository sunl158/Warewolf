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
using Caliburn.Micro;


namespace Dev2.Studio.Core.ViewModels.Base
{
    public class BaseConductor<T> : Conductor<T>.Collection.OneActive, IDisposable
        where T : IScreen
    {
        readonly IEventAggregator _eventPublisher;
        bool _disposed;

        public IEventAggregator EventPublisher => _eventPublisher;

        protected BaseConductor(IEventAggregator eventPublisher)
        {
            VerifyArgument.IsNotNull("eventPublisher", eventPublisher);
            _eventPublisher = eventPublisher;
            _eventPublisher.Subscribe(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                // If we have any managed, IDisposable resources, Dispose of them here.
                EventPublisher.Unsubscribe(this);
            }

            // Mark us as disposed, to prevent multiple calls to dispose from having an effect, 
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
