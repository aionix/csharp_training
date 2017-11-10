using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.navigator.GoToContactpage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname =   cells[1].Text;
            string firstname =  cells[2].Text;
            string address =    cells[3].Text;            
            string allphones =  cells[5].Text;
            string allemails =  cells[4].Text;  //works fine


            return new ContactData(firstname, lastname)
            {
                Address = address,
                Allphones = allphones,
                Allmails = allemails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.navigator.GoToContactpage();
            InitContactModification(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homephone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workphone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
          //  System.Console.WriteLine("func " );
            return new ContactData(firstname, lastname)
            {
                Address = address, Homephone = homephone,
                Mobile = mobile, WorkPhone = workphone,
                Middlename = middlename,
                Email = email, Email2 = email2, Email3 = email3

            };
                       
        }

        public void InitContactModification(int index)
        {   //first element starts from 0
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
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
        private List<ContactData> contactCache = null;

        public List<ContactData> GetListOfContacts()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.navigator.GoToContactpage();
          //      List<ContactData> contacts = new List<ContactData>();
                manager.navigator.GoToContactpage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//*[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData(element.FindElement(By.XPath(".//td[3]")).Text);
                    contact.Lastname = element.FindElement(By.XPath(".//td[2]")).Text;
                    contact.Id = element.FindElement(By.TagName("input")).GetAttribute("id");
                    contactCache.Add(contact);
                }
            
            }return new List<ContactData>(contactCache);
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
            contactCache = null;
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
            Type(By.Name("firstname"), contact.Firstname);//+" "+time);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;       
        }            

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {   
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }        
        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }
        public ContactHelper ModifyContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
            contactCache = null;
            return this;
        }
        public bool IsThereAContact()
        {
            manager.navigator.GoToContactpage();
            return isElementPresent(By.CssSelector(".center>input[name='selected[]']"));
        }
        public int GetNumberOfSearchResults()
        {
            manager.navigator.GoToContactpage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex("\\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }


}


