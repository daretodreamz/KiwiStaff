using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyTest.Booking_Pages
{
    class Bookings
    {
       public bool BookingWizard()
        {
            var step1 = new BookingPages_Wizard1();
            var step2 = step1.StepsForBookingWizard1();
            var step3 = step2.StepsForBookingWizard2();
            var step4 = step3.StepsForBookingWizard3();
            var step5 = step4.StepsForBookingWizard4();
            var step6 = step5.StepsForBookingWizard5();
            var step7 = step6.StepsForBookingWizard6();
            var step8 = step7.StepsForBookingWizard7();
            var final = step8.StepsForBookingWizard8();
            return final;
        }
    }
}
