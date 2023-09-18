using Azure_servicebus_usecase.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_servicebus_usecase.Pages
{
    internal class NavigateTo : BaseClass
    {
        internal static AzureSignInPage SignInAzurePage
        {
            get
            {
                return new AzureSignInPage(driver);
            }
        }

        internal static AzureAllResourcesPage AllResourceAzurePage
        {
            get
            {
                return new AzureAllResourcesPage(driver);
            }
        }
    }
}
