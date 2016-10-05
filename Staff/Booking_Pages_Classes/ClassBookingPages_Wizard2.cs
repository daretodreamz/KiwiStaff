using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Booking_Pages_BSC_ASC;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest.Booking_Pages_Classes
{
    public class ClassBookingPages_Wizard2 : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children      
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/div[1]/div[1]/div[1]/ul/li[1]/div/div[4]/div/input")]
        private IWebElement btnMakeCustBooking { get; set; }

        public void StepsForBookingWizard2(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnMakeCustBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            
        }
    }
}
