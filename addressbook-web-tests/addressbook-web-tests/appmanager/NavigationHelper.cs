﻿using OpenQA.Selenium;
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
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenHomepage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/group.php");
        }

        public void ReturnToGroupspage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}