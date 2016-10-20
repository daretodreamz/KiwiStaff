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
        // statusNo                   
        [FindsBy(How = How.Id, Using = "statusNo")]
        private IWebElement chkStatusNo { get; set; }
        //attendStatusYes
        [FindsBy(How = How.Id, Using = "attendStatusYes")]
        private IWebElement chkAttendedStatusYes { get; set; }
        //attendStatusNo
        [FindsBy(How = How.Id, Using = "attendStatusNo")]
        private IWebElement chkAttendedStatusNo { get; set; }
        // Cancel Button              
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div[2]/div/div[2]/a[2]")]
        private IWebElement btnCancel { get; set; }
        // Save Button                
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div[2]/div/div[2]/a[1]")]
        private IWebElement btnSave { get; set; }
        //Dialog Ok Button
        [FindsBy(How = How.Id, Using = "kiwi-confirm-yes")]
        private IWebElement btnOK { get; set; }

        //the value of Signout By
        [FindsBy(How = How.XPath, Using = "html/body/div[13]/div[2]/div/div[1]/table/tbody/tr[7]/td/div/table/tbody/tr/td[2]/div/div/table/tbody/tr[1]/td[2]/span/span/span[1]")]
        private IWebElement ddlItemSignOutBy { get; set; }

        // actual Sign In DDL
        [FindsBy(How = How.XPath, Using = "html/body/div[13]/div[2]/div/div[1]/table/tbody/tr[7]/td/div/table/tbody/tr/td[1]/div/div/table/tbody/tr[3]/td[2]/div/span/span/input")]
        private IWebElement ddlActualSignIn { get; set; }
        // actual Sign Out DDL
        [FindsBy(How = How.XPath, Using = "html/body/div[13]/div[2]/div/div[1]/table/tbody/tr[7]/td/div/table/tbody/tr/td[2]/div/div/table/tbody/tr[3]/td[2]/div/span/span/input")]
        private IWebElement ddlActualSignOut { get; set; }

        public bool ReconciliateForExtraCharge(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, ddlActualSignIn);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
            Common.SelectKendoDDLByTextValue(driver, "3:00 p.m.", "html/body/div[14]/div/ul/li");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
            AimyClick(driver, ddlActualSignOut);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
            Common.SelectKendoDDLByTextValue(driver, "6:30 p.m.", "html/body/div[15]/div/ul/li");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
            return true;
        }

        public bool IsSignOutByAuthedParent(IWebDriver driver, string parentName)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            if (ddlItemSignOutBy.Text.Equals(parentName))
                return true;
            return false;
        }

        public bool IsChildBeenPickedUp(IWebDriver driver, bool flag)
        {
            bool result;
            if(flag)
                result = chkStatusYes.Selected;
            else result = chkStatusNo.Selected;
            return result;
        }

        public bool IsChildSignedIn(IWebDriver driver, bool flag)
        {
            bool result;
            if(flag)
                result = chkAttendedStatusYes.Selected;
            else result = chkAttendedStatusNo.Selected;
            return result;
        }

        public void CloseDialog(IWebDriver driver)
        {
            AimyClick(driver, btnCancel);
        }

        public void SaveDialog(IWebDriver driver)
        {
            AimyClick(driver, btnSave);
            //
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
            AimyClick(driver, btnOK);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 10);
        }
    }
}