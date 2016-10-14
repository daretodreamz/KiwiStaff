using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet.SignOut
{
    public class ChildSignOut : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Next button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[2]/ul/li/a")]
        private IWebElement btnNext { get; set; }

        // Refresh button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div/a/img")]
        private IWebElement btnRefresh { get; set; }

        // a class="signOut ui-btn"
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[2]/ul/li/a")]
        private IWebElement btn { get; set; }

        public bool ClickOnChildSignOut(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnRefresh);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            try
            {
                bool element = !btn.Enabled;
            }
            catch(Exception e)
            {
                return false;
            }
           
            if (Pages.SignYourChildOutPage.CheckNoRecord(driver))
                return false;
            AimyClick(driver, btnNext);
            return true;
        }
    }
}
