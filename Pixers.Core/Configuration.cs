using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pixers.Core
{
    public class Configuration
    {
        private const string LoginKey = "Login";
        private const string PasswordKey = "Password";
        private const string BaseAddressKey = "BaseAddress";

        public static string GetUserLogin
        {
            get { return ConfigurationManager.AppSettings[LoginKey]; }
        }

        public static string GetUserPassword
        {
            get { return ConfigurationManager.AppSettings[PasswordKey]; }
        }

        public static string GetBaseAddress
        {
            get { return ConfigurationManager.AppSettings[BaseAddressKey]; }
        }

    }
}
