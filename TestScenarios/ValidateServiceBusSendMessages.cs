using Azure_servicebus_usecase.Core;
using Azure_servicebus_usecase.Pages;
using Azure_servicebus_usecase.TestData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.TestScenarios
{
    [TestFixture]
    internal class ValidateServiceBusSendMessages : BaseClass
    {
        [Test]
        [Description("Test Case 3: Processing Queue Messages and UI Verification")]
        public void ValidateSignInWithMicrosoft()
        {
            NavigateTo.SignInAzurePage.EnterEmailPhoneSkype(AzureCreds.MicrosoftEmail);
            NavigateTo.SignInAzurePage.ClickNxtBtn();
            NavigateTo.SignInAzurePage.EnterPassword(AzureCreds.MicrosoftPassword);
            NavigateTo.SignInAzurePage.ClickSignInBtn();
            NavigateTo.SignInAzurePage.StaySignInYes();
            NavigateTo.AllResourceAzurePage.ClickDrawer();
            NavigateTo.AllResourceAzurePage.GoToAllResources();
            NavigateTo.AllResourceAzurePage.SearchResources();
            NavigateTo.AllResourceAzurePage.ClickSearchedResource();
            NavigateTo.AllResourceAzurePage.ScrollToMessageCount();
            int QueueCount = NavigateTo.AllResourceAzurePage.GetMessageCount();
            Assert.IsTrue(QueueCount > 0);
        }
    }
}
