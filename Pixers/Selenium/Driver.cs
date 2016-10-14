using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Pixers.Selenium
{
    public class Driver
    {
        public static FirefoxDriver Instance { get; set; }

        public static void Initialize()
        {
            Instance = new FirefoxDriver();
        }

        public static void Close()
        {
            Instance.Quit();
        }
    }
}
