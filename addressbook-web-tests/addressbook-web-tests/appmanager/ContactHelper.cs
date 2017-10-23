using System;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Threading;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.navigator.GoToContactpage();
            InitContactCreation()
            .FillContactInfo(contact)
            .SubmitContactCreation();
            return this;
        }

        public ContactHelper Modify(int n, ContactData contact)
        {
            manager.navigator.GoToContactpage();
            SelectContactToModify(n);
            FillContactInfo(contact)
            .SubmitContactModification();
            manager.navigator.GoToContactpage();
            return this;
        }

        public void Remove(int n)
        {
            manager.navigator.GoToContactpage();
            SelectContact(n)
            .RemoveContact();
            AcceptAlert();
            manager.navigator.GoToContactpage();
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.CssSelector(".left>input[value='Delete']")).Click();
            return this;
        }

        private ContactHelper SelectContact(int index) {
            if (index < 2)
            {
                index = 2;
            }driver.FindElement(By.XPath(".//tbody/tr["+ index +"]"+"/td[1]")).Click();
            return this;
        } 

        public ContactHelper FillContactInfo(ContactData contact)
        {
            string time = GetCurTime();
            Type(By.Name("firstname"),contact.Firstname+" "+time);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;       
        }            

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }        
        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }
        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public ContactHelper SelectContactToModify(int index)
        {
            if (index < 2){index = 2;
            }
                driver.FindElement(By.XPath(".//tbody/tr["+index+"]/td[8]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public bool IsThereAContact()
        {
            manager.navigator.GoToContactpage();
            return isElementPresent(By.CssSelector(".center>input[name='selected[]']"));
        }
    }


}


