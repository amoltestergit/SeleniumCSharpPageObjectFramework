using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_usecase.TestData
{
    internal class MicrosoftUserCreds
    {
        private static readonly string _emailConfigManagerKeyMicrosoft = "MicrosoftEmail";
        private static readonly string _passwordConfigManagerKeyMicrosoft = "MicrosoftPassword";

        internal static string MicrosoftEmail
        {
            get
            {
                return ConfigurationManager.AppSettings[_emailConfigManagerKeyMicrosoft];
            }
        }

        internal static string MicrosoftPassword
        {
            get
            {
                return ConfigurationManager.AppSettings[_passwordConfigManagerKeyMicrosoft];
            }
        }
    }
}
