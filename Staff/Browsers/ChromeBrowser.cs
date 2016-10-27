using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace AimyTest.Browsers
{
    public static class ChromeBrowser
    {
        private static string baseUrl = Utilities.GlobalVariable.sURL;
        
        private static IWebDriver webDriver = new ChromeDriver();

        private static void Initialize()
        {
            Goto("");
        }

        public static IWebDriver chromeDriver
        {
            get
            {
                Initialize();
                return webDriver;
            }
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

