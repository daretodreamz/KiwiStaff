using AimyTest.Browsers;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AimyTest.TestSuits
{
    class SpecialDayBooking_Testcases : TestBase
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private IWebDriver driver = null;

        public SpecialDayBooking_Testcases()
        {
            driver = ChromeBrowser.chromeDriver;
            ChromeBrowser.Initialize();
        }

        [Test]
        public void SpecialDay_Booking_01_For_One_Child_One_Day()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Parent/Management");
            Common.TitleValidation(driver, "Validate Parent Management Title", "Parent Management - aimy plus");
            Pages.ParentManagementPage.FindTheParent(driver, "ema su");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToBookingInYourChildPage(driver);
            Assert.AreEqual(0, Common.TitleValidation(driver, "Validate Book In Your Child Title", "Booking - aimy plus"));
            Assert.AreEqual(true, Pages.SpecailDayBookingPage.SpecailDayBookingWizard(driver));
            Assert.AreEqual(true, Pages.BookingManagerPage.ValidationPendingBookingExist(driver, "ema1 ch"));
        }
    }
}
