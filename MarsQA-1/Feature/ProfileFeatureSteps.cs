using System;
using System.Threading;
using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using September2021.Utilities;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    public class ProfileFeatureSteps : Start
    {
        private ProfilePage profilePageObj = new ProfilePage();


        [BeforeScenario(Order = 1), Scope(Tag = "education")]
        public void ClearEducationRows()
        {
            profilePageObj.clickOnTab(driver, "Education");
            profilePageObj.clearRows(driver, "Education");
        }

        [BeforeScenario(Order = 1), Scope(Tag = "certifications")]
        public void ClearCertificationsRows()
        {
            profilePageObj.clickOnTab(driver, "Certifications");
            profilePageObj.clearRows(driver, "Certifications");
        }

        [BeforeScenario(Order = 1), Scope(Tag = "skills")]
        public void ClearSkillsRows()
        {
            profilePageObj.clickOnTab(driver, "Skills");
            profilePageObj.clearRows(driver, "Skills");
        }

        [BeforeScenario(Order = 1), Scope(Tag = "language")]
        public void ClearLanguagesRows()
        {
            profilePageObj.clickOnTab(driver, "Languages");
            profilePageObj.clearRows(driver, "Languages");
        }

        [Given(@"Seller is on Profile Page")]
        public void GivenSellerIsOnProfilePage()
        {
            // Note - Setup method in Start class will be executed before each scenario.

            // wait for div with id 'account-profile-section' to appear
            Wait.waitForElementToBeVisible(driver, LocatorType.Id, "account-profile-section", 2);

            // assert that you are on Profile Page - URL contains Profile.
            string URL = driver.Url;
            Assert.That(URL, Contains.Substring("Profile"));
        }

        //EDUCATION

        [When(@"he clicks on Add New button under (.*) tab")]
        public void WhenHeClicksOnAddNewButtonUnderEducationTab(String tabName)
        {
            profilePageObj.clickOnTab(driver, tabName);
        }


        [When(@"he enters '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)' in Education")]
        public void WhenHeEntersAndInEducation(string university, string country, string title, string degree, string yearOfGraduation)
        {
            profilePageObj.addEducation(driver, university, country, title, degree, yearOfGraduation);
        }

        [Then(@"a success popup message '(.*)' will appear")]
        public void ThenAPopupMessageWillAppear(string message)
        {
            profilePageObj.verifyPopupMessage(driver, message);
        }

        [Then(@"an error pop up message '(.*)' will appear")]
        public void ThenAnErrorPopUpMessageWillAppear(string errorMessage)
        {
            profilePageObj.verifyPopupMessage(driver, errorMessage);
        }

        [Then(@"a new row with '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' will be added successfully")]
        public void ThenANewRowWithWillBeAddedSuccessfully(string university, string country, string title, string degree, string yearOfGraduation)
        {
            string newUniversity = profilePageObj.getUniversity(driver);
            string newCountry = profilePageObj.getCountry(driver);
            string newTitle = profilePageObj.getTitle(driver);
            string newDegree = profilePageObj.getDegree(driver);
            string newGraduationYear = profilePageObj.getGraduationYear(driver);

            //Assert 
            Assert.AreEqual(university, newUniversity, "University not matches");
            Assert.AreEqual(country, newCountry, "Country not matches");
            Assert.AreEqual(title, newTitle, "Title not matches");
            Assert.AreEqual(degree, newDegree, "Degree not matches");
            Assert.AreEqual(yearOfGraduation, newGraduationYear, "GraduationYear not matches");
        }



        //SELLERS NAME

        [When(@"he click on dropdown icon, just before his name")]
        public void WhenHeClickOnDropdownArrowJustBeforeHisName()
        {
            profilePageObj.profileNameDropdownIcon(driver);
        }

        [When(@"updates his '(.*)' and '(.*)'")]
        public void WhenUpdatesHisAnd(string firstName, string lastName)
        {
            profilePageObj.updateName(driver, firstName, lastName);
        }

        [Then(@"he must be able to see '(.*)' and '(.*)' updated on the Profile Page")]
        public void ThenHeMustBeAbleToSeeAndUpdatedOnTheProfilePage(string firstName, string lastName)
        {
            string updatedName = profilePageObj.getupdatedName(driver);
            string expectedName = firstName + " " + lastName;

            //Assert..what about last name
            Assert.AreEqual(expectedName, updatedName, "Expected Name not matched");
        }



        //DESCRIPTION
        [When(@"he clicks on the Edit icon next to Description")]
        public void WhenHeClicksOnTheEditIconNextToDescription()
        {
            profilePageObj.descriptionEditIcon(driver);
        }

        [When(@"enter '(.*)' in the textbox")]
        public void WhenEnterInTheTextbox(string description)
        {
            profilePageObj.createDescription(driver, description);
        }

        [Then(@"he must be able to see '(.*)' on the Profile Page")]
        public void ThenHeMustBeAbleToSeeOnTheProfilePage(string description)
        {
            string createdDescription = profilePageObj.getcreateDescription(driver);

            //Assert
            Assert.AreEqual(description, createdDescription, "Description not matched");
        }




        //CERTIFICATION
        [When(@"he enters '(.*)', '(.*)', '(.*)' in Certifications")]
        public void WhenHeEntersInCertifications(string certificate, string from, string year)
        {
            profilePageObj.addCertificate(driver, certificate, from, year);
        }

        [Then(@"a new row with '(.*)', '(.*)', '(.*)' will be added sucessfully")]
        public void ThenANewRowWithWillBeAddedSucessfully(string certificate, string from, string year)
        {
            string addedCertificate = profilePageObj.getCertificate(driver);
            string addedFrom = profilePageObj.getFrom(driver);
            string addedYear = profilePageObj.getYear(driver);

            //Assert
            Assert.AreEqual(certificate, addedCertificate, "Certificate not added");
            Assert.AreEqual(from, addedFrom, "Certificate not added");
            Assert.AreEqual(year, addedYear, "Certificate not added");
        }

        // Skills

        [When(@"he enters '(.*)' in Add Skill textbox, and select '(.*)' from Choose Skill Level dropdown list")]
        public void WhenHeEntersInAddSkillTextboxAndSelectFromChooseSkillLevelDropdownList(string skill, string level)
        {
            profilePageObj.addSkill(driver, skill, level);
        }




        // Languages
        [When(@"he enters '(.*)' and '(.*)'")]
        public void WhenHeEntersLanguageAndLevel(string language, string level)
        {
            profilePageObj.addLanguage(driver, language, level);
        }

        [Then(@"a row with '(.*)' and '(.*)' will not be added to the list")]
        public void ThenARowWithWillNotBeAddedToTheList(string language, string level)
        {
            // table element
            var tableElement = driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table"));

            // count tbody or tr elements in table element
            var rowCount = tableElement.FindElements(By.TagName("tbody")).Count;

            // assert row count is equal to 0
            Assert.AreEqual(0, rowCount, "Rows exist in the table");
        }


    }
}
