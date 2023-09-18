using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_usecase.Core
{
    abstract internal class BarcodeTotpWizard
    {
        protected abstract string ReadQRCode();
        protected abstract string ExtractSecretKeyFromUrl(string otpUrl);
        protected abstract string GenerateTotp(string secretKey);
    }
}
