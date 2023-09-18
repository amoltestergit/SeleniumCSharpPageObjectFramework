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
    internal class SignInWithMicrosoftPage
    {

        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "i0116")]
        private readonly IWebElement userNameField;

        [FindsBy(How = How.Id, Using = "idSIButton9")]
        private readonly IWebElement nxtButton;

        [FindsBy(How = How.Id, Using = "i0118")]
        private readonly IWebElement passwordField;

        [FindsBy(How = How.Id, Using = "idSIButton9")]
        private readonly IWebElement signInButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private readonly IWebElement staySignInYes;

        [FindsBy(How = How.XPath, Using = "//input[@type='button']")]
        private readonly IWebElement staySignInNo;

        internal SignInWithMicrosoftPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        internal void EnterEmailPhoneSkype(string username)
        {
            userNameField.SendKeys(username);
        }
        internal void ClickNxtBtn()
        {
            int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    IWebElement clickableElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(nxtButton));
                    clickableElement.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine("Stale Element Reference Exception occurred. Retrying...");
                    attempts++;
                }
            }
        }

        internal void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }
        internal void ClickSignInBtn()
        {
            int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                try
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                    IWebElement clickableSignInButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(signInButton));
                    Console.WriteLine("Clicking the 'Sign In' button...");
                    clickableSignInButton.Click();
                    break;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine("Stale Element Reference Exception occurred. Retrying...");
                    attempts++;
                }
            }
        }

        internal void StaySignInYes()
        {
            staySignInYes.Click();         
        }

        internal void StaySignInNo()
        {
            staySignInNo.Click();
        }
    }
}
