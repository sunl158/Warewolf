/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Activities.Presentation.Model;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using Caliburn.Micro;
using Dev2.Activities.Designers2.Email;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Help;
using Dev2.Common.Interfaces.Threading;
using Dev2.Communication;
using Dev2.Runtime.Diagnostics;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Studio.Core.Activities.Utils;
using Dev2.Studio.Core.Messages;
using Dev2.Studio.Interfaces;
using Dev2.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Dev2.Activities.Designers.Tests.Email
{
    [TestClass]
    public class EmailDesignerViewModelTests
    {
        const string AppLocalhost = "http://localhost:3142";

        [TestInitialize]
        public void Initialize()
        {
            AppUsageStats.LocalHost = AppLocalhost;
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailDesignerViewModel_Constructor_AsyncWorkerIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            
            new EmailDesignerViewModel(CreateModelItem(), null, null, null);
            

            //------------Assert Results-------------------------
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailDesignerViewModel_Constructor_EnvironmentModelIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            
            new EmailDesignerViewModel(CreateModelItem(), new Mock<IAsyncWorker>().Object, null, null);
            

            //------------Assert Results-------------------------
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmailDesignerViewModel_Constructor_EventAggregatorIsNull_ThrowsArgumentNullException()
        {
            //------------Setup for test--------------------------

            //------------Execute Test---------------------------
            
            new EmailDesignerViewModel(CreateModelItem(), new Mock<IAsyncWorker>().Object, new Mock<IServer>().Object, null);
            

            //------------Assert Results-------------------------
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        public void EmailDesignerViewModel_Constructor_ModelItemIsNew_InitializesProperties()
        {
            //------------Setup for test--------------------------
            var modelItem = CreateModelItem();
            var propertyChanged = false;
            modelItem.PropertyChanged += (sender, args) =>
            {
                propertyChanged = true;
            };
            const int EmailSourceCount = 2;
            var sources = CreateEmailSources(EmailSourceCount);

            //------------Execute Test---------------------------
            var viewModel = CreateViewModel(sources, modelItem);


            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.ModelItem);
            Assert.IsNotNull(viewModel.EditEmailSourceCommand);
            Assert.IsNotNull(viewModel.NewEmailSourceCommand);
            Assert.IsNotNull(viewModel.TestEmailAccountCommand);
            Assert.IsNotNull(viewModel.ChooseAttachmentsCommand);
            Assert.IsNotNull(viewModel.EmailSources);
            Assert.IsNotNull(viewModel.Priorities);
            Assert.IsFalse(viewModel.IsEmailSourceSelected);
            Assert.IsFalse(viewModel.IsRefreshing);
            Assert.IsTrue(viewModel.CanTestEmailAccount);

            Assert.AreEqual(EmailSourceCount, viewModel.EmailSources.Count);
            Assert.IsNull(viewModel.SelectedEmailSource);

            Assert.IsNull(viewModel.SelectedEmailSourceModelItemValue);

            Assert.IsFalse(propertyChanged);
        }

        [TestMethod]
        [Owner("Pieter Terblanche")]
        [TestCategory("EmailDesignerViewModel_Handle")]
        public void EmailDesignerViewModel_UpdateHelp_ShouldCallToHelpViewMode()
        {
            //------------Setup for test--------------------------      
            const int EmailSourceCount = 2;
            var sources = CreateEmailSources(EmailSourceCount);
            var selectedEmailSource = sources.First();

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", selectedEmailSource);

            var mockMainViewModel = new Mock<IShellViewModel>();
            var mockHelpViewModel = new Mock<IHelpWindowViewModel>();
            mockHelpViewModel.Setup(model => model.UpdateHelpText(It.IsAny<string>())).Verifiable();
            mockMainViewModel.Setup(model => model.HelpViewModel).Returns(mockHelpViewModel.Object);
            CustomContainer.Register(mockMainViewModel.Object);

            var viewModel = CreateViewModel(sources, modelItem);
            //------------Execute Test---------------------------
            viewModel.UpdateHelpDescriptor("help");
            //------------Assert Results-------------------------
            mockHelpViewModel.Verify(model => model.UpdateHelpText(It.IsAny<string>()), Times.Once());
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        public void EmailDesignerViewModel_Constructor_ModelItemIsNotNew_InitializesProperties()
        {
            //------------Setup for test--------------------------
            const int EmailSourceCount = 2;
            var sources = CreateEmailSources(EmailSourceCount);
            var selectedEmailSource = sources.First();

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", selectedEmailSource);

            var propertyChanged = false;
            modelItem.PropertyChanged += (sender, args) =>
            {
                propertyChanged = true;
            };

            //------------Execute Test---------------------------
            var viewModel = CreateViewModel(sources, modelItem);


            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.ModelItem);
            Assert.IsNotNull(viewModel.EditEmailSourceCommand);
            Assert.IsNotNull(viewModel.TestEmailAccountCommand);
            Assert.IsNotNull(viewModel.ChooseAttachmentsCommand);
            Assert.IsNotNull(viewModel.EmailSources);
            Assert.IsNotNull(viewModel.Priorities);
            Assert.IsTrue(viewModel.IsEmailSourceSelected);
            Assert.IsFalse(viewModel.IsRefreshing);
            Assert.IsTrue(viewModel.CanTestEmailAccount);

            Assert.AreEqual(EmailSourceCount, viewModel.EmailSources.Count);
            Assert.AreEqual(selectedEmailSource, viewModel.SelectedEmailSource);

            Assert.IsNotNull(viewModel.SelectedEmailSourceModelItemValue);

            Assert.IsFalse(propertyChanged);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Constructor")]
        public void EmailDesignerViewModel_Constructor_DoesNotAutoCopyEmailSourceUserNameIntoFromAccount()
        {
            Verify_Constructor_DoesNotAutoCopyEmailSourceUserNameIntoFromAccount("test@mydomain.com");
            Verify_Constructor_DoesNotAutoCopyEmailSourceUserNameIntoFromAccount("");
        }

        void Verify_Constructor_DoesNotAutoCopyEmailSourceUserNameIntoFromAccount(string expectedFromAccount)
        {
            //------------Setup for test--------------------------
            var activity = new DsfSendEmailActivity { FromAccount = expectedFromAccount };

            var emailSource = new EmailSource
            {
                UserName = "bob@mydomain.com",
                Password = "MyPassword",
                EnableSsl = false,
                Host = "mx.mydomain.com",
                Port = 25,
                ResourceID = Guid.NewGuid()
            };
            var modelItem = ModelItemUtils.CreateModelItem(activity);
            var viewModel = CreateViewModel(null, modelItem);

            //------------Execute Test---------------------------
            viewModel.SelectedEmailSource = emailSource;

            //------------Assert Results-------------------------
            var fromAccount = modelItem.GetProperty<string>("FromAccount");
            Assert.AreEqual(expectedFromAccount, fromAccount);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_EditEmailSource")]
        public void EmailDesignerViewModel_EditEmailSource_PublishesShowEditResourceWizardMessage()
        {
            //------------Setup for test--------------------------
            var emailSources = CreateEmailSources(2);

            var selectedEmailSource = emailSources.First();

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", selectedEmailSource);

            var eventPublisher = new Mock<IEventAggregator>();
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(model => model.EditResource(It.IsAny<IEmailServiceSource>())).Verifiable();
            CustomContainer.Register(mockShellViewModel.Object);
            var resourceModel = new Mock<IResourceModel>();

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, resourceModel.Object);

            //------------Execute Test---------------------------
            viewModel.EditEmailSourceCommand.Execute(null);


            //------------Assert Results-------------------------
            mockShellViewModel.Verify(model => model.EditResource(It.IsAny<IEmailServiceSource>()));
            CustomContainer.DeRegister<IShellViewModel>();
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_CreateEmailSource")]
        public void EmailDesignerViewModel_CreateEmailSource_PublishesShowNewResourceWizard()
        {
            //------------Setup for test--------------------------
            var emailSources = CreateEmailSources(2);

            var selectedEmailSource = emailSources.First();

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", selectedEmailSource);

            var eventPublisher = new Mock<IEventAggregator>();

            var resourceModel = new Mock<IResourceModel>();
            var mockShellViewModel = new Mock<IShellViewModel>();
            mockShellViewModel.Setup(model => model.NewEmailSource(It.IsAny<string>()));
            var shellViewModel = mockShellViewModel.Object;
            CustomContainer.Register(shellViewModel);
            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, resourceModel.Object);

            var createEmailSource = viewModel.EmailSources[0];
            Assert.AreEqual("Email0", createEmailSource.ResourceName);

            //------------Execute Test---------------------------
            viewModel.NewEmailSourceCommand.Execute(null);

            //------------Assert Results-------------------------
            mockShellViewModel.Verify(model => model.NewEmailSource(It.IsAny<string>()));
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_CreateEmailSource")]
        public void EmailDesignerViewModel_SetEmailSource_FiresEditEmailSourceCommand_CanExecuteChanged()
        {
            //------------Setup for test--------------------------
            var emailSources = CreateEmailSources(2);

            var selectedEmailSource = emailSources.First();

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", selectedEmailSource);

            var eventPublisher = new Mock<IEventAggregator>();

            var resourceModel = new Mock<IResourceModel>();

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, resourceModel.Object);
            var hitCount = 0;
            viewModel.EditEmailSourceCommand.CanExecuteChanged += (sender, args) =>
            {
                hitCount++;
            };
            var createEmailSource = viewModel.EmailSources[0];
            Assert.AreEqual("Email0", createEmailSource.ResourceName);

            //------------Execute Test---------------------------
            viewModel.SelectedEmailSource = createEmailSource;

            //------------Assert Results-------------------------
            Assert.AreEqual(1, hitCount);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ChooseAttachments")]
        public void EmailDesignerViewModel_ChooseAttachments_PublishesFileChooserMessage()
        {
            //------------Setup for test--------------------------
            var emailSources = CreateEmailSources(2);
            var modelItem = CreateModelItem();

            var eventPublisher = new Mock<IEventAggregator>();
            eventPublisher.Setup(p => p.Publish(It.IsAny<FileChooserMessage>())).Verifiable();

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, new Mock<IResourceModel>().Object);

            //------------Execute Test---------------------------
            viewModel.ChooseAttachmentsCommand.Execute(null);

            //------------Assert Results-------------------------
            eventPublisher.Verify(p => p.Publish(It.IsAny<FileChooserMessage>()));
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ChooseAttachments")]
        public void EmailDesignerViewModel_ChooseAttachments_SelectedFilesIsNotNull_AddsFilesToAttachments()
        {
            var selectedFiles = new List<string> { @"c:\tmp2.txt", @"c:\logs\errors2.log" };
            //------------Setup for test--------------------------
            var existingFiles = new List<string> { @"c:\tmp1.txt", @"c:\logs\errors1.log" };

            var expectedFiles = new List<string>();
            expectedFiles.AddRange(existingFiles);
            if (selectedFiles != null)
            {
                expectedFiles.AddRange(selectedFiles);
            }

            var emailSources = CreateEmailSources(2);
            var modelItem = CreateModelItem();
            modelItem.SetProperty("Attachments", string.Join(";", expectedFiles));

            var eventPublisher = new Mock<IEventAggregator>();
            eventPublisher.Setup(p => p.Publish(It.IsAny<FileChooserMessage>())).Callback((object m) =>
            {
                ((FileChooserMessage)m).SelectedFiles = expectedFiles;
            });

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, new Mock<IResourceModel>().Object);

            //------------Execute Test---------------------------
            viewModel.ChooseAttachmentsCommand.Execute(null);

            //------------Assert Results-------------------------
            eventPublisher.Verify(p => p.Publish(It.IsAny<FileChooserMessage>()));
            var attachments = modelItem.GetProperty<string>("Attachments");
            Assert.AreEqual(string.Join(";", expectedFiles), attachments);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ChooseAttachments")]
        public void EmailDesignerViewModel_ChooseAttachments_SelectedFilesIsNotNull_SelectedNewFilesToAttachments()
        {
            var selectedFiles = new List<string> { @"c:\tmp2.txt", @"c:\logs\errors2.log" };
            //------------Setup for test--------------------------
            var existingFiles = new List<string> { @"c:\tmp1.txt", @"c:\logs\errors1.log" };

            var expectedFiles = new List<string>();
            expectedFiles.AddRange(existingFiles);
            if (selectedFiles != null)
            {
                expectedFiles.AddRange(selectedFiles);
            }

            var emailSources = CreateEmailSources(2);
            var modelItem = CreateModelItem();
            modelItem.SetProperty("Attachments", string.Join(";", existingFiles));

            var eventPublisher = new Mock<IEventAggregator>();
            eventPublisher.Setup(p => p.Publish(It.IsAny<FileChooserMessage>())).Callback((object m) =>
            {
                ((FileChooserMessage)m).SelectedFiles = selectedFiles;
            });

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, new Mock<IResourceModel>().Object);

            //------------Execute Test---------------------------
            viewModel.ChooseAttachmentsCommand.Execute(null);

            //------------Assert Results-------------------------
            eventPublisher.Verify(p => p.Publish(It.IsAny<FileChooserMessage>()));
            var attachments = modelItem.GetProperty<string>("Attachments");
            Assert.AreEqual(string.Join(";", selectedFiles), attachments);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ChooseAttachments")]
        public void EmailDesignerViewModel_ChooseAttachments_SelectedFilesIsNull_DoesAddNotFilesToAttachments()
        {
            //------------Setup for test--------------------------
            var existingFiles = new List<string> { @"c:\tmp1.txt", @"c:\logs\errors1.log" };

            var expectedFiles = new List<string>();
            var emailSources = CreateEmailSources(2);
            var modelItem = CreateModelItem();
            modelItem.SetProperty("Attachments", string.Join(";", existingFiles));

            var eventPublisher = new Mock<IEventAggregator>();
            eventPublisher.Setup(p => p.Publish(It.IsAny<FileChooserMessage>())).Callback((object m) =>
            {
                ((FileChooserMessage)m).SelectedFiles = null;
            });

            var viewModel = CreateViewModel(emailSources, modelItem, eventPublisher.Object, new Mock<IResourceModel>().Object);

            //------------Execute Test---------------------------
            viewModel.ChooseAttachmentsCommand.Execute(null);

            //------------Assert Results-------------------------
            eventPublisher.Verify(p => p.Publish(It.IsAny<FileChooserMessage>()));
            var attachments = modelItem.GetProperty<string>("Attachments");
            Assert.AreEqual(string.Join(";", expectedFiles), attachments);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("EmailDesignerViewModel_TestEmailCommand")]
        public void EmailDesignerViewModel_TestEmailCommand_WhenFromAddressIsVariable_ShouldBeError()
        {
            //------------Setup for test--------------------------
            const string ExpectedUri = AppLocalhost + "/wwwroot/sources/Service/EmailSources/Test";
            const string TestToAddress = "test@mydomain.com";
            const string TestFromAccount = "[[var1]]";
            const string TestFromPassword = "FromPassword";

            var emailSource = new EmailSource
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "EmailTest",
                UserName = "user@mydomain.com",
                Password = "SourcePassword",
            };

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", emailSource);
            modelItem.SetProperty("To", TestToAddress);


            var expectedSource = new EmailSource(emailSource.ToXml()) { TestToAddress = TestToAddress };
            modelItem.SetProperty("FromAccount", TestFromAccount);
            modelItem.SetProperty("Password", TestFromPassword);
            expectedSource.UserName = TestFromAccount;
            expectedSource.Password = TestFromPassword;
            expectedSource.TestFromAddress = TestFromAccount;


            var webRequestInvoker = new Mock<IWebRequestInvoker>();
            webRequestInvoker.Setup(w => w.ExecuteRequest("POST", ExpectedUri, It.IsAny<string>(), null, It.IsAny<Action<string>>()))
                .Returns(string.Empty)
                .Verifiable();

            var viewModel = CreateViewModel(new List<EmailSource> { emailSource }, modelItem);
            viewModel.WebRequestInvoker = webRequestInvoker.Object;

            Assert.IsTrue(viewModel.CanTestEmailAccount);

            //------------Execute Test---------------------------
            viewModel.TestEmailAccountCommand.Execute(null);
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual("Variable [[var1]] cannot be used while testing.", viewModel.Errors[0].Message);
            Assert.IsFalse(viewModel.IsFromAccountFocused);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsFromAccountFocused);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("EmailDesignerViewModel_TestEmailCommand")]
        public void EmailDesignerViewModel_TestEmailCommand_WhenToAddressIsBlank_ShouldBeError()
        {
            //------------Setup for test--------------------------
            const string ExpectedUri = AppLocalhost + "/wwwroot/sources/Service/EmailSources/Test";
            const string TestToAddress = "";
            const string TestFromAccount = "[[var1]]";
            const string TestFromPassword = "FromPassword";

            var emailSource = new EmailSource
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "EmailTest",
                UserName = "user@mydomain.com",
                Password = "SourcePassword",
            };

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", emailSource);
            modelItem.SetProperty("To", TestToAddress);


            var expectedSource = new EmailSource(emailSource.ToXml()) { TestToAddress = TestToAddress };
            modelItem.SetProperty("FromAccount", TestFromAccount);
            modelItem.SetProperty("Password", TestFromPassword);
            expectedSource.UserName = TestFromAccount;
            expectedSource.Password = TestFromPassword;
            expectedSource.TestFromAddress = TestFromAccount;


            var webRequestInvoker = new Mock<IWebRequestInvoker>();
            webRequestInvoker.Setup(w => w.ExecuteRequest("POST", ExpectedUri, It.IsAny<string>(), null, It.IsAny<Action<string>>()))
                .Returns(string.Empty)
                .Verifiable();

            var viewModel = CreateViewModel(new List<EmailSource> { emailSource }, modelItem);
            viewModel.WebRequestInvoker = webRequestInvoker.Object;

            Assert.IsTrue(viewModel.CanTestEmailAccount);

            //------------Execute Test---------------------------
            viewModel.TestEmailAccountCommand.Execute(null);
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual("Please supply a To address in order to Test.", viewModel.Errors[0].Message);
            Assert.IsFalse(viewModel.IsToFocused);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsToFocused);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("EmailDesignerViewModel_TestEmailCommand")]
        public void EmailDesignerViewModel_TestEmailCommand_WhenToAddressIsVariable_ShouldBeError()
        {
            //------------Setup for test--------------------------
            const string ExpectedUri = AppLocalhost + "/wwwroot/sources/Service/EmailSources/Test";
            const string TestToAddress = "[[var1]]";
            const string TestFromAccount = "test@mydomain.com";
            const string TestFromPassword = "FromPassword";

            var emailSource = new EmailSource
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "EmailTest",
                UserName = "user@mydomain.com",
                Password = "SourcePassword",
            };

            var modelItem = CreateModelItem();
            modelItem.SetProperty("SelectedEmailSource", emailSource);
            modelItem.SetProperty("To", TestToAddress);


            var expectedSource = new EmailSource(emailSource.ToXml()) { TestToAddress = TestToAddress };
            modelItem.SetProperty("FromAccount", TestFromAccount);
            modelItem.SetProperty("Password", TestFromPassword);
            expectedSource.UserName = TestFromAccount;
            expectedSource.Password = TestFromPassword;
            expectedSource.TestFromAddress = TestFromAccount;


            var webRequestInvoker = new Mock<IWebRequestInvoker>();
            webRequestInvoker.Setup(w => w.ExecuteRequest("POST", ExpectedUri, It.IsAny<string>(), null, It.IsAny<Action<string>>()))
                .Returns(string.Empty)
                .Verifiable();

            var viewModel = CreateViewModel(new List<EmailSource> { emailSource }, modelItem);
            viewModel.WebRequestInvoker = webRequestInvoker.Object;

            Assert.IsTrue(viewModel.CanTestEmailAccount);

            //------------Execute Test---------------------------
            viewModel.TestEmailAccountCommand.Execute(null);
            //------------Assert Results-------------------------
            Assert.IsNotNull(viewModel.Errors);
            Assert.AreEqual("Variable [[var1]] cannot be used while testing.", viewModel.Errors[0].Message);
            Assert.IsFalse(viewModel.IsFromAccountFocused);
            viewModel.Errors[0].Do();
            Assert.IsTrue(viewModel.IsFromAccountFocused);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_EmailSourceIsNull_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailSourceNotNullErrorTest, EmailDesignerViewModel.IsEmailSourceFocusedProperty, false);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_RecipientsIsEmpty_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "Please supply at least one of the following: 'To', 'Cc' or 'Bcc'", EmailDesignerViewModel.IsToFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_RecipientsToIsNotEmpty_DoesHaveNotErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_RecipientsCcIsNotEmpty_DoesHaveNotErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "user2@mydomain.com",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_RecipientsBccIsNotEmpty_DoesHaveNotErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "user2@mydomain.com",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_SubjectAndBodyIsEmpty_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "",
                Attachments = "",
                Body = "",
            };
            Verify_ValidateThis(activity, "Please supply at least one of the following: 'Subject' or 'Body'", EmailDesignerViewModel.IsSubjectFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_SubjectIsNotEmpyAndBodyIsEmpty_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_SubjectIsEmpyAndBodyIsNotEmpty_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "",
                Attachments = "",
                Body = "The Body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_FromAccountIsNotValidExpression_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "h]]",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailFromAccountInvalidExpressionErrorTest, EmailDesignerViewModel.IsFromAccountFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_FromAccountIsValidExpression_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "[[h]]",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_FromAccountIsNotValidEmailAddress_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1#mydomain.com",
                Password = "xxx",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "'From Account' contains an invalid email address", EmailDesignerViewModel.IsFromAccountFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_FromAccountIsValidAndPasswordBlank_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "",
                To = "user2@mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailPasswordNotNullErrorTest, EmailDesignerViewModel.IsPasswordFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_ToIsNotValidExpression_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "h]]",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailToInvalidExpressionErrorTest, EmailDesignerViewModel.IsToFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_ToIsValidExpression_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "[[h]]",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_ToIsNotValidEmailAddress_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "user2#mydomain.com",
                Cc = "",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "'To' contains an invalid email address", EmailDesignerViewModel.IsToFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_CcIsNotValidExpression_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "h]]",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailCcInvalidExpressionErrorTest, EmailDesignerViewModel.IsCcFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_CcIsValidExpression_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "[[h]]",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_CcIsNotValidEmailAddress_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "user2#mydomain.com",
                Bcc = "",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "'Cc' contains an invalid email address", EmailDesignerViewModel.IsCcFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_BccIsNotValidExpression_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "h]]",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailBccInvalidExpressionErrorTest, EmailDesignerViewModel.IsBccFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_BccIsValidExpression_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "[[h]]",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_BccIsNotValidEmailAddress_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "user2#mydomain.com",
                Subject = "The Subject",
                Attachments = "",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "'Bcc' contains an invalid email address", EmailDesignerViewModel.IsBccFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_AttachmentsIsNotValidExpression_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "user2@mydomain.com",
                Subject = "The Subject",
                Attachments = "h]]",
                Body = "The body",
            };
            Verify_ValidateThis(activity, Warewolf.Resource.Errors.ErrorResource.EmailAttachmentsInvalidExpressionErrorTest, EmailDesignerViewModel.IsAttachmentsFocusedProperty);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_AttachmentsIsValidExpression_DoesNotHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "user2@mydomain.com",
                Subject = "The Subject",
                Attachments = "[[h]]",
                Body = "The body",
            };
            Verify_ValidateThis(activity);
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_ValidateThis")]
        public void EmailDesignerViewModel_ValidateThis_AttachmentsIsNotValidFileName_DoesHaveErrors()
        {
            var activity = new DsfSendEmailActivity
            {
                FromAccount = "user1@mydomain.com",
                Password = "xxx",
                To = "",
                Cc = "",
                Bcc = "user2@mydomain.com",
                Subject = "The Subject",
                Attachments = "c:\\logs",
                Body = "The body",
            };
            Verify_ValidateThis(activity, "'Attachments' contains an invalid file name", EmailDesignerViewModel.IsAttachmentsFocusedProperty);
        }

        void Verify_ValidateThis(DsfSendEmailActivity activity, string expectedErrorMessage = null, DependencyProperty isFocusedProperty = null, bool setSelectedEmailSource = true)
        {
            var sources = CreateEmailSources(1);
            if (setSelectedEmailSource)
            {
                activity.SelectedEmailSource = sources[0];
            }

            var modelItem = ModelItemUtils.CreateModelItem(activity);

            var viewModel = CreateViewModel(sources, modelItem);

            //------------Execute Test---------------------------
            viewModel.Validate();

            //------------Assert Results-------------------------
            if (string.IsNullOrEmpty(expectedErrorMessage))
            {
                Assert.IsNull(viewModel.Errors);
            }
            else
            {
                Assert.IsNotNull(viewModel.Errors);
                Assert.AreEqual(1, viewModel.Errors.Count);
                StringAssert.Contains(viewModel.Errors[0].Message, expectedErrorMessage);

                viewModel.Errors[0].Do();
                var isFocused = isFocusedProperty != null && (bool)viewModel.GetValue(isFocusedProperty);
                Assert.IsTrue(isFocused);
            }
        }

        [TestMethod]
        [Owner("Trevor Williams-Ros")]
        [TestCategory("EmailDesignerViewModel_Handles")]
        public void EmailDesignerViewModel_Handles_UpdateResourceMessage_EmailSourceIsUpdated()
        {
            //------------Setup for test--------------------------
            var resourceID = Guid.NewGuid();
            var emailSource = new EmailSource
            {
                ResourceID = resourceID,
                ResourceName = "Email1",
                UserName = "user1@test.com",
                Password = "pasword1"
            };

            // var emailSources = CreateEmailSources(2);
            var modelItem = ModelItemUtils.CreateModelItem(new DsfSendEmailActivity
            {
                SelectedEmailSource = emailSource
            });

            var viewModel = CreateViewModel(new List<EmailSource> { emailSource }, modelItem);

            var updatedEmailSource = new EmailSource
            {
                ResourceID = resourceID,
                ResourceName = "EmailTest",
                UserName = "UpdateEmail@test.com",
                Password = "UpdatedPassword"
            };

            //var xaml = new StringBuilder
            var resourceModel = new Mock<IContextualResourceModel>();
            resourceModel.Setup(r => r.WorkflowXaml).Returns(new StringBuilder(updatedEmailSource.ToXml().ToString()));

            var message = new UpdateResourceMessage(resourceModel.Object);

            //------------Execute Test---------------------------
            viewModel.Handle(message);

            //------------Assert Results-------------------------
            var selectedSource = viewModel.SelectedEmailSourceModelItemValue;
            Assert.AreEqual(updatedEmailSource.UserName, selectedSource.UserName);
            Assert.AreEqual(updatedEmailSource.Password, selectedSource.Password);
        }

        [TestMethod]
        [Owner("Tshepo Ntlhokoa")]
        [TestCategory("EmailDesignerViewModel_Handles")]
        public void EmailDesignerViewModel_Handles_UpdateResourceMessageResourceIdAreNotTheSame_EmailSourceIsNotUpdated()
        {
            //------------Setup for test--------------------------
            var emailSource = new EmailSource
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "Email1",
                UserName = "user1@test.com",
                Password = "pasword1"
            };

            var emailSources = CreateEmailSources(2);
            var modelItem = ModelItemUtils.CreateModelItem(new DsfSendEmailActivity
            {
                SelectedEmailSource = emailSource
            });

            var viewModel = CreateViewModel(new List<EmailSource> { emailSource }, modelItem);

            var updatedEmailSource = new EmailSource(emailSources[0].ToXml())
            {
                ResourceID = Guid.NewGuid(),
                UserName = "UpdateEmail@test.com",
                Password = "UpdatedPassword"
            };

            //var xaml = new StringBuilder
            var resourceModel = new Mock<IContextualResourceModel>();
            resourceModel.Setup(r => r.WorkflowXaml).Returns(new StringBuilder(updatedEmailSource.ToXml().ToString()));

            var message = new UpdateResourceMessage(resourceModel.Object);

            //------------Execute Test---------------------------
            viewModel.Handle(message);

            //------------Assert Results-------------------------
            var selectedSource = viewModel.SelectedEmailSourceModelItemValue;
            Assert.AreNotEqual(updatedEmailSource.UserName, selectedSource.UserName);
            Assert.AreNotEqual(updatedEmailSource.Password, selectedSource.Password);
        }

        static ModelItem CreateModelItem()
        {
            return ModelItemUtils.CreateModelItem(new DsfSendEmailActivity());
        }

        static List<EmailSource> CreateEmailSources(int count)
        {
            var result = new List<EmailSource>();

            for (var i = 0; i < count; i++)
            {
                result.Add(new EmailSource
                {
                    ResourceID = Guid.NewGuid(),
                    ResourceName = "Email" + i,
                    UserName = "user" + i + "@test.com",
                    Password = "pasword" + i
                });
            }

            return result;
        }

        static TestEmailDesignerViewModel CreateViewModel(List<EmailSource> sources, ModelItem modelItem)
        {
            return CreateViewModel(sources, modelItem, new Mock<IEventAggregator>().Object, new Mock<IResourceModel>().Object);
        }

        static TestEmailDesignerViewModel CreateViewModel(List<EmailSource> sources, ModelItem modelItem, IEventAggregator eventPublisher, IResourceModel resourceModel)
        {
            if (CustomContainer.Get<IShellViewModel>() == null)
            {
                CustomContainer.Register(new Mock<IShellViewModel>().Object);
            }
            var environment = new Mock<IServer>();
            environment.Setup(e => e.ResourceRepository.FindSourcesByType<EmailSource>(It.IsAny<IServer>(), enSourceType.EmailSource))
                .Returns(sources);
            environment.Setup(e => e.ResourceRepository.FindSingle(It.IsAny<Expression<Func<IResourceModel, bool>>>(), false, false))
                .Returns(resourceModel);

            var testEmailDesignerViewModel = new TestEmailDesignerViewModel(modelItem, environment.Object, eventPublisher)
                {
                    GetDatalistString = () =>
                        {
                            const string trueString = "True";
                            const string noneString = "None";
                            var datalist = string.Format("<DataList><var Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /><a Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /><b Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /><h Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /><r Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /><rec Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" ><set Description=\"\" IsEditable=\"{0}\" ColumnIODirection=\"{1}\" /></rec></DataList>", trueString, noneString);
                            return datalist;
                        }
                };

            return testEmailDesignerViewModel;
        }
    }
}
