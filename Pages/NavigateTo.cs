using Login_usecase.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_usecase.Pages
{
    internal class NavigateTo : BaseClass
    {
        internal static OpenAIDashboardLandingPage OpenAIDashboard
        {
            get
            {
                return new OpenAIDashboardLandingPage(driver);
            }
        }

        internal static OpenAIHomePage HomePage
        {
            get
            {
                return new OpenAIHomePage(driver);
            }
        }

        internal static OpenAISignInPage SignInPage
        {
            get
            {
                return new OpenAISignInPage(driver);
            }
        }

        internal static SignInWithGooglePage SignInGooglePage
        {
            get
            {
                return new SignInWithGooglePage(driver);
            }
        }

        internal static SignInWithMicrosoftPage SignInMicrosoftPage
        {
            get
            {
                return new SignInWithMicrosoftPage(driver);
            }
        }
    }
}
