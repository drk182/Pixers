using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Pixers.Pages;

namespace Pixers.Navigation
{
    public class MenuSelector : PixersPage
    {
        public MenuSelector(IWebDriver driver) : base(driver)
        {
        }

        public static void Select(By locator)
        {
            Click(locator);
        }
    }
}
