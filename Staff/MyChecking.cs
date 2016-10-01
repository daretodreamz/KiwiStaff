using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AimyTest
{
    public class MyChecking
    {
        //public static IWebDriver driver { get; set; }

        private static readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        public static string script, ActualText, expectedText, TestDescription;

       
        public bool Verify_ParentName(IWebDriver driver, string sscript, string sExpectedText1)
        {
            var executor = driver as IJavaScriptExecutor;

            string ActualText = (string)executor.ExecuteScript(sscript);

            if (!ActualText.Contains(sExpectedText1)) // wrong Parent name display
            {
                log.Error("[Fail] to compare Text as expected");
                Utilities.Common.TakeScreenShot(driver, "FAIL- REG_PARENT_02 Registering a new second parent");
                log.Debug("ActualText: " + ActualText);
                log.Debug("expectedText: " + sExpectedText1);
                return false;

            }
            return true;
        }
        /// <summary>
        /// Verify for the list of information Name, email, school, DOB .. for Child, Second parent, EM contacts ...
        /// </summary>
        /// <param name="sscript"></param>
        /// <param name="sExpectedText1"></param>
        /// <param name="sExpectedText2"></param>
        /// <param name="sExpectedText3"></param>
        /// <param name="sExpectedText4"></param>
        /// <returns></returns>
        public bool Verify_ParentChildInfo(IWebDriver driver, string sscript, string sExpectedText1, string sExpectedText2, string sExpectedText3, string sExpectedText4)
        {
            var executor = driver as IJavaScriptExecutor;

            string ActualText = (string)executor.ExecuteScript(sscript);

            if (!ActualText.Contains(sExpectedText1)) // wrong Parent name display
            {
                log.Error("[Fail] to compare Text as expected");
                log.Debug("ActualText: " + ActualText);
                log.Debug("expectedText: " + sExpectedText1);
                return false;

            }
            else log.Debug("[PASS] Comparing for " + sExpectedText1);
            if (sExpectedText2 != null && !ActualText.Contains(sExpectedText2))
            {
                log.Error("[Fail] to compare Text as expected");
                log.Debug("ActualText: " + ActualText);
                log.Debug("expectedText: " + sExpectedText2);
                return false;

            
        }
            else log.Debug("[PASS] Comparing for " + sExpectedText2);
            if (sExpectedText3 != null && !ActualText.Contains(sExpectedText3))
            {
                log.Error("[Fail] to compare Text as expected");
                log.Debug("ActualText: " + ActualText);
                log.Debug("expectedText: " + sExpectedText3);
                return false;

            }
            else log.Debug("[PASS] Comparing for " + sExpectedText3);

            if (sExpectedText4 != null && !ActualText.Contains(sExpectedText4))
            {
                log.Error("[Fail] to compare Text as expected");
                log.Debug("ActualText: " + ActualText);
                log.Debug("expectedText: " + sExpectedText4);
                return false;

            }
            else log.Debug("[PASS] Comparing for " + sExpectedText4);

            Utilities.Common.TakeScreenShot(driver, "Verify Profile Info displayed");

            return true;
        }
    }
}
