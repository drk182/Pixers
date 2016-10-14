using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Pixers.Core;
using Pixers.Selenium;

namespace Pixers.Pages
{
    public abstract class PixersPage : Driver
    {
        private static By _searchBox = By.Name("q");
        
        private static By _popUp = By.Id("newsletter_popup");

        private static By _popUpCloseButton = By.ClassName("close-reveal-modal");

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

        public static string GetValue(By locator)
        {
            var attempts = 0;

            while (attempts < 3)
            {
                try
                {
                    var value = Instance.FindElement(locator).Text;
                    return value;
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException type: [{0}], attempt: [{1}] in GetValue( [{2}] ) \n", e.GetType().Name, attempts + 1, locator);
                }
                attempts++;
            }
            return String.Empty;
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
            var searchBox = FindElement(_searchBox);
            searchBox.SendKeys(Configuration.GetFototapeta);
            searchBox.SendKeys(Keys.Enter);
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
                Console.WriteLine("Url does not contain string [{0}].", value);
            }
        }

        public void ClosePopUpIfVisible()
        {
            try
            {
                var popup = FindElement(_popUp);
                Click(_popUpCloseButton);
                WaitUntilElementIsVisible(_popUp);
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public void WaitUntilElementIsVisible(By locator, int timeout = 5)
        {
            new WebDriverWait(Instance, TimeSpan.FromSeconds(timeout)).Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
