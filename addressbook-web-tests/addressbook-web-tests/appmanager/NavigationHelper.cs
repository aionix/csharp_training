using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class NavigationHelper : HelperBase
    {
      
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseurl) : base(manager) {

            this.baseURL = baseurl;
        }

        public void GoToGroupspage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php"
                && isElementPresent(By.Name("new")))
            {
                return;
            } driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        public void ReturnToGroupspage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();            
        }
        public void GoToContactpage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
