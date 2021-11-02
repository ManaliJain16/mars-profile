using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ProfilePage
    {       
        public void addProfile(IWebDriver driver, string University, string Country, string Title, string Degree, string YearofGraduation)
        {
            //Identify "University Name" textbox and input code
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys(University);

            //Identify "Country of College" dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select")).Click();

            //Select Country-India from dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[66]")).Click();

            //Identify "Title" dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select")).Click();

            //Select title-B.Sc from dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[6]")).Click();

            //Identify "Degree" textbox and input code
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys(Degree);

            //Identify "Year of graduation" dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select")).Click();

            //Select year-2020 from dropdown list
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[3]")).Click();

            //Select "Add" button 
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();
        }

        public string getCountry(IWebDriver driver)
        {            
            IWebElement newCountry = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
            return newCountry.Text;
        }

        public string getUniversity(IWebDriver driver)
        {
            //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr
            IWebElement newUniversity = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[2]"));
            return newUniversity.Text;
        }

        public string getTitle(IWebDriver driver)
        {
            IWebElement newTitle = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[3]"));
            return newTitle.Text;
        }
        
        public string getDegree(IWebDriver driver)
        {
            IWebElement newDegree = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]"));
            return newDegree.Text;
        }
        public string getGraduationYear(IWebDriver driver)
        {
            IWebElement newGraduationYear = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[5]"));
            return newGraduationYear.Text;
        }

        public void clickOnTab(IWebDriver driver, string tabName)
        {
            // TODO: click tab based on tab name
            //Click on Education tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }

        public void clearEducationRows(IWebDriver driver)
        {
            while (true)
            {
                try
                {
                    var deleteButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]"));
                    deleteButton.Click();
                    Thread.Sleep(1000);
                }
                catch (NoSuchElementException ex)
                {
                    // no more rows to delete
                    break;
                }                
            }
        }


        //SELLERS NAME
        public void updateName(IWebDriver driver, string firstName, string lastName)
        {
            // Identify FirstName Textbox, edit existing value and add new first name 
            Thread.Sleep(500);

            IWebElement firstNametextbox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[1]"));
            firstNametextbox.Clear();
            firstNametextbox.SendKeys(firstName);

            //Identify LastName Textbox, edit existing value and add new first name
            IWebElement lastNametextbox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[1]/input[2]"));
            lastNametextbox.Clear();
            lastNametextbox.SendKeys(lastName);

            // Press Save Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button")).Click();
        }

        public string getupdatedName(IWebDriver driver)
        {
            Thread.Sleep(500);                                
            IWebElement updatedName = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
            Thread.Sleep(300);
            return updatedName.Text;
        }
    }
}






