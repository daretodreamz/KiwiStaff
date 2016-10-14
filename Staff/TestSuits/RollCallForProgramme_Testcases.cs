﻿using AimyTest.Browsers;
using AimyTest.Tablet;
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
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Green));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.3 Extra Inv A"));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Green));// can be improved with options
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.3 Extra Inv A"));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver));// can be improved with options
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendacneBeenSignedOut(driver, "EA.3 Extra Inv A", "Mary Extra Inv A"));
        }

        [Test]
        public void Roll_call_for_Program_TC02()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Red));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            //Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.4 Extra Inv A", false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Green));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.4 Extra Inv A"));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendacneBeenSignedOut(driver, "EA.4 Extra Inv A", "Mary Extra Inv A"));
        }

        [Test]
        public void Roll_call_for_Program_TC03()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Red));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "Weekly Do"));
            //Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.4 Extra Inv A", false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Red));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "Weekly Do"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "Weekly Do", false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(false, Pages.MobilePage.ClickOnSignOut(driver));
        }
    }
}
