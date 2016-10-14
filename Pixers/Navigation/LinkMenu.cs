using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Pixers.Pages;

namespace Pixers.Navigation
{
    public class LinkMenu
    {
        private static By _fototapetyLink = By.CssSelector("a[href='/fototapety']");

        private static By _fototapetyBestseller = By.CssSelector("a[href='http://pixers.pl/fototapety/bestsellery']");

        private static By _obrazyiplakatyLink = By.CssSelector("a[href*='/obrazy-i-plakaty']");

        private static By _naklejkiLink = By.CssSelector("a[href*='/naklejki']");

        private static By _ztwojegozdjeciaLink = By.CssSelector("a[href*='/z-twojego-zdjecia']");

        public class MainMenu
        {
            public class Fototapety
            {
                public static void Select()
                {
                    MenuSelector.Select(_fototapetyLink);
                }

                public static void Hover()
                {
                    MenuSelector.Hover((_fototapetyLink));
                }

                public class Bestseller
                {
                    public static void Select()
                    {
                        MenuSelector.Select(_fototapetyBestseller);
                    }
                }
            }

            public class ObrazyIPlakaty
            {
                public static void Select()
                {
                    MenuSelector.Select(_obrazyiplakatyLink);
                }
            }

            public class Naklejki
            {
                public static void Select()
                {
                    MenuSelector.Select(_naklejkiLink);
                }
            }

            public class ZTwojegoZdjecia
            {
                public static void Select()
                {
                    MenuSelector.Select(_ztwojegozdjeciaLink);
                }
            }
        }
    }
}
