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
    public class SpecialDayBookingPages_Wizard4 : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
       
        // Finish Button
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[3]/div/div[1]/div[4]/button[2]")]
        private IWebElement btnFinish { get; set; }

        public void StepsForBookingWizard4(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnFinish);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
        }
    }
}
