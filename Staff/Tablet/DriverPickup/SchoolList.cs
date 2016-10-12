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
    public class SchoolList : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Next button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[2]/ul/li/div/div[2]/a")]
        private IWebElement btnNext { get; set; }

        public bool ClickOnNext(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnNext);
            return true;
        }
    }
}
