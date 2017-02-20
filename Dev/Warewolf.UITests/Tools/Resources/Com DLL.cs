﻿using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Warewolf.UITests.ComPluginSource.ComPluginSourceUIMapClasses;
using Warewolf.UITests.Tools.ToolsUIMapClasses;

namespace Warewolf.UITests.Tools.Resources
{
    [CodedUITest]
    public class Com_DLL
    {        
        [TestMethod]
        [TestCategory("Resource Tools")]
        public void ComDLLTool_Small_And_LargeView_Then_NewSource_UITest()
        {
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.Exists,
                "Com DLL tool does not exist on the design surface after dragging in from the toolbox.");
            //Small View
            ToolsUIMap.ComDLLTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.SmallView.Exists,
                "Com DLL tool small view does not exist after double clicking tool large view.");
            //Large View
            ToolsUIMap.ComDLLTool_ChangeView_With_DoubleClick();
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.SourcesCombobox.Exists,
                "Sources Combobox does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.EditSourceButton.Exists,
                "EditSources Button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.NewSourceButton.Exists,
                "NewSource Button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.NamespaceCombobox.Exists,
                "Namespace Combobox does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.RefreshNamespaceButton.Exists,
                "RefeshNamespace Button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.ActionsCombobox.Exists,
                "Actions Combobox does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.ActionRefreshButton.Exists,
                "ActionRefresh Button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.InputsTable.Exists,
                "Inputs Table does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.GenerateOutputsButton.Exists,
                "Generate Outputs Button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.OutputToObjectCheckbox.Exists,
                "OutputToObjective Checkbox does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.OutputsTable.Exists,
                "Outputs Table does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.RecordsetNameTextbox.Exists,
                "RecrodsetName Textbox does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.LargeView.OnErrorPanel.Exists,
                "OnError Pane does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            Assert.IsTrue(
                ToolsUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.WorkflowTab.WorkSurfaceContext
                    .WorkflowDesignerView.DesignerView.ScrollViewerPane.ActivityTypeDesigner.WorkflowItemPresenter
                    .Flowchart.ComDll.DoneButton.Exists,
                "Done button does not exist on Com DLL tool large view after openning it by double clicking the small view.");
            //New Source
            ToolsUIMap.Click_NewSourceButton_From_COMDLLPluginTool();
            Assert.IsTrue(
                ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                    .WorkSurfaceContext.SearchTextBox.Enabled, "Search Textbox is not enabled");
            Assert.IsTrue(
                ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                    .WorkSurfaceContext.RefreshButton.RefreshSpinner.Exists);
            UIMap.WaitForControlVisible(
                ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                    .WorkSurfaceContext.DataTree);
            ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                .WorkSurfaceContext.SearchTextBox.SearchText.Text = "ADODB.CONNECTION";
            Mouse.Click(
                ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                    .WorkSurfaceContext.DataTree.ItemTreeItem, new Point(55, 27));
            Assert.AreEqual("ADODB.Connection.6.0",
                    ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                        .WorkSurfaceContext.AssemblyNameTextBox.Text,
                "Assembly Name Textbox is empty after selecting an assembly.");
            UIMap.Save_With_Ribbon_Button_And_Dialog("COMPluginSourceToEdit");
            Mouse.Click(ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab.CloseTabButton);
            ToolsUIMap.ComDLLTool_ChangeView_With_DoubleClick();
            ToolsUIMap.Select_Source_From_ComDLLTool();
            ToolsUIMap.Click_EditSourceButton_On_ComDLLTool();
            UIMap.WaitForControlVisible(
             ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                 .WorkSurfaceContext.DataTree);
            Assert.AreEqual("ADODB.Connection.6.0",
                     ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                         .WorkSurfaceContext.AssemblyNameTextBox.Text,
                 "Assembly Name Textbox is not equal to ADODB.Connection.6.0.");
            ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                .WorkSurfaceContext.SearchTextBox.SearchText.Text = "ADODB.Parameter";
            Mouse.Click(ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                    .WorkSurfaceContext.DataTree.ItemTreeItem, new Point(55, 27));
            UIMap.Click_Save_Ribbon_Button_Without_Expecting_A_Dialog();
            Mouse.Click(ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab.CloseTabButton);
            ToolsUIMap.ComDLLTool_ChangeView_With_DoubleClick();
            ToolsUIMap.Select_Source_From_ComDLLTool();
            ToolsUIMap.Click_EditSourceButton_On_ComDLLTool();
            UIMap.WaitForControlVisible(
               ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                   .WorkSurfaceContext.DataTree);
            Assert.AreEqual("ADODB.Parameter.6.0",
                    ComPluginSourceUIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceTab
                        .WorkSurfaceContext.AssemblyNameTextBox.Text,
                "Assembly Name Textbox is not equal to ADODB.Parameter.6.0.");
        }

        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
            UIMap.Click_NewWorkflow_RibbonButton();
            ToolsUIMap.Drag_ComDLLConnector_Onto_DesignSurface();
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

        ComPluginSourceUIMap ComPluginSourceUIMap
        {
            get
            {
                if (_ComPluginSourceUIMap == null)
                {
                    _ComPluginSourceUIMap = new ComPluginSourceUIMap();
                }

                return _ComPluginSourceUIMap;
            }
        }

        private ComPluginSourceUIMap _ComPluginSourceUIMap;

        #endregion
    }
}
