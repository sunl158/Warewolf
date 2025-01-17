/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Activities.Presentation.Model;
using System.Collections.Generic;
using Dev2.Activities.Designers2.Decision;
using Dev2.Common.Interfaces.Help;
using Dev2.Data.Decisions.Operations;
using Dev2.Data.SystemTemplates.Models;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.Interfaces;
using Dev2.TO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Dev2.Data.TO;
using Warewolf.Storage.Interfaces;
using System;
using System.Linq;

namespace Dev2.Activities.Designers.Tests.Decision
{
    [TestClass]
    public class DecisionTests
    {
        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_Equal_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("=", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_NotContains_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Doesn't Contain", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_Contains_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Contains", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_NotEqual_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("<> (Not Equal)", true, false);

        }
        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_EndsWith_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Ends With", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_StartsWith_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Starts With", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_Regex_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Is Regex", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_GreaterThan_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled(">", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_LessThan_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("<", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_LessThanEqual_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("<=", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_GreaterThanEqual_RequiresCriteriaInput_IsCriteriaEnabledTrue()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled(">=", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_NotInRequiresCriteriaInputList_IsCriteriaEnabledFalseSearchCriteriaEmptyString()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Is Numeric", false, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_IndexObjectIsnotZero()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Is Numeric", false, false, -1);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_InRequiresCriteriaInputList_IsCriteriaEnabledFalseSearchCriteriaInBetween()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Is Between", true, false);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_InRequiresCriteriaInputList_IsCriteriaEnabledFalseSearchCriteriaNotBetween()
        {
            Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled("Not Between", true, false);
        }

        void Verify_OnSearchTypeChanged_IsSearchCriteriaEnabled(string searchType, bool isSearchCriteriaEnabled, bool isSearchCriteriaBlank, int indexObject = 0)
        {
            //------------Setup for test--------------------------
            var decisionTO = new DecisionTO("xxxx","xxxx", searchType, 1);

            var viewModel = new DecisionDesignerViewModel(CreateModelItem());

            //------------Precondition---------------------------           
           

            //------------Execute Test---------------------------
            viewModel.SearchTypeUpdatedCommand.Execute(indexObject);

            //------------Assert Results-------------------------
            Assert.AreEqual(isSearchCriteriaEnabled, decisionTO.IsSearchCriteriaVisible);
            Assert.AreEqual(isSearchCriteriaBlank, string.IsNullOrEmpty(decisionTO.SearchCriteria));
        }


        class DecisionDesignerViewModelTestObject : DecisionDesignerViewModel
        {
            public DecisionDesignerViewModelTestObject(ModelItem modelItem): base(modelItem)
            {
            }
            public string GetDisplayText => DisplayText;
            public void TestUpdateDecisionDisplayName(DecisionTO dec)
            {
                this.UpdateDecisionDisplayName(dec);
            }
        }

        [TestMethod]
        [Owner("Rory McGuire")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void Verify_UpdateDecisionDisplayName()
        {
            //------------Setup for test--------------------------
            var items = new List<DecisionTO>
            {
                new DecisionTO("xxxx","xxxx", "Equals", 1),
                new DecisionTO("yyyy","yyyy", "Contains", 2)
            };
            using (var viewModel = new DecisionDesignerViewModelTestObject(CreateModelItem("If this or that"))) {
                viewModel.DisplayText = "If this or that";
                //------------Precondition---------------------------
                Assert.AreEqual(viewModel.DisplayText, "If this or that");

                //------------Execute Test---------------------------
                viewModel.TestUpdateDecisionDisplayName(items[0]);
                Assert.AreEqual(viewModel.DisplayText, "If xxxx Is = xxxx");

                viewModel.TestUpdateDecisionDisplayName(items[1]);
                Assert.AreEqual(viewModel.DisplayText, "If xxxx Is = xxxx");
            }
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_OnSearchTypeChanged_IndexOutOfBounds_DoesNothing()
        {
            Verify_OnSearchTypeChanged_IndexOutOfBounds_DoesNothing(-2);
            Verify_OnSearchTypeChanged_IndexOutOfBounds_DoesNothing(2);
            Verify_OnSearchTypeChanged_IndexOutOfBounds_DoesNothing(3);
        }

        void Verify_OnSearchTypeChanged_IndexOutOfBounds_DoesNothing(int index)
        {
            //------------Setup for test--------------------------
            var items = new List<DecisionTO>
            {
                new DecisionTO("xxxx","xxxx", "Equals", 1),
                new DecisionTO("yyyy","yyyy", "Contains", 2)
            };

            var viewModel = new DecisionDesignerViewModel(CreateModelItem());

      

            //------------Execute Test---------------------------
            viewModel.SearchTypeUpdatedCommand.Execute(index);

            //------------Assert Results-------------------------
            foreach (var dto in items)
            {
                Assert.IsTrue(dto.IsSearchCriteriaEnabled);
                Assert.IsFalse(string.IsNullOrEmpty(dto.SearchCriteria));
            }
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_CustomizedDisplayText()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem("Decision"))
            {
                DisplayText = "",
                TrueArmText = "",
                FalseArmText = "",
                ExpressionText = ""
            };
            viewModel.DisplayText = "Testing";
            var dev2Decision = new Dev2Decision
            {
                Col1 = "[[val]]",
                EvaluationFn = enDecisionType.IsEqual,
                Col2 = "5"
            };
            var item = new DecisionTO(dev2Decision, 1);
            viewModel.Collection.Insert(0, item);
            //------------Execute Test---------------------------
            //------------Assert Results-------------------------
            Assert.AreEqual("Testing", viewModel.DisplayText);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DecisionTo_SearchCriteria")]
        public void DecisionTo_SearchCriteria_Validate_IsFalse()
        {
            //------------Setup for test--------------------------
            //------------Setup for test--------------------------
            var decisionTO = new DecisionTO("xxxx", null, "Equals", 1);

            Assert.IsNotNull(decisionTO.GetRuleSet("SearchCriteria", ""));
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DecisionTo_CanAddOrRemove")]
        public void DecisionTo_CanAddOrRemove_Validate_IsTrue()
        {
            //------------Setup for test--------------------------
            //------------Setup for test--------------------------
            var decisionTO = new DecisionTO("xxxx", "xxxx", "Equals", 1);

            var canAdd = decisionTO.CanAdd();
            var canDelete = decisionTO.CanDelete(decisionTO);
            var canRemove = decisionTO.CanRemove();

            //------------Execute Test---------------------------

            //------------Assert Results-------------------------
            Assert.IsTrue(canAdd);
            Assert.IsTrue(canDelete);
            Assert.IsFalse(canRemove);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DecisionTo_CanAddOrRemoveItems")]
        public void DecisionTo_CanAddOrRemoveItems_Validate_IsTrue()
        {
            //------------Setup for test--------------------------
            //------------Setup for test--------------------------
            var items = new List<DecisionTO>
            {
                new DecisionTO("xxxx","xxxx", "Equals", 1),
                new DecisionTO("","", "Contains", 2)
            };

            //------------Execute Test---------------------------
            var item1 = items[0];
            var item2 = items[1];

            item1.IsFromFocused = false;
            item1.IsToFocused = true;

            //------------Assert Results-------------------------
            Assert.IsFalse(item1.IsFromFocused);
            Assert.IsTrue(item1.IsToFocused);
            Assert.IsTrue(item1.CanAdd());
            Assert.IsTrue(item1.CanDelete(item1));
            Assert.IsFalse(item1.CanRemove());

            Assert.IsFalse(item2.CanAdd());
            Assert.IsTrue(item2.CanDelete(item1));
            Assert.IsFalse(item2.CanRemove());
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("DecisionTo_ClearRow")]
        public void DecisionTo_ClearRow_Validate_RowRemoved()
        {
            //------------Setup for test--------------------------
            //------------Setup for test--------------------------
            var items = new List<DecisionTO>
            {
                new DecisionTO("xxxx","xxxx", "Equals", 1),
                new DecisionTO("","", "Contains", 2)
            };

            //------------Execute Test---------------------------
            var item2 = items[1];

            //------------Assert Results-------------------------

            Assert.AreEqual(2, items.Count);

            item2.ClearRow();

            Assert.AreEqual("", item2.MatchValue);
            Assert.AreEqual("", item2.SearchCriteria);
            Assert.AreEqual("", item2.SearchType);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Constructor_PropertiesInitialized()
        {
            //------------Setup for test--------------------------
           //------------Execute Test---------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem());

            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.ModelItem);
            Assert.IsNotNull(viewModel.Collection);
            Assert.AreEqual("ResultsCollection", viewModel.CollectionName);
            Assert.AreEqual(0, viewModel.TitleBarToggles.Count);
            Assert.AreEqual(38,viewModel.WhereOptions.Count);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_All()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "",
                TrueArmText = "",
                FalseArmText = ""
            };
            viewModel.Collection.RemoveAt(0);
            //------------Execute Test---------------------------
            viewModel.Validate();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(3,viewModel.Errors.Count);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionDisplayTextNotNullErrorTest,viewModel.Errors[0].Message);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionTrueArmTextNotNullErrorTest, viewModel.Errors[1].Message);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionFalseArmTextNotNullErrorTest, viewModel.Errors[2].Message);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_DisplayText()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "",
                TrueArmText = "some text",
                FalseArmText = "some text"
            };
            viewModel.Collection.RemoveAt(0);
            //------------Execute Test---------------------------
            viewModel.Validate();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1,viewModel.Errors.Count);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionDisplayTextNotNullErrorTest, viewModel.Errors[0].Message);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsDisplayTextFocused);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_TrueArm()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "some text",
                TrueArmText = "",
                FalseArmText = "some text"
            };
            viewModel.Collection.RemoveAt(0);
            //------------Execute Test---------------------------
            viewModel.Validate();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionTrueArmTextNotNullErrorTest, viewModel.Errors[0].Message);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsTrueArmFocused);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_FalseText()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "text",
                TrueArmText = "some text",
                FalseArmText = ""
            };
            viewModel.Collection.RemoveAt(0);
            //------------Execute Test---------------------------
            viewModel.Validate();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionFalseArmTextNotNullErrorTest, viewModel.Errors[0].Message);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsFalseArmFocused);
        }

        [TestMethod]
        [Owner("Ashley Lewis")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_Validate_MatchType()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "text",
                TrueArmText = "some text",
                FalseArmText = "some text"
            };
            //------------Execute Test---------------------------
            viewModel.Validate();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual(1, viewModel.Errors.Count);
            Assert.AreEqual(Warewolf.Resource.Errors.ErrorResource.DecisionMatchTypeNotNullErrorTest, viewModel.Errors[0].Message);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_HandleConfigureMessage_SetShowLarge()
        {
            //------------Setup for test--------------------------            
            var viewModel = new DecisionDesignerViewModel(CreateModelItem());           
            //------------Execute Test---------------------------
            viewModel.Handle(new ConfigureDecisionExpressionMessage());
            //------------Assert Results-------------------------
            Assert.IsTrue(viewModel.ShowLarge);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_UpdateHelp_ShouldCallToHelpViewMode()
        {
            //------------Setup for test--------------------------            
            var mockMainViewModel = new Mock<IShellViewModel>();
            var mockHelpViewModel = new Mock<IHelpWindowViewModel>();
            mockHelpViewModel.Setup(model => model.UpdateHelpText(It.IsAny<string>())).Verifiable();
            mockMainViewModel.Setup(model => model.HelpViewModel).Returns(mockHelpViewModel.Object);
            CustomContainer.Register(mockMainViewModel.Object);
            var viewModel = new DecisionDesignerViewModel(CreateModelItem());
            //------------Execute Test---------------------------
            viewModel.UpdateHelpDescriptor("help");
            //------------Assert Results-------------------------
            mockHelpViewModel.Verify(model => model.UpdateHelpText(It.IsAny<string>()),Times.Once());
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_GetExpressionText_ShouldSetExpressionText()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "",
                TrueArmText = "",
                FalseArmText = ""
            };
            var dev2Decision = new Dev2Decision
            {
                Col1 = "[[val]]",
                EvaluationFn = enDecisionType.IsEqual,
                Col2 = "5"
            };
            viewModel.Collection.Add(new DecisionTO(dev2Decision,1));
            //------------Execute Test---------------------------
            viewModel.GetExpressionText();
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.ExpressionText);
            StringAssert.Contains(viewModel.ExpressionText, "{\"TheStack\":[{\"Col1\":\"[[val]]\",\"Col2\":\"5\",\"Col3\":\"\",\"Cols1\":null,\"Cols2\":null,\"Cols3\":null,\"PopulatedColumnCount\":2,\"EvaluationFn\":\"IsEqual\"}],\"TotalDecisions\":1,\"ModelName\":\"Dev2DecisionStack\",\"Mode\":\"AND\",\"TrueArmText\":\"\",\"FalseArmText\":\"\",\"DisplayText\":\"\",\"Version\":null}");
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory(nameof(DecisionDesignerViewModel))]
        public void DecisionDesignerViewModel_RemoveRow_ShouldRemove()
        {
            //------------Setup for test--------------------------
            var viewModel = new DecisionDesignerViewModel(CreateModelItem())
            {
                DisplayText = "",
                TrueArmText = "",
                FalseArmText = ""
            };
            var dev2Decision = new Dev2Decision
            {
                Col1 = "[[val]]",
                EvaluationFn = enDecisionType.IsEqual,
                Col2 = "5"
            };
            var item = new DecisionTO(dev2Decision,1);
            viewModel.Collection.Insert(0,item);
            //------------Assert Preconsidtions------------------
            Assert.AreEqual(3,viewModel.Collection.Count);
            //------------Execute Test---------------------------
            viewModel.DeleteCommand.Execute(item);
            //------------Assert Results-------------------------
            Assert.AreEqual(2, viewModel.Collection.Count);
        }

        [TestMethod]
        [Owner("Ashley Lewis")]
        public void Decision_StaredRecordsetIsBetweenTwoStaredRecordsets_ValidateAndGenerateUserFriendlyModel()
        {
            //------------Setup for test--------------------------
            using (var viewModel = new DecisionDesignerViewModel(CreateModelItem(nameof(Decision)))
            {
                TrueArmText = "",
                FalseArmText = "",
                ExpressionText = "",
                DisplayText = "Testing"
            })
            {
                var dev2Decision = new Dev2Decision
                {
                    Col1 = "[[recset(*).field]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[recset(*).field]]",
                    Col3 = "[[recset(*).field]]"
                };
                var mockedEnvironment = new Mock<IExecutionEnvironment>();
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                var userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out ErrorResultTO errors);
                Assert.AreEqual("If Some Value Is Between Some Value AND Some Value", userFriendlyModel, "User friendly model was not generated correctly for decision on multiple starred recordsets.");
                var item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[recset(*).field]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[recset(*).field]]",
                    Col3 = "[[val]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If Some Value Is Between Some Value AND [[val]]", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[recset(*).field]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[val]]",
                    Col3 = "[[recset(*).field]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If Some Value Is Between [[val]] AND Some Value", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                var dev2Decision4 = new Dev2Decision
                {
                    Col1 = "[[val]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[recset(*).field]]",
                    Col3 = "[[recset(*).field]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                item = new DecisionTO(dev2Decision4, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[val]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[val]]",
                    Col3 = "[[recset(*).field]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If [[val]] Is Between [[val]] AND Some Value", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[val]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[recset(*).field]]",
                    Col3 = "[[val]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If [[val]] Is Between Some Value AND [[val]]", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[recset(*).field]]",
                    EvaluationFn = enDecisionType.IsBetween,
                    Col2 = "[[val]]",
                    Col3 = "[[val]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If Some Value Is Between [[val]] AND [[val]]", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                dev2Decision = new Dev2Decision
                {
                    Col1 = "[[recset(*).field]]",
                    EvaluationFn = enDecisionType.IsEqual,
                    Col2 = "[[recset(*).field]]"
                };
                mockedEnvironment.Setup(env => env.EvalAsListOfStrings(It.IsAny<string>(), It.IsAny<int>())).Returns(new List<string> { "Some Value" });
                userFriendlyModel = dev2Decision.GenerateToolLabel(mockedEnvironment.Object, Dev2DecisionMode.AND, out errors);
                Assert.AreEqual("If Some Value = Some Value", userFriendlyModel, "User friendly model was not generated correctly.");
                item = new DecisionTO(dev2Decision, 1);
                viewModel.Collection.Insert(0, item);
                //------------Execute Test---------------------------
                //------------Assert Results-------------------------
                Assert.AreEqual("Testing", viewModel.DisplayText);
            }
        }

        static ModelItem CreateModelItem(string displayName = "Find")
        {
            var modelItem = ModelItemUtils.CreateModelItem(new DsfDecision());
            modelItem.SetProperty("DisplayName", displayName);

            return modelItem;
        }


        class Entry
        {
            public enDecisionType _decisionType;
            public bool _found;
        }
        [TestMethod]
        [Owner("Rory McGuire")]
        [TestCategory(nameof(enDecisionType))]
        public void enDecisionType_Handled()
        {
            var type = typeof(IDecisionOperation);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);

            var names = Enum.GetValues(typeof(enDecisionType))
                .Cast<enDecisionType>()
                .Select(o => new Entry { _decisionType = o, _found = false })
                .ToArray();

            foreach (var item in names)
            {
                if (types.Any(t =>
                {
                    var v = Activator.CreateInstance(t) as IDecisionOperation;
                    var handlesType = (enDecisionType)v.HandlesType();
                    return handlesType == item._decisionType;
                }))
                {
                    item._found = true;
                }
            }

            var unhandledDecisionTypes = names.Where(o => !o._found).ToArray();

            Assert.AreEqual(1, unhandledDecisionTypes.Length);
            Assert.AreEqual(enDecisionType.Choose, unhandledDecisionTypes[0]._decisionType);
        }
    }
}
