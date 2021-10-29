using System;
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

        [Given(@"Seller is on Profile Page")]
        public void GivenSellerIsOnProfilePage()
        {
            // Setup method in Start class will be executed before each scenario.
            // TODO: assert that you are on Profile Page.
        }

        [When(@"he clicks on Add New button under (.*) tab")]
        public void WhenHeClicksOnAddNewButtonUnderEducationTab(String tabName)
        {
            //Click on Education tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();

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
            //TODO: popup message
        }

        [Then(@"a new row with '(.*)', '(.*)', '(.*)', '(.*)', '(.*)' will be added successfully")]
        public void ThenANewRowWithWillBeAddedSuccessfully(string University, string Country, string Title, string Degree, string YearofGraduation)
        { 
            //ScenarioContext.Current.Pending();
        }
    }
}
