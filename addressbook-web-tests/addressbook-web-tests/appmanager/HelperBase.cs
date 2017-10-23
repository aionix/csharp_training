using OpenQA.Selenium;
using System;

namespace WebAddressBookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager manager;

        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.driver = manager.Driver;
        }

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }
        public void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public String GetCurTime()
        {
            DateTime thisDay = DateTime.Now;
            String hour = thisDay.Hour.ToString();
            String time = thisDay.Minute.ToString();
            String sec = thisDay.Second.ToString();
            String TheTime = "Hr_" + hour + ":" + time + "." + sec;
            return TheTime;
            // System.Console.Out.WriteLine(TheTime);
        }
        public Boolean isElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}