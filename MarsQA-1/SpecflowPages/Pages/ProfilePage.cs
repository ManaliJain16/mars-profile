using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ProfilePage
    {
        //EDUCATION
        //TO DO - remove all Thread.sleep
        public void clickEducationTab(IWebDriver driver)
        {
            // click on Education tab 
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }

        public void addEducation(IWebDriver driver, string university, string country, string title, string degree, string yearOfGraduation)
        {
            //Click on Add New button under Education                           
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            //Identify "University Name" textbox and input code
            Thread.Sleep(300);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")).SendKeys(university);

            //Select country from dropdown list
            var countrySelect = new SelectElement(driver.FindElement(By.Name("country")));
            countrySelect.SelectByText(country);

            //Identify "Title" dropdown list
            var titleSelect = new SelectElement(driver.FindElement(By.Name("title")));
            titleSelect.SelectByText(title);

            //Identify "Degree" textbox and input code
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")).SendKeys(degree);

            //Identify "Year of graduation" dropdown list
            var yearOfGraduationSelect = new SelectElement(driver.FindElement(By.Name("yearOfGraduation")));
            yearOfGraduationSelect.SelectByText(yearOfGraduation);

            //Click "Add" button 
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")).Click();
        }

        //Check educational row
        public string getCountry(IWebDriver driver)
        {
            IWebElement newCountry = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[1]"));
            return newCountry.Text;
        }

        public string getUniversity(IWebDriver driver)
        {
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
        public void profileNameDropdownIcon(IWebDriver driver)
        {
            //Seller Clicks on dropdown icon
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
        }

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

        //Check updated name
        public string getupdatedName(IWebDriver driver)
        {
            Thread.Sleep(500);
            IWebElement updatedName = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]"));
            Thread.Sleep(300);
            return updatedName.Text;
        }



        //DESCRIPTION
        public void descriptionEditIcon(IWebDriver driver)
        {
            //Click on Edit Icon
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")).Click();
        }

        public void createDescription(IWebDriver driver, string description)
        {
            //Identify description textbox and input values
            Thread.Sleep(500);
            var descriptiontextbox = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea"));
            descriptiontextbox.Clear();
            descriptiontextbox.SendKeys(description);

            //Click on Save Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")).Click();
        }

        //Check created description
        public string getcreateDescription(IWebDriver driver)
        {
            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            return createdDescription.Text;
        }



        //Certifications

        //Clear certification rows
        public void clearCertificationRows(IWebDriver driver)
        {
            while (true)
            {
                try
                {
                    //                                                
                    var deleteButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]"));
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

        public void clickCertificationTab(IWebDriver driver)
        {
            // click on Certification tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }

        public void addCertificate(IWebDriver driver, string certificate, string from, string year)
        {
            //Click on Add New button under Certifications tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();
            Thread.Sleep(500);

            //Click on Certificate or Award textbox  
            driver.FindElement(By.Name("certificationName")).SendKeys(certificate);

            //Click on Certified From textbox 
            driver.FindElement(By.Name("certificationFrom")).SendKeys(from);

            //Select Year from dropdown list
            var yearSelect = new SelectElement(driver.FindElement(By.Name("certificationYear")));
            yearSelect.SelectByText(year);

            //Click on Add button   
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")).Click();
        }

        // Check added Certificate
        public string getCertificate (IWebDriver driver)
        {
            IWebElement addedCertificate = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]"));
            return addedCertificate.Text;
        }

        public string getFrom(IWebDriver driver)
        {
            IWebElement addedFrom = driver.FindElement(By.XPath("//*[@id='account-profile-section']/ div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[2]"));
            return addedFrom.Text;
        }

        public string getYear(IWebDriver driver)
        {
            IWebElement addedYear = driver.FindElement(By.XPath("//*[@id='account-profile-section']/ div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[3]"));
            return addedYear.Text;
        }
    }
}






