using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_usecase.TestData
{
    internal class GoogleUserCreds
    {
        private static readonly string _EmailConfigManagerKeyGoogle = "GoogleEmail";
        private static readonly string _PasswordConfigManagerKeyGoogle = "GooglePassword";

        internal static string GoogleEmail
        {
            get
            {
                return ConfigurationManager.AppSettings[_EmailConfigManagerKeyGoogle];
            }
        }

        internal static string GooglePassword
        {
            get
            {
                return ConfigurationManager.AppSettings[_PasswordConfigManagerKeyGoogle];
            }
        }
    }
}
