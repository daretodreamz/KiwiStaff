using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using AimyTest.Utilities;

namespace AimyTest.Term_programs
{

    //This class is for testing "Add Term Program" function
    class CreateTermProgramPage
    {
        IWebDriver driver = null;
        public CreateTermProgramPage(IWebDriver _driver)
        {
            driver = _driver;
            PageFactory.InitElements(driver, this);
        }

        public static readonly log4net.ILog log = LogHelper.GetLogger();
        
        private const string TAB_TERM_PROGRAM = "/html/body/div[3]/div[1]/ul/li[1]/a/span";
        private const string TP_PATH_ADD_TERM_PROGRAM = "/html/body/div[3]/div[1]/div[1]/div/div[1]/a";
        private const string TP_PATH_PROGRAM_NAME = "/html/body/div[9]/div[2]/div/div[4]/input";
        private const string TP_PATH_CAT_DDL = "/html/body/div[9]/div[2]/div/div[6]/span/span/span[2]/span";

        private const string TP_PATH_CAT = "/html/body/div[10]/div/ul/li";
        private const string TP_PATH_S_TIME = "/html/body/div[11]/div/ul/li";
        private const string TP_PATH_E_TIME = "/html/body/div[12]/div/ul/li";
        private const string TP_PATH_MIN_AGE = "/html/body/div[9]/div[2]/div/div[18]/span/span/span/span[1]/span";
        private const string TP_PATH_MAX_AGE = "/html/body/div[9]/div[2]/div/div[20]/span/span/span/span[1]/span";
        private const string TP_PATH_FT_RATE = "/html/body/div[9]/div[2]/div/div[22]/span/span/span/span[1]/span";
        private const string TP_PATH_PT_RATE = "/html/body/div[9]/div[2]/div/div[24]/span/span/span/span[1]/span";
        private const string TP_PATH_C_RATE = "/html/body/div[9]/div[2]/div/div[26]/span/span/span/span[1]/span";

        private const string TP_PATH_CASUAL_CODE = "/html/body/div[15]/div/ul/li";
        private const string TP_PATH_TRACKING_CAT = "/html/body/div[16]/div/ul/li";
        private const string TP_PATH_TRACKING_OPT = "/html/body/div[17]/div/ul/li";

        private const string TP_PATH_CASUAL_CODE_DDL = "/html/body/div[9]/div[2]/div/div[32]/span/span/span/span";

        private const string TP_PATH_TRACKING_CAT_DDL = "/html/body/div[9]/div[2]/div/div[36]/span/span/span[2]";
        private const string TP_PATH_TRACKING_OPT_DDL = "/html/body/div[9]/div[2]/div/div[38]/span/span";
        private const string TP_PATH_S_TIME_DDL = "/html/body/div[9]/div[2]/div/div[14]/span/span/span/span";
        private const string TP_PATH_E_TIME_DDL = "/html/body/div[9]/div[2]/div/div[16]/span/span/span/span";

        private const string TP_PATH_SAVE_BTN = "html/body/div[9]/div[2]/div/div[39]/a[1]";
        private const string TP_LIST_TABLE = "html/body/div[3]/div[1]/div[1]/div/div[3]/table";


        //Term Program Tab
        [FindsBy(How = How.Id, Using = "programs")]
        public IWebElement btnTermProgram { get; set; }

        //Add New Program
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/div/div[1]/a")]
        public IWebElement btnAddNewProgram { get; set; }

        //Program Name
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[4]/input")]
        public IWebElement txtProgramName { get; set; }

        //Category DDL 
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[6]/span/span/span[2]/span")]
        public IWebElement ddlCategory { get; set; }

        //Description 
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[8]/textarea")]
        public IWebElement txtDescription { get; set; }

        //Tag
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[10]/ul/li/input")]
        public IWebElement txtTag { get; set; }

        //Start Time
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[14]/span/span/span/span")]
        public IWebElement ddlStartTime { get; set; }

        //End Time
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[16]/span/span/span/span")]
        public IWebElement ddlEndTime { get; set; }

        //Min Age
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[18]/span/span/input[2]")]
        public IWebElement spnMinAge { get; set; }

        //Max Age
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[20]/span/span/input[2]")]
        public IWebElement spnMaxAge { get; set; }

        //Full Time Rate
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[22]/span/span/input[2]")]
        public IWebElement spnFullTimeRate { get; set; }

        //Part Time Rate
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[24]/span/span/input[2]")]
        public IWebElement spnPartTimeRate { get; set; }

        //Casual Rate
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[26]/span/span/input[2]")]
        public IWebElement spnCasualRate { get; set; }

        //Full Time Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[28]/span/span/input")]
        public IWebElement ddlFullTimeCode { get; set; }

        //Part Time Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[30]/span/span/input")]
        public IWebElement ddlPartTimeCode { get; set; }

        //Casual Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[32]/span/span/input")]
        public IWebElement ddlCasualCode { get; set; }

        //Tracking Category
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[36]/span/span/span[2]")]
        public IWebElement ddlTrackingCategory { get; set; }

        //Tracking Option
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[38]/span/span")]
        public IWebElement ddlTrackingOption { get; set; }

        //Save
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[39]/a[1]")]
        public IWebElement btnSave { get; set; }

        //Cancel
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[39]/a[2]")]
        public IWebElement btnCancel { get; set; }

        //Error message for Name
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[4]/div")]
        public IWebElement msgName { get; set; }

        //Error message for Category
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[6]/span/div")]
        public IWebElement msgCategory { get; set; }

        //Error message for Start Time
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[14]/span/span/div")]
        public IWebElement msgSTime { get; set; }

        //Error message for End Time
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[16]/span/span/div")]
        public IWebElement msgETime { get; set; }

        //Error message for Min Age
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[18]/span/span/div")]
        public IWebElement msgMAge { get; set; }

        //Error message for Full Time Rate
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[22]/span/span/div")]
        public IWebElement msgFTRate { get; set; }

        //Error message for Full Time Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[28]/span/div")]
        public IWebElement msgFTCode { get; set; }

        //Error message for Part Time Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[30]/span/div")]
        public IWebElement msgPTCode { get; set; }

        //Error message for Casual Code
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[32]/span/div")]
        public IWebElement msgCCode { get; set; }

        //Error message for Tracking Category
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[36]/span/div")]
        public IWebElement msgTCategory { get; set; }

        //Error message for Tracking Option
        [FindsBy(How = How.XPath, Using = "/html/body/div[9]/div[2]/div/div[38]/span/div")]
        public IWebElement msgTOpt { get; set; }

        //View Detail Link of the first row of the Term Program list
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/div/div[3]/table/tbody/tr[1]/td[6]/div/span")]
        public IWebElement lnkViewDetail { get; set; }

        //Edit Link of the first row of the Term Program list
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/div/div[3]/table/tbody/tr[1]/td[20]/a[1]/span")]
        public IWebElement lnkEdit { get; set; }

        //Delete Link of the first row of the Term Program list
        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[1]/div/div[3]/table/tbody/tr[1]/td[20]/a[2]/span")]
        public IWebElement lnkDelete { get; set; }
                                           

        public void FillInTermProgramForm(string programURL, string tpName, int tpCatIdex,
            string tpDesc, string tpTag, int tpSTimeIndex, int tpETimeIndex, string tpMinAge,
            string tpMaxAge, string tpFTRate, string tpPTRate, string tpCasualRate,
            string tpFTCode, string tpPTCode, string tpCasualCode,
            int tpTrackingCatIndex, int tpTrackingOptIndex)
            {
                try
                {
                driver.Navigate().GoToUrl(GlobalVariable.sURL + programURL);
                Common.WaitForElementClickable(driver, By.XPath(TAB_TERM_PROGRAM), 30);

                btnTermProgram.Click();
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_ADD_TERM_PROGRAM), 30);

                btnAddNewProgram.Click();
                Common.WaitForElementLoad(driver, By.XPath(TP_PATH_PROGRAM_NAME), 30);

                //Scroll up to the top
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0)");

                Thread.Sleep(3000);

                //Enter program name
                txtProgramName.SendKeys(tpName);

                /*** Program Category DDL ***/
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_CAT_DDL), 30);

                Actions actions = new Actions(driver);
                actions.MoveToElement(ddlCategory);
                actions.Perform();

                ddlCategory.Click();

                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_CAT), 30);

                if (!Common.SelectKendoDDLByIndex(driver, tpCatIdex, TP_PATH_CAT))
                {
                    log.Info("Failure in Program Category DDL!" + Environment.NewLine + "Term Program Creation");
                }

                //Enter description
                txtDescription.SendKeys(tpDesc);

                //Enter tags
                txtTag.SendKeys(tpTag);

                /*** Start Time DDL ***/
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_S_TIME_DDL), 40);

                actions = new Actions(driver);
                actions.MoveToElement(ddlStartTime);
                actions.Perform();

                Thread.Sleep(3000);
                ddlStartTime.Click();

                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_S_TIME), 40);

                if (!Common.SelectKendoDDLByIndex(driver, tpSTimeIndex, TP_PATH_S_TIME))
                {
                    log.Info("Failure in Start Time DDL!" + Environment.NewLine + "Term Program Creation");
                }

                /*** End Time DDL ***/
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_E_TIME_DDL), 30);

                actions = new Actions(driver);
                actions.MoveToElement(ddlEndTime);
                actions.Perform();

                ddlEndTime.Click();
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_E_TIME), 30);

                if (!Common.SelectKendoDDLByIndex(driver, tpETimeIndex, TP_PATH_E_TIME))
                {
                    log.Info("Failure in End Time DDL!" + Environment.NewLine + "Term Program Creation");
                }

                //Min age
                Thread.Sleep(3000);
                Common.IcrementKendoSpinCtrl(driver, tpMinAge, TP_PATH_MIN_AGE);
                //Max age
                Common.IcrementKendoSpinCtrl(driver, (int.Parse(tpMaxAge) - int.Parse(tpMinAge) - 1).ToString(), TP_PATH_MAX_AGE);
                //Daily full time rate
                Common.IcrementKendoSpinCtrl(driver, tpFTRate, TP_PATH_FT_RATE);
                //Daily part time rate
                Common.IcrementKendoSpinCtrl(driver, tpPTRate, TP_PATH_PT_RATE);
                //Daily casual rate
                Common.IcrementKendoSpinCtrl(driver, tpCasualRate, TP_PATH_C_RATE);

                //Scroll down the page
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - ((document.body.scrollHeight)/2))");

                /*** Full Time Code ***/
                Thread.Sleep(2000);
                ddlFullTimeCode.SendKeys(tpFTCode);

                /*** Part Time Code ***/
                Thread.Sleep(2000);
                ddlPartTimeCode.SendKeys(tpPTCode);

                /*** Casual Code ***/
                Thread.Sleep(3000);
                actions = new Actions(driver);
                actions.MoveToElement(ddlCasualCode);
                actions.Perform();
                ddlCasualCode.SendKeys(tpCasualCode);

                /*** Tracking Category DDL ***/
                //Utilities.Common.WaitForElementClickable(By.XPath(TP_PATH_TRACKING_CAT_DDL), 30);

                actions = new Actions(driver);
                actions.MoveToElement(ddlTrackingCategory);
                actions.Perform();

                ddlTrackingCategory.Click();

                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_TRACKING_CAT), 30);

                if (!Common.SelectKendoDDLByIndex(driver, tpTrackingCatIndex, TP_PATH_TRACKING_CAT))
                {
                    log.Info("Failure in Tracking Category DDL!" + Environment.NewLine + "Term Program Creation");
                }

                /*** Tracking Option DDL ***/
                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_TRACKING_OPT_DDL), 30);

                actions = new Actions(driver);
                actions.MoveToElement(ddlTrackingOption);
                actions.Perform();

                ddlTrackingOption.Click();

                Common.WaitForElementClickable(driver, By.XPath(TP_PATH_TRACKING_OPT), 30);

                if (!Common.SelectKendoDDLByIndex(driver, tpTrackingOptIndex, TP_PATH_TRACKING_OPT))
                {
                    log.Info("Failure in Tracking Option DDL!" + Environment.NewLine + "Special Program Creation");
                }

                log.Info(" Program name: " + tpName + Environment.NewLine
                  + " Category: " + tpCatIdex + Environment.NewLine
                  + " Description: " + tpDesc + Environment.NewLine
                  + " Tag: " + tpTag + Environment.NewLine
                  + " Start time: " + tpSTimeIndex + Environment.NewLine
                  + " End time: " + tpETimeIndex + Environment.NewLine
                  + " Min age: " + tpMinAge + Environment.NewLine
                  + " Max age: " + tpMaxAge + Environment.NewLine
                  + " Full time rate: " + tpFTRate + Environment.NewLine
                  + " Part time rate: " + tpPTRate + Environment.NewLine
                  + " Casual rate: " + tpCasualRate + Environment.NewLine
                  + " Full time code: " + tpFTCode + Environment.NewLine
                  + " Part time code: " + tpPTCode + Environment.NewLine
                  + " Casual code: " + tpCasualCode + Environment.NewLine
                  + " Tracking category: " + tpTrackingCatIndex + Environment.NewLine
                  + " Tracking option: " + tpTrackingOptIndex
                  );


                //Take a screenshot and save it 
                Common.TakeScreenShot(driver, DateTime.Now.ToString("[MM-dd]-HH-mm-ss ") + Common.TestDescription + "BeforeSave2");
                
                //Scroll up to the top
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0)");

                //Take a screenshot and save it 
                Common.TakeScreenShot(driver, DateTime.Now.ToString("[MM-dd]-HH-mm-ss ") + Common.TestDescription + "BeforeSave1");

                //Save data
                btnSave.Click();

            }

            catch (Exception ex)
            {
                log.Info("Exception in new special program creation... " + ex.Message);
            }
        }
    }

}

