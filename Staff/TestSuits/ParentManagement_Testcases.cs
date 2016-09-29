using System;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Deleting_a_child;
using AimyTest.Deleting_a_parent;
using AimyTest.Utilities;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium;

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
            Assert.AreEqual(true, handle.AchiveParent(Common.driver, "Nakkala, Ravito", "ravito@yahoo.co.in"));
        }
        [Test]
        public void DEL_PARENT_02_Has_Some_Children()
        {
            var handle = new ParentManagementPage();
            Assert.AreEqual(true, handle.AchiveParent(Common.driver, "Attendance B, Hana", "dfaf1bb4-0@delete.auto.com"));
        }
        [Test]
        public void DEL_PARENT_03_Has_Some_Bookings()
        {
            var handle = new ParentManagementPage();
            Assert.AreEqual(true, handle.AchiveParent(Common.driver, "su, ema", "ema@gmail.com"));
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
    }
}

