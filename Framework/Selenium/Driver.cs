using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Framework.Selenium
{
    public class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            _driver = new ChromeDriver(Path.GetFullPath(@"../../../../" + "_drivers"));
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }
            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}