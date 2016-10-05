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
    public class ClassBookingPages_Wizard3 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[1]/div/div[1]/label[1]")]
        private IWebElement btnTerms { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[1]/div/div[2]/div/div/div/input")]
        private IWebElement ddlChooseTerm { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[1]/div/div[2]/div/div/input/option[6]")]
        private IWebElement itemTerm4 { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[1]/div/div[5]/button[2]")]
        private IWebElement btnNext { get; set; }





        public void StepsForBookingWizard3(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnTerms);
            Thread.Sleep(1000);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, ddlChooseTerm);
            Thread.Sleep(2000);
            //                                          
            Common.SelectKendoDDLByTextValue(driver, "Term 4 (2016)", "html/body/div[8]/div/ul/li/span");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            AimyClick(driver, btnNext);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
        }
    }
}
