using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Registering_a_parent
{
    public class Child_20_Profile : MyElelment
    {
        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;
        public Child_20_Profile()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();


        // link to add Authorised Pickup

        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']//div[7]//a")]
        public IWebElement lnkAddAuthorisedPickup { get; set; }

        // link to Add NON_AuthorisedPickup
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']//div[9]//a")]
        public IWebElement lnkAdd_NON_AuthorisedPickup { get; set; }

        // link to Add Medical Condition
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']//div[11]//a")]
        public IWebElement lnkAddMedicalCondition { get; set; }

        // link to Add New Child
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']//div[15]//a[1]")]
        public IWebElement lnkAddNewChild { get; set; }

        // link to Proceed Booking for the Child
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']//div[15]//a[2]")]
        public IWebElement lnkProceedBooking { get; set; }
      

        // navigation to another pages
        public Child_21_AddAuthorisedPickup AddAuthorisedPickup(IWebDriver driver)
        {
            AimyClick(lnkAddAuthorisedPickup);
            log.Debug("Add_AuthorisedPickup starts...");
            return new Child_21_AddAuthorisedPickup();
        }
        public Child_23_NonAuthorisedPickup Add_NON_AuthorisedPickup(IWebDriver driver)
        {
            AimyClick(lnkAdd_NON_AuthorisedPickup);

            log.Debug("Add_NON_AuthorisedPickup starts...");
            return new Child_23_NonAuthorisedPickup();
        }
        public Child_22_MedicalCondition AddMedicalCondition(IWebDriver driver)
        {
            AimyClick(lnkAddMedicalCondition);
            log.Debug("AddMedicalCondition starts...");
            return new Child_22_MedicalCondition();
        }

        public Child_1_Enrollment AddNewChild(IWebDriver driver)
        {
            AimyClick(lnkAddNewChild);

            log.Debug("AddNewChild starts...");

            return new Child_1_Enrollment();
        }

        public void ProceedBooking(IWebDriver driver)
        {
            AimyClick(lnkProceedBooking);

            log.Debug("ProceedBooking for a chid starts...");

            
        }


    }

   
}

