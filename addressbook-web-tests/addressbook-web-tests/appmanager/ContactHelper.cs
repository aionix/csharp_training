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
            Thread.Sleep(5000);
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

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath(".//tbody/tr["+ index +"]"+"/td[1]")).Click();
            return this;
        }

        public ContactHelper FillContactInfo(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            // driver.FindElement(By.CssSelector("form>input[name='submit']:nth-of-type(1)")).Click;
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
            driver.FindElement(By.XPath(".//tbody/tr["+index+"]/td[8]")).Click();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


    }

}
