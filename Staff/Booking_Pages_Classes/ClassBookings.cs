using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AimyTest.Booking_Pages_Classes
{
    public class ClassBookings
    {
        public bool ClassBookingWizard(IWebDriver driver, string[] dates, bool needSecondChild = false, bool needSecondClass = false)
        {

            Pages.ClassBookingPagesWizard1.StepsForBookingWizard1(driver, needSecondChild);
            Pages.ClassBookingPagesWizard2.StepsForBookingWizard2(driver);
            Pages.ClassBookingPagesWizard3.StepsForBookingWizard3(driver);
            Pages.ClassBookingPagesWizard4.StepsForBookingWizard4(driver);
            Pages.ClassBookingPagesWizard5.BookForOneDay(driver, dates);
            if (needSecondClass)
            {
                Pages.ClassBookingPagesWizard5.btnBookingAnotherClass.Click();
                Pages.ClassBookingPagesWizard4.StepsForBookingWizard4(driver, false);
                Pages.ClassBookingPagesWizard5.BookNextAvailableDay(driver);
            }
            Pages.ClassBookingPagesWizard5.StepsForBookingWizard5(driver);
            Pages.ClassBookingPagesWizard6.StepsForBookingWizard6(driver, needSecondChild);
            Pages.ClassBookingPagesWizard7.StepsForBookingWizard7(driver);
            return true;
        }
    }
}
