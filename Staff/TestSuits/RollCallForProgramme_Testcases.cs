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
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.MobilePage.ClickOnDriverPickup(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.SchoolListPage.ClickOnNext(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.ChildListPage.ClickOnGreenTick(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.2 Extra Inv A"));
            Pages.AttendanceManagerPage.InputSearchBox(driver, "EA.2 Extra Inv A");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.AttendanceManagerPage.ClickOnEditButton(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Assert.AreEqual(true, Pages.EditPage.IsChildBeenPickedUp(driver));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Pages.EditPage.CloseDialog(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
        }
    }
}
