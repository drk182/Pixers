using System.Configuration;

namespace Pixers.Core
{
    public class Configuration
    {
        private const string LoginKey = "Login";
        private const string PasswordKey = "Password";
        private const string BaseAddressKey = "BaseAddress";
        private const string Fototapeta = "Fototapeta";

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

        public static string GetFototapeta
        {
            get { return ConfigurationManager.AppSettings[Fototapeta]; }
        }
    }
}
