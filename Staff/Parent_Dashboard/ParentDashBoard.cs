using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using AimyTest.Utilities;
using OpenQA.Selenium.Remote;
using AimyTest.Booking_Pages;

namespace AimyTest.Parent_Dashboard
{
    class ParentDashBoard : MyElelment
    {
        public ParentDashBoard()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);
        }

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // 'Select All Terms' checkbox
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div/div[1]/div[1]/div[2]/div[2]/a")]
        public IWebElement btnMakeBooking { get; set; }

        public void DoBookingForChild()
        {
            AimyClick(btnMakeBooking);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
        }
    }
}
