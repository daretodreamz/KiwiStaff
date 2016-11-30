using AimyTest.Browsers;
using AimyTest.Tablet;
using AimyTest.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace AimyTest.TestSuits
{
    class RollCallForProgramme_Testcases : TestBase
    {
        public static readonly log4net.ILog log = LogHelper.GetLogger();
        private IWebDriver driver = null;

        //public RollCallForProgramme_Testcases()
        //{
        //    driver = ChromeBrowser.chromeDriver;
        //    ChromeBrowser.Initialize();            
        //}

        public void Init(string browserName)
        {
            if (browserName.Equals("Chrome"))
            {
                driver = ChromeBrowser.chromeDriver;
                driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
            else if (browserName.Equals("IE"))
            {
                driver = IEBrowser.IEDriver;
                driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
            else if (browserName.Equals("FireFox"))
            {
                //driver = FireFoxBrowser.firefoxDriver;
                //driver.Navigate().GoToUrl(GlobalVariable.sURL);
            }
        }
        
        [TestCase("Chrome")]
        [TestCase("IE")]
        [TestCase("FireFox")]
        public void Roll_call_for_Program_TC01(string browserName)
        {
            Init(browserName);
            Pages.OnWhichBrowser(driver);            
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            driver.Navigate().GoToUrl("http://uat.aimy.co.nz/Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Green, "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            //Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.4 Extra Inv A"));
            driver.Navigate().GoToUrl("http://uat.aimy.co.nz/Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Green, "EA.4 Extra Inv A", Mobile.ProgrammesOptions.ASC));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.4 Extra Inv A", Mobile.ProgrammesOptions.ASC));
            driver.Navigate().GoToUrl("http://uat.aimy.co.nz/Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver, "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.4 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedOut(driver, "EA.4 Extra Inv A", "Mary Extra Inv A"));
        }

        [Test]
        public void Roll_call_for_Program_TC02()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Red, "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            //Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.3 Extra Inv A", false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Green, "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.3 Extra Inv A", Mobile.ProgrammesOptions.ASC));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver, "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.3 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedOut(driver, "EA.3 Extra Inv A", "Mary Extra Inv A"));
        }

        [Test]
        public void Roll_call_for_Program_TC03()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnDriverPickup(driver, Mobile.GreenRedOptions.Red, "EA.2 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.2 Extra Inv A"));
            //Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendancePickedup(driver, "EA.2 Extra Inv A", false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Red, "EA.2 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.2 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.2 Extra Inv A", Mobile.ProgrammesOptions.ASC, false));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(false, Pages.MobilePage.ClickOnSignOut(driver, "EA.2 Extra Inv A"));
        }

        [Test]
        public void Roll_call_for_Program_TC04()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Red, "EA.5 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "EA.5 Extra Inv A"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "EA.5 Extra Inv A", Mobile.ProgrammesOptions.ASC, false));
            ChromeBrowser.Goto("RollSheet/CostReconciliationV2");
            Assert.AreEqual(true, Pages.BookingReconciliationPage.CreateCreditNote(driver, "EA.5 Extra Inv A", "20/10/2016"));
            ChromeBrowser.Goto("Finance/RedirectType?type=XeroInvoicePage");
            Assert.AreEqual(true, Pages.TransactionHistoryPage.CheckCreditNote(driver, "Mary Extra Inv A", "20/10/2016"));
        }

        [Test]
        public void Roll_call_for_Program_TC05()
        {
            Pages.OnWhichBrowser(driver);
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Common.TitleValidation(driver, "Validate Aimy Home Title", "Home - aimy plus");
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignIn(driver, Mobile.GreenRedOptions.Green, "William Wallace"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "William Wallace"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedIn(driver, "William Wallace", Mobile.ProgrammesOptions.ASC));
            ChromeBrowser.Goto("Mobile");
            Common.TitleValidation(driver, "Validate Aimy Tablet Home Page Title", "aimy plus");
            Assert.AreEqual(true, Pages.MobilePage.ClickOnSignOut(driver, "William Wallace"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "term4", "William Wallace"));
            Assert.AreEqual(true, Pages.AttendanceManagerPage.IsAttendanceSignedOut(driver, "William Wallace", "Kevin Duong", 
                Mobile.ProgrammesOptions.ASC, true, true));
            ChromeBrowser.Goto("RollSheet/CostReconciliationV2");
            Assert.AreEqual(true, Pages.BookingReconciliationPage.GenerateInvoice(driver, "William Wallace", "20/10/2016"));
            ChromeBrowser.Goto("Finance/RedirectType?type=XeroInvoicePage");
            Assert.AreEqual(true, Pages.TransactionHistoryPage.CheckExtraInvoice(driver, "Kevin Duong", "20/10/2016"));
        }
    }
}
