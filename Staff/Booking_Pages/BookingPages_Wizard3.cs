using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AimyTest.Booking_Pages
{
    class BookingPages_Wizard3 : MyElelment
    {
        public BookingPages_Wizard3()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[1]/label[1]")]
        public IWebElement btnRegularBooking { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[2]/label[2]")]
        public IWebElement btnTerms { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div/div[1]/div/div[7]/button[2]")]
        public IWebElement btnNext { get; set; }


        private void DoScrollTo(By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)Common.driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard4 StepsForBookingWizard3()
        {
            AimyClick(btnRegularBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(btnTerms);
            Thread.Sleep(2000);

            AimyClick(btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            return new BookingPages_Wizard4();
        }
    }
}
