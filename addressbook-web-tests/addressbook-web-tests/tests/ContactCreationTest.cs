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
            app.groups. InitContactCreation();
            ContactData contact = new ContactData("firstname7717");
            contact.Middlename = "mid namme";
            app.groups. FillContactInfo(contact);
            app.groups. SubmitContactCreation();
            app.groups.Logout();
        }

       }
    }

