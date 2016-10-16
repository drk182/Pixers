using OpenQA.Selenium;
using Pixers.Core;
using Pixers.Navigation;

namespace Pixers.Pages
{
    public class MainPage : PixersPage
    {
        private static By _mainLogo = By.ClassName("logo");

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public static void GoTo(MainPageLinkType mainType)
        {
            switch (mainType)
            {
                case MainPageLinkType.Fototapety:
                    LinkMenu.MainMenu.Fototapety.Select();
                    break;
                case MainPageLinkType.Naklejki:
                    LinkMenu.MainMenu.Naklejki.Select();
                    break;
                case MainPageLinkType.ObrazyIPlakaty:
                    LinkMenu.MainMenu.ObrazyIPlakaty.Select();
                    break;
                case MainPageLinkType.ZTwojegoZdjecia:
                    LinkMenu.MainMenu.ZTwojegoZdjecia.Select();
                    break;
                case MainPageLinkType.FototapetyBestseller:
                    LinkMenu.MainMenu.Fototapety.Hover();
                    LinkMenu.MainMenu.Fototapety.Bestseller.Select();
                    break;
                case MainPageLinkType.ObrazyIPlakatyTematy:
                    LinkMenu.MainMenu.ObrazyIPlakaty.Hover();
                    LinkMenu.MainMenu.ObrazyIPlakaty.Tematy.Select();
                    break;
            }
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
