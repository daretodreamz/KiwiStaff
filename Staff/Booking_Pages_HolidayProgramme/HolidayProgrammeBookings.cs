using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AimyTest.Booking_Pages_HolidayProgramme
{
    public class HolidayProgrammeBookings
    {
        public bool HolidayProgrammeBookingWizard(IWebDriver driver, bool needSecondChild = false)
        {
            Pages.HolidayProgrammeBookingPagesWizard1.StepsForBookingWizard1(driver, needSecondChild);
            Pages.HolidayProgrammeBookingPagesWizard2.StepsForBookingWizard2(driver);
            Pages.HolidayProgrammeBookingPagesWizard3.StepsForBookingWizard3(driver);
            Pages.HolidayProgrammeBookingPagesWizard4.StepsForBookingWizard4(driver);
            return true;
        }
    }
}
