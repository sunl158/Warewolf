﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UITests.Tools.ToolsUIMapClasses;
using Warewolf.UITests.WcfSource.WcfSourceUIMapClasses;

namespace Warewolf.UITests.Tools.Resources
{
    [CodedUITest]
    public class WCF_Service
    {
        [TestMethod]
		[TestCategory("Resource Tools")]
        public void WCFServiceTool_Small_And_LargeView_Then_NewSource_UITest()
        {
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.Exists, "WCF Service tool does not exist on the design surface after dragging in from the toolbox.");
            //Small View
            ToolsUIMap.WCFServiceTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.SmallView.Exists, "WCF Toll Small view does not exist.");
            //Large View
            ToolsUIMap.WCFServiceTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.SourcesCombobox.Exists, "Sources Combobox does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.EditSourceButton.Exists, "EditSource Button does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.NewButton.Exists, "NewSource Button does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.ActionsCombobox.Exists, "Actions Combobox does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.RefreshActionsButton.Exists, "RefreshActions Button does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.InputsTable.Exists, "Inputs Table does not exist on WCFService tool tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.GenerateOutputsButton.Exists, "Generate Outputs Button does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.OutputToObjectCheckbox.Exists, "OutputToObject Checkbox does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.OutputsTable.Exists, "Outputs Table does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.RecordSetTextbox.Exists, "Recordset Textbox does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.LargeView.OnErrorPanel.Exists, "OnError Pane does not exist on WCFService tool large view");
            Assert.IsTrue(ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext.WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter.Flowchart.WcfService.DoneButton.Exists, "Done button does not exist on WCFService tool");
            //New Source
            ToolsUIMap.Click_NewSourceButton_From_WCFTool();
            Assert.IsTrue(WcfSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WCFServiceSourceTab.WorkSurfaceContext.WCFEndpointURLEdit.Enabled, "WCF Endpoint URL Textbox is not enabled");
            Assert.IsFalse(WcfSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WCFServiceSourceTab.WorkSurfaceContext.TestConnectionButton.Enabled, "Test Connection button is enabled");
        }

        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
            UIMap.Click_NewWorkflow_RibbonButton();
            ToolsUIMap.Drag_WCFServiceConnector_Onto_DesignSurface();
        }

        UIMap UIMap
        {
            get
            {
                if ((_UIMap == null))
                {
                    _UIMap = new UIMap();
                }

                return _UIMap;
            }
        }

        private UIMap _UIMap;

        ToolsUIMap ToolsUIMap
        {
            get
            {
                if (_ToolsUIMap == null)
                {
                    _ToolsUIMap = new ToolsUIMap();
                }

                return _ToolsUIMap;
            }
        }

        private ToolsUIMap _ToolsUIMap;

        WcfSourceUIMap WcfSourceUIMap
        {
            get
            {
                if (_WcfSourceUIMap == null)
                {
                    _WcfSourceUIMap = new WcfSourceUIMap();
                }

                return _WcfSourceUIMap;
            }
        }

        private WcfSourceUIMap _WcfSourceUIMap;

        #endregion
    }
}
