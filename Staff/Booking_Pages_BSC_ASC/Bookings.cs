using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AimyTest.Booking_Pages_BSC_ASC
{
    public class Bookings
    {
       public bool BookingWizard(IWebDriver driver)
        {
            Pages.BookingPagesWizard1.StepsForBookingWizard1(driver);
            Pages.BookingPagesWizard2.StepsForBookingWizard2(driver);
            Pages.BookingPagesWizard3.StepsForBookingWizard3(driver);
            Pages.BookingPagesWizard4.StepsForBookingWizard4(driver);
            Pages.BookingPagesWizard5.StepsForBookingWizard5(driver);
            Pages.BookingPagesWizard6.StepsForBookingWizard6(driver);
            Pages.BookingPagesWizard7.StepsForBookingWizard7(driver);
            bool final = Pages.BookingPagesWizard8.StepsForBookingWizard8(driver);
            return final;
        }
    }
}
