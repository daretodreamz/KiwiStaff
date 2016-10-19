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

namespace AimyTest.Transaction_History
{
    public class TransactionHistory : MyElelment
    {
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // 'Credit Note' tab
        [FindsBy(How = How.XPath, Using = "html/body/div[3]/div/div[2]/ul/li[4]/a")]
        private IWebElement tabCreditNote { get; set; }

        private int PositionRecordOnCreditNotePage(IWebDriver driver, string whichParent, string whichDate)
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

        private int PositionRecordOnInvoicePage(IWebDriver driver, string whichParent, string whichDate)
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
            int i = PositionRecordOnCreditNotePage(driver, whichParent, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            if (null != driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[4]/div/div/div[2]/table/tbody/tr[" + i + "]/td[8]")))
                return true;
            else return false;
        }

        public bool CheckExtraInvoice(IWebDriver driver, string whichParent, string whichDate)
        {
            Common.WaitBySleeping(GlobalVariable.iShortWait * 20);
            int i = PositionRecordOnInvoicePage(driver, whichParent, whichDate);
            if (i == -1) throw new Exception("There is NOT any items available, Please check!");
            if (null != driver.FindElement(By.XPath("html/body/div[3]/div/div[2]/div[1]/div/div[1]/div[2]/table/tbody/tr[" + i + "]/td[10]")))
                return true;
            else return false;
        }
    }
}
