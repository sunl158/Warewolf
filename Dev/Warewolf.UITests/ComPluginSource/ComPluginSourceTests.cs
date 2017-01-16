﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warewolf.UITests
{
    [CodedUITest]
    public class COMPluginSourceTests
    {
        const string SourceName = "CodedUITestCOMPluginSource";

        [TestMethod]
        [TestCategory("COMPluginSource")]
        public void SelectComPluginSource()
        {
            UIMap.Select_NewCOMPluginSource_FromExplorerContextMenu();
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceWizardTab.WorkSurfaceContext.SearchTextBox.Enabled);
            UIMap.WaitForSpinner(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceWizardTab.WorkSurfaceContext.RefreshButton.RefreshSpinner);
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceWizardTab.WorkSurfaceContext.DataTree.Enabled);
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.COMPlugInSourceWizardTab.WorkSurfaceContext.RefreshButton.Enabled);
            UIMap.Select_AssemblyFile_From_COMPluginDataTree();
            UIMap.Save_With_Ribbon_Button_And_Dialog("COM Plugin Source");
        }

        #region Additional test attributes

        [TestInitialize()]
        public void MyTestInitialize()
        {
            UIMap.SetPlaybackSettings();
            UIMap.AssertStudioIsRunning();
        }
        
        public UIMap UIMap
        {
            get
            {
                if (_UIMap == null)
                {
                    _UIMap = new UIMap();
                }

                return _UIMap;
            }
        }

        private UIMap _UIMap;

        #endregion
    }
}