using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace AimyTest.Booking_Pages_Classes
{
    public class ClassBookingPages_Wizard5 : MyElelment
    {

        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[2]/div/div[2]/input")]
        private IWebElement btnBookThisClass { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[3]/div/div[2]/div[1]/div/div/ul/li/div/div[1]")]
        private IWebElement btnBigBlue { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[4]/div[2]/div[3]/div/div[2]/div[1]/div/div/ul/li/div/div[2]/div/button[1]")]
        private IWebElement btnConfirm { get; set; }

        [FindsBy(How = How.Id, Using = "book-another-class-link")]
        public IWebElement btnBookingAnotherClass { get; set; }

        [FindsBy(How = How.Id, Using = "booking-confirm-booking-next-btn")]
        private IWebElement btnNext { get; set; }

        [FindsBy(How = How.Id, Using = "btn-complete-booking-button")]
        private IWebElement btnCompleteBooking { get; set; }

        //

        private static int i =0,  col=0;


        public void BookForOneDay(IWebDriver driver, string[] oneDay)
        {
            Thread.Sleep(2000);
            // get the calendar
            IWebElement table = driver.FindElement(By.ClassName("fc-day-grid"));
            // get tableRows: day and circle
            IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.ClassName("fc-content-skeleton"));
            
            int j = 0;
           
            // loop for location the date: record the row number and col number
            foreach (var row in tableRows)
            {
                i++;
                IReadOnlyCollection<IWebElement> days = row.FindElements(By.ClassName("fc-day-number"));

                foreach (var d in days)
                {
                    j++;
                    if (d.GetAttribute("data-date").Equals(oneDay[0]))
                    {
                        col = j - 1;
                        break;
                    }
                }
                j = 0;
                if (col != 0) break;
            }
            // loop for location the circle: click point
            int row_counter = 0;
            foreach (var row in tableRows)
            {
                row_counter++;

                if (row_counter == i)
                {

                    IWebElement target = row.FindElements(By.ClassName("fc-day-grid-event"))[col - 1];
                    target.Click();

                    AimyClick(driver, btnBigBlue);
                    Common.WaitBySleeping(GlobalVariable.iShortWait);
                    AimyClick(driver, btnConfirm);
                    
                    break;
                }
            }
        }

        public bool BookNextAvailableDay(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // get the calendar
            IWebElement table = driver.FindElement(By.ClassName("fc-day-grid"));
            // get tableRows: day and circle
            IReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.ClassName("fc-content-skeleton"));

            // loop for location the circle: click point
            int row_counter = 0;
            foreach (var row in tableRows)
            {
                row_counter++;

                if (row_counter == i)
                {

                    IWebElement target = row.FindElements(By.ClassName("fc-day-grid-event"))[col];
                    if(target!=null)
                    {
                        target.Click();
                        Thread.Sleep(5000);

                        AimyClick(driver, btnBigBlue);
                        Common.WaitBySleeping(GlobalVariable.iShortWait);
                        AimyClick(driver, btnConfirm);

                        return true;
                    }
                }
            }
            return false;
        }

        public void StepsForBookingWizard5(IWebDriver driver)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait);

            AimyClick(driver, btnNext);

            AimyClick(driver, btnCompleteBooking);

            Thread.Sleep(5000);
        }
    }
}
