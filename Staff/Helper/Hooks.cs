using AimyTest.Browsers;
using AimyTest.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AimyTest.Helper
{
    [Binding]
    public sealed class Hooks
    {
        private static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private IWebDriver driver = null;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        [BeforeScenario]
        public void BeforeScenario()
        {
            log.Info("---------------------------------------------------------------------");
            log.Info("Test Execution is started |  Start Time : " + DateTime.Now.ToString());
            log.Info("---------------------------------------------------------------------");
            driver = ChromeBrowser.chromeDriver;
            Pages.OnWhichBrowser(driver);
            driver.Navigate().GoToUrl(GlobalVariable.sURL);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            log.Info("---------------------------------------------------------------------");
            log.Info("Test Execution is ended |  End Time : " + DateTime.Now.ToString());
            log.Info("---------------------------------------------------------------------");

            ChromeBrowser.Close();
            ChromeBrowser.Quite();
        }
    }
}
