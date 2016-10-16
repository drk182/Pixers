using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Pixers.Selenium
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }
        
        private const string Path = @"D:\drivers";

        public static void Initialize()
        {
            Instance = new ChromeDriver(Path);
            Instance.Manage().Window.Maximize();
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}
