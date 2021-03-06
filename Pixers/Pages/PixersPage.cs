﻿using System;
using OpenQA.Selenium;
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
                    ////TODO: zastanowić się czy nie dać jednak wait for element is clickable do każdego clicka?
                    Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                    var element = Instance.FindElement(locator);
                    element.Click();
                    result = true;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception type: [{0}], attempt: [{1}] in Click( [{2}] ) ", e.GetType().Name, attempts + 1, locator);
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
                    Console.WriteLine("Exception type: [{0}], attempt: [{1}] in InsertText( [{2}] ) ", e.GetType().Name, attempts + 1, locator);
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
                    Console.WriteLine("Exception type: [{0}], attempt: [{1}] in GetValue( [{2}] ) ", e.GetType().Name, attempts + 1, locator);
                }
                attempts++;
            }
            return string.Empty;
        }

        public static void WaitForElementClickable(By locator, int timeOutInSeconds = 3)
        {
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeOutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
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
            var wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
