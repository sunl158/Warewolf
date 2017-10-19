﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 15.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Warewolf.UI.Tests.MergeDialog.MergeDialogUIMapClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public partial class MergeDialogUIMap
    {
        
        #region Properties
        public MergeDialogWindow MergeDialogWindow
        {
            get
            {
                if ((this.mMergeDialogWindow == null))
                {
                    this.mMergeDialogWindow = new MergeDialogWindow();
                }
                return this.mMergeDialogWindow;
            }
        }
        #endregion
        
        #region Fields
        private MergeDialogWindow mMergeDialogWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeDialogWindow : WpfWindow
    {
        
        public MergeDialogWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "MergeDialogView";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public MergeConnectControl MergeConnectControl
        {
            get
            {
                if ((this.mMergeConnectControl == null))
                {
                    this.mMergeConnectControl = new MergeConnectControl(this);
                }
                return this.mMergeConnectControl;
            }
        }
        
        public MergeExplorerView MergeExplorerView
        {
            get
            {
                if ((this.mMergeExplorerView == null))
                {
                    this.mMergeExplorerView = new MergeExplorerView(this);
                }
                return this.mMergeExplorerView;
            }
        }
        
        public MergeResourceVersionList MergeResourceVersionList
        {
            get
            {
                if ((this.mMergeResourceVersionList == null))
                {
                    this.mMergeResourceVersionList = new MergeResourceVersionList(this);
                }
                return this.mMergeResourceVersionList;
            }
        }
        
        public WpfText LocalMergeText
        {
            get
            {
                if ((this.mLocalMergeText == null))
                {
                    this.mLocalMergeText = new WpfText(this);
                    #region Search Criteria
                    this.mLocalMergeText.SearchProperties[WpfText.PropertyNames.AutomationId] = "SelectedResourceTextBox";
                    this.mLocalMergeText.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mLocalMergeText;
            }
        }
        
        public WpfText MergewithText
        {
            get
            {
                if ((this.mMergewithText == null))
                {
                    this.mMergewithText = new WpfText(this);
                    #region Search Criteria
                    this.mMergewithText.SearchProperties[WpfText.PropertyNames.Name] = "merge with";
                    this.mMergewithText.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mMergewithText;
            }
        }
        
        public WpfText ResourceToMergeText
        {
            get
            {
                if ((this.mResourceToMergeText == null))
                {
                    this.mResourceToMergeText = new WpfText(this);
                    #region Search Criteria
                    this.mResourceToMergeText.SearchProperties[WpfText.PropertyNames.AutomationId] = "ResourceToMergeTextBox";
                    this.mResourceToMergeText.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mResourceToMergeText;
            }
        }
        
        public WpfButton MergeButton
        {
            get
            {
                if ((this.mMergeButton == null))
                {
                    this.mMergeButton = new WpfButton(this);
                    #region Search Criteria
                    this.mMergeButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "MergeButton";
                    this.mMergeButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mMergeButton;
            }
        }
        
        public WpfButton CancelButton
        {
            get
            {
                if ((this.mCancelButton == null))
                {
                    this.mCancelButton = new WpfButton(this);
                    #region Search Criteria
                    this.mCancelButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "CancelButton";
                    this.mCancelButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mCancelButton;
            }
        }
        #endregion
        
        #region Fields
        private MergeConnectControl mMergeConnectControl;
        
        private MergeExplorerView mMergeExplorerView;
        
        private MergeResourceVersionList mMergeResourceVersionList;
        
        private WpfText mLocalMergeText;
        
        private WpfText mMergewithText;
        
        private WpfText mResourceToMergeText;
        
        private WpfButton mMergeButton;
        
        private WpfButton mCancelButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeConnectControl : WpfCustom
    {
        
        public MergeConnectControl(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ConnectControl";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "SourceConnectControl";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public ServerComboBox ServerComboBox
        {
            get
            {
                if ((this.mServerComboBox == null))
                {
                    this.mServerComboBox = new ServerComboBox(this);
                }
                return this.mServerComboBox;
            }
        }
        
        public WpfButton EditServerButton
        {
            get
            {
                if ((this.mEditServerButton == null))
                {
                    this.mEditServerButton = new WpfButton(this);
                    #region Search Criteria
                    this.mEditServerButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "UI_SourceServerEditbtn_AutoID";
                    this.mEditServerButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mEditServerButton;
            }
        }
        
        public WpfButton NewServerButton
        {
            get
            {
                if ((this.mNewServerButton == null))
                {
                    this.mNewServerButton = new WpfButton(this);
                    #region Search Criteria
                    this.mNewServerButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "NewServerButton";
                    this.mNewServerButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mNewServerButton;
            }
        }
        #endregion
        
        #region Fields
        private ServerComboBox mServerComboBox;
        
        private WpfButton mEditServerButton;
        
        private WpfButton mNewServerButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ServerComboBox : WpfCustom
    {
        
        public ServerComboBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.XamComboEditor";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "TheServerComboBox";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfButton ToggleButton
        {
            get
            {
                if ((this.mToggleButton == null))
                {
                    this.mToggleButton = new WpfButton(this);
                    #region Search Criteria
                    this.mToggleButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "ToggleButton";
                    this.mToggleButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mToggleButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mToggleButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeExplorerView : WpfCustom
    {
        
        public MergeExplorerView(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfControl.PropertyNames.ClassName] = "Uia.ExplorerView";
            this.SearchProperties[WpfControl.PropertyNames.AutomationId] = "ExplorerView";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public SearchTextBox SearchTextBox
        {
            get
            {
                if ((this.mSearchTextBox == null))
                {
                    this.mSearchTextBox = new SearchTextBox(this);
                }
                return this.mSearchTextBox;
            }
        }
        
        public WpfButton RefreshButton
        {
            get
            {
                if ((this.mRefreshButton == null))
                {
                    this.mRefreshButton = new WpfButton(this);
                    #region Search Criteria
                    this.mRefreshButton.SearchProperties[WpfButton.PropertyNames.AutomationId] = "FilterRefreshButton";
                    this.mRefreshButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mRefreshButton;
            }
        }
        
        public MergeExplorerTree MergeExplorerTree
        {
            get
            {
                if ((this.mMergeExplorerTree == null))
                {
                    this.mMergeExplorerTree = new MergeExplorerTree(this);
                }
                return this.mMergeExplorerTree;
            }
        }
        #endregion
        
        #region Fields
        private SearchTextBox mSearchTextBox;
        
        private WpfButton mRefreshButton;
        
        private MergeExplorerTree mMergeExplorerTree;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class SearchTextBox : WpfEdit
    {
        
        public SearchTextBox(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfEdit.PropertyNames.AutomationId] = "SearchTextBox";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText SearchResourcesWatermark
        {
            get
            {
                if ((this.mSearchResourcesWatermark == null))
                {
                    this.mSearchResourcesWatermark = new WpfText(this);
                    #region Search Criteria
                    this.mSearchResourcesWatermark.SearchProperties[WpfText.PropertyNames.AutomationId] = "LabelText";
                    this.mSearchResourcesWatermark.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mSearchResourcesWatermark;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mSearchResourcesWatermark;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeExplorerTree : WpfTree
    {
        
        public MergeExplorerTree(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTree.PropertyNames.AutomationId] = "ExplorerTree";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public ExplorerTreeItem ExplorerTreeItem
        {
            get
            {
                if ((this.mExplorerTreeItem == null))
                {
                    this.mExplorerTreeItem = new ExplorerTreeItem(this);
                }
                return this.mExplorerTreeItem;
            }
        }
        #endregion
        
        #region Fields
        private ExplorerTreeItem mExplorerTreeItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ExplorerTreeItem : WpfTreeItem
    {
        
        public ExplorerTreeItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfTreeItem.PropertyNames.Name] = "Warewolf.Studio.ViewModels.EnvironmentViewModel";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfButton Expander
        {
            get
            {
                if ((this.mExpander == null))
                {
                    this.mExpander = new WpfButton(this);
                    #region Search Criteria
                    this.mExpander.SearchProperties[WpfButton.PropertyNames.AutomationId] = "Expander";
                    this.mExpander.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mExpander.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mExpander;
            }
        }
        
        public WpfTreeItem ExplorerItemTreeItemOne
        {
            get
            {
                if ((this.mExplorerItemTreeItemOne == null))
                {
                    this.mExplorerItemTreeItemOne = new WpfTreeItem(this);
                    #region Search Criteria
                    this.mExplorerItemTreeItemOne.SearchProperties[WpfTreeItem.PropertyNames.Name] = "Warewolf.Studio.ViewModels.ExplorerItemViewModel";
                    this.mExplorerItemTreeItemOne.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mExplorerItemTreeItemOne.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mExplorerItemTreeItemOne;
            }
        }
        
        public WpfButton ExplorerItemTreeItemRefreshButton
        {
            get
            {
                if ((this.mExplorerItemTreeItemRefreshButton == null))
                {
                    this.mExplorerItemTreeItemRefreshButton = new WpfButton(this);
                    #region Search Criteria
                    this.mExplorerItemTreeItemRefreshButton.SearchProperties[WpfButton.PropertyNames.Instance] = "2";
                    this.mExplorerItemTreeItemRefreshButton.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mExplorerItemTreeItemRefreshButton.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mExplorerItemTreeItemRefreshButton;
            }
        }
        #endregion
        
        #region Fields
        private WpfButton mExpander;
        
        private WpfTreeItem mExplorerItemTreeItemOne;
        
        private WpfButton mExplorerItemTreeItemRefreshButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeResourceVersionList : WpfList
    {
        
        public MergeResourceVersionList(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfList.PropertyNames.AutomationId] = "MergeResourceVersionList";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WarewolfStudioViewMoListItem WarewolfStudioViewMoListItem
        {
            get
            {
                if ((this.mWarewolfStudioViewMoListItem == null))
                {
                    this.mWarewolfStudioViewMoListItem = new WarewolfStudioViewMoListItem(this);
                }
                return this.mWarewolfStudioViewMoListItem;
            }
        }
        #endregion
        
        #region Fields
        private WarewolfStudioViewMoListItem mWarewolfStudioViewMoListItem;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class WarewolfStudioViewMoListItem : WpfListItem
    {
        
        public WarewolfStudioViewMoListItem(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfListItem.PropertyNames.Name] = "Warewolf.Studio.ViewModels.VersionViewModel";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public ItemRadioButton ItemRadioButton
        {
            get
            {
                if ((this.mItemRadioButton == null))
                {
                    this.mItemRadioButton = new ItemRadioButton(this);
                }
                return this.mItemRadioButton;
            }
        }
        
        public ItemRadioButton2 ItemRadioButton2
        {
            get
            {
                if ((this.mItemRadioButton2 == null))
                {
                    this.mItemRadioButton2 = new ItemRadioButton2(this);
                }
                return this.mItemRadioButton2;
            }
        }
        #endregion
        
        #region Fields
        private ItemRadioButton mItemRadioButton;
        
        private ItemRadioButton2 mItemRadioButton2;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ItemRadioButton : WpfRadioButton
    {
        
        public ItemRadioButton(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public MergeWfWithVersion MergeWfWithVersion
        {
            get
            {
                if ((this.mMergeWfWithVersion == null))
                {
                    this.mMergeWfWithVersion = new MergeWfWithVersion(this);
                }
                return this.mMergeWfWithVersion;
            }
        }
        
        public MergeHelloWorldVersionV2 MergeHelloWorldVersionV2
        {
            get
            {
                if ((this.mMergeHelloWorldVersionV2 == null))
                {
                    this.mMergeHelloWorldVersionV2 = new MergeHelloWorldVersionV2(this);
                }
                return this.mMergeHelloWorldVersionV2;
            }
        }
        
        public MergeSequence MergeSequence
        {
            get
            {
                if ((this.mMergeSequence == null))
                {
                    this.mMergeSequence = new MergeSequence(this);
                }
                return this.mMergeSequence;
            }
        }
        
        public MergeSwitch MergeSwitch
        {
            get
            {
                if ((this.mMergeSwitch == null))
                {
                    this.mMergeSwitch = new MergeSwitch(this);
                }
                return this.mMergeSwitch;
            }
        }
        
        public MergeForeach MergeForeach
        {
            get
            {
                if ((this.mMergeForeach == null))
                {
                    this.mMergeForeach = new MergeForeach(this);
                }
                return this.mMergeForeach;
            }
        }
        #endregion
        
        #region Fields
        private MergeWfWithVersion mMergeWfWithVersion;
        
        private MergeHelloWorldVersionV2 mMergeHelloWorldVersionV2;
        
        private MergeSequence mMergeSequence;
        
        private MergeSwitch mMergeSwitch;
        
        private MergeForeach mMergeForeach;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeWfWithVersion : WpfText
    {
        
        public MergeWfWithVersion(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110122017100449SaveText1
        {
            get
            {
                if ((this.mUIV110122017100449SaveText1 == null))
                {
                    this.mUIV110122017100449SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110122017100449SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110122017100449SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110122017100449SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110122017100449SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeHelloWorldVersionV2 : WpfText
    {
        
        public MergeHelloWorldVersionV2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfText.PropertyNames.Name, "v.2", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV210132017131521SaveText1
        {
            get
            {
                if ((this.mUIV210132017131521SaveText1 == null))
                {
                    this.mUIV210132017131521SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV210132017131521SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.2 10132017 131521 Save";
                    this.mUIV210132017131521SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV210132017131521SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV210132017131521SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV210132017131521SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeSequence : WpfText
    {
        
        public MergeSequence(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114409 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017114409SaveText1
        {
            get
            {
                if ((this.mUIV110162017114409SaveText1 == null))
                {
                    this.mUIV110162017114409SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017114409SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114409 Save";
                    this.mUIV110162017114409SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017114409SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017114409SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017114409SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeSwitch : WpfText
    {
        
        public MergeSwitch(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114512 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017114512SaveText1
        {
            get
            {
                if ((this.mUIV110162017114512SaveText1 == null))
                {
                    this.mUIV110162017114512SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017114512SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114512 Save";
                    this.mUIV110162017114512SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017114512SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017114512SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017114512SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeForeach : WpfText
    {
        
        public MergeForeach(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 103850 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017103850SaveText1
        {
            get
            {
                if ((this.mUIV110162017103850SaveText1 == null))
                {
                    this.mUIV110162017103850SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017103850SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 103850 Save";
                    this.mUIV110162017103850SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017103850SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017103850SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017103850SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class ItemRadioButton2 : WpfRadioButton
    {
        
        public ItemRadioButton2(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfRadioButton.PropertyNames.Instance] = "2";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public MergeWfWithVersion1 MergeWfWithVersion
        {
            get
            {
                if ((this.mMergeWfWithVersion == null))
                {
                    this.mMergeWfWithVersion = new MergeWfWithVersion1(this);
                }
                return this.mMergeWfWithVersion;
            }
        }
        
        public MergeHelloWorldVersionV21 MergeHelloWorldVersionV2
        {
            get
            {
                if ((this.mMergeHelloWorldVersionV2 == null))
                {
                    this.mMergeHelloWorldVersionV2 = new MergeHelloWorldVersionV21(this);
                }
                return this.mMergeHelloWorldVersionV2;
            }
        }
        
        public MergeSequence1 MergeSequence
        {
            get
            {
                if ((this.mMergeSequence == null))
                {
                    this.mMergeSequence = new MergeSequence1(this);
                }
                return this.mMergeSequence;
            }
        }
        
        public MergeSwitch1 MergeSwitch
        {
            get
            {
                if ((this.mMergeSwitch == null))
                {
                    this.mMergeSwitch = new MergeSwitch1(this);
                }
                return this.mMergeSwitch;
            }
        }
        
        public MergeForeach1 MergeForeach
        {
            get
            {
                if ((this.mMergeForeach == null))
                {
                    this.mMergeForeach = new MergeForeach1(this);
                }
                return this.mMergeForeach;
            }
        }
        #endregion
        
        #region Fields
        private MergeWfWithVersion1 mMergeWfWithVersion;
        
        private MergeHelloWorldVersionV21 mMergeHelloWorldVersionV2;
        
        private MergeSequence1 mMergeSequence;
        
        private MergeSwitch1 mMergeSwitch;
        
        private MergeForeach1 mMergeForeach;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeWfWithVersion1 : WpfText
    {
        
        public MergeWfWithVersion1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110122017100449SaveText1
        {
            get
            {
                if ((this.mUIV110122017100449SaveText1 == null))
                {
                    this.mUIV110122017100449SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110122017100449SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110122017100449SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110122017100449SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110122017100449SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeHelloWorldVersionV21 : WpfText
    {
        
        public MergeHelloWorldVersionV21(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties.Add(new PropertyExpression(WpfText.PropertyNames.Name, "v.2", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV210132017131521SaveText1
        {
            get
            {
                if ((this.mUIV210132017131521SaveText1 == null))
                {
                    this.mUIV210132017131521SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV210132017131521SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.2 10132017 131521 Save";
                    this.mUIV210132017131521SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV210132017131521SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV210132017131521SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV210132017131521SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeSequence1 : WpfText
    {
        
        public MergeSequence1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114409 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017114409SaveText1
        {
            get
            {
                if ((this.mUIV110162017114409SaveText1 == null))
                {
                    this.mUIV110162017114409SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017114409SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114409 Save";
                    this.mUIV110162017114409SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017114409SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017114409SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017114409SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeSwitch1 : WpfText
    {
        
        public MergeSwitch1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114512 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017114512SaveText1
        {
            get
            {
                if ((this.mUIV110162017114512SaveText1 == null))
                {
                    this.mUIV110162017114512SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017114512SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 114512 Save";
                    this.mUIV110162017114512SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017114512SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017114512SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017114512SaveText1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "15.0.26208.0")]
    public class MergeForeach1 : WpfText
    {
        
        public MergeForeach1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 103850 Save";
            this.WindowTitles.Add("MergeDialogView");
            #endregion
        }
        
        #region Properties
        public WpfText UIV110162017103850SaveText1
        {
            get
            {
                if ((this.mUIV110162017103850SaveText1 == null))
                {
                    this.mUIV110162017103850SaveText1 = new WpfText(this);
                    #region Search Criteria
                    this.mUIV110162017103850SaveText1.SearchProperties[WpfText.PropertyNames.Name] = "v.1 10162017 103850 Save";
                    this.mUIV110162017103850SaveText1.SearchConfigurations.Add(SearchConfiguration.DisambiguateChild);
                    this.mUIV110162017103850SaveText1.WindowTitles.Add("MergeDialogView");
                    #endregion
                }
                return this.mUIV110162017103850SaveText1;
            }
        }
        #endregion
        
        #region Fields
        private WpfText mUIV110162017103850SaveText1;
        #endregion
    }
}
