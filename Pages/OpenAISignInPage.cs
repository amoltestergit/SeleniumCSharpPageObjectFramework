using Login_usecase.Core;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login_usecase.Pages
{
    internal class OpenAISignInPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//button/span[contains(text(),'Continue with Google')][1]")]
        private readonly IWebElement _continueWithGoogleBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Continue with Microsoft Account')]")]
        private readonly IWebElement _continueWithMicrosoftBtn;
        internal OpenAISignInPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        internal void ClickContinueWithGoogle()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _continueWithGoogleBtn.Click();
        }

        internal void ClickContinueWithMicrosoftAccount()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            _continueWithMicrosoftBtn.Click();
        }
    }
}
