using System.Configuration;

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
