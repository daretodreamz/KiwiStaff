using AimyTest.Browsers;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AimyTest.TestSuits
{
    class RollCallForProgramme_Testcases : TestBase
    {
        public static readonly log4net.ILog log = LogHelper.GetLogger();
        private IWebDriver driver = null;

        public RollCallForProgramme_Testcases()
        {
            driver = ChromeBrowser.chromeDriver;
            ChromeBrowser.Initialize();
        }

        [Test]
        public void Roll_call_for_Program_TC01()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceBeenPickedup(driver, "EA.3 Extra Inv A"));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceBeenSignedIn(driver, "EA.3 Extra Inv A"));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendacneBeenSignedOut(driver, "EA.3 Extra Inv A", "Mary Extra Inv A"));
        }
    }
}
