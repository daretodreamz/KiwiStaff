using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Attendance_Manager;
using AimyTest.Booking_Manager;
using AimyTest.Booking_Pages_BSC_ASC;
using AimyTest.Booking_Pages_Classes;
using AimyTest.Booking_Pages_HolidayProgramme;
using AimyTest.Booking_Pages_SpecialDay;
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

        public static ClassBookings ClassBookingPage
        {
            get { return GetPage<ClassBookings>(); }
        }
        public static ClassBookingPages_Wizard1 ClassBookingPagesWizard1
        {
            get { return GetPage<ClassBookingPages_Wizard1>(); }
        }

        public static ClassBookingPages_Wizard2 ClassBookingPagesWizard2
        {
            get { return GetPage<ClassBookingPages_Wizard2>(); }
        }

        public static ClassBookingPages_Wizard3 ClassBookingPagesWizard3
        {
            get { return GetPage<ClassBookingPages_Wizard3>(); }
        }

        public static ClassBookingPages_Wizard4 ClassBookingPagesWizard4
        {
            get { return GetPage<ClassBookingPages_Wizard4>(); }
        }

        public static ClassBookingPages_Wizard5 ClassBookingPagesWizard5
        {
            get { return GetPage<ClassBookingPages_Wizard5>(); }
        }

        public static ClassBookingPages_Wizard6 ClassBookingPagesWizard6
        {
            get { return GetPage<ClassBookingPages_Wizard6>(); }
        }

        public static ClassBookingPages_Wizard7 ClassBookingPagesWizard7
        {
            get { return GetPage<ClassBookingPages_Wizard7>(); }
        }

        public static HolidayProgrammeBookings HolidayProgrammeBookingPage
        {
            get { return GetPage<HolidayProgrammeBookings>(); }
        }
        public static HolidayProgrammeBookingPages_Wizard1 HolidayProgrammeBookingPagesWizard1
        {
            get { return GetPage<HolidayProgrammeBookingPages_Wizard1>(); }
        }
        public static HolidayProgrammeBookingPages_Wizard2 HolidayProgrammeBookingPagesWizard2
        {
            get { return GetPage<HolidayProgrammeBookingPages_Wizard2>(); }
        }
        public static HolidayProgrammeBookingPages_Wizard3 HolidayProgrammeBookingPagesWizard3
        {
            get { return GetPage<HolidayProgrammeBookingPages_Wizard3>(); }
        }
        public static HolidayProgrammeBookingPages_Wizard4 HolidayProgrammeBookingPagesWizard4
        {
            get { return GetPage<HolidayProgrammeBookingPages_Wizard4>(); }
        }

        public static SpecialDayBookings SpecailDayBookingPage
        {
            get { return GetPage<SpecialDayBookings>(); }
        }
        public static SpecialDayBookingPages_Wizard1 SpecialDayBookingPagesWizard1
        {
            get { return GetPage<SpecialDayBookingPages_Wizard1>(); }
        }
        public static SpecialDayBookingPages_Wizard2 SpecialDayBookingPagesWizard2
        {
            get { return GetPage<SpecialDayBookingPages_Wizard2>(); }
        }
        public static SpecialDayBookingPages_Wizard3 SpecialDayBookingPagesWizard3
        {
            get { return GetPage<SpecialDayBookingPages_Wizard3>(); }
        }
        public static SpecialDayBookingPages_Wizard4 SpecialDayBookingPagesWizard4
        {
            get { return GetPage<SpecialDayBookingPages_Wizard4>(); }
        }
    }
}
