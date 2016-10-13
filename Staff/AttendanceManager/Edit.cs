using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Attendance_Manager
{
    public class Edit : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // statusYes                    
        [FindsBy(How = How.Id, Using = "statusYes")]
        private IWebElement chkStatusYes { get; set; }
        //attendStatusYes
        [FindsBy(How = How.Id, Using = "attendStatusYes")]
        private IWebElement chkAttendedStatusYes { get; set; }
        // Cancel Button   html/body/div[17]/div[2]/div/div[2]/a[2]             
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div[2]/div/div[2]/a[2]")]
        private IWebElement btnCancel { get; set; }

        //the value of Signout By
        [FindsBy(How = How.XPath, Using = "html/body/div[13]/div[2]/div/div[1]/table/tbody/tr[7]/td/div/table/tbody/tr/td[2]/div/div/table/tbody/tr[1]/td[2]/span/span/span[1]")]
        private IWebElement ddlItemSignOutBy { get; set; }

        public bool IsSignOutByAuthedParent(IWebDriver driver, string parentName)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            if (ddlItemSignOutBy.Text.Equals(parentName))
                return true;
            return false;
        }

        public bool IsChildBeenPickedUp(IWebDriver driver)
        {
            bool flag = chkStatusYes.Selected;
            return flag;
        }

        public bool IsChildSignedIn(IWebDriver driver)
        {
            bool flag = chkAttendedStatusYes.Selected;
            return flag;
        }

        public void CloseDialog(IWebDriver driver)
        {
            AimyClick(driver, btnCancel);
        }

    }
}