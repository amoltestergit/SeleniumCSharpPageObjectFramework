using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.Pages
{
    internal class AzureAllResourcesPage
    {

        private readonly IWebDriver _driver;

        internal static string resourceName = "ResourceName";
        private string resource = ConfigurationManager.AppSettings[resourceName];

        [FindsBy(How = How.XPath, Using = "//a[@id='_weave_e_3']")]
        private readonly IWebElement drawer;

        [FindsBy(How = How.XPath, Using = "//div[@class='fxs-sidebar-label'][normalize-space()='All resources']")]
        private readonly IWebElement allResources;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'form-label-id-') and @aria-label='text search filter']")]
        private readonly IWebElement searchResource;

        internal AzureAllResourcesPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        internal void ScrollToElement(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        internal void ClickDrawer()
        {
            Thread.Sleep(5000);
            drawer.Click();
            Thread.Sleep(5000);
        }

        internal void GoToAllResources()
        {
            Thread.Sleep(5000);
            allResources.Click();
            Thread.Sleep(5000);
        }

        internal void SearchResources()
        {
            Thread.Sleep(5000);
            searchResource.SendKeys(resource);
            Thread.Sleep(5000);
        }

        internal void ClickSearchedResource()
        {
            Thread.Sleep(5000);
            IWebElement searchedContainer = _driver.FindElement(By.XPath("/html/body/div[1]/div[4]/main/div[3]/div[2]/section/div[1]/div[1]/div[4]/div[2]/div/div/div[2]/div/div[2]/div[2]/div[1]/div[3]/div/div/div[2]/div/div[2]/div[1]/div/div[1]/div[2]/div/a"));
            searchedContainer.Click();
            Thread.Sleep(5000);
        }

        internal void ScrollToMessageCount()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement scroll = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[4]/main/div[3]/div[2]/section[2]/div[1]/div[2]/div[2]/div[4]/div[2]/div/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div[1]/div/div[1]/div[3]/div")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scroll);
        }

        internal int GetMessageCount()
        {
            IWebElement count = _driver.FindElement(By.XPath("/html/body/div[1]/div[4]/main/div[3]/div[2]/section[2]/div[1]/div[2]/div[2]/div[4]/div[2]/div/div/div[2]/div/div[2]/div[2]/div[2]/div[3]/div[2]/div[2]/div[2]/div/div[2]/div/div/div[2]/div/div[2]/div[1]/div/div[1]/div[3]/div"));
            string countText = count.Text;
            int countValue = int.Parse(countText);
            return countValue;
        }
    }
}
