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
    public class ClassBookingPages_Wizard6 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
                                           
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[4]/div/div/div/button[2]")]  ///one
        private IWebElement btnNextForOneChild { get; set; }

        
        public void StepsForBookingWizard6(IWebDriver driver, bool needSecondChild)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait*2);
            //if (needSecondChild)
                AimyClick(driver, btnNextForOneChild);
            //else
            //{
            //    AimyClick(driver, btnNextForOneChild);
            //}
            
            Thread.Sleep(2000);
        }
    }
}
