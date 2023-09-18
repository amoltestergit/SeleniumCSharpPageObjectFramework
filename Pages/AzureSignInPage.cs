using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.Pages
{
    internal class AzureSignInPage
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

        internal AzureSignInPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        internal void EnterEmailPhoneSkype(string username)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            userNameField.SendKeys(username);
        }
        internal void ClickNxtBtn()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    IWebElement clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(nxtButton));
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
            Thread.Sleep(TimeSpan.FromSeconds(5));
            passwordField.SendKeys(password);
        }
        internal void ClickSignInBtn()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            int maxAttempts = 3;
            int attempts = 0;

            while (attempts < maxAttempts)
            {
                try
                {
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                    IWebElement clickableSignInButton = wait.Until(ExpectedConditions.ElementToBeClickable(signInButton));
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
            Thread.Sleep(TimeSpan.FromSeconds(5));
            staySignInYes.Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        internal void StaySignInNo()
        {
            staySignInNo.Click();
        }
    }
}
