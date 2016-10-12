using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AimyTest.Utilities;

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

        // EDIT button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[10]/a[1]")]
        private IWebElement btnEdit { get; set; }

        public bool InputSearchBox(IWebDriver driver, string childName)
        {
            AimySendKeys(driver, inputSearchBox, childName);
            return true;
        }

        public bool ClickOnEditButton(IWebDriver driver)
        {
            AimyClick(driver, btnEdit);
            return true;
        }

        private bool ValidationAttendance(IWebDriver driver, string TestName, string ChildName)
        {
            log.Info("Attendance Manager Validation Test Case: ");

            try
            {
                if (txtChildName!=null && txtChildName.Displayed)
                {
                    bool flag = txtChildName.Text.Equals(ChildName);
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
            return true;
        }

        public bool ValidationAttendanceExist(IWebDriver driver, string whichTerm, string ChildName)
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

            bool exist = ValidationAttendance(driver, "AttendanceManager - Attendance Checking",
                ChildName);
            return exist;
        }
    }
}
