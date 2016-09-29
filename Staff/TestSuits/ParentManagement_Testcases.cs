using System;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Deleting_a_child;
using AimyTest.Deleting_a_parent;
using AimyTest.Utilities;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari.Internal;

namespace AimyTest.TestSuits
{

    [TestFixture]
    public class ParentManagement_Testcases : TestBase
    {

        public static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        //private ParentManagementPage handle = null;

        //public ParentManagement_Testcases(): base()
        //{
        //    var handle = new ParentManagementPage();
        //}

        [Test]
        public void DEL_PARENT_01_Has_No_Children()
        {
            var handle = new ParentManagementPage();
            handle.AchiveParent(Common.driver, "Nakkala, Ravito");
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.LogoutAdminPort();
            Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "ravito@yahoo.co.in"));
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
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "dfaf1bb4-0@delete.auto.com"));
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
            Assert.AreEqual(true, handle.LoginParentPortalDefault(Common.driver, "ema@gmail.com"));
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
            //handle.AchiveParent(Common.driver, "Nakkala, Ravito");
            //Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            handle.GoToAchivePage(Common.driver, "Nakkala, Ravito");
            Assert.AreEqual(true, handle.FindArchivedParent("Nakkala, Ravito"));
            handle.RestoreArchivedParent("Nakkala, Ravito");
            Assert.AreEqual(true, handle.IsParentBeenRestore("Nakkala, Ravito"));
        }
    }
}

