﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warewolf.UITests
{
    [CodedUITest]
    public class PostgreSQLSourceTests
    {
        const string SourceName = "CodedUITestMyPostgreSQLSource";

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void PostgreSQLSource_CreateSourceUITests()
        {
            UIMap.Select_NewPostgreSQLSource_FromExplorerContextMenu();
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.ManageDatabaseSourceControl.ServerComboBox.Enabled, "PostgreSQL Server Address combobox is disabled new PostgreSQL Source wizard tab");
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.UserRadioButton.Enabled, "User authentification rabio button is not enabled.");
            //Assert.IsFalse(UIMap.ControlExistsNow(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.WindowsRadioButton), "Windows authentification radio button is visible.");
            Assert.IsFalse(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.TestConnectionButton.Enabled, "Test Connection Button is enabled.");
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.UserNameTextBox.Enabled, "Username textbox is not enabled.");
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.PasswordTextBox.Enabled, "Password textbos is not enabled.");
            UIMap.Enter_Text_Into_DatabaseServer_Tab();
            UIMap.IEnterRunAsUserUsernameAndPasswordOnDatabaseSource();
            Assert.IsTrue(UIMap.MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.DBSourceWizardTab.WorkSurfaceContext.TestConnectionButton.Enabled, "Test Connection Button is not enabled.");
            UIMap.Click_DB_Source_Wizard_Test_Connection_Button();
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