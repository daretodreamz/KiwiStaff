using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Tablet.SignIn
{
    public class ChildSignIn : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Next button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[2]/div[3]/ul/li/a")]
        private IWebElement btnNext { get; set; }

        public bool ClickOnChildSignIn(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnNext);
            return true;
        }
    }
}
