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
    public class SignYourChildOut : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Click on Green Tick              
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[3]/div/ul/li/div[1]/div[2]/div/a/img")]
        private IWebElement btnGreenTick { get; set; }

        public bool ClickOnGreenTick(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnGreenTick);
            return true;
        }
    }
}
