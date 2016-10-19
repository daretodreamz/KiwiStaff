using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using static AimyTest.Tablet.Mobile;

namespace AimyTest.Attendance_Manager
{
    public class AttendanceManager : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // Term Selector
        //[FindsBy(How = How.CssSelector, Using = "span.k-icon.k-i-arrow-s")]
        //[FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/span[1]/span/span[2]/span")]
        //public IWebElement ddlTermSelector { get; set; }

        // Pick term3                     
        [FindsBy(How = How.XPath, Using = "html/body/div[7]/div/ul/li[6]")]
        private IWebElement ddlTerm3 { get; set; }
        // Pick term4
        [FindsBy(How = How.XPath, Using = "html/body/div[7]/div/ul/li[8]")]
        private IWebElement ddlTerm4 { get; set; }

        // ChildName
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[5]")]
        private IWebElement txtChildName { get; set; }
        
        // Search Box
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[6]/input[1]")]
        private IWebElement inputSearchBox { get; set; }

        // EDIT button                     html/body/div[3]/div[7]/div[2]/table/tbody/tr[1]/td[10]/a[1]
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[10]/a[1]")]
        private IWebElement btnEdit { get; set; }

        // AttendedYes
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[2]/table/tbody/tr[1]/td[6]/img")]
        private IWebElement imgAttendedYes { get; set; }

        // RefreshButton
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[4]/a[5]/span")]
        private IWebElement btnRefresh { get; set; }

        //Loading Animation Icon
        [FindsBy(How = How.XPath, Using = "html/body/div[1]")]
        private IWebElement loadingIcon { get; set; }
        

        private bool IsLoadingIconOff(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.PollingInterval = TimeSpan.FromSeconds(2);
            wait.Until(ExpectedConditionsExtension.LoadingIconDisappears());
            return true;
        }

        private bool IsImgShownAttendedStatus(IWebDriver driver, string ChildName, ProgrammesOptions whichProg, bool flag)
        {
            log.Info("Attendance Manager Validation Test Case: ");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            try
            {
                if (driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]")).Count > 0)
                {
                    if (whichProg == ProgrammesOptions.ASC)
                    {
                        var elements = driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]"));
                        int counter = 0;
                        foreach (var e in elements)
                        {
                            counter++;
                            if (e != null && e.Displayed && e.Text.Contains("ASC"))
                            {
                                if (flag)
                                {
                                    if (driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[6]/img")).Displayed)
                                    {
                                        return flag = driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[6]/img")).GetAttribute("src").Contains("Yes");
                                    }
                                }
                                else
                                {
                                    if (driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[6]/img")).Displayed)
                                    {
                                        return flag = driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[6]/img")).GetAttribute("src").Contains("No");
                                    }
                                }
                            }                             }
                        }
                    }                
            }
            catch (Exception e)
            {
                if (txtChildName == null)
                {
                    log.Info("[FAIL]");
                    log.Info("'" + ChildName + "' does NOT exist. FAILED!");
                    return false;
                }
            }
            log.Info("[PASS]");
            log.Info("The child '" + ChildName + "' exist. PASSED!");
            return false;
        }

        private bool InputSearchBox(IWebDriver driver, string childName)
        {
            AimySendKeys(driver, inputSearchBox, childName);
            return true;
        }

        private bool ClickOnEditButton(IWebDriver driver, string ChildName, ProgrammesOptions whichProg)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnRefresh);
            if (IsLoadingIconOff(driver))
            {
                Common.WaitBySleeping(GlobalVariable.iShortWait * 40);
                if (driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]")).Count > 0)
                {
                    if (whichProg == ProgrammesOptions.ASC)
                    {
                        var elements = driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]"));
                        int counter = 0;
                        foreach (var e in elements)
                        {
                            counter++;
                            if (e != null && e.Displayed && e.Text.Contains("ASC"))
                            {
                                AimyClick(driver, driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[10]/a[1]")));
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool ValidationAttendance(IWebDriver driver, string TestName, string ChildName, ProgrammesOptions whichProg)
        {
            log.Info("Attendance Manager Validation Test Case: ");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            try
            {
                if(driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]")).Count > 0)
                {
                    if(whichProg == ProgrammesOptions.ASC)
                    {
                        var elements = driver.FindElements(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[3]"));
                        int counter = 0;
                        foreach(var e in elements)
                        {
                            counter++;
                            if (e != null && e.Displayed && e.Text.Contains("ASC"))
                            {
                                bool flag = driver.FindElement(By.XPath("html/body/div[3]/div[7]/div[2]/table/tbody/tr[" + counter + "]/td[5]")).Text.Equals(ChildName);
                                return flag;
                            }
                        }
                    }                    
                }                
            }
            catch (Exception e)
            {
                if (txtChildName == null)
                {
                    log.Info("[FAIL] " + TestName);
                    log.Info("'" + ChildName + "' does NOT exist " + TestName + ". FAILED!");
                    return false;
                }
            }
            log.Info("[PASS] " + TestName);
            log.Info("The child '" + ChildName + "' exist " + TestName + ". PASSED!");
            return false;
        }

        public bool IsAttendanceSignedOut(IWebDriver driver, string ChildName, string AuthedParentName, ProgrammesOptions whichProgramme = ProgrammesOptions.ASC, bool attendedStatus = true, bool reconciliationForExtraCharge = false)
        {
            // First to check the Status of Edit Page
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            InputSearchBox(driver, ChildName);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            ClickOnEditButton(driver, ChildName, whichProgramme);            
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            //Assert.AreEqual(true, Pages.EditPage.IsChildBeenPickedUp(driver, true), "IsChildBeenPickedUp");
            Assert.AreEqual(true, Pages.EditPage.IsChildSignedIn(driver, attendedStatus), "IsChildSignedIn");
            Assert.AreEqual(true, Pages.EditPage.IsSignOutByAuthedParent(driver, AuthedParentName), "IsSignOutByAuthedParent");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            if (reconciliationForExtraCharge)
            {
                //do extra update
                if (Pages.EditPage.ReconciliateForExtraCharge(driver))
                {
                    Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
                    Pages.EditPage.SaveDialog(driver);
                }                    
                return true;
            }
            Pages.EditPage.CloseDialog(driver);
            return true;
        }

        public bool IsAttendanceSignedIn(IWebDriver driver, string ChildName, ProgrammesOptions whichProgramme, bool flag = true)
        {
            // First to check the 'Green' tick flag on Attendance Management Page
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            InputSearchBox(driver, ChildName);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            IsImgShownAttendedStatus(driver, ChildName, whichProgramme, flag);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 40);
            // Second to go to 'Edit' page to check the status
            ClickOnEditButton(driver, ChildName, whichProgramme);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            //Assert.AreEqual(true, Pages.EditPage.IsChildBeenPickedUp(driver, true), "IsChildBeenPickedUp");
            Assert.AreEqual(true, Pages.EditPage.IsChildSignedIn(driver, flag), "IsChildSignedIn");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.EditPage.CloseDialog(driver);
            //
            return true;
        }

        public bool IsAttendancePickedup(IWebDriver driver, string ChildName, ProgrammesOptions whichProgramme, bool flag = true)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            InputSearchBox(driver, ChildName);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            ClickOnEditButton(driver, ChildName, whichProgramme);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            bool result = Pages.EditPage.IsChildBeenPickedUp(driver, flag);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.EditPage.CloseDialog(driver);

            return result;
        }

        public bool ValidationAttendanceExist(IWebDriver driver, string whichTerm, string ChildName, ProgrammesOptions whichProg = ProgrammesOptions.ASC)
        {
            sURL = GlobalVariable.sURL + "RollSheet/AttendanceManager";
            driver.Navigate().GoToUrl(sURL);

            Common.WaitBySleeping(GlobalVariable.iShortWait);

            IReadOnlyCollection<IWebElement> selectors = WebDriverExtensions.FindElements(driver,
                By.XPath("html/body/div[3]/div[5]/span[1]/span/span[2]/span"), 10);
            if (selectors.Count != 0)
            {
                foreach (var selector in selectors)
                {
                    AimyClick(driver, selector);
                    break;
                }
            }

            Common.WaitBySleeping(GlobalVariable.iShortWait);
            if (whichTerm.ToLower().Contains("term3"))
                AimyClick(driver, ddlTerm3);
            else if (whichTerm.ToLower().Contains("term4"))
                AimyClick(driver, ddlTerm4);

            Common.WaitBySleeping(GlobalVariable.iShortWait);
            InputSearchBox(driver, ChildName);
            bool exist = ValidationAttendance(driver, "AttendanceManager - Attendance Checking",
                ChildName, whichProg);
            return exist;
        }
    }

    public class ExpectedConditionsExtension
    {
        public static Func<IWebDriver, bool> LoadingIconDisappears()
        {
            return delegate (IWebDriver driver)
            {
                IWebElement element = null;
                try
                {
                    element = driver.FindElement(By.XPath("html/body/div[1]"));
                }
                catch (NoSuchElementException) { return true; }
                return !element.Displayed;
            };
        }
    }
}
