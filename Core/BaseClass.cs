using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.Core
{
    internal class BaseClass
    {
        protected static IWebDriver driver;

        internal string _baseUrlConfigManagerKey = "BaseUrl";
        private static string connStringConfigManagerKey = "ConString";
        private static string queueNameConfigManagerKey = "QName";
        internal string messageBody = "Hello, Azure Service Bus!";

        AzureServiceBusQueueSender sender;
        private string conString = ConfigurationManager.AppSettings[connStringConfigManagerKey];
        private string queue = ConfigurationManager.AppSettings[queueNameConfigManagerKey];

        [OneTimeSetUp]
        public void SendMessageServiceBusQueue()
        {
            sender = new AzureServiceBusQueueSender(conString, queue);
            sender.SendMessage(messageBody);
        }

        [SetUp]
        protected void Setup()
        {
            driver = new ChromeDriver();
            string baseUrl = ConfigurationManager.AppSettings[_baseUrlConfigManagerKey];
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        protected void Teardown()
        {
            driver.Quit();
        }

        public void ScrollToElement(By loc)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            IWebElement scroll = driver.FindElement(loc);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", scroll);
        }
    }
}
