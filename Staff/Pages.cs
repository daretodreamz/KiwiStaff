using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Booking_Pages;
using AimyTest.Browsers;
using AimyTest.Deleting_a_child;
using AimyTest.Deleting_a_parent;
using AimyTest.Login_out;
using AimyTest.Parent_Dashboard;
using AimyTest.Edit_Login;
using OpenQA.Selenium.Support.PageObjects;

namespace AimyTest
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(ChromeBrowser.Driver, page);
            return page;
        }

        public static Login LoginPage
        {
            get { return GetPage<Login>(); }
        }

        public static LogOut LogOutPage
        {
            get { return GetPage<LogOut>(); }
        }

        public static ParentManagement ParentManagementPage
        {
            get { return GetPage<ParentManagement>(); }
        }

        public static ChildrenManagement ChildrenManagementPage
        {
            get { return GetPage<ChildrenManagement>(); }
        }

        public static AttendanceManager AttendanceManagerPage
        {
            get { return GetPage<AttendanceManager>(); }
        }

        public static BookingManager BookingManagerPage
        {
            get { return GetPage<BookingManager>(); }
        }

        public static Bookings BookingPage
        {
            get { return GetPage<Bookings>(); }
        }

        public static BookingPages_Wizard1 BookingPagesWizard1
        {
            get { return GetPage<BookingPages_Wizard1>(); }
        }

        public static BookingPages_Wizard2 BookingPagesWizard2
        {
            get { return GetPage<BookingPages_Wizard2>(); }
        }

        public static BookingPages_Wizard3 BookingPagesWizard3
        {
            get { return GetPage<BookingPages_Wizard3>(); }
        }

        public static BookingPages_Wizard4 BookingPagesWizard4
        {
            get { return GetPage<BookingPages_Wizard4>(); }
        }

        public static BookingPages_Wizard5 BookingPagesWizard5
        {
            get { return GetPage<BookingPages_Wizard5>(); }
        }

        public static BookingPages_Wizard6 BookingPagesWizard6
        {
            get { return GetPage<BookingPages_Wizard6>(); }
        }

        public static BookingPages_Wizard7 BookingPagesWizard7
        {
            get { return GetPage<BookingPages_Wizard7>(); }
        }

        public static BookingPages_Wizard8 BookingPagesWizard8
        {
            get { return GetPage<BookingPages_Wizard8>(); }
        }

        public static ParentDashBoard ParentDashBoardPage
        {
            get { return GetPage<ParentDashBoard>(); }
        }

        public static EditLogin EditLoginPage
        {
            get { return GetPage<EditLogin>(); }
        }
    }
}
