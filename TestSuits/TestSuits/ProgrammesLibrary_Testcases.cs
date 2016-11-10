using AimyTest.Browsers;
using AimyTest.Term_programs;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AimyTest.TestSuits
{
    class ProgrammesLibrary_Testcases : TestBase
    {
        public static readonly log4net.ILog log = LogHelper.GetLogger();
        private IWebDriver driver = null;
        private const string TAB_TERM_PROGRAM = "/html/body/div[3]/div[1]/ul/li[1]/a/span";
        private const string TP_PATH_VIEW_DETAIL = "/html/body/div[3]/div[1]/div[1]/div/div[3]/table/tbody/tr[1]/td[6]/div/span";

        public void Init(string browserName)
        {
            if (browserName.Equals("Chrome"))
            {
                driver = ChromeBrowser.chromeDriver;
                driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
            else if (browserName.Equals("IE"))
            {
                driver = IEBrowser.IEDriver;
                driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
            else if (browserName.Equals("FireFox"))
            {
                driver = FireFoxBrowser.firefoxDriver;
                driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
        }

        [TestCase("Chrome")]
        [TestCase("IE")]
        [TestCase("FireFox")]
        public void TERM_PRO_LIB_06(string browserName)
        {
            Init(browserName);
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            //Navigate to programme library
            driver.Navigate().GoToUrl("http://uat.aimy.co.nz/Admin/Program");
            Common.TitleValidation(driver, "Validate Aimy Programmes Library Page Title", "Programmes - aimy plus");
            Common.WaitForElementClickable(driver, By.XPath(TAB_TERM_PROGRAM), 30);
            //Click term program tab
            CreateTermProgramPage tp = new CreateTermProgramPage(driver);
            tp.btnTermProgram.Click();
            Common.WaitForElementClickable(driver, By.XPath(TP_PATH_VIEW_DETAIL), 30);
            Thread.Sleep(1000);
            //Click edit link
            tp.lnkEdit.Click();
            Thread.Sleep(3000);
            //Scroll up to the top
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0)");
            //Enter description
            tp.txtDescription.SendKeys("Angular JS basic for junior kids who are dreaming to be a front end web developer!");
            //Scroll down the page so that save button can be clicked
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - ((document.body.scrollHeight)/2))");
            Thread.Sleep(5000);
            //Click save button
            tp.btnSave.Click();
        }

        [TestCase("Chrome")]
        [TestCase("IE")]
        [TestCase("FireFox")]
        public void TERM_PRO_LIB_11(string browserName)
        {
            Init(browserName);
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            //Navigate to programme library
            driver.Navigate().GoToUrl("http://uat.aimy.co.nz/Admin/Program");
            Common.TitleValidation(driver, "Validate Aimy Programmes Library Page Title", "Programmes - aimy plus");
            Common.WaitForElementClickable(driver, By.XPath(TAB_TERM_PROGRAM), 30);
            //Click term program tab
            CreateTermProgramPage tp = new CreateTermProgramPage(driver);
            tp.btnTermProgram.Click();
            Common.WaitForElementClickable(driver, By.XPath(TP_PATH_VIEW_DETAIL), 30);
            Thread.Sleep(1000);
            //Click delete link
            tp.lnkDelete.Click();
            Thread.Sleep(3000);
            //Scroll up to the top
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0)");
            //Enter description
            tp.txtDescription.SendKeys("Angular JS basic for junior kids who are dreaming to be a front end web developer!");
            //Scroll down the page so that save button can be clicked
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - ((document.body.scrollHeight)/2))");
            Thread.Sleep(5000);
            //Click save button
            tp.btnSave.Click();
        }
    }
}
