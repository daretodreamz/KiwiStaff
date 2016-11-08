using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Parent_Management
{
    public class ParentManagement : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        //private string ParentName = String.Empty;

        // 'Archive' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "ARCHIVE")]
        private IWebElement menuItemArchive { get; set; }

        // 'Unlock' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "UNLOCK")]
        private IWebElement menuItemUnlock { get; set; }

        // 'EDIT LOGIN' item of DropDown List 
        [FindsBy(How = How.LinkText, Using = "EDIT LOGIN")]
        private IWebElement menuItemEditLogin { get; set; }

        // 'OK' button of Confirm Dialog 
        [FindsBy(How = How.Id, Using = "kiwi-confirm-yes")]
        private IWebElement buttonOK { get; set; }

        // locate the archived parent name on Archive Page             
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[2]/table/tbody/tr/td[3]/b")]
        private IWebElement filteredParentName { get; set; }

        // locate the restored parent name on Parent management page
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/div[2]/table/tbody/tr[1]/td[3]/div/p[1]/b")]
        private IWebElement restoredParentName { get; set; }

        // locate 'RESTORE' link button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div[2]/table/tbody/tr[1]/td[7]/a[1]")]
        private IWebElement lnkRestore { get; set; }

        // 'BOOKING' dropdown list
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/div[2]/table/tbody/tr/td[8]/div/a")]
        private IWebElement btnBooking { get; set; }

        // 'MAKE BOOKING' dropdown list
        [FindsBy(How = How.LinkText, Using = "MAKE BOOKING")]
        private IWebElement ddlMakeBooking { get; set; }

        //
        public bool TitleValidationExpectNagetive(IWebDriver driver, string TestName, string sTitle)
        {
            log.Info("Parents Mangement Validation Test Case: ");

            if (driver.Title == sTitle || driver.Title == "Terms And Conditions - aimy plus")
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

        public bool LoginParentPortalDefault(IWebDriver driver, string ParentLoginEmail, string Password, bool LoginFlag = true)
        {
            bool ActualResutl = false;
            driver.Navigate().GoToUrl(GlobalVariable.sURL);
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            if (Password.Equals(GlobalVariable.sloginPassword))
            {
                
                Pages.LoginPage.LoginAimy(driver, ParentLoginEmail, GlobalVariable.sloginPassword);
            }
            else
            {
                Pages.LoginPage.LoginAimy(driver, ParentLoginEmail, Password);
            }
            
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            if (LoginFlag.Equals(false))
            {
                ActualResutl = TitleValidationExpectNagetive(driver, "AchiveParent",
                    "Login - AIMY");
                return ActualResutl;
            }
            ActualResutl = driver.Title.Equals("Dashboard - aimy plus");
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

        public bool FindTheParent(IWebDriver driver, string ParentName)
        {
            log.Info("Parent Manager - FindArchivedParentName : Validation Test Case: ");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);
            AimySendKeys(driver, txtCategory, ParentName);
            txtCategory.SendKeys(Keys.Enter);


            try
            {
                if (filteredParentName != null && filteredParentName.Displayed)
                {
                    bool flag = filteredParentName.Text.Equals(ParentName);
                }
            }
            catch (Exception e)
            {
                if (filteredParentName == null)
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

        public bool IsParentLocked(IWebDriver driver, string ParentName)
        {
            log.Info("Parent Manager - FindTheLockedParent : Validation Test Case: ");
            
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IReadOnlyCollection<IWebElement> TableRows = WebDriverExtensions.FindElements(driver,
                By.XPath("html/body/div[3]/div[3]/div[2]/table/tbody/tr"), 2);


            for (int t = 0; t < TableRows.Count; t++)
            {
                if (TableRows.ElementAt(t) != null)
                {
                    if (!String.IsNullOrEmpty(TableRows.ElementAt(t).GetAttribute("style")))
                    {
                       if (TableRows.ElementAt(t).GetAttribute("style").Equals("background-color: rgb(239, 201, 201);"))
                        {
                           return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool IsParentUnlocked(IWebDriver driver, string ParentName)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            IReadOnlyCollection<IWebElement> TableRows = WebDriverExtensions.FindElements(driver,
                By.XPath("html/body/div[3]/div[3]/div[2]/table/tbody/tr"), 2);

            for (int t = 0; t < TableRows.Count; t++)
            {
                if (TableRows.ElementAt(t) != null)
                {
                    if (!String.IsNullOrEmpty(TableRows.ElementAt(t).GetAttribute("style")))
                    {
                        if (TableRows.ElementAt(t).GetAttribute("style").Equals("background-color: rgb(239, 201, 201);"))
                        {
                            // filter for this parent
                            IWebElement txtCategory = WebDriverExtensions.FindElement(driver, By.Id("category"), 2);

                            AimySendKeys(driver, txtCategory, ParentName);
                            txtCategory.SendKeys(Keys.Enter);

                            // locate the 'profile' dropdown list
                            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(500));
                            wait.PollingInterval = TimeSpan.FromSeconds(2);
                            wait.Until(
                                ExpectedConditions.ElementExists(By.CssSelector("span.caret.split-dropdown-caret")));

                            IReadOnlyCollection<IWebElement> items =
                                driver.FindElements(By.CssSelector("span.caret.split-dropdown-caret"));
                            // click on 'profile'dropdown list
                            foreach (var item in items)
                            {
                                item.Click();
                                break;
                            }

                            Thread.Sleep(2000);
                            AimyClick(driver, menuItemUnlock);
                            Thread.Sleep(2000);
                            AimyClick(driver, buttonOK);

                            return true;
                        }
                    }
                }
            }
            return true;
        }

        public void GoToEditLoginDetailPage(IWebDriver driver, String ParentName)
        {
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

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
            AimyClick(driver, menuItemEditLogin);
        }

        public void GoToBookingInYourChildPage(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait*2);
            AimyClick(driver, ddlMakeBooking);
        }
    }
}
