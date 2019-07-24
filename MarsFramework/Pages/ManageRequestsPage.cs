using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsFramework.Pages
{
    class ManageRequestsPage
    {
        public ManageRequestsPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region
        //Intilaize web elements

        //click on Recieved Requests
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Received Requests')]")]
        private IWebElement recievedRequests { get; set; }

        //click on sent requests
        [FindsBy(How =How.XPath, Using = "//a[contains(text(),'Sent Requests')]")]
        private IWebElement sentRequests { get; set; }

        //Enter skill in seach skills
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search skills']")]
        private IWebElement searchSkills { get; set; }

        //click on all categories
        [FindsBy(How = How.XPath, Using = "//b[contains(text(),'All Categories')]")]
        private IWebElement allCategories { get; set;}


        //click on chat
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Chat')]")]
        private IWebElement chatButton { get; set; }

        #endregion

        public void Requests()
        {

            Actions manageRequestaction = new Actions(Global.GlobalDefinitions.driver);
            manageRequestaction.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();

            WebDriverWait recievedRequetsWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement recievedRequestObj = recievedRequetsWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Received Requests')]")));
            recievedRequests.Click();

            Actions action = new Actions(Global.GlobalDefinitions.driver);
            action.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[contains(text(), 'Manage Requests')]"))).Click().Build().Perform();

            WebDriverWait sentRequetsWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement sentRequestObj = sentRequetsWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Sent Requests')]")));
            sentRequests.Click();
          

            
        }

        public void SearchSkills()
        {
            //Populate data from Excel
           //GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SearchSkills");
            WebDriverWait skillWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement skillObj = skillWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Search skills']")));

           //Enter skill in skill search
            searchSkills.SendKeys("Testing");
            searchSkills.SendKeys(Keys.Enter);

            //Explicit wait for All categories
            WebDriverWait allCategoriesWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement allCategoriesObj = allCategoriesWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//b[contains(text(),'All Categories')]")));


            //Actions cat = new Actions(Global.GlobalDefinitions.driver);
            //cat.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]"))).Click().Build().Perform();

            //click on all category
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'All Categories')]")).Click();

            //Explicit wait for categories
            WebDriverWait categoriesWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            IWebElement categoriesObj = categoriesWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]")));


            //Actions clickCategory = new Actions(Global.GlobalDefinitions.driver);
            //clickCategory.MoveToElement(Global.GlobalDefinitions.driver.FindElement(By.XPath("//a[@role = 'listitem']//b[text() = 'Writing & Translation']"))).Click().Build().Perform();
            
            //click on category
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]")).Click();

            //wait for sub category
            //WebDriverWait subCategoriesWait = new WebDriverWait(Global.GlobalDefinitions.driver, TimeSpan.FromSeconds(10));
            //IWebElement subCategoriesObj = subCategoriesWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]")));

            ////click on sub category
            //Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[4]")).Click();

            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //click onsite
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Onsite')]")).Click();

            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //click on online 
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//button[contains(text(),'Online')]")).Click();

            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            //click on chat button
            chatButton.Click();

            Global.GlobalDefinitions.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //click on notification
            Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui top left pointing dropdown item']")).Click();






            //IList<IWebElement> categoryTxt = Global.GlobalDefinitions.driver.FindElements(By.XPath("//a[@class= 'item subcategory']"));

            //for (int i = 1; i <= categoryTxt.Count; i++)
            //{
            //    var catObj = Global.GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'+ i +')]"));
            //    Thread.Sleep(1000);
            //    if (catObj.)
            //    {
            //        // Actions clickCategory = new Actions(Global.GlobalDefinitions.driver);
            //        //clickCategory.DoubleClick(Global.GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/div/a[" + i + "]"))).Build().Perform();
            //        Global.GlobalDefinitions.driver.FindElement(By.XPath("//b[contains(text(),'+ i +')]")).Click();
            //        Console.WriteLine("passed");


            //    }
            //}

        }


    }
}
           
