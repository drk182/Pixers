using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pixers.Selenium;

namespace Pixers.Pages
{
    public abstract class PixersPage : Driver
    {
        private static By _searchBox = By.Name("q");

        private static By _searchClick = By.ClassName("fa fa-search");

        protected PixersPage(IWebDriver driver)
        {
            Instance = driver;
        }

        public static bool Click(By locator)
        {
            var result = false;
            var attempts = 0;

            while (attempts < 3)
            {
                try
                {
                    Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    var element = Instance.FindElement(locator);
                    element.Click();
                    result = true;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException type: [{0}], attempt: [{1}] in Click( [{2}] ) \n", e.GetType().Name, attempts + 1, locator);
                }
                attempts++;
            }
            return result;
        }

        public static void InsertText(By locator, string text)
        {
            var attempts = 0;

            while (attempts < 3)
            {
                try
                {
                    Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    var element = Instance.FindElement(locator);
                    element.Clear();
                    element.SendKeys(text);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException type: [{0}], attempt: [{1}] in InsertText( [{2}] ) \n", e.GetType().Name, attempts + 1, locator);
                }
                attempts++;
            }
        }

        public static void WaitAndClick(By locator, int timeOutInSeconds = 3)
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeOutInSeconds));

            var actions = new Actions(Instance);
            var myDynamicElement = Instance.FindElement(locator);

            actions.MoveToElement(myDynamicElement).Click().Perform();
        }

        public static IWebElement FindElement(By locator)
        {
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(1));
            var myElement = wait.Until(x => x.FindElement(locator));

            return myElement;
        }

        public static void SearchInPixers(string query)
        {
            InsertText(_searchBox, query);
            Click(_searchClick);
        }

        public void WaitUntilUrlContains(string value)
        {
            try
            {
                var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(5));
                wait.Until(ExpectedConditions.UrlContains(value));
            }
            catch (Exception)
            {
                Console.WriteLine("Url strony nie zawiera ciągu [{0}].", value);
            }
        }
    }
}
