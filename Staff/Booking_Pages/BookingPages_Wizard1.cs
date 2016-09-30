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
    class BookingPages_Wizard1 : MyElelment
    {
        public BookingPages_Wizard1()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // select one of the children
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/div[2]/label[1]")]
        public IWebElement lblChild1 { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[2]/div/div[2]/div/span")]
        public IWebElement lblProgrammesVenue { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[2]/div[1]/div/div/a[1]")]
        public IWebElement lblSiteName { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[5]/div/div/div[3]/button[2]")]
        public IWebElement btnOK { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[5]/button")]
        public IWebElement btnNext { get; set; }

        private void DoScrollTo(By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)Common.driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        public BookingPages_Wizard2 StepsForBookingWizard1()
        {
            AimyClick(lblChild1);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(lblProgrammesVenue);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(lblSiteName);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            DoScrollTo(By.XPath("html/body/div[3]/div[5]/div/div/div[3]/button[2]"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(btnOK);
            Thread.Sleep(2000);
            AimyClick(btnNext);
            return new BookingPages_Wizard2();
        }
    }
}
