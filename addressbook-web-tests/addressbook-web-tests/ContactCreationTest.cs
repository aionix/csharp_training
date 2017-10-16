using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    
    public class ContactCreationTests : TestBase
    {       
        [Test]
        public void ContactCreationTest()
        {
            OpenHomepage();
            Login(new AccountData("admin", "secret"));
            InitContactCreation();
            ContactData contact = new ContactData("firstname7717");
            contact.Middlename = "mid namme";
            FillContactInfo(contact);
            SubmitContactCreation();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

       }
    }

