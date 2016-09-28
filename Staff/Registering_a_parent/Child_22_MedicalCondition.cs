
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AimyTest.Registering_a_parent
{
    public class Child_22_MedicalCondition : MyElelment
    {
        public Child_22_MedicalCondition()
        {
            PageFactory.InitElements(Utilities.Common.driver, this);

        }
        private readonly log4net.ILog log = Utilities.LogHelper.GetLogger();

        // Button saveProceedBut
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/form/div/div[18]/div/input[1]")]
        public IWebElement btnSubmit { get; set; }

        // Button skipProceedBut
        [FindsBy(How = How.XPath, Using = ".//*[@id='body-container']/form/div/div[18]/div/input[2]")]
        public IWebElement btnCancel { get; set; }

        private IJavaScriptExecutor executor = Utilities.Common.driver as IJavaScriptExecutor;
        /// <summary>
        ///  medicalType 1: ADHD, 2: Asthma,  3: Diabetes, 4: Epilepsy, 5: Haemophilia, 6: Heart Problems, 7: Dairy Allergy, 8: Wheat Allergy, 9: Peneart Allergy, 99: Others
        /// </summary>
        /// <param name="medicalType"></param>
        /// <param name="medicalName"></param>
        /// <param name="medicalSeverity"></param>
        /// <param name="medicalSympotoms"></param>
        /// <param name="medicalTreatment"></param>
        public int TC_CRE_CHILD_07_MedicalCondition(int medicalType
                                    , string medicalName
                                    , string medicalSeverity
                                    , string medicalSympotoms
                                    , string medicalTreatment)
        {
            WebDriverWait wait = new WebDriverWait(Utilities.Common.driver, TimeSpan.FromSeconds(Utilities.GlobalVariable.iShortWait));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(btnSubmit));

                switch (medicalType)
                {
                    case 1: // "A.D.H.D":
                            //Input data for ADHD
                        Utilities.Common.driver.FindElement(By.Id("ADHD")).Click();
                        executor.ExecuteScript("$('#ADHDSeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#ADHDSymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#ADHDTreatment').val('" + medicalTreatment + "')");

                        //Uploading a file
                        //  executor.ExecuteScript("document.getElementByClassName('modalLink btn btn-default')[0].click();");
                        //   Common.driver.FindElement(By.Name("files")).SendKeys("D:\\LoginSucceed.png");
                        break;

                    case 2: // "Asthma":
                            //Input data for Asthma
                        Utilities.Common.driver.FindElement(By.Id("Asthma")).Click();
                        executor.ExecuteScript("$('#AsthmaSeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#AsthmaSymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#AsthmaTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 3: // "Diabetes":
                            //Input data for Diabetes 
                        Utilities.Common.driver.FindElement(By.Id("Diabetes")).Click();
                        executor.ExecuteScript("$('#DiabetesSeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#DiabetesSymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#DiabetesTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 4: // "Epilepsy":
                            //Input data for Epilepsy
                        Utilities.Common.driver.FindElement(By.Id("Epilepsy")).Click();
                        executor.ExecuteScript("$('#EpilepsySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#EpilepsySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#EpilepsyTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 5: // "Haemophilia":
                            //Input data for Haemophilia
                        Utilities.Common.driver.FindElement(By.Id("Haemophilia")).Click();
                        executor.ExecuteScript("$('#HaemophiliaSeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#HaemophiliaSymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#HaemophiliaTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 6: // "Heart Problems":
                            //Input data for Heart Problems
                        Utilities.Common.driver.FindElement(By.Id("HeartProblems")).Click();
                        executor.ExecuteScript("$('#HeartProblemsSeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#HeartProblemsSymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#HeartProblemsTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 7: // "Dairy Allergy":
                            //Input data for Dairy Allergy
                        Utilities.Common.driver.FindElement(By.Id("DairyAllergy")).Click();
                        executor.ExecuteScript("$('#DairyAllergySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#DairyAllergySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#DairyAllergyTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 8: // "Wheat Allergy":
                            //Input data for Wheat Allergy
                        Utilities.Common.driver.FindElement(By.Id("WheatAllergy")).Click();
                        executor.ExecuteScript("$('#WheatAllergySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#WheatAllergySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#WheatTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 9: // "Peanut Allergy":
                            //Input data for Wheat Allergy
                        Utilities.Common.driver.FindElement(By.Id("PeaNutAllergy")).Click();
                        executor.ExecuteScript("$('#PeaNutAllergySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#PeaNutAllergySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#PeaNutAllergyTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 10: // "Medicine Allergy":
                             //Input data for Wheat Allergy
                        Utilities.Common.driver.FindElement(By.Id("MedicineAllergy")).Click();
                        executor.ExecuteScript("$('#MedicineAllergySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#MedicineAllergySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#MedTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 11: // "Bee Sting Allergy":
                             //Input data for Wheat Allergy
                        Utilities.Common.driver.FindElement(By.Id("BeeStingAllergy")).Click();
                        executor.ExecuteScript("$('#BeeStingAllergySeverity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#BeeStingAllergySymptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#BeeTreatment').val('" + medicalTreatment + "')");

                        break;

                    case 99: // "Other":
                             //Input data for Wheat Allergy
                        Utilities.Common.driver.FindElement(By.Id("Other1")).Click();
                        executor.ExecuteScript("$('#Other1Name').val('" + medicalName + "')");
                        executor.ExecuteScript("$('#Other1Severity').data('kendoDropDownList').value('" + medicalSeverity + "')");
                        executor.ExecuteScript("$('#Other1Symptoms').val('" + medicalSympotoms + "')");
                        executor.ExecuteScript("$('#Other1Treatment').val('" + medicalTreatment + "')");

                        break;
                }
                Utilities.Common.WaitBySleeping(Utilities.GlobalVariable.iShortWait);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_07_MedicalCondition");
                log.Info("[PASS] TC_CRE_CHILD_07_MedicalCondition: Add medical condition for a child");
                AimyClick(btnSubmit);
            }
            catch (Exception e)
            {
                log.Error(e.Message);
                Utilities.Common.TakeScreenShot("TC_CRE_CHILD_07_MedicalCondition FAIL");
                log.Error("TC_CRE_CHILD_07_MedicalCondition: Add medical condition for a child: [FAIL]");
                return 1;
            }
            return 0;
            
        }
    }
}
