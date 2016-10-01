using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace AimyTest.Browsers
{
    public static class IEBrowser
    {
        private static string baseUrl = Utilities.GlobalVariable.sURL;
        private static IWebDriver webDriver = null;
        public static void Initialize()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.RequireWindowFocus = true;
            webDriver = new InternetExplorerDriver(options);

            Goto("");
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Url = baseUrl + url;
        }

        public static void Close()
        {
            webDriver.Close();
        }

        public static void Quite()
        {
            webDriver.Quit();
        }
    }
}

