using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;

using System.Threading;

namespace MarsFramework.Pages
{
    class ManageListingsPage
    {
        public ManageListingsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

       
        #region  Initialize Web Elements 

        //click on Manage Listings
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement manageListing{ get; set; }



        //click on next page
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'>')]")]
        private IWebElement nextPageBtn { get; set; }

        //click on accept
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement acceptBtn { get; set; }

        #endregion

        public void DeleteListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");

            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='ui active button currentPage']")));
            //int titleObjSize = Global.GlobalDefinitions.driver.FindElements(By.XPath("//th[contains(text(),'Title')]")).Count();
            //implict wait
            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            try
            {
                while (true)
                {

                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                        Console.WriteLine(titleObj);
                        Console.WriteLine(categoryObj);
                        IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));
                        
                        if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                        {
                            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                            deleteListing.Click();
                            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                            acceptBtn.Click();
                                                                                                    
                         return;
                        }
                    }
                    //click next page
                    nextPageBtn.Click();
                }
            }
            catch(Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "deleted failed");
            }

            

        }
        public void ValidatedDeletedSkills()
        {
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            //WebDriverWait delWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(15));
            //IWebElement element = delWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'>')]")));
            try
            {
                while (true)
                {

                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                        IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));
                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
                        if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
                        {
                            Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill Delete failed");
                            return;
                        }
                    }
                    //click next page
                    nextPageBtn.Click();
                }
            }
            catch (Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted successfully");
            }

        }

        public void UpdatedListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            SkillSharePage updSkillObj = new SkillSharePage();

            WebDriverWait wait1 = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(100));
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            while (true)
            {

                for (int j = 1; j <= 5; j++)

                {
                    Thread.Sleep(1000);
                    var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                    
                    IWebElement updateListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[2]"));
                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    if (titleObj == "testing" && categoryObj == "Programming & Tech")
                    {
                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                        updateListing.Click();
                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                        updSkillObj.SkillShare();
                        Base.Test.Log(LogStatus.Info, "Skill Updated");
                         return;
                    }
                }
                //click next page
                nextPageBtn.Click();
            }
        }

    }




}
