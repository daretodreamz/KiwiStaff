using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet.DriverPickup
{
    public class ChildList : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Green tick
        [FindsBy(How = How.XPath, Using = "html/body/div[5]/div[3]/ul/li[1]/div[1]/div[3]/a[1]/img")]
        private IWebElement btnGreenTick { get; set; }

        public bool ClickOnGreenTick(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnGreenTick);
            return true;
        }
    }
}
