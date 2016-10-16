using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
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

        public static void Hover(By locator)
        {
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));

            var action = new Actions(Instance);
            action.MoveToElement(element).Perform();
        }
    }
}
