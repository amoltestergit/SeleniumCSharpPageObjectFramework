using Login_usecase.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Login_usecase.Pages
{
    internal class SignInWithGooglePage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        private readonly IWebElement emailOrPhoneTextField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Next')]")]
        private readonly IWebElement nextButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private readonly IWebElement passwordTextField;

        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
        private readonly IWebElement totpTextField;

        internal SignInWithGooglePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        internal void EnterEmailOrPhone(string emailOrPhone)
        {
            emailOrPhoneTextField.SendKeys(emailOrPhone);
        }

        public void ClickNextBtn()
        {
            int maxRetries = 3;
            int retryCount = 0;

            while (retryCount < maxRetries)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementToBeClickable(nextButton));
                    nextButton.Click();
                    return;
                }
                catch (StaleElementReferenceException)
                {
                    Console.WriteLine("StaleElementReferenceException occurred. Retrying...");
                    Thread.Sleep(1000);
                    retryCount++;
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Timeout waiting for the element to become clickable.");
                    retryCount++;
                }
            }

            throw new StaleElementReferenceException("Failed to click the 'Next' button after multiple retries.");
        }

        internal void EnterPassword(string password)
        {
            int maxRetries = 3;
            int retryCount = 0;
            bool isElementInteractable = false;

            while (!isElementInteractable && retryCount < maxRetries)
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(passwordTextField));
                    passwordTextField.Clear();
                    passwordTextField.SendKeys(password);
                    isElementInteractable = true;
                }
                catch (StaleElementReferenceException)
                {
                    retryCount++;
                }
                catch (ElementNotInteractableException)
                {
                    retryCount++;
                }
            }

            if (!isElementInteractable)
            {
                throw new ElementNotInteractableException("Failed to interact with the password field after multiple retries.");
            }
        }

        internal void EnterTotp(string totp)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(totpTextField));
            element.SendKeys(totp);
        }

    }
}
