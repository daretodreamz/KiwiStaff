using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Login_out;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Deleting_a_parent
{
    public class ParentManagement : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        //private string ParentName = String.Empty;

        // 'Archive' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "ARCHIVE")]
        private IWebElement menuItemArchive { get; set; }

        // 'OK' button of Confirm Dialog 
        [FindsBy(How = How.Id, Using = "kiwi-confirm-yes")]
        private IWebElement buttonOK { get; set; }
                                           
        // locate the archived parent name on Archive Page             
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[2]/table/tbody/tr/td[3]/b")]
        private IWebElement archivedParentName { get; set; }
        
        // locate the restored parent name on Parent management page
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/div[2]/table/tbody/tr[1]/td[3]/div/p[1]/b")]
        private IWebElement restoredParentName { get; set; }

        // locate 'RESTORE' link button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[2]/table/tbody/tr[1]/td[7]/a[1]")]
        private IWebElement lnkRestore { get; set; }

        //
        public bool TitleValidationExpectNagetive(IWebDriver driver, string TestName, string sTitle)
        {
            log.Info("Parents Mangement Validation Test Case: ");

            if (driver.Title == sTitle)
            {
                log.Info("[PASS] " + TestName);
                log.Info("driver.Title: " + "'" + driver.Title + "'" + " sTitle: " + "'" + sTitle + "'");
                return true;
            }
            log.Info("[FAIL] " + TestName);
            log.Info("We expect that " + "'" + driver.Title + "'" + " should be equal to " + "'" + sTitle + "'");
            return false;
        }


        public void AchiveParent(IWebDriver driver, string ParentName)
        {
            sURL = Utilities.GlobalVariable.sURL + "Parent/Management";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.TitleValidation(driver, "AchiveParent",
                "Parent Management - aimy plus");


            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);


            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);

            AimySendKeys(driver, txtCategory, ParentName);
            txtCategory.SendKeys(Keys.Enter);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("span.caret.split-dropdown-caret")));

            IReadOnlyCollection<IWebElement> items =
                driver.FindElements(By.CssSelector("span.caret.split-dropdown-caret"));

            foreach (var item in items)
            {
                item.Click();
                break;
            }
            Thread.Sleep(2000);
            AimyClick(driver, menuItemArchive);
            Thread.Sleep(2000);
            AimyClick(driver, buttonOK);
        }

        public void LogoutAdminPort(IWebDriver driver)
        {
            Pages.LogOutPage.LogOutAimy(driver);
        }

        public bool LoginParentPortalDefault(IWebDriver driver, string ParentLoginEmail, bool LoginFlag = true)
        {
            bool ActualResutl = false;
            driver.Navigate().GoToUrl(GlobalVariable.sURL);
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Pages.LoginPage.LoginAimy(driver, ParentLoginEmail, GlobalVariable.sloginPassword);
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            if (LoginFlag.Equals(false))
            {
                ActualResutl = TitleValidationExpectNagetive(driver, "AchiveParent",
                    "Login - AIMY");
                return ActualResutl;
            }
            ActualResutl = driver.FindElement(By.XPath("html/body/div[3]/div/h2")).Text.Equals("Dashboard");
            return ActualResutl;
        }

        public void GoToAchivePage(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("html/body/div[3]/div[2]/a[3]")));
            driver.FindElement(By.XPath("html/body/div[3]/div[2]/a[3]")).Click();

            Common.TitleValidation(driver, "AchiveParent",
                "Parent Management - Archived List - aimy plus");

            Common.WaitBySleeping(GlobalVariable.iShortWait);


        }

        public bool FindArchivedParent(IWebDriver driver, string ParentName)
        {
            log.Info("Parent Manager - FindArchivedParentName : Validation Test Case: ");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);
            AimySendKeys(driver, txtCategory, ParentName);
            txtCategory.SendKeys(Keys.Enter);


            try
            {
                if (archivedParentName != null && archivedParentName.Displayed)
                {
                    bool flag = archivedParentName.Text.Equals(ParentName);
                }
            }
            catch (Exception e)
            {
                if (archivedParentName == null)
                {
                    log.Info("[FAIL]  '" + ParentName + "' does NOT exist. FAILED!");
                    return false;
                }
            }
            log.Info("[PASS] '" + ParentName + "' exist. PASSED!");
            return true;
        }

        public void RestoreArchivedParent(IWebDriver driver, string ParentName)
        {
            Thread.Sleep(2000);
            AimyClick(driver, lnkRestore);
            Thread.Sleep(2000);
            AimyClick(driver, buttonOK);
        }

        public bool IsParentBeenRestoredFromAchiveList(IWebDriver driver, string ParentName)
        {
            log.Info("Parent Archive Restore Validation Test");

            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = WebDriverExtensions.FindElements(driver,
                    By.LinkText("Restore"),
                    5);
            }
            catch (Exception e)
            {
                if (elements == null)
                {
                    log.Info("[PASS] We expect that there should NO '" + ParentName + "' been found.");
                    return true;
                }
            }
            log.Info("[FAIL] There is '" + ParentName + "' which should NOT be!");
            return false;
        }

        public bool IsParentBeenRestoredToParentManagePage(IWebDriver driver, string ParentName)
        {
            log.Info("Parent Archive Restore Validation Test");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            sURL = GlobalVariable.sURL + "Parent/Management";
            driver.Navigate().GoToUrl(sURL);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);

            AimySendKeys(driver, txtCategory, ParentName);
            txtCategory.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = WebDriverExtensions.FindElements(driver,
                    By.XPath("html/body/div[3]/div[3]/div[2]/table/tbody/tr[1]/td[3]/div/p[1]/b"),
                    10);
            }
            catch (Exception e)
            {
                if (elements == null)
                {
                    log.Info("[FAIL]: '" + ParentName + "' has NOT been found.");
                    return false;
                }
            }
            log.Info("[PASS]: '" + ParentName + "' has been RESTORED!");
            return true;
        }
    }
}
