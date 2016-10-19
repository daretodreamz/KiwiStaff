using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AimyTest.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;

namespace AimyTest.Booking_Reconciliation
{
    public class BookingReconciliation : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        static private string sURL;

        // Filter 'Invoice and Credit Note'
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div[2]/div/div[1]/div/span")]
        private IWebElement ddlFilter { get; set; }
        //kiwi-confirm-yes
        [FindsBy(How = How.Id, Using = "kiwi-confirm-yes")]
        private IWebElement btnOK { get; set; }

        //list of Date 
        //html/body/div[3]/div[2]/div/div[3]/table/tbody/tr/td[4]/span

        //list of ChildName 
        //html/body/div[3]/div[2]/div/div[3]/table/tbody/tr/td[5]/span[1]

        //list of Credit Note button
        //html/body/div[3]/div[2]/div/div[3]/table/tbody/tr/td[12]/span/button[1]

        private void DoScrollTo(IWebDriver driver, By by)
        {
            System.Drawing.Point point = ((RemoteWebElement)driver.FindElement(by)).LocationOnScreenOnceScrolledIntoView;
        }

        private int PositionChild(IWebDriver driver, string childName, string whichDate)
        {
            var elementsName = driver.FindElements(By.XPath("html/body/div[3]/div[2]/div/div[3]/table/tbody/tr/td[5]/span[1]"));
            var elementsDate = driver.FindElements(By.XPath("html/body/div[3]/div[2]/div/div[3]/table/tbody/tr/td[4]/span"));
            if (elementsName.Count > 0)
            {
                for (int i = 0; i < elementsName.Count; i++)
                {
                    if (elementsName.ElementAt(i).Text.Contains(childName))
                    {
                        if(elementsDate.ElementAt(i).Text.Contains(whichDate))
                        {
                            return i + 1;
                        }                        
                    }
                }
            }
            return -1;
        }

        public bool CreateCreditNote(IWebDriver driver, string whichChild, string whichDate)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            DoScrollTo(driver, By.XPath("html/body/div[3]/div[2]/div/div[1]/div/span/span/span[2]/span"));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, ddlFilter);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Common.SelectKendoDDLByTextValue(driver, "Credit Note", "html/body/div[12]/div/ul/li");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            int i = PositionChild(driver, whichChild, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, driver.FindElement(By.XPath("html/body/div[3]/div[2]/div/div[3]/table/tbody/tr[" + i + "]/td[12]/span/button[1]")));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnOK);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            return true;
        }

        public bool GenerateInvoice(IWebDriver driver, string whichChild, string whichDate)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            DoScrollTo(driver, By.XPath("html/body/div[3]/div[2]/div/div[1]/div/span/span/span[2]/span"));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, ddlFilter);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            Common.SelectKendoDDLByTextValue(driver, "Invoice", "html/body/div[12]/div/ul/li");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            int i = PositionChild(driver, whichChild, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, driver.FindElement(By.XPath("html/body/div[3]/div[2]/div/div[3]/table/tbody/tr[" + i + "]/td[12]/span/button[1]")));
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, btnOK);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            return true;
        }
    }
}
