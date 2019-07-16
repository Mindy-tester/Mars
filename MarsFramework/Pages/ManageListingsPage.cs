using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

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
        private IWebElement manageListing { get; set; }



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
            IWebElement element1 = wait1.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));
            //int titleObjSize = Global.GlobalDefinitions.driver.FindElements(By.XPath("//th[contains(text(),'Title')]")).Count();
            //implict wait
            //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            try
            {
                IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

                for (int i = 0; i <= noOfPages.Count; i++)
                {

                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
                        Console.WriteLine(titleObj);
                        Console.WriteLine(categoryObj);
                        IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));

                        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        if (titleObj == "testing" && categoryObj == "Programming & Tech")
                        {
                            //Explicit wait for delete btn
                            WebDriverWait deleteListingWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
                            IWebElement deleteListingObj = deleteListingWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]")));
                            //Console.WriteLine(titleObj);
                            //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                            deleteListing.Click();
                            //Explicit wait for accept btn
                            WebDriverWait acceptBtnWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
                            IWebElement acceptBtnObj = acceptBtnWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='ui icon positive right labeled button']")));
                            //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                           acceptBtn.Click();

                         return;

                         }
                     }
                    //click next page
                    nextPageBtn.Click();
                 }
             }


            catch (Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "deleted failed");
            }



        }
        public void ValidatedDeletedSkills()
        {
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
                       
            IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));
            try
            {
                for (int i = 0; i <= noOfPages.Count; i++)
                {
                    for (int j = 1; j <= 5; j++)

                    {
                        var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                        var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                        if (titleObj == "testing" && categoryObj == "Programming & Tech")
                        {
                            Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted failed");
                        }

                    }
                    //click next page
                    nextPageBtn.Click();
                }
            }
            catch(Exception)
            {
                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted passed");
            }


        }

            //try
            //{
            //    while (true)
            //    {

            //        for (int j = 1; j <= 5; j++)

            //        {
            //            var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
            //            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //            var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
            //            IWebElement deleteListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + " ]/td[8]/i[3]"));
            //            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //            if (titleObj == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && categoryObj == "Writing & Translation")
            //            {
            //                //Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill Delete failed");
            //                continue;
            //            }
            //            
            //        }
            //        //click next page
            //        nextPageBtn.Click();

            //    }
            //}
            //catch (Exception e)
            //{
            //    Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill deleted successfully");
            //}

       

        public void UpdatedListing()
        {
            manageListing.Click();
            //Populate data from Excel
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SkillShare");
            SkillSharePage updSkillObj = new SkillSharePage();

            WebDriverWait manageListingWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(20));
            IWebElement manageListingObj = manageListingWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//h2[contains(text(),'Manage Listings')]")));

            //    IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//table[@class='ui striped table']//div[@class='ui buttons semantic-ui-react-button-pagination']//button[@role = 'button']"));

            //    Thread.Sleep(1000);
            //    for (int i = 1; i <= noOfPages.Count; i++)
            //    {
            //        Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //        for (int j = 1; j <= 5; j++)

            //        {
            //            var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
            //            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //            var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;
            //            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //            IWebElement updateListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[2]"));

            //            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //            if (titleObj == "testing" && categoryObj == "Programming & Tech")
            //            {
            //                updateListing.Click();
            //                Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //                updSkillObj.SkillShare();
            //                Global.Base.Test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Skill updated Successfully");
            //                return;
            //            }

            //        }
            //        //click next page
            //        nextPageBtn.Click();
            //    }

            //}


            //IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']"));
            IList<IWebElement> noOfPages = Global.GlobalDefinitions.driver.FindElements(By.XPath("//button[@class='ui button otherPage']"));

            for (int i = 0; i <= noOfPages.Count; i++)
            {

                for (int j = 1; j <= 5; j++)

                {
                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    var titleObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[3]")).Text;
                    var categoryObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[2]")).Text;

                    IWebElement updateListing = Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr[" + j + "]/td[8]/i[2]"));
                    Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    if (titleObj == "testing" && categoryObj == "Programming & Tech")
                    {
                        //Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        updateListing.Click();
                       Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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






