using NUnit.Framework;
using Pixers.Pages;
using Pixers.Selenium;

namespace PixersTests.Utilities
{
    public class PixersTests
    {
        [SetUp]
        public static void Init()
        {
            Driver.Initialize();

            MainPage.OpenMainPage();
        }

        [TearDown]
        public static void CleanUp()
        {
            Driver.Close();
        }
    }
}
