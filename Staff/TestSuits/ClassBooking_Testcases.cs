using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AimyTest.Browsers;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AimyTest.TestSuits
{
    class ClassBooking_Testcases : TestBase
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private IWebDriver driver = null;

        public ClassBooking_Testcases()
        {
            driver = ChromeBrowser.chromeDriver;
            ChromeBrowser.Initialize();
        }

        [Test]
        public void Class_Booking_01_For_One_Child_One_Day_Each_Class()
        {
            Pages.LoginPage.LoginAimy(driver, "bing@cssteam.co.nz", "123123");
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Parent/Management");
            Common.TitleValidation(driver, "Validate Parent Management Title", "Parent Management - aimy plus");
            Pages.ParentManagementPage.FindTheParent(driver, "123456789@gmail.com");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToBookingInYourChildPage(driver);
            Assert.AreEqual(0, Common.TitleValidation(driver, "Validate Book In Your Child Title", "Booking - aimy plus"));
            Pages.ClassBookingPage.ClassBookingWizard(driver, new string[] { "2016-10-10" }, false, true);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Assert.AreEqual(true, Pages.BookingManagerPage.ValidationPendingBookingExist(driver, "Test Aimy"));
            

        }

        [Test]
        public void Class_Booking_02_For_Two_Children_One_Day_Each_Class()
        {
            Pages.LoginPage.LoginAimy(driver, "bing@cssteam.co.nz", "123123");
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Parent/Management");
            Common.TitleValidation(driver, "Validate Parent Management Title", "Parent Management - aimy plus");
            Pages.ParentManagementPage.FindTheParent(driver, "123456789@gmail.com");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToBookingInYourChildPage(driver);
            Assert.AreEqual(0, Common.TitleValidation(driver, "Validate Book In Your Child Title", "Booking - aimy plus"));
            Pages.ClassBookingPage.ClassBookingWizard(driver, new string[] { "2016-10-17" }, true, true);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Assert.AreEqual(true, Pages.BookingManagerPage.ValidationPendingBookingExist(driver, "Test Aimy"));
        }
    }
}
