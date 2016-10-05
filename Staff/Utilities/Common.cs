using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace AimyTest.Utilities
{
   
    /// <summary>
    /// Common methods or functions can be used in different feature
    /// </summary>
    public class Common
    {
        
        // Auto element properties  IWebDriver driver
        //public static IWebDriver driver { get; set; }
        public static readonly log4net.ILog log = LogHelper.GetLogger();


        // public static IJavaScriptExecutor executor = Common.driver as IJavaScriptExecutor;
        // not working when run script
        
            //Added by Kathy
        public static string TestDescription;

        public static Screenshot Screen;

        public static void TakeScreenShot(IWebDriver driver, string ss)
        {
            WaitBySleeping(Utilities.GlobalVariable.iShortWait);
            try
            {
                Screen = ((ITakesScreenshot)driver).GetScreenshot();
                ss = DateTime.Now.ToString("[yy-MM-dd]-HH-mm-ss ") + ss;
                log.Debug    ("Screenshot name: " + ss);
                Screen.SaveAsFile("..\\images\\" + ss + ".png", System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                log.Error(e.StackTrace);

            }
        }
        public static void CreateFolder(string sFolder)
        {

            bool exists = System.IO.Directory.Exists(sFolder);
            if (!exists)
                System.IO.Directory.CreateDirectory(sFolder);
        }

        public static bool IsElementPresent(IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
   
        public static int TitleValidation(IWebDriver driver, string TestName, string sTitle)
        {
            log.Info("TitleValidation Test Case: ");


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            
            if (wait.Until((d) => { return d.Title == sTitle; })) 
            {
                log.Info("[PASS] " + TestName);
                return 0;
            }
            else
            {
                log.Info("Status = Fail : Expected: "
                     + sTitle +  " Actual: "
                     + driver.Title);
                return 1;
            }
        }
        public static void WriteTestData(string Test)
        {
            log.Info("Test Data: " + Test + Environment.NewLine);
        }
        public static void WriteStrokeLine()
        {
            log.Info("---------------------------------------------------------------");
        }
        /// <summary>
        /// Comparing messages: Output the test result to log file with snapshot
        /// </summary> 
        /// <param name="Actual"></param>
        /// <param name="Expected"></param>
        /// <param name="TestCaseDescription"></param>
        /// <param name="TestStepDesc"></param>
        /// <param name="TestCase"></param>
        /// <param name="result"></param>
        public static void PrintResult(IWebDriver driver, string Actual, string Expected, string TestCaseDescription, string TestStepDesc, bool TestCase, bool result)
        {
            string Desc;

            if (result) // no error
            {
                if (TestCase)
                {
                    Desc = TestCaseDescription;
                    log.Info(" [PASS] " + Desc);
                }
                else
                {
                    Desc = TestStepDesc;
                    log.Info(" [PASS] " + Desc );
                }

                log.Debug("Actual result: " + Actual);
                log.Debug("Expected result: " + Expected);

            }

            TakeScreenShot(driver, TestCaseDescription + TestStepDesc);
            if (result == false) // fail to compare
            {
              
                log.Info("[FAIL] " + TestCaseDescription + TestStepDesc);
                log.Info("Actual result: " + Actual);
                log.Info("Expected result: " + Expected);
                Assert.Fail();
            }

          
        }

        public static string GetObjectID(IWebDriver driver)
        {
            var executor = driver as IJavaScriptExecutor;

            string parentId = (string)executor.ExecuteScript("return document.URL.substring(document.URL.lastIndexOf('=')+1)");
            Console.WriteLine("ID has been created: " + parentId);
            return parentId;

        }
        public static string GetParentID(IWebDriver driver)
        {
            var executor = driver as IJavaScriptExecutor;

            string parentId = (string)executor.ExecuteScript("return document.URL.substring(document.URL.lastIndexOf('/')+1)");
            Console.WriteLine("ID has been created: " + parentId);
            return parentId;

        }

               /// <summary>
        /// Wait until the expected element loaded
        /// </summary>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        public static void WaitForElementLoad(IWebDriver driver, By by, int timeoutInSeconds)
        {
            // Create an “Explicit” wait to this driver:
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(by));
            }
        }

        public static void WaitBySleeping(int timeoutInMilliSeconds)
        {
            Thread.Sleep((int)timeoutInMilliSeconds);

        }

        //Added by Kathy 05/04/2016
        /// <summary>
        /// This method checks text values of Kendo UI dropdown list and clicks an item that has designated value
        /// Before calling this method, plz make sure to click the target DDL as Kendo UI DDL dynamically creates option lists when it is clicked
        /// </summary>
        /// <param name="value"> String need to be inputted</param>
        /// <param name="ddlPath">XPath of the dropdownlist</param>
        /// <returns></returns>
        public static bool SelectItemOfKendoDDL(IWebDriver driver, string value, string ddlPath)
        {
            try
            {
                bool found = false;

                // Find target DDL
                IReadOnlyCollection<IWebElement> Elements = driver.FindElements(By.XPath(ddlPath));

                log.Debug("Xpath of dropdown control: " + ddlPath);

                log.Debug("Number of items in the dropdown control: " + Elements.Count);
                // Check each item of DDL
                for (int i = 1; i < Elements.Count; i++)
                {
                    // Create a path for each item of DDL and find it
                    string itemPath = ddlPath + "[" + i + "]";
                    IWebElement target = driver.FindElement(By.XPath(itemPath));

                    if (target.Text == value)
                    {
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(target);
                        actions.Perform();
                        target.Click();
                        i = Elements.Count;
                        found = true;
                    }
                    log.Debug("Index i: " + i + "value: " + target.Text);
                }

                return found;
            }

            catch (Exception ex)
            {
                log.Error("Failure in SelectItemOfKendoDDL method : value = " + value + " " + ex.Message);

                return false;
            }
        }

        /// <summary>
        /// Selecting School and Site for enrolling Child
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="SchoolName"></param>
        public static void SelectSchoolName_frmPopUp(IWebDriver driver, string SchoolName)
        {
            var executor = driver as IJavaScriptExecutor;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(GlobalVariable.iLongWait));
            WaitBySleeping(GlobalVariable.iMediumWait);
            try
            {
                log.Debug("Start selecting a school");

                executor.ExecuteScript("document.getElementById('SchoolName').focus()");
                driver.FindElement(By.Id("SchoolName")).Click();
                executor.ExecuteScript("$('#category').val('" + SchoolName + "');");
                executor.ExecuteScript("$('#category').keyup();");
                // How to select from Grid 

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(GlobalVariable.iShortWait));
                string sSelectButtonPath = "/html/body/div[3]/div[2]/div/div/div[2]/div[2]/div[3]/table/tbody/tr/td[3]/a";
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(sSelectButtonPath)));
                var button = driver.FindElement(By.XPath(sSelectButtonPath));
                button.Click();


            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        /******************************* Added by Kathy ****************************************/
        /* This method takes index number and clicks designated option of Kendo UI DDL         */
        /* Before calling this method, plz make sure to click the target DDL                   */
        /* as Kendo UI DDL dynamically creates option lists when it is clicked                 */
        /***************************************************************************************/
        public static bool SelectKendoDDLByIndex(IWebDriver driver, int value, string ddlPath)
        {
            bool found = false;

            if ((value.Equals(null)) || (ddlPath.Equals(null)))
            {
                log.Info("Parameter error in SelectKendoDDLByIndex method!");
                return found;
            }

            else
            {
                try
                {
                    // Find target DDL
                    IReadOnlyCollection<IWebElement> Elements = driver.FindElements(By.XPath(ddlPath));

                    // Create a path to a target option
                    string itemPath = ddlPath + "[" + value.ToString() + "]";
                    IWebElement target = driver.FindElement(By.XPath(itemPath));

                    if (!target.Equals(null))
                    {
                        Actions actions = new Actions(driver);
                        actions.MoveToElement(target);
                        actions.Perform();
                        target.Click();
                        Thread.Sleep(1500);
                        found = true;
                    }

                    return found;
                }

                catch (Exception ex)
                {
                    log.Info("Failure in SelectKendoDDLByIndex method : value = " + value + " " + ex.Message);
                    return false;
                }
            }
        }

        /******************************* Added by Kathy ****************************************/
        /* This method takes Xpath to a Kendo Spin Control and a value to be entered           */
        /* It increments value by clicking "Increment Button"                                  */
        /***************************************************************************************/
        public static void IcrementKendoSpinCtrl(IWebDriver driver, string value, string spnPath)
        {
            if ((value.Equals(null)) || (spnPath.Equals(null)))
            {
                log.Info("Parameter error in IcrementKendoSpinCtrl method!");
            }

            else
            {
                try
                {
                    IWebElement target = driver.FindElement(By.XPath(spnPath));
                    int intValue = 0;

                    if (value.Trim().Substring(0, 1) == "$")
                    {
                        if (value.Trim().Contains("."))
                        {
                            intValue = int.Parse(value.Trim().Substring(1, value.Length - (value.IndexOf(".") + 1)));
                        }

                        else
                        {
                            intValue = int.Parse(value.Trim().Substring(1, value.Length - 1));
                        }
                    }

                    else
                    {
                        if (value.Trim().Contains("."))
                        {
                            intValue = int.Parse(value.Trim().Substring(0, value.Length - (value.IndexOf(".") + 1)));
                        }
                        else
                        {
                            intValue = int.Parse(value.Trim());
                        }
                    }

                    for (int i = 0; i < intValue; i++)
                    {
                        target.Click();
                    }
                }

                catch (Exception ex)
                {
                    log.Info("Failure in IcrementKendoSpinCtrl method : value = " + value + " " + ex.Message);
                }
            }
        }


        /************************************ Added by Kathy ****************************************************************/
        /* This method checks text values of Kendo UI dropdown list and clicks an option that has designated value          */
        /* Before calling this method, plz make sure to click the target DDL                                                */
        /* as Kendo UI DDL dynamically creates option lists when it is clicked                                              */
        /********************************************************************************************************************/
        public static bool SelectKendoDDLByTextValue(IWebDriver driver, string value, string ddlPath)
        {
            bool found = false;

            if ((value.Equals(null)) || (ddlPath.Equals(null)))
            {
                log.Info("Parameter error in SelectKendoDDLByTextValue method!");
                return found;
            }

            else
            {
                try
                {
                    // Find target DDL
                    IReadOnlyCollection<IWebElement> Elements = driver.FindElements(By.XPath(ddlPath));

                    // Check each item of DDL
                    for (int i = 1; i <= Elements.Count; i++)
                    {
                        // Create a path for each item of DDL and find it
                        
                        IWebElement target = driver.FindElements(By.XPath(ddlPath))[i];
                        if (target.Text == value)
                        {
                            Actions actions = new Actions(driver);
                            actions.MoveToElement(target);
                            actions.Perform();
                            target.Click();
                            Thread.Sleep(3000);
                            found = true;

                            Console.WriteLine(target.Text);
                        }
                    }

                    return found;
                }

                catch (Exception ex)
                {
                    log.Info("Failure in SelectKendoDDLByTextValue method : value = " + value + " " + ex.Message);
                    return false;
                }
            }

        }




        //******************************* Added by Kathy ****************************************/
        //* This method explicitly makes a driver wait until a target element becomes clickable */
        //***************************************************************************************/
        public static void WaitForElementClickable(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if ((timeoutInSeconds <= 0) || (by.Equals(null)))
            {
                log.Info("Parameter error in WaitForElementClickable method!");
            }

            else
            {
                try
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    wait.Until(ExpectedConditions.ElementToBeClickable(by));
                    Thread.Sleep(1000);
                }

                catch (Exception ex)
                {
                    log.Info("Failure in WaitForElementClickable method : " + Environment.NewLine + ex.Message);
                }
            }
        }

    }
}
