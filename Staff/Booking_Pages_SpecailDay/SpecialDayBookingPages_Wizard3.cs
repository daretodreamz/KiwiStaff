using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Booking_Pages_BSC_ASC;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Booking_Pages_SpecialDay
{
    public class SpecialDayBookingPages_Wizard3 : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
       
        // Next Button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[2]/div/div/div[4]/button[2]")]
        private IWebElement btnNext { get; set; }

        public void StepsForBookingWizard3(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
        }
    }
}
