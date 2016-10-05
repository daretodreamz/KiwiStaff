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
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Pages_Classes
{
    public class ClassBookingPages_Wizard7 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[5]/div/div[1]/div[4]/button[2]")]
        private IWebElement btnFinish { get; set; }
       

        public void StepsForBookingWizard7(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait*2);

            AimyClick(driver, btnFinish);

            Thread.Sleep(5000);
        }
    }
}
