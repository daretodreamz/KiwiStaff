using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AimyTest.Booking_Pages_BSC_ASC
{
    public class BookingPages_Wizard5 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[3]/div/div/div[4]/button[2]")]
        private IWebElement btnNext { get; set; }

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard6 StepsForBookingWizard5(IWebDriver driver)
        {
            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return new BookingPages_Wizard6();
        }
    }
}
