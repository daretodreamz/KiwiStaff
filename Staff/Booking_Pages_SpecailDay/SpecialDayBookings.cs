using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AimyTest.Booking_Pages_SpecialDay
{
    public class SpecialDayBookings
    {
        public bool SpecailDayBookingWizard(IWebDriver driver, bool needSecondChild = false)
        {
            Pages.SpecialDayBookingPagesWizard1.StepsForBookingWizard1(driver, needSecondChild);
            Pages.SpecialDayBookingPagesWizard2.StepsForBookingWizard2(driver);
            Pages.SpecialDayBookingPagesWizard3.StepsForBookingWizard3(driver);
            Pages.SpecialDayBookingPagesWizard4.StepsForBookingWizard4(driver);
            return true;
        }
    }
}
