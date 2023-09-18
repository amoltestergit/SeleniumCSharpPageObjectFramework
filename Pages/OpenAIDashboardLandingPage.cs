using Login_usecase.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Login_usecase.Pages
{
    internal class OpenAIDashboardLandingPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//h1[text()='DALL·E']")]
        private readonly IWebElement _dallETab;

        [FindsBy(How = How.XPath, Using = "//h1[text()='API']")]
        private readonly IWebElement _apiTab;

        [FindsBy(How = How.XPath, Using = "//h1[text()='Tell us about you']")]
        private readonly IWebElement _tellUsAboutYouSection;

        private readonly By chatGPTTabLocator = By.XPath("//h1[text()='ChatGPT']");

        internal OpenAIDashboardLandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        internal string PageTitle()
        {
            string pagetitle =  _driver.Title;
            return pagetitle;
        }
        
        internal bool TabDallE()
        {
            bool tabdale = false;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                tabdale = _dallETab.Displayed;
                return tabdale;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
            return tabdale;
        }
        internal bool TabApi()
        {
            bool apitab = false;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                apitab = _apiTab.Displayed;
                return apitab;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
            return apitab;
        }

        internal bool TellUsAboutYou()
        {
            bool tellusaboutyou = false;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                tellusaboutyou = _tellUsAboutYouSection.Displayed;
                return tellusaboutyou;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
            return tellusaboutyou;
        }

        internal bool TabChatGPT()
        {
            bool chatGptTabVisible = false;

            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(chatGPTTabLocator));
                IWebElement chatGPTTab = _driver.FindElement(chatGPTTabLocator);
                chatGptTabVisible = chatGPTTab.Displayed;
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine("Timeout waiting for the element to be visible.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
            return chatGptTabVisible;
        }

    }
}
