using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Booking_Pages;
using AimyTest.Browsers;
using AimyTest.Deleting_a_child;
using AimyTest.Deleting_a_parent;
using AimyTest.Login_out;
using AimyTest.Parent_Dashboard;
using AimyTest.Utilities;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari.Internal;


/// <summary>
/// There is always the need to prepare the test data before run
/// and the same to clean up after running test
/// </summary>

namespace AimyTest.TestSuits
{

    [TestFixture]
    public class ParentManagement_Testcases : TestBase
    {
        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private IWebDriver driver = null;

        public ParentManagement_Testcases()
        {
            driver = ChromeBrowser.chromeDriver;
            ChromeBrowser.Initialize();
        }

        [Test]
        public void DEL_PARENT_01_Has_No_Children()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Nakkala, Ravito");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Assert.AreEqual(true,
                Pages.ParentManagementPage.LoginParentPortalDefault(driver, "ravito@yahoo.co.in", false));
        }

        [Test]
        public void DEL_PARENT_02_Has_Some_Children()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Attendance B, Hana");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Assert.AreEqual(true,
                Pages.ParentManagementPage.LoginParentPortalDefault(driver, "dfaf1bb4-0@delete.auto.com", false));
        }

        [Test]
        public void DEL_PARENT_03_Has_Some_Bookings()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "su, ema");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Assert.AreEqual(true, Pages.ParentManagementPage.LoginParentPortalDefault(driver, "ema@gmail.com", false));
        }

        [Test]
        public void DEL_CHILD_01_From_Parent()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Assert.AreEqual(true, Pages.ChildrenManagementPage.AchiveChildren(driver, "Casson, Fiona"));
        }

        [Test]
        public void DEL_CHILD_02_Has_Some_Pending_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Assert.AreEqual(true, Pages.BookingManagerPage.ValidationPendingBookingExist(driver, "Marlon Casson"));
            Assert.AreEqual(true, Pages.ChildrenManagementPage.AchiveChildren(driver, "Marlon Casson"));
        }

        [Test]
        public void DEL_CHILD_03_Has_Some_Confirmed_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Assert.AreEqual(true, Pages.BookingManagerPage.ValidationConfirmedBookingExist(driver, "Tony Casson"));
            Assert.AreEqual(true, Pages.ChildrenManagementPage.AchiveChildren(driver, "Tony Casson"));
        }

        [Test]
        public void DEL_CHILD_04_Has_Some_Attendance_Records()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.AttendanceManagerPage.ValidationAttendanceExist(driver, "Tony Casson");
            Pages.ChildrenManagementPage.AchiveChildren(driver, "Tony Casson");
        }

        [Test]
        public void RES_PARENT_01_Has_No_Children()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Nakkala, Ravito");
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindArchivedParent(driver, "Nakkala"));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, "Nakkala");
            Assert.AreEqual(true,
                Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, "Nakkala, Ravito"));
            Assert.AreEqual(true,
                Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, "Nakkala, Ravito"));
        }

        ////
        ////Currently the Enrollment for Child is blocking
        ////Children enrollment part is missing for now
        ////Work around is to find parent who has some chilren enrolled already
        ////
        [Test]
        public void RES_PARENT_02_Has_No_Children_Do_Enrol_Do_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Attendance B, Hana");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindArchivedParent(driver, "Attendance B, Hana"));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, "Attendance B, Hana");
            Assert.AreEqual(true,
                Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, "Attendance B, Hana"));
            Assert.AreEqual(true,
                Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, "Attendance B, Hana"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            //// Try to login to the restored parent account
            Assert.AreEqual(true,
                Pages.ParentManagementPage.LoginParentPortalDefault(driver, "dfaf1bb4-0@delete.auto.com"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentDashBoardPage.DoBookingForChild(driver);
            Assert.AreEqual(true,Pages.BookingPage.BookingWizard(driver));
        }

        ////
        ////Currently the Enrollment for Child is blocking
        ////Children enrollment part is missing for now
        ////
        [Test]
        public void RES_PARENT_03_Has_Some_Children_Do_Enrol_Do_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Attendance B, Hana");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindArchivedParent(driver, "Attendance B, Hana"));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, "Attendance B, Hana");
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, "Attendance B, Hana"));
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, "Attendance B, Hana"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            //// Try to login to the restored parent account
            Assert.AreEqual(true, Pages.ParentManagementPage.LoginParentPortalDefault(driver, "dfaf1bb4-0@delete.auto.com"));
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            Pages.ParentDashBoardPage.DoBookingForChild(driver);
            Assert.AreEqual(true, Pages.BookingPage.BookingWizard(driver));
        }

        ////Cleanup data
        [Test]
        public void DeleteBooking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            if (Pages.BookingManagerPage.ValidationPendingBookingExist(driver, "dfaf1bb4-0@delete.auto.com").Equals(true))
            {
                //click on Cancel the entire book button
                Common.WaitBySleeping(GlobalVariable.iShortWait);
                driver.FindElement(
                        By.XPath(
                            "html/body/div[3]/div[3]/div[1]/div/div/div[2]/table/tbody/tr[2]/td[2]/div/table/tbody/tr[3]/td[28]/div/input[5]"), 10)
                    .Click();
                Thread.Sleep(2000);
                //click on OK button on warning dialog
                driver.FindElement(By.XPath("html/body/div[10]/div/div/div[3]/button")).Click();
                Thread.Sleep(2000);
                //click on OK button on confirmation dialog
                driver.FindElement(By.XPath("html/body/div[10]/div/div/div[3]/button[1]")).Click();
            }
        }

        //[Test]
        public void RES_PARENT_04_Has_Some_Children_Has_Some_Bookings_Do_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "ema su");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindArchivedParent(driver, "ema su"));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, "ema su");
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, "ema su"));
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, "ema su"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            //Try to login to the restored parent account
            Assert.AreEqual(true, Pages.ParentManagementPage.LoginParentPortalDefault(driver, "ema@gmail.com"));
            Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            Pages.ParentDashBoardPage.DoBookingForChild(driver);
            Assert.AreEqual(true, Pages.BookingPage.BookingWizard(driver));
        }

        [Test]
        public void RES_PARENT_05_Has_Some_Children_Has_Some_Invoices_Do_Booking()
        {
            Pages.LoginPage.LoginAimy(driver, GlobalVariable.sloginUsername, GlobalVariable.sloginPassword);
            Pages.ParentManagementPage.AchiveParent(driver, "Attendance B, Hana");
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.GoToAchivePage(driver);
            Assert.AreEqual(true, Pages.ParentManagementPage.FindArchivedParent(driver, "Attendance B, Hana"));
            Pages.ParentManagementPage.RestoreArchivedParent(driver, "Attendance B, Hana");
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredFromAchiveList(driver, "Attendance B, Hana"));
            Assert.AreEqual(true, Pages.ParentManagementPage.IsParentBeenRestoredToParentManagePage(driver, "Attendance B, Hana"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            Pages.ParentManagementPage.LogoutAdminPort(driver);
            Common.WaitBySleeping(GlobalVariable.iShortWait);
            // Try to login to the restored parent account
            Assert.AreEqual(true, Pages.ParentManagementPage.LoginParentPortalDefault(driver, "dfaf1bb4-0@delete.auto.com"));
            Common.WaitBySleeping(GlobalVariable.iShortWait);

            Pages.ParentDashBoardPage.DoBookingForChild(driver);
            Assert.AreEqual(true, Pages.BookingPage.BookingWizard(driver));
        }

        [Test]
        public void PARENT_MGT_UNLOCK_01()
        {

        }
    }
}


