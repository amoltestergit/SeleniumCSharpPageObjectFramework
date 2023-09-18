using Login_usecase.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login_usecase.Pages 
{
    internal class OpenAIHomePage : BaseClass
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//nav[@aria-label='Navigation quick links']/descendant::span[text()='Log in']")]
        private readonly IWebElement _signIn;

        internal OpenAIHomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        internal void ClickSignInButton()
        {
            int maxAttempts = 3;
            int attempts = 0;
            while (attempts < maxAttempts)
            {
                try
                {
                    _signIn.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine("Stale Element Reference Exception occurred. Retrying...");
                    attempts++;
                }
            }

            SwitchToNewWindow();
        }
    }
}
