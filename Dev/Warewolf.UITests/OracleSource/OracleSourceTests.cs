﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Warewolf.UITests
{
    [CodedUITest]
    public class OracleSourceTests
    {
        const string SourceName = "CodedUITestOracleSource";

        [TestMethod]
        // ReSharper disable once InconsistentNaming
        public void OracleSource_CreateSourceUITests()
        {
            UIMap.Select_NewOracleSource_FromExplorerContextMenu();
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