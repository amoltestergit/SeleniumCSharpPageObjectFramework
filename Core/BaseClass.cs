using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OtpNet;
using System;
using System.Configuration;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Login_usecase.Core
{
    internal class BaseClass : BarcodeTotpWizard
    {
        protected static IWebDriver driver;
        private string _key;
        private string _securityKey;
        private string  _totp;
        private int _index;

        private readonly string _BarCodeImagePathConfigManagerKey = "BarcodeImagePath";
        internal string _baseUrlConfigManagerKey = "BaseUrl";

        internal string _allowAccessAutomatedBrowser = "--disable-blink-features=AutomationControlled";       
       
        [SetUp]
        protected void Setup()
        {
            string baseUrl = ConfigurationManager.AppSettings[_baseUrlConfigManagerKey];
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument(_allowAccessAutomatedBrowser);
            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        protected void SwitchToNewWindow()
        {
            _index = 1;
            var windowHandles = driver.WindowHandles;
            string nextTabHandle = windowHandles[_index];
            driver.SwitchTo().Window(nextTabHandle);
        }
        protected override string ReadQRCode()
        {
            string secretKey = null;
            string imagePath = ConfigurationManager.AppSettings[_BarCodeImagePathConfigManagerKey];
            Bitmap qrcodebitmap = (Bitmap)Bitmap.FromFile(imagePath);
            ZXing.BarcodeReader qrcodeReader = new ZXing.BarcodeReader();
            ZXing.Result qrcodeResult = qrcodeReader.Decode(qrcodebitmap);
            if (qrcodeResult != null)
            {
                secretKey = qrcodeResult.Text;
            }
            else
            {
                Console.WriteLine("Failed to decode QR Code.");
            }

            return secretKey;
        }

        protected override string ExtractSecretKeyFromUrl(string otpUrl)
        {
            string pattern = @"[?&]secret=([^&]+)";
            Match match = Regex.Match(otpUrl, pattern);
            if (match.Success && match.Groups.Count >= 2)
            {
                string secretKey = match.Groups[1].Value;
                secretKey = Uri.UnescapeDataString(secretKey);
                return secretKey;
            }
            else
            {
                return null;
            }
        }

        protected override string GenerateTotp(string secretKey)
        {
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new ArgumentException("Invalid secret key.");
            }
            // Decode the base32 encoded secret key
            byte[] keyBytes = Base32Encoding.ToBytes(secretKey);
            // Create a TOTP generator with a 30-second time step
            OtpNet.Totp totp = new OtpNet.Totp(keyBytes, step: 30);
            string totpCode = totp.ComputeTotp();
            return totpCode;
        }    

        protected string Totp()
        {
            _key = ReadQRCode();
            _securityKey = ExtractSecretKeyFromUrl(_key);
            _totp = GenerateTotp(_securityKey);
            return _totp;
        }
    }
}
