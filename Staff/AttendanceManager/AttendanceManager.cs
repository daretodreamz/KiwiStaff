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
    class AttendanceManager : MyElelment
    {
        public AttendanceManager()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // Term Selector
        //[FindsBy(How = How.CssSelector, Using = "span.k-icon.k-i-arrow-s")]
        //[FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/span[1]/span/span[2]/span")]
        //public IWebElement ddlTermSelector { get; set; }

        // Pick a term
        [FindsBy(How = How.XPath, Using = "html/body/div[7]/div/ul/li[6]")]
        public IWebElement ddlTerm3 { get; set; }

        // ChildName
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[7]/div[2]/table/tbody/tr/td[5]")]
        public IWebElement txtChildName { get; set; }

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

        public bool ValidationAttendanceExist(IWebDriver driver, string ChildName)
        {
            sURL = Utilities.GlobalVariable.sURL + "RollSheet/AttendanceManager";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            IReadOnlyCollection<IWebElement> selectors = WebDriverExtensions.FindElements(Common.driver,
                By.XPath("html/body/div[3]/div[5]/span[1]/span/span[2]/span"), 10);
            if (selectors.Count != 0)
            {
                foreach (var selector in selectors)
                {
                    AimyClick(selector);
                    break;
                }
            }
           
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            AimyClick(ddlTerm3);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            bool exist = ValidationAttendance(Utilities.Common.driver, "AttendanceManager - Attendance Checking",
                ChildName);
            return exist;
        }
    }
}
