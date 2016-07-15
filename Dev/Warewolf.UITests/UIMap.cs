﻿using System.Linq;

namespace Warewolf.UITests
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;
    using System.Reflection;
    using System.Threading;
    
    public partial class UIMap
    {
        public void SetGlobalPlaybackSettings()
        {
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
            Playback.PlaybackSettings.ShouldSearchFailFast = false;
            Playback.PlaybackSettings.SearchTimeout = 5000;
            // Ensure the error handler is attached
            Playback.PlaybackError -= Playback_PlaybackError;
            Playback.PlaybackError += Playback_PlaybackError;
        }

        /// <summary> PlaybackError event handler. </summary>
        private static void Playback_PlaybackError(object sender, PlaybackErrorEventArgs e)
        {
            Console.WriteLine("Error from " + sender.GetType() + "\n" + e.Error.Message);
            if (sender is UITestControl)
            {
                (sender as UITestControl).DrawHighlight();
            }
            else
            {
                Playback.Wait(1000);
            }
            e.Result = PlaybackErrorOptions.Retry;
        }

        public void WaitIfStudioDoesNotExist()
        {
            var sleepTimer = 60;
            try
            {
                if (!this.MainStudioWindow.Exists)
                {
                    WaitForStudioStart(sleepTimer * 1000);
                }
            }
            catch (UITestControlNotFoundException)
            {
                WaitForStudioStart(sleepTimer * 1000);
            }
        }

        private void WaitForStudioStart(int timeout)
        {
            Console.WriteLine("Waiting for studio to start.");
            Playback.Wait(timeout);
            if (!this.MainStudioWindow.Exists)
            {
                throw new InvalidOperationException("Warewolf studio is not running. You are expected to run \"Dev\\TestScripts\\Studio\\Startup.bat\" as an administrator and wait for it to complete before running any coded UI tests");
            }
        }
        
        public void InitializeABlankWorkflow()
        {
            Assert_NewWorkFlow_RibbonButton_Exists();
            Click_New_Workflow_Ribbon_Button();
            Assert_StartNode_Exists();
        }
        
        public void CleanupWorkflow()
        {
            try
            {
                Assert_Close_Tab_Button_Exists();
                Click_Close_Tab_Button();
                Click_MessageBox_No();
            }
            catch (UITestControlNotFoundException e)
            {
                //Test may have crashed before tab is even openned
            }
        }
        public UITestControl FindAddResourceButton(UITestControl row)
        {
            var firstOrDefaultCell = row.GetChildren().Where(child => child.ControlType == ControlType.Cell).ElementAtOrDefault(0);
            return firstOrDefaultCell?.GetChildren().FirstOrDefault(child => child.ControlType == ControlType.Button);
        }

        public UITestControl FindAddWindowsGroupButton(UITestControl row)
        {
            var firstOrDefaultCell = row.GetChildren().Where(child => child.ControlType == ControlType.Cell).ElementAtOrDefault(1);
            return firstOrDefaultCell?.GetChildren().FirstOrDefault(child => child.ControlType == ControlType.Button);
        }

        public UITestControl FindViewPermissionsCheckbox(UITestControl row)
        {
            var firstOrDefaultCell = row.GetChildren().Where(child => child.ControlType == ControlType.Cell).ElementAtOrDefault(2);
            return firstOrDefaultCell?.GetChildren().FirstOrDefault(child => child.ControlType == ControlType.CheckBox);
        }

        public UITestControl FindExecutePermissionsCheckbox(UITestControl row)
        {
            var firstOrDefaultCell = row.GetChildren().Where(child => child.ControlType == ControlType.Cell).ElementAtOrDefault(3);
            return firstOrDefaultCell?.GetChildren().FirstOrDefault(child => child.ControlType == ControlType.CheckBox);
        }

        public UITestControl FindContributePermissionsCheckbox(UITestControl row)
        {
            var firstOrDefaultCell = row.GetChildren().Where(child => child.ControlType == ControlType.Cell).ElementAtOrDefault(4);
            return firstOrDefaultCell?.GetChildren().FirstOrDefault(child => child.ControlType == ControlType.CheckBox);
        }
    }
}
