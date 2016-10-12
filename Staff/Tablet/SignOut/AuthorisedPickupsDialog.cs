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
    public class AuthorisedPickupsDialog : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Parent Pickup button
        [FindsBy(How = How.XPath, Using = "html/body/div[4]/div[14]/div/ul/li[2]/div[2]/a")]
        private IWebElement btnAuthPickup { get; set; }

        public bool ClickOnAuthPickup(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnAuthPickup);
            return true;
        }
    }
}
