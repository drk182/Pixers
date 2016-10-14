using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Pixers.Core;

namespace Pixers.Pages
{
    public class MainPage : PixersPage
    {
        private static By _mainLogo = By.ClassName("logo");

        public MainPage(ChromeDriver driver) : base(driver)
        {
        }

        public static void OpenMainPage()
        {
            Instance.Navigate().GoToUrl(Configuration.GetBaseAddress);
        }

        public static bool IsAt()
        {
            var logo = FindElement(_mainLogo);

            return logo.Displayed;
        }
    }
}
