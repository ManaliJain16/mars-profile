using System;
using System.Threading;
using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using MarsQA_1.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
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
            Thread.Sleep(500);
            profilePageObj.clickOnTab(driver, "Education");
            profilePageObj.clearEducationRows(driver);
        }

        [Given(@"Seller is on Profile Page")]
        public void GivenSellerIsOnProfilePage()
        {
            // Setup method in Start class will be executed before each scenario.
            // assert that you are on Profile Page - URL contains Profile.
            Thread.Sleep(500);
            string URL = driver.Url;
            Assert.That(URL, Contains.Substring("Profile"));
        }

        [When(@"he clicks on Add New button under (.*) tab")]
        public void WhenHeClicksOnAddNewButtonUnderEducationTab(String tabName)
        {
            // Click on Education tab
            profilePageObj.clickOnTab(driver, tabName);

            //Click on "Add New" button 
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();
        }

        [When(@"he enters '(.*)', '(.*)', '(.*)', '(.*)' and '(.*)' in Education")]
        public void WhenHeEntersAndInEducation(string University, string Country, string Title, string Degree, string YearofGraduation)
        {
            profilePageObj.addProfile(driver, University, Country, Title, Degree, YearofGraduation);
        }

        [Then(@"a popup message '(.*)' will appear")]
        public void ThenAPopupMessageWillAppear(string message)
        {
            //popup message
            Thread.Sleep(200);
            var popup = driver.FindElement(By.XPath("//*[@class='ns-box-inner']"));
            Assert.AreEqual(message, popup.Text, "Popup text not matching");
        }

        [Then(@"a new row with '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' will be added successfully")]
        public void ThenANewRowWithWillBeAddedSuccessfully(string University, string Country, string Title, string Degree, string YearofGraduation)
        {
            string newUniversity = profilePageObj.getUniversity(driver);
            string newCountry = profilePageObj.getCountry(driver);
            string newTitle = profilePageObj.getTitle(driver);
            string newDegree = profilePageObj.getDegree(driver);
            string newGraduationYear = profilePageObj.getGraduationYear(driver);

            //Assert 
            Assert.AreEqual(University, newUniversity, "University not matches");
            Assert.AreEqual(Country, newCountry, "Country not matches");
            Assert.AreEqual(Title, newTitle, "Title not matches");
            Assert.AreEqual(Degree, newDegree, "Degree not matches");
            Assert.AreEqual(YearofGraduation, newGraduationYear, "GraduationYear not matches");
        }
    }
}
