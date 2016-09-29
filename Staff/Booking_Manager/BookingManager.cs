using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Manager
{
    class BookingManager : MyElelment
    {
        public BookingManager()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // 'Select All Terms' checkbox
        [FindsBy(How = How.Id, Using = "all-terms-toggle")]
        public IWebElement chkAllTerms { get; set; }

        // 'CONFIRMED BOOKING' pane
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[3]/ul/li[2]/a")]
        public IWebElement lnkConfirmedBooking { get; set; }

        //// Child 'Marlon Casson' under Pending Bookings
        //[FindsBy(How = How.LinkText, Using = "Marlon Casson")]
        //public IWebElement lnkChild1 { get; set; }

        //// Child 'Marlon Casson' under Pending Bookings
        //[FindsBy(How = How.LinkText, Using = "Tony Casson")]
        //public IWebElement lnkChild2 { get; set; }

        private bool ValidationBooking(IWebDriver driver, string TestName, string ChildName)
        {
            log.Info("Booking Manager Validation Test Case: ");

            AimyClick(chkAllTerms);

            IReadOnlyCollection<IWebElement> elements = null;
            try
            {
                elements = WebDriverExtensions.FindElements(driver,
                    By.LinkText(ChildName),
                    10);
            }
            catch (Exception e)
            {
                if (elements == null)
                {
                    log.Info("[FAIL] " + TestName);
                    log.Info("'" + ChildName + "' does NOT exist under " + TestName + ". FAILED!");
                    return false;
                }
            }
            log.Info("[PASS] " + TestName);
            log.Info("The child '" + ChildName + "' exist under " + TestName + ". PASSED!");
            return true;
        }

        public bool ValidationPendingBookingExist(IWebDriver driver, string ChildName)
        {
            sURL = Utilities.GlobalVariable.sURL + "Finance/RedirectType?type=BookingConfirmation";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            bool exist = ValidationBooking(Utilities.Common.driver, "BookingManager - Pending Booking Checking",
                ChildName);
            return exist;            
        }

        public bool ValidationConfirmedBookingExist(IWebDriver driver, string ChildName)
        {
            sURL = Utilities.GlobalVariable.sURL + "Finance/RedirectType?type=BookingConfirmation";
            driver.Navigate().GoToUrl(sURL);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            AimyClick(lnkConfirmedBooking);

            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            bool exist = ValidationBooking(Utilities.Common.driver, "BookingManager - Confirmed Booking Checking",
                ChildName);
            return exist;
        }
    }
}
