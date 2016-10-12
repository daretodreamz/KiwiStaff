using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Cancel Button   html/body/div[17]/div[2]/div/div[2]/a[2]             
        [FindsBy(How = How.XPath, Using = "/html/body/div[13]/div[2]/div/div[2]/a[2]")]
        private IWebElement btnCancel { get; set; }

        public bool IsChildBeenPickedUp(IWebDriver driver)
        {
            bool flag = chkStatusYes.Selected;
            return flag;
        }

        public void CloseDialog(IWebDriver driver)
        {
            AimyClick(driver, btnCancel);
        }

    }
}