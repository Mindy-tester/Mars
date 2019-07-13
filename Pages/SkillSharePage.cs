using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using System.Threading;
using OpenQA.Selenium.Interactions;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class SkillSharePage
    {

        public SkillSharePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements    
        //Click on share skill
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement shareSkillBtn { get; set; }

        //Add Title
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement addTitle { get; set; }

        //Enter Description
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement addDescription { get; set; }

        //Add Tags
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement addTags { get; set; }

        //Select start date from calendar
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Start date']")]
        private IWebElement startDate { get; set; }

        //Select end date from calendar
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='End date']")]
        private IWebElement endDate { get; set; }

        //select days
        //[FindsBy(How = How.Name, Using = "Available")]
        //private IWebElement daysCheckBox { get; set; }

        //Start time
        //[FindsBy(How = How.XPath, Using = "//div[@class='twelve wide column']//div[2]//div[2]//input[1]")]
        //private IWebElement startTime { get; set; }
                    
        //Select credit from skill trade

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement credit { get; set; }

        //Select skill exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement skillExchange { get; set; }
                
        //Upload Work Samples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement uploadFile { get; set; }
                
        //Add is Active
       [FindsBy(How = How.XPath, Using = "//div[10]//div[2]//div[1]//div[2]//div[1]//input[1]")]
        private IWebElement addActive { get; set; }
        
        //Click Save
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        private IWebElement saveBtn { get; set; }

        //click on next page
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement nextPageBtn { get; set; }
        #endregion

        public void SkillShare()
        {
            WebDriverWait wait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@class='ui basic green button']")));


            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            shareSkillBtn.Click();

            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);

            //add Title
            addTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //add Description
            addDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("categoryId")));


            //Select Category
            SelectElement categoryObj = new SelectElement(Global.GlobalDefinitions.driver.FindElement(By.Name("categoryId")));
            categoryObj.SelectByValue("3");

            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            //Select Sub Category

            SelectElement subCategoryObj = new SelectElement(Global.GlobalDefinitions.driver.FindElement(By.Name("subcategoryId")));
            subCategoryObj.SelectByIndex(2);
             //add Tags
               addTags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            addTags.SendKeys(Keys.Enter);


            //Select  Service type

            IList<IWebElement> serviceRadioBtnO = Global.GlobalDefinitions.driver.FindElements(By.Name("serviceType"));

            // Create a boolean variable which will hold the value (True/False)
            Boolean bValue = false;

            // This statement will return True, in case of first Radio button is selected
            bValue = serviceRadioBtnO.ElementAt(0).Selected;

            // This will check that if the bValue is True means if the first radio button is selected
            if (bValue == true)
            {
                // This will select Second radio button, if the first radio button is selected by default
                serviceRadioBtnO.ElementAt(1).Click();
            }
            else
            {
                // If the first radio button is not selected by default, the first will be selected
                serviceRadioBtnO.ElementAt(0).Click();
            }


            //Select Location Type

            IList<IWebElement> loacationRadioBtnO = Global.GlobalDefinitions.driver.FindElements(By.Name("locationType"));
            Boolean bVal = false;

            bVal = loacationRadioBtnO.ElementAt(0).Selected;

            if (bVal == true)
            {
                loacationRadioBtnO.ElementAt(1).Click();
            }
            else
            {
                loacationRadioBtnO.ElementAt(0).Click();
            }

            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Enter date in startdate

            startDate.SendKeys("07252019");

            //Press tab to shift focus to End date
            startDate.SendKeys(Keys.Tab);
            //Enter date in end date 
            endDate.SendKeys("07302019");

            //Press tab to shift focus to End date
            startDate.SendKeys(Keys.Tab);
            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            //count number of days 
            //IList<IWebElement> days = Global.GlobalDefinitions.driver.FindElements(By.Name("Available"));
            int noOfDays = Global.GlobalDefinitions.driver.FindElements(By.Name("Available")).Count();

            for (var i = 1; i <= noOfDays; i++)
            {
                var daysObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[1]/div/label")).Text;
                var daysChekBox = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[1]/div/input"));
                var startTime = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[2]/input"));
                var endTime = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[" + (i + 1) + "]/div[3]/input"));
                if (daysObj == "Sun")

                {
                    daysChekBox.Click();
                    daysChekBox.SendKeys(Keys.Tab);
                    startTime.SendKeys("0940am");
                    daysChekBox.SendKeys(Keys.Tab);
                    endTime.SendKeys("0500pm");
                   // Thread.Sleep(1000);
                }
                else
                {
                    if (daysObj == "Tue")
                    {
                        daysChekBox.Click();
                        daysChekBox.SendKeys(Keys.Tab);
                        startTime.SendKeys("0800am");
                        daysChekBox.SendKeys(Keys.Tab);
                        endTime.SendKeys("0310pm");


                    }
                    else
                    {
                        if (daysObj == "Sat")
                        {
                            daysChekBox.Click();
                            daysChekBox.SendKeys(Keys.Tab);
                            startTime.SendKeys("0800am");
                            daysChekBox.SendKeys(Keys.Tab);
                            endTime.SendKeys("0310pm");
                            break;
                        }
                    }
                }
            }


            //Select SkillTrade

            IList<IWebElement> skillTradeObj = Global.GlobalDefinitions.driver.FindElements(By.Name("skillTrades"));
            Boolean val = false;

            val = skillTradeObj.ElementAt(0).Selected;

            if (val == true)
            {
                skillTradeObj.ElementAt(1).Click();
                Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }
            else
            {
                skillTradeObj.ElementAt(0).Click();
                Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                skillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill-Exchange"));
            }

            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            //select file for work sample

            uploadFile.Click();
            //create a AutoIT class and object
            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(1000);
            autoIt.Send(@"C:\Users\minty\OneDrive\Desktop\SampleImage");
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            autoIt.Send("{Enter}");

            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            // Select Active
            addActive.Click();


            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);

            //click Save

            saveBtn.Click();
            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            //Base.Test.Log(LogStatus.Info, "Added Skill");


        }


        public void ValidateTheSkillAdded()
        {
            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            //int titleObjSize = Global.GlobalDefinitions.driver.FindElements(By.XPath("//th[contains(text(),'Title')]")).Count();

            while (true)
            {
               
                for (int j =1; j<= 5; j++)

                {
                    var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                    if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                    {
                        Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill added Successfully");
                        return;
                    }
                    
                }
                //click next page
                nextPageBtn.Click();

            }




        }



        
       

    }
}
    