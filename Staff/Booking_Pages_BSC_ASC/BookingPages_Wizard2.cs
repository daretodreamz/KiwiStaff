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
    public class BookingPages_Wizard2 : MyElelment
    {
        
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children      
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/div[1]/div[1]/div[1]/ul/li[1]/div/div[4]/div/input")]
        private IWebElement btnMakeCustBooking { get; set; }
        

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard3 StepsForBookingWizard2(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnMakeCustBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return new BookingPages_Wizard3();
        }
    }
}
