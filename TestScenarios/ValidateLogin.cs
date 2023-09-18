using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using Login_usecase.Core;
using Login_usecase.Pages;
using Login_usecase.TestData;
using System;
using System.IO;

namespace Login_usecase.TestScenarios
{
    [TestFixture]
    internal class ValidateLogin : BaseClass
    {
        [Test]
        [Description("Test Case 1: Logging in via Gmail Account | TOTP based login)")]
        public void ValidateSignInWithGoogle()
        {
            NavigateTo.HomePage.ClickSignInButton();
            NavigateTo.SignInPage.ClickContinueWithGoogle();
            NavigateTo.SignInGooglePage.EnterEmailOrPhone(GoogleUserCreds.GoogleEmail);
            NavigateTo.SignInGooglePage.ClickNextBtn();
            NavigateTo.SignInGooglePage.EnterPassword(GoogleUserCreds.GooglePassword);
            NavigateTo.SignInGooglePage.ClickNextBtn();
            NavigateTo.SignInGooglePage.EnterTotp(Totp());
            NavigateTo.SignInGooglePage.ClickNextBtn();
            bool chatGPTTab = NavigateTo.OpenAIDashboard.TabChatGPT();
            bool dalleTab = NavigateTo.OpenAIDashboard.TabDallE();
            bool apiTab = NavigateTo.OpenAIDashboard.TabApi();
            bool tellUsAboutYouTab = NavigateTo.OpenAIDashboard.TellUsAboutYou();
            Assert.IsTrue((chatGPTTab && dalleTab && apiTab) || tellUsAboutYouTab, "Sign in with Google failed.");
        }

        [Test]
        [Description("Test Case 2: Logging in via Microsoft Account")]
        public void ValidateSignInWithMicrosoft()
        {
            NavigateTo.HomePage.ClickSignInButton();
            NavigateTo.SignInPage.ClickContinueWithMicrosoftAccount();
            NavigateTo.SignInMicrosoftPage.EnterEmailPhoneSkype(MicrosoftUserCreds.MicrosoftEmail);
            NavigateTo.SignInMicrosoftPage.ClickNxtBtn();
            NavigateTo.SignInMicrosoftPage.EnterPassword(MicrosoftUserCreds.MicrosoftPassword);
            NavigateTo.SignInMicrosoftPage.ClickSignInBtn();
            NavigateTo.SignInMicrosoftPage.StaySignInYes();
            bool chatGPTTab = NavigateTo.OpenAIDashboard.TabChatGPT();
            bool dalleTab = NavigateTo.OpenAIDashboard.TabDallE();
            bool apiTab = NavigateTo.OpenAIDashboard.TabApi();
            bool tellUsAboutYouTab = NavigateTo.OpenAIDashboard.TellUsAboutYou();
            Assert.IsTrue((chatGPTTab && dalleTab && apiTab) || tellUsAboutYouTab, "Sign in with Microsoft failed.");
        }
    }
}
