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
using System.Threading;

namespace AimyTest.Transaction_History
{
    public class TransactionHistory : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();
        private const int Rows = 3;
        // 'Credit Note' tab
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div[2]/ul/li[4]/a")]
        private IWebElement tabCreditNote { get; set; }

        private By totalRecordsOnInvoicePage = By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr");

        private By totalRecordsOnCreditNotePage = By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr");

        public int CompareFirstThreeRecordsOnCreditNotePageWithDetail(IWebDriver driver)
        {
            Thread.Sleep(5000);
            AimyClick(driver, tabCreditNote);
            Thread.Sleep(1000);
            int elements = driver.FindElements(totalRecordsOnCreditNotePage).Count;
            if (elements == 0)
                return -1;
            else if (elements >= 1)
            {
                for (int i = 1; i <= Rows; i++)
                {
                    var eachBookingTotal = driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr[" + (i) + "]/td[7]")).Text.ToString();
                    double iSubTotal = 0;
                    Thread.Sleep(1000);          
                    driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr[" + (i) + "]/td[10]/a")).Click();
                    Thread.Sleep(1000);
                    int LinesofDetailInvoice = driver.FindElements(By.XPath(".//*[@id='someContainerForCreditNoteLine']/div[2]/table/tbody/tr/td[1]")).Count;
                    if (LinesofDetailInvoice == 0) return -1;
                    if (LinesofDetailInvoice >= 1)
                    {
                        for (int j = 1; j <= LinesofDetailInvoice; j++)
                        {
                            var s = driver.FindElement(By.XPath(".//*[@id='someContainerForCreditNoteLine']/div[2]/table/tbody/tr[" + j + "]/td[1]")).Text.ToString().Replace("$", String.Empty);
                            double tmp = Convert.ToDouble(s);
                            iSubTotal = iSubTotal + tmp;
                        }
                        Thread.Sleep(5000);
                        driver.FindElement(By.XPath("html/body/div/div[1]/div/a/span")).Click();
                        if (Convert.ToDouble(eachBookingTotal.Replace("$", String.Empty)).Equals(iSubTotal))
                            continue;
                        return -1;
                    }
                }
                return 0;
            }
            return -1;
        }

        public int CompareFirstThreeRecordsOnInvoicePageWithDetail(IWebDriver driver)
        {
            Thread.Sleep(5000);
            int elements = driver.FindElements(totalRecordsOnInvoicePage).Count;
            if (elements == 0)
                return -1;
            else if (elements >= 1)
            {
                for (int i = 1; i<= Rows; i++) {
                    var eachBookingTotal = driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr[" + (i) + "]/td[9]")).Text.ToString();
                    double iSubTotal = 0;
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr[" + (i) + "]/td[14]/a[1]")).Click();
                    Thread.Sleep(1000);                    
                    int LinesofDetailInvoice = driver.FindElements(By.XPath(".//*[@id='someContainer']/div[2]/table/tbody/tr/td[7]")).Count;         
                    if (LinesofDetailInvoice == 0) return -1;
                    if (LinesofDetailInvoice >= 1)
                    {
                        for(int j = 1; j <= LinesofDetailInvoice; j++)
                        {                                       
                            var s = driver.FindElement(By.XPath(".//*[@id='someContainer']/div[2]/table/tbody/tr[" + j +"]/td[7]")).Text.ToString().Replace("$", String.Empty);
                            double tmp = Convert.ToDouble(s);
                            iSubTotal = iSubTotal + tmp;
                        }
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("html/body/div/div[1]/div/a/span")).Click();
                        if (Convert.ToDouble(eachBookingTotal.Replace("$", String.Empty)).Equals(iSubTotal))
                            continue;
                        return -1;
                    }                    
                }
                return 0;
            }           
            return -1;
        }
       
        private int LocateRecordOnCreditNotePage(IWebDriver driver, string whichParent, string whichDate)
        {                                                    
            var elementsName = driver.FindElements(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr/td[6]"));
            var elementsDate = driver.FindElements(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr/td[9]"));
            if (elementsName.Count > 0)
            {
                for (int i = 0; i < elementsName.Count; i++)
                {
                    if (elementsName.ElementAt(i).Text.Contains(whichParent))
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

        private int LocateRecordOnInvoicePage(IWebDriver driver, string whichParent, string whichDate)
        {                                                    
            var elementsName = driver.FindElements(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr/td[6]"));
            var elementsDate = driver.FindElements(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr/td[12]"));
            if (elementsName.Count > 0)
            {
                for (int i = 0; i < elementsName.Count; i++)
                {
                    if (elementsName.ElementAt(i).Text.Contains(whichParent))
                    {
                        if (elementsDate.ElementAt(i).Text.Contains(whichDate))
                        {
                            return i + 1;
                        }
                    }
                }
            }
            return -1;
        }

        public bool CheckCreditNote(IWebDriver driver, string whichParent, string whichDate)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            AimyClick(driver, tabCreditNote);
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            int i = LocateRecordOnCreditNotePage(driver, whichParent, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            if (null != driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr[" + i + "]/td[8]")))
                return true;
            else return false;
        }

        public bool CheckExtraInvoice(IWebDriver driver, string whichParent, string whichDate)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            int i = LocateRecordOnInvoicePage(driver, whichParent, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            if (null != driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr[" + i + "]/td[10]")))
                return true;
            else return false;
        }
    }
}
