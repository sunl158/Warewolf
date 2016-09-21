﻿using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warewolf.UITests.Tools.Utility
{
    [CodedUITest]
    public class Calculate
    {
        [TestMethod]
		[TestCategory("Tools")]
        public void CalculateToolUITest()
        {
            Uimap.Drag_Toolbox_Calculate_Onto_DesignSurface();
            Uimap.Open_Calculate_Tool_Large_View();
            Uimap.Enter_SomeVariable_Into_Calculate_Large_View_Function_Textbox();
            Uimap.Click_Calculate_Large_View_Done_Button();
            Uimap.Click_Debug_Ribbon_Button();
            Uimap.Click_DebugInput_Debug_Button();
            Uimap.WaitForControlNotVisible(Uimap.MainStudioWindow.DockManager.SplitPaneRight.DebugOutput.StatusBar.Spinner);
            Uimap.Click_Debug_Output_Calculate_Cell();
        }

        #region Additional test attributes

        [TestInitialize]
        public void MyTestInitialize()
        {
            Uimap.SetPlaybackSettings();
            Uimap.InitializeABlankWorkflow();
        }

        UIMap Uimap
        {
            get
            {
                if (_uiMap == null)
                {
                    _uiMap = new UIMap();
                }

                return _uiMap;
            }
        }

        private UIMap _uiMap;

        #endregion
    }
}
