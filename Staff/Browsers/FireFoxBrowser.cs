using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace AimyTest.Browsers
{
    public static class FireFoxBrowser
    {
        private static string baseUrl = Utilities.GlobalVariable.sURL;
        private static IWebDriver webDriver = null;
        public static void Initialize()
        {
            FirefoxBinary ffbinary = new FirefoxBinary(@"C:\Program Files\Mozilla Firefox\firefox.exe");
            FirefoxProfile ffprofile = new FirefoxProfile();
            webDriver = new FirefoxDriver(ffbinary, ffprofile);

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
