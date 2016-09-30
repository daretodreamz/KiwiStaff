using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Deleting_a_child;
using AimyTest.Deleting_a_parent;
using AimyTest.Login;
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

        [Test]
        public void DEL_PARENT_01_Has_No_Children()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Nakkala, Ravito");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "ravito@yahoo.co.in", false));
            handle = null;
        }

        [Test]
        public void DEL_PARENT_02_Has_Some_Children()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Attendance B, Hana");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "dfaf1bb4-0@delete.auto.com", false));
            handle = null;
        }

        [Test]
        public void DEL_PARENT_03_Has_Some_Bookings()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "su, ema");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "ema@gmail.com", false));
            handle = null;
        }

        [Test]
        public void DEL_CHILD_01_From_Parent()
        {
            var handle = new ChildrenManagement();
            Assert.AreEqual(true, handle.AchiveChildren(Common.driver, "Casson, Fiona"));
        }

        [Test]
        public void DEL_CHILD_02_Has_Some_Pending_Booking()
        {
            var bookingManger = new BookingManager();
            Assert.AreEqual(true, bookingManger.ValidationPendingBookingExist(Common.driver, "Marlon Casson"));
            var childMangement = new ChildrenManagement();
            Assert.AreEqual(true, childMangement.AchiveChildren(Common.driver, "Marlon Casson"));
        }

        [Test]
        public void DEL_CHILD_03_Has_Some_Confirmed_Booking()
        {
            var bookingManger = new BookingManager();
            Assert.AreEqual(true, bookingManger.ValidationConfirmedBookingExist(Common.driver, "Tony Casson"));
            var childMangement = new ChildrenManagement();
            Assert.AreEqual(true, childMangement.AchiveChildren(Common.driver, "Tony Casson"));
        }

        [Test]
        public void DEL_CHILD_04_Has_Some_Attendance_Records()
        {
            var attendacneManager = new AttendanceManager();
            attendacneManager.ValidationAttendanceExist(Common.driver, "Tony Casson");

            var childManagement = new ChildrenManagement();
            childManagement.AchiveChildren(Common.driver, "Tony Casson");
        }

        [Test]
        public void RES_PARENT_01_Has_No_Children()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Nakkala, Ravito");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.GoToAchivePage(Common.driver);
            Assert.AreEqual(true, handle.FindArchivedParent("Nakkala"));
            handle.RestoreArchivedParent("Nakkala");
            Assert.AreEqual(true, handle.IsParentBeenRestoredFromAchiveList("Nakkala, Ravito"));
            Assert.AreEqual(true, handle.IsParentBeenRestoredToParentManagePage("Nakkala, Ravito"));
            handle = null;
        }

        //
        //Currently the Enrollment for Child is blocking
        //Children enrollment part is missing for now
        //Work around is to find parent who has some chilren enrolled already
        //
        [Test]
        public void RES_PARENT_02_Has_No_Children_Do_Enrol_Do_Booking()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Attendance B, Hana");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.GoToAchivePage(Common.driver);
            Assert.AreEqual(true, handle.FindArchivedParent("Attendance B, Hana"));
            handle.RestoreArchivedParent("Attendance B, Hana");
            Assert.AreEqual(true, handle.IsParentBeenRestoredFromAchiveList("Attendance B, Hana"));
            Assert.AreEqual(true, handle.IsParentBeenRestoredToParentManagePage("Attendance B, Hana"));
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            // Try to login to the restored parent account
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "dfaf1bb4-0@delete.auto.com"));
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            var pdb = new ParentDashBoard();
            var step1 = pdb.DoBookingForChild();
            var step2 = step1.StepsForBookingWizard1();
            var step3 = step2.StepsForBookingWizard2();
            var step4 = step3.StepsForBookingWizard3();
            var step5 = step4.StepsForBookingWizard4();
            var step6 = step5.StepsForBookingWizard5();
            var step7 = step6.StepsForBookingWizard6();
            var step8 = step7.StepsForBookingWizard7();
            var final = step8.StepsForBookingWizard8();

            Assert.AreEqual(true, final);
        }

        //
        //Currently the Enrollment for Child is blocking
        //Children enrollment part is missing for now
        //
        [Test]
        public void RES_PARENT_03_Has_Some_Children_Do_Enrol_Do_Booking()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Attendance B, Hana");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.GoToAchivePage(Common.driver);
            Assert.AreEqual(true, handle.FindArchivedParent("Attendance B, Hana"));
            handle.RestoreArchivedParent("Attendance B, Hana");
            Assert.AreEqual(true, handle.IsParentBeenRestoredFromAchiveList("Attendance B, Hana"));
            Assert.AreEqual(true, handle.IsParentBeenRestoredToParentManagePage("Attendance B, Hana"));
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            // Try to login to the restored parent account
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "dfaf1bb4-0@delete.auto.com"));
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);

            var pdb = new ParentDashBoard();
            var step1 = pdb.DoBookingForChild();
            var step2 = step1.StepsForBookingWizard1();
            var step3 = step2.StepsForBookingWizard2();
            var step4 = step3.StepsForBookingWizard3();
            var step5 = step4.StepsForBookingWizard4();
            var step6 = step5.StepsForBookingWizard5();
            var step7 = step6.StepsForBookingWizard6();
            var step8 = step7.StepsForBookingWizard7();
            var final = step8.StepsForBookingWizard8();

            Assert.AreEqual(true, final);
            
        }

        //Cleanup data
        [Test]
        public void DeleteBooking()
        {
            var bm = new BookingManager();
            if (bm.ValidationPendingBookingExist(Common.driver, "dfaf1bb4-0@delete.auto.com").Equals(true))
            {
                //click on Cancel the entire book button
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Common.driver.FindElement(
                    By.XPath(
                        "html/body/div[3]/div[3]/div[1]/div/div/div[2]/table/tbody/tr[2]/td[2]/div/table/tbody/tr[3]/td[28]/div/input[5]")).Click();
                Thread.Sleep(2000);
                //click on OK button on warning dialog
                Common.driver.FindElement(By.XPath("html/body/div[10]/div/div/div[3]/button")).Click();
                Thread.Sleep(2000);
                //click on OK button on confirmation dialog
                Common.driver.FindElement(By.XPath("html/body/div[10]/div/div/div[3]/button[1]")).Click();
                
            }
        }
    }
}


