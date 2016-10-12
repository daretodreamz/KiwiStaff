using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet
{
    public class Mobile : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Driver Pickup
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[1]/a")]
        private IWebElement btnDriverPickup { get; set; }
        // SignIn
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[2]/a")]
        private IWebElement btnSignIn { get; set; }
        // SignOut
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[1]/div[5]/div[3]/a")]
        private IWebElement btnSignOut { get; set; }

        public bool ClickOnDriverPickup(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnDriverPickup);
            return true;
        }

        public bool ClickOnSignIn(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnSignIn);
            return true;
        }

        public bool ClickOnSignOut(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnSignOut);
            return true;
        }
    }
}
