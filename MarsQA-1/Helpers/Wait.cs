using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace September2021.Utilities
{
    class Wait
    {
        public static void waitForElementToBeClickable(IWebDriver driver, LocatorType locatorType, string locatorValue, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                By locator = getElementLocator(locatorType, locatorValue);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (TimeoutException ex)
            {
                Assert.Fail("Element with locatorType: '" + locatorType + "' and locatorValue: '" + locatorValue + "' was not found in current context page.");
            }
        }

        public static void waitForElementExists(IWebDriver driver, LocatorType locatorType, string locatorValue, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                By locator = getElementLocator(locatorType, locatorValue);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (TimeoutException ex)
            {
                Assert.Fail("Element with locatorType: '" + locatorType + "' and locatorValue: '" + locatorValue + "' was not found in current context page.");
            }
        }

        public static void waitForElementToBeVisible(IWebDriver driver, LocatorType locatorType, string locatorValue, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                By locator = getElementLocator(locatorType, locatorValue);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (TimeoutException ex)
            {
                Assert.Fail("Element with locatorType: '" + locatorType + "' and locatorValue: '" + locatorValue + "' was not found in current context page.");
            }
        }

        private static By getElementLocator(LocatorType locatorType, string locatorValue)
        {
            By locator = null;

            switch (locatorType)
            {
                case LocatorType.XPath:
                    locator = By.XPath(locatorValue);
                    break;
                case LocatorType.Id:
                    locator = By.Id(locatorValue);
                    break;
                case LocatorType.CssSelector:
                    locator = By.CssSelector(locatorValue);
                    break;
                case LocatorType.Name:
                    locator = By.Name(locatorValue);
                    break;
                default:
                    locator = By.XPath(locatorValue);
                    break;
            }
            return locator;
        }

        public static void waitForElementToDisappear(IWebDriver driver, IWebElement element, int seconds)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
            }
            catch (TimeoutException ex)
            {
                Assert.Fail("Element has not disappeared from current context page.");
            }
        }
    }
}
