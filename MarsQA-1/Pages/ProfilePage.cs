using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using September2021.Utilities;

namespace MarsQA_1.SpecflowPages.Pages
{
    class ProfilePage
    {
        public void clickOnTab(IWebDriver driver, string tabName)
        {
            // find tab xpath based on tab name
            string tabXPath = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[" + getTabNumber(tabName) + "]";

            // wait for tab to appear
            Wait.waitForElementToBeClickable(driver, LocatorType.XPath, tabXPath, 2);

            // click on tab
            driver.FindElement(By.XPath(tabXPath)).Click();
        }

        public void clearRows(IWebDriver driver, string tabName)
        {

            while (true)
            {
                try
                {
                    int tableNumber = getTabNumber(tabName) + 1;
                    var deleteButton = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[" + tableNumber + "]/div/div[2]/div/table/tbody/tr/td[last()]/span[2]"));
                    deleteButton.Click();

                    // wait for delete button of deleted row to disappear
                    Wait.waitForElementToDisappear(driver, deleteButton, 2);

                    // close the popup
                    var popupClose = driver.FindElement(By.XPath("//a[@class='ns-close']"));
                    popupClose.Click();
                }
                catch (NoSuchElementException ex)
                {
                    // no more rows to delete
                    break;
                }
            }
        }

        private int getTabNumber(string tabName)
        {
            int tabNumber = 1;
            switch (tabName)
            {
                case "Languages":
                    tabNumber = 1;
                    break;
                case "Skills":
                    tabNumber = 2;
                    break;
                case "Education":
                    tabNumber = 3;
                    break;
                case "Certifications":
                    tabNumber = 4;
                    break;
                default:
                    Assert.Fail("Tab not found");
                    break;
            }
            return tabNumber;
        }

        public void verifyPopupMessage(IWebDriver driver, string message)
        {
            // wait for popup message to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.XPath, "//*[@class='ns-box-inner']", 2);

            // assert popup message
            var popup = driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
            Assert.AreEqual(message, popup.Text, "Popup text not matching");

            // close the popup
            var popupClose = driver.FindElement(By.XPath("//a[@class='ns-close']"));
            popupClose.Click();
        }


        //EDUCATION

        public void addEducation(IWebDriver driver, string university, string country, string title, string degree, string yearOfGraduation)
        {
            //Click on Add New button under Education                           
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();

            // wait for University text box to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "instituteName", 2);

            //Identify "University Name" textbox and input code
            driver.FindElement(By.Name("instituteName")).SendKeys(university);

            //Select country from dropdown list
            var countrySelect = new SelectElement(driver.FindElement(By.Name("country")));
            countrySelect.SelectByText(country);

            //Identify "Title" dropdown list
            var titleSelect = new SelectElement(driver.FindElement(By.Name("title")));
            titleSelect.SelectByText(title);

            //Identify "Degree" textbox and input code
            driver.FindElement(By.Name("degree")).SendKeys(degree);

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



        //SELLERS NAME
        public void profileNameDropdownIcon(IWebDriver driver)
        {
            //Seller Clicks on dropdown icon
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[1]/i")).Click();
        }

        public void updateName(IWebDriver driver, string firstName, string lastName)
        {
            // wait for FirstName textbox to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "firstName", 2);

            // Identify FirstName Textbox, edit existing value and add new first name 
            IWebElement firstNametextbox = driver.FindElement(By.Name("firstName"));
            // TODO: How to remove this sleep?
            Thread.Sleep(500);
            // Wait.waitForElementToBeClickable(driver, LocatorType.Name, "firstName", 2);
            firstNametextbox.Clear();
            firstNametextbox.SendKeys(firstName);

            // wait for FirstName textbox to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "lastName", 2);

            // Identify LastName Textbox, edit existing value and add new first name
            IWebElement lastNametextbox = driver.FindElement(By.Name("lastName"));
            Thread.Sleep(500);
            // Wait.waitForElementToBeClickable(driver, LocatorType.Name, "lastName", 2);
            lastNametextbox.Clear();
            lastNametextbox.SendKeys(lastName);

            // Press Save Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[2]/div/div/div[2]/div/div[2]/button")).Click();
        }

        //Check updated name
        public string getupdatedName(IWebDriver driver)
        {
            // Wait for title to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.CssSelector, ".title", 2);

            // get updated title
            IWebElement updatedName = driver.FindElement(By.CssSelector(".title"));
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
            // wait for description textbox to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "value", 2);

            // Identify description textbox and input values
            var descriptiontextbox = driver.FindElement(By.Name("value"));
            // TODO: How to remove this sleep
            Thread.Sleep(500);
            descriptiontextbox.Clear();
            descriptiontextbox.SendKeys(description);

            // Click on Save Button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")).Click();
        }

        //Check created description
        public string getcreateDescription(IWebDriver driver)
        {
            // wait for description to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.XPath, "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 2);

            IWebElement createdDescription = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
            return createdDescription.Text;
        }



        //Certifications

        public void addCertificate(IWebDriver driver, string certificate, string from, string year)
        {
            // Click on Add New button under Certifications tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")).Click();

            // wait for certificate text box to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "certificationName", 2);

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
        public string getCertificate(IWebDriver driver)
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




        // Skills

        public void addSkill(IWebDriver driver, string skill, string level)
        {
            // click on Add New button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            // wait for add Skills text box to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "name", 2);

            // add skill
            driver.FindElement(By.Name("name")).SendKeys(skill);

            var levelSelect = new SelectElement(driver.FindElement(By.Name("level")));
            levelSelect.SelectByText(level);

            // click on Add button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")).Click();
        }

        public void addLanguage(IWebDriver driver, string language, string level)
        {
            // click on Add New button
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")).Click();

            // wait for add Language text box to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Name, "name", 2);

            // add language
            driver.FindElement(By.Name("name")).SendKeys(language);

            // add level
            var levelSelect = new SelectElement(driver.FindElement(By.Name("level")));
            if (level != "")
            {
                levelSelect.SelectByText(level);
            }

            // click Add
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]")).Click();
        }
    }
}






