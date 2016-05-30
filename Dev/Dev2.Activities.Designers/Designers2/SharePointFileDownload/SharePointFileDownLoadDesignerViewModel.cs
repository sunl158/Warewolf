using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using Dev2.Activities.Designers2.SharepointListRead;
using Dev2.Common.Interfaces.Infrastructure.Providers.Errors;
using Dev2.Common.Interfaces.Threading;
using Dev2.Interfaces;
using Dev2.Providers.Errors;
using Dev2.Services.Events;
using Dev2.Studio.Core;
using Dev2.Studio.Core.Interfaces;
using Dev2.Threading;

// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace Dev2.Activities.Designers2.SharePointFileDownload
{
    public class SharePointFileDownLoadDesignerViewModel : SharepointListDesignerViewModelBase
    {
        public SharePointFileDownLoadDesignerViewModel(ModelItem modelItem)
            : this(modelItem, new AsyncWorker(), EnvironmentRepository.Instance.ActiveEnvironment)
        {
        }

        public SharePointFileDownLoadDesignerViewModel(ModelItem modelItem, IAsyncWorker asyncWorker, IEnvironmentModel envModel)
            : base(modelItem, asyncWorker, envModel, EventPublishers.Aggregator, false)
        {
           
        }

        #region Overrides of ActivityCollectionDesignerViewModel<SharepointSearchTo>

        public override void UpdateHelpDescriptor(string helpText)
        {
            var mainViewModel = CustomContainer.Get<IMainViewModel>();
            if (mainViewModel != null)
            {
                mainViewModel.HelpViewModel.UpdateHelpText(helpText);
            }
        }
        public string LocalInputPath { get { return GetProperty<string>(); } }

        protected override IEnumerable<IActionableErrorInfo> ValidateThis()
        {
            if (Errors != null && Errors.Count > 0)
            {
                Errors.Clear();
            }

            if (SharepointServerResourceId == Guid.Empty)
            {
                Errors = new List<IActionableErrorInfo> { new ActionableErrorInfo() { Message = "Please Select a SharePoint Server" } };

                return Errors;
            }

            if (string.IsNullOrEmpty(LocalInputPath))
            {
                Errors = new List<IActionableErrorInfo> { new ActionableErrorInfo() { Message = "Please enter local path" } };

                return Errors;
            }

            return new List<IActionableErrorInfo>();
        }

        #endregion

        public override string CollectionName { get { return "FilterCriteria"; } }
    }
}
